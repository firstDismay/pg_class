using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод добавляет новое свойство класса
        /// </summary>
        public class_prop class_prop_add(Int64 iid_class, Int32 iid_prop_type, Boolean ion_override, Int32 iid_data_type, String iname, String idesc, String itag, Int32 isort)
        {
            class_prop class_prop = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_add");
            if (cmdk != null)
            {
                if (!cmdk.Access)
                {
                    throw new AccessDataBaseException(404, String.Format(@"Отказано в доступе к методу: {0}!", cmdk.CommandText));
                }
            }
            else
            {
                throw new AccessDataBaseException(405, String.Format(@"Не найден метод: {0}!", cmdk.CommandText));
            }

            cmdk.Parameters["iid_class"].Value = iid_class;
            cmdk.Parameters["iid_prop_type"].Value = iid_prop_type;
            cmdk.Parameters["ion_override"].Value = ion_override;
            cmdk.Parameters["iid_data_type"].Value = iid_data_type;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["itag"].Value = itag;
            cmdk.Parameters["isort"].Value = isort;
            cmdk.ExecuteNonQuery();

            id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
            if (id > 0)
            {
                class_prop = class_prop_by_id(id);
            }

            if (class_prop != null)
            {
                //Генерируем событие изменения свойства класса
                ClassPropChangeEventArgs e = new ClassPropChangeEventArgs(class_prop, eAction.Insert);
                ClassPropOnChange(e);
            }
            //Возвращаем сущность
            return class_prop;
        }

        /// <summary>
        /// Метод добавляет новое свойство класса
        /// </summary>
        public class_prop class_prop_add(vclass Class, prop_type Prop_type, Boolean On_Override, con_prop_data_type Data_type, String iname, String idesc, String itag, Int32 isort)
        {
            class_prop Result = null;
            if (Class != null)
            {
                if (Class.StorageType == eStorageType.Active)
                {
                    Result = class_prop_add(Class.Id, Prop_type.Id, On_Override, Data_type.Id, iname, idesc, itag, isort);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        "Метод обновления данных класса не применим к историческому представлению класса!");
                }
            }
            return Result;
        }


        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_add");
            if (cmdk != null)
            {
                Result = cmdk.Access;
                if (Result)
                {
                    Access = eAccess.Success;
                }
                else
                {
                    Access = eAccess.NotAvailable;
                }
            }
            return Result;
        }
    }
}