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
        /// Метод изменяет выделенный диапазон планового диапазона плана
        /// </summary>
        public plan_given_range_plan plan_given_range_plan_upd(Int64 iid, NpgsqlRange<DateTime> irange_plan)
        {
            plan_given_range_plan centity = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_given_range_plan_upd");
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

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            switch (error)
            {
                case 0:
                    centity = plan_given_range_plan_by_id(iid);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid, eEntity.plan_given_range_plan, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (centity != null)
            {
                //Генерируем событие изменения планового диапазона
                PlanGivenRangePlanChangeEventArgs e = new PlanGivenRangePlanChangeEventArgs(centity, eAction.Update);
                PlanGivenRangePlanOnChange(e);
            }
            //Возвращаем сущность
            return centity;
        }

        /// <summary>
        /// Метод изменяет выделенный диапазон планового диапазона плана
        /// </summary>
        public plan_given_range_plan plan_given_range_plan_upd(plan_given_range_plan Plan_given_range_plan)
        {
            return plan_given_range_plan_upd(Plan_given_range_plan.Id, Plan_given_range_plan.Range_plan);
        }


        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_given_range_plan_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_given_range_plan_upd");
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