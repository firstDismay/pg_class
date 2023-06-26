using pg_class.pg_classes.calendar;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод удаляет плановый диапазон
        /// </summary>
        public void plan_range_del(Int64 iid)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_range_del");
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

            plan_range centity = plan_range_by_id(iid);
            cmdk.Parameters["iid"].Value = iid;
            cmdk.ExecuteNonQuery();
                        
            //Генерируем событие изменения концепции
            if (centity != null)
            {
                PlanRangeChangeEventArgs e = new PlanRangeChangeEventArgs(centity, eAction.Delete);
                PlanRangeOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет план
        /// </summary>
        public void plan_range_del(plan_range Plan_range)
        {
            plan_range_del(Plan_range.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_range_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_range_del");
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
