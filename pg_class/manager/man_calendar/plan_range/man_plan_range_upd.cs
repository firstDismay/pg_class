using NpgsqlTypes;
using pg_class.pg_classes.calendar;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод изменяет плановый диапазон
        /// </summary>
        public plan_range plan_range_upd(Int64 iid, NpgsqlRange<DateTime> irange_plan)
        {
            plan_range centity = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_range_upd");
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
            cmdk.Parameters["irange_plan"].Value = irange_plan;
            cmdk.ExecuteNonQuery();

            centity = plan_range_by_id(iid);
            if (centity != null)
            {
                //Генерируем событие изменения планового диапазона
                PlanRangeChangeEventArgs e = new PlanRangeChangeEventArgs(centity, eAction.Update);
                PlanRangeOnChange(e);
            }

            //Возвращаем сущность
            return centity;
        }

        /// <summary>
        ///  Метод изменяет плановый диапазон
        /// </summary>
        public plan_range plan_range_upd(plan_range Plan_range)
        {
            return plan_range_upd(Plan_range.Id, Plan_range.Range_plan);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_range_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_range_upd");
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