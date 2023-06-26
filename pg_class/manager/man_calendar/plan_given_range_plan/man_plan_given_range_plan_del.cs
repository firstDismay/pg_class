using pg_class.pg_classes.calendar;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод удаляет выделенный  диапазон планового диапазона плана
        /// </summary>
        public void plan_given_range_plan_del(Int64 iid)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_given_range_plan_del");
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

            plan_given_range_plan centity = plan_given_range_plan_by_id(iid);
            cmdk.Parameters["iid"].Value = iid;
            cmdk.ExecuteNonQuery();

            //Генерируем событие изменения выделенного диапазона планового диапазона плана
            if (centity != null)
            {
                PlanGivenRangePlanChangeEventArgs e = new PlanGivenRangePlanChangeEventArgs(centity, eAction.Delete);
                PlanGivenRangePlanOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет выделенный  диапазон планового диапазона плана
        /// </summary>
        public void plan_given_range_plan_del(plan_given_range_plan Plan_given_range_plan)
        {
            plan_given_range_plan_del(Plan_given_range_plan.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_given_range_plan_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_given_range_plan_del");
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

        /// <summary>
        /// Метод удаляет выделенные  диапазоны планового диапазона плана по идентификатору планового диапазона
        /// </summary>
        public void plan_given_range_plan_del_by_id_plan_range(Int64 iid_plan_range)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_given_range_plan_del_by_id_plan_range");
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

            plan_range centity = plan_range_by_id(iid_plan_range);
            cmdk.Parameters["iid_plan_range"].Value = iid_plan_range;
            cmdk.ExecuteNonQuery();

            //Генерируем событие изменения планового диапазона плана
            if (centity != null)
            {
                PlanRangeChangeEventArgs e = new PlanRangeChangeEventArgs(centity, eAction.Delete);
                PlanRangeOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет выделенные  диапазоны планового диапазона плана по идентификатору планового диапазона
        /// </summary>
        public void plan_given_range_plan_del_by_id_plan_range(plan_range Plan_range)
        {
            plan_given_range_plan_del_by_id_plan_range(Plan_range.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_given_range_plan_del_by_id_plan_range(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_given_range_plan_del_by_id_plan_range");
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
