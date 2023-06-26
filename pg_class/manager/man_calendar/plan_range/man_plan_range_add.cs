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
        /// Метод добавляет новый плановый диапазон
        /// </summary>
        public plan_range plan_range_add(Int64 iid_plan, NpgsqlRange<DateTime> irange_plan)
        {
            plan_range centity = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_range_add");
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

            cmdk.Parameters["iid_plan"].Value = iid_plan;
            cmdk.Parameters["irange_plan"].Value = irange_plan;
            cmdk.ExecuteNonQuery();

            id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
            if (id > 0)
            {
                centity = plan_range_by_id(id);
            }

            if (centity != null)
            {
                //Генерируем событие изменения планового диапазона
                PlanRangeChangeEventArgs e = new PlanRangeChangeEventArgs(centity, eAction.Insert);
                PlanRangeOnChange(e);
            }
            //Возвращаем сущность
            return centity;
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_range_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_range_add");
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
