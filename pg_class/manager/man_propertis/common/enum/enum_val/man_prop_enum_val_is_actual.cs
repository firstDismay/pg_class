using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Определить актуальность состояния элемента перечисления для свойства
        /// </summary>
        public eEntityState prop_enum_val_is_actual(Int64 iid, DateTime itimestamp)
        {
            Int32 is_actual = 3;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("prop_enum_val_is_actual");
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

            cmdk.Parameters["iid"].Value = iid;
            cmdk.Parameters["itimestamp"].Value = itimestamp;
            is_actual = (Int32)cmdk.ExecuteScalar();

            return (eEntityState)is_actual;
        }

        /// <summary>
        /// Определить актуальность состояния элемента перечисления для свойства
        /// </summary>
        public eEntityState prop_enum_val_is_actual(prop_enum_val Prop_enum)
        {
            return prop_enum_is_actual(Prop_enum.Id_prop_enum, Prop_enum.Timestamp);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_val_is_actual(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("prop_enum_val_is_actual");
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