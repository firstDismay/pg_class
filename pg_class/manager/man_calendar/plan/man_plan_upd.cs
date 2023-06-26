using pg_class.pg_classes.calendar;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод изменяет план
        /// </summary>
        public plan plan_upd(Int64 iid, String iname, String idesc, Boolean ion, Boolean ion_crossing, Int32 iplan_max, Int32 irange_max, Boolean ion_freeze)
        {
            plan centity = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_upd");
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
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["ion"].Value = ion;
            cmdk.Parameters["ion_crossing"].Value = ion_crossing;
            cmdk.Parameters["ion_freeze"].Value = ion_freeze;
            cmdk.Parameters["iplan_max"].Value = iplan_max;
            cmdk.Parameters["irange_max"].Value = irange_max;
            cmdk.ExecuteNonQuery();

            centity = plan_by_id(iid);
            if (centity != null)
            {
                //Генерируем событие изменения плана
                PlanChangeEventArgs e = new PlanChangeEventArgs(centity, eAction.Update);
                PlanOnChange(e);
            }
            //Возвращаем сущность
            return centity;
        }

        /// <summary>
        ///  Метод изменяет план
        /// </summary>
        public plan plan_upd(plan Plan)
        {
            return plan_upd(Plan.Id, Plan.Name, Plan.Desc, Plan.On, Plan.On_crossing, Plan.Plan_max, Plan.Range_max, Plan.On_freeze);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_upd");
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
