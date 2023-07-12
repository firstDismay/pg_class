using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Добавить данные значения свойства типа перечисление объектам снимка класса в указанной позиции
        /// </summary>
        public position object_prop_enum_val_objects_set(position Position_parent, class_prop_enum_val newClass_prop_enum_val, Boolean on_internal = false)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;

            cmdk = CommandByKey("object_prop_enum_val_objects_set");
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

            cmdk.Parameters["iid_position"].Value = Position_parent.Id;
            cmdk.Parameters["iid_class_prop"].Value = newClass_prop_enum_val.Id_class_prop;
            cmdk.Parameters["itimestamp_class"].Value = newClass_prop_enum_val.Timestamp_class;
            cmdk.Parameters["on_internal"].Value = on_internal;
            cmdk.Parameters["iid_prop_enum_val"].Value = newClass_prop_enum_val.Id_prop_enum_val;
            cmdk.ExecuteNonQuery();

            //Возвращаем сущность
            return Position_parent;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_enum_val_objects_set(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_prop_enum_val_objects_set");
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