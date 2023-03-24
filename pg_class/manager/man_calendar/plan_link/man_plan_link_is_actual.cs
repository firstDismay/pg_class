using pg_class.pg_classes.calendar;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод определяет актуальность состояния ссылки плана
        /// </summary>
        public eEntityState plan_link_is_actual(Int64 iid)
        {
            Int32 is_actual = 3;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_link_is_actual");
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
            is_actual = (Int32)cmdk.ExecuteScalar();

            return (eEntityState)is_actual;
        }

        /// <summary>
        /// Метод определяет актуальность состояния ссылки плана
        /// </summary>
        public eEntityState plan_link_is_actual(plan Plan)
        {
            return plan_link_is_actual(Plan.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_link_is_actual(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_link_is_actual");
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