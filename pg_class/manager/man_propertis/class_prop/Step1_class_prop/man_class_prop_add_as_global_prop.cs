using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод добавляет новое свойство класса по шаблону глобального свойства
        /// </summary>
        public class_prop class_prop_add_as_global_prop(Int64 iid_class, Int64 iid_global_prop, Boolean ion_override, String itag, Int32 isort)
        {
            class_prop class_prop = null;
            Int64 id = 0;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_add_as_global_prop");
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
            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;
            cmdk.Parameters["ion_override"].Value = ion_override;
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
        /// Метод добавляет новое свойство класса по шаблону глобального свойства
        /// </summary>
        public class_prop class_prop_add_as_global_prop(vclass Class, global_prop Global_prop, Boolean On_Override, String itag, Int32 isort)
        {
            class_prop Result = null;
            if (Class != null)
            {
                if (Class.StorageType == eStorageType.Active)
                {
                    Result = class_prop_add_as_global_prop(Class.Id, Global_prop.Id, On_Override, itag, isort);
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
        public Boolean class_prop_add_as_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_add_as_global_prop");
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