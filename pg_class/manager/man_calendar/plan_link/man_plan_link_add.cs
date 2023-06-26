using pg_class.pg_classes.calendar;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод добавляет новую ссылку плана
        /// </summary>
        public plan_link plan_link_add(Int64 iid_plan, Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            plan_link centity = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_link_add");
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
            cmdk.Parameters["iid_entity"].Value = iid_entity;
            cmdk.Parameters["iid_entity_instance"].Value = iid_entity_instance;
            cmdk.Parameters["iid_sub_entity_instance"].Value = iid_sub_entity_instance;
            cmdk.ExecuteNonQuery();

            centity = plan_link_by_id(id);
            if (centity != null)
            {
                //Генерируем событие изменения плана
                PlanLinkChangeEventArgs e = new PlanLinkChangeEventArgs(centity, eAction.Insert);
                PlanLinkOnChange(e);
            }
            //Возвращаем сущность
            return centity;
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_link_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_link_add");
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