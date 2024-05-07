using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;
using System.Collections.Generic;
using System.Data;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод удаляет снимки концепции не содержащие каскадно наследующие объекты и классы значения свойств
        /// </summary>
        public Int64 class_snapshot_clear(Int64 iid_conception)
        {
            Int64 Result = 0;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_snapshot_clear");
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

            conception conception = conception_by_id(iid_conception);
            cmdk.Parameters["iid_conception"].Value = iid_conception;
            Result = (Int64)cmdk.ExecuteScalar();
            return Result;
        }

        /// <summary>
        /// Метод удаляет снимки концепции не содержащие каскадно наследующие объекты и классы значения свойств
        /// </summary>
        public Int64 class_snapshot_clear(conception Conception)
        {
            return class_snapshot_clear(Conception.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_clear(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_snapshot_clear");
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