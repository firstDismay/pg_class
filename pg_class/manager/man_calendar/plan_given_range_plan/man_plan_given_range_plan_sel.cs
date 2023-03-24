using pg_class.pg_classes.calendar;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;
using System.Collections.Generic;
using System.Data;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Выделенный диапазон плана по идентификатору
        /// </summary>
        public plan_given_range_plan plan_given_range_plan_by_id(Int64 iid)
        {
            plan_given_range_plan plan_given_range_plan = null;
            DataTable tbl_entity = TableByName("vplan_given_range_plan");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_given_range_plan_by_id");
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
            cmdk.Fill(tbl_entity);

            if (tbl_entity.Rows.Count > 0)
            {
                plan_given_range_plan = new plan_given_range_plan(tbl_entity.Rows[0]);
            }
            return plan_given_range_plan;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_given_range_plan_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_given_range_plan_by_id");
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
        /// Лист выделенных диапазонов планового диапаона плана по идентификатору планового диапазона
        /// </summary>
        public List<plan_given_range_plan> plan_given_range_plan_by_id_plan_range(Int64 iid_plan_range)
        {
            List<plan_given_range_plan> entity_list = new List<plan_given_range_plan>();
            DataTable tbl_entity = TableByName("vplan_given_range_plan");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_given_range_plan_by_id_plan_range");
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

            cmdk.Parameters["iid_plan_range"].Value = iid_plan_range;
            cmdk.Fill(tbl_entity);

            plan_given_range_plan centity;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    centity = new plan_given_range_plan(dr);
                    entity_list.Add(centity);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист выделенных диапазонов планового диапаона плана по идентификатору планового диапазона
        /// </summary>
        public List<plan_given_range_plan> plan_given_range_plan_by_id_plan_range(plan_range Plan_range)
        {
            return plan_given_range_plan_by_id_plan_range(Plan_range.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_given_range_plan_by_id_plan_range(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("plan_given_range_plan_by_id_plan_range");
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