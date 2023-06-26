using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Удалить значение объектного свойства активного представления класса
        /// </summary>
        public void class_prop_object_val_del(Int64 iid_class_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            class_prop_object_val class_prop_object_val = null;

            cmdk = CommandByKey("class_prop_object_val_del");
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

            //Предварительный запрос данных
            class_prop_object_val = class_prop_object_val_by_id_prop(iid_class_prop);

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.ExecuteNonQuery();

            class_prop class_prop = class_prop_by_id(iid_class_prop);
            //Генерируем событие удаления значения свойства класса
            if (class_prop != null)
            {
                ClassPropChangeEventArgs e = new ClassPropChangeEventArgs(class_prop, eAction.Update);
                ClassPropOnChange(e);
            }

            if (class_prop_object_val != null)
            {
                //Генерируем событие изменения значения объектного свойства класса
                ClassPropObjectValChangeEventArgs e2 = new ClassPropObjectValChangeEventArgs(class_prop_object_val, eAction.Delete);
                ClassPropObjectValOnChange(e2);
            }
        }


        /// <summary>
        /// Удалить значение объектного свойства активного представления класса
        /// </summary>
        public void class_prop_object_val_del(class_prop class_prop)
        {
            if (class_prop != null)
            {
                if (class_prop.StorageType == eStorageType.Active)
                {
                    class_prop_object_val_del(class_prop.Id);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        "Метод удаления значения объектного свойства класса не применим к историческому представлению класса!");
                }
            }
        }

        /// <summary>
        /// Удалить значение объектного свойства активного представления класса
        /// </summary>
        public void class_prop_object_val_del(class_prop_object_val ClassPropObjectVal)
        {
            if (ClassPropObjectVal != null)
            {
                if (ClassPropObjectVal.StorageType == eStorageType.Active)
                {
                    class_prop_object_val_del(ClassPropObjectVal.Id_class_prop);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        "Метод удаления значения объектного свойства класса не применим к историческому представлению класса!");
                }
            }
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_object_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_object_val_del");
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