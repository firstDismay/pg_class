using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Определить актуальность состояния данных значения свойства перечисления
        /// </summary>
        public eEntityState class_prop_enum_val_is_actual(Int64 iid_class_prop, DateTime itimestamp_class)
        {
            Int32 is_actual = 3;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_enum_val_is_actual");
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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;
            is_actual = (Int32)cmdk.ExecuteScalar();

            return (eEntityState)is_actual;
        }

        /// <summary>
        /// Определить актуальность состояния данных значения свойства перечисления
        /// </summary>
        public eEntityState class_prop_enum_val_is_actual(class_prop_enum_val Class_prop_enum_val)
        {
            eEntityState Result = eEntityState.History;
            if (Class_prop_enum_val.StorageType == eStorageType.Active)
            {
                Result = class_prop_enum_val_is_actual(Class_prop_enum_val.Id_class_prop, Class_prop_enum_val.Timestamp_class);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_enum_val_is_actual(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_enum_val_is_actual");
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