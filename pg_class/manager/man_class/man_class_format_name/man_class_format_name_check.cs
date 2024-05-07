using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод проверяет поле формата для редактируемого класса на готовность к созданию объектов
        /// </summary>
        public Boolean class_act_name_format_check(Int64 iid_class)
        {
            Boolean Result = false;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_act_name_format_check");
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
            Result = (Boolean)cmdk.ExecuteScalar();

            return Result;
        }

        /// <summary>
        /// Метод проверяет поле формата для снимка класса на готовность к созданию имени объектов
        /// </summary>
        public Boolean class_snapshot_name_format_check(Int64 iid_class, DateTime itimestamp_class)
        {
            Boolean Result = false;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_snapshot_name_format_check");
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
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;
            Result = (Boolean)cmdk.ExecuteScalar();

            return Result;
        }

        /// <summary>
        /// Метод проверяет поле формата для редактируемого класса на готовность к созданию объектов
        /// </summary>
        public Boolean class_name_format_check(vclass Class)
        {
            Boolean Result = false;
            if (Class.StorageType == eStorageType.Active)
            {
                Result = class_act_name_format_check(Class.Id);
            }

            if (Class.StorageType == eStorageType.History)
            {
                Result = class_snapshot_name_format_check(Class.Id, Class.Timestamp);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_name_format_check(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_act_name_format_check");
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