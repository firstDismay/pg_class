using pg_class.pg_classes.calendar;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод добавляет новую ссылку выделенный диапазон плановго диапазона
        /// </summary>
        public plan_given_range_plan_link plan_given_range_plan_link_add(Int64 iid_plan_given_range_plan, Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            plan_given_range_plan_link centity = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_given_range_plan_link_add");
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

            cmdk.Parameters["iid_plan_given_range_plan"].Value = iid_plan_given_range_plan;
            cmdk.Parameters["iid_entity"].Value = iid_entity;
            cmdk.Parameters["iid_entity_instance"].Value = iid_entity_instance;
            cmdk.Parameters["iid_sub_entity_instance"].Value = iid_sub_entity_instance;
            cmdk.ExecuteNonQuery();

            id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
            if (id > 0)
            {
                centity = plan_given_range_plan_link_by_id(id);
            }
            if (centity != null)
            {
                //Генерируем событие изменения плана
                PlanGivenRangePlanLinkChangeEventArgs e = new PlanGivenRangePlanLinkChangeEventArgs(centity, eAction.Insert);
                PlanGivenRangePlanLinkOnChange(e);
            }
            //Возвращаем сущность
            return centity;
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_given_range_plan_link_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_given_range_plan_link_add");
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