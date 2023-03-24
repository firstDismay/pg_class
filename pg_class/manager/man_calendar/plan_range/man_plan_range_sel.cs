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
        /// Плановый диапазон по идентификатору
        /// </summary>
        public plan_range plan_range_by_id(Int64 iid)
        {
            plan_range plan_range = null;

            DataTable tbl_entity = TableByName("vplan_range");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("plan_range_by_id");

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
                plan_range = new plan_range(tbl_entity.Rows[0]);
            }
            return plan_range;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_range_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("plan_range_by_id");
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
        /// Лист плановых диапазонов по идентификатору плана
        /// </summary>
        public List<plan_range> plan_range_by_id_plan(Int64 iid_plan)
        {
            List<plan_range> entity_list = new List<plan_range>();


            DataTable tbl_entity = TableByName("vplan_range");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("plan_range_by_id_plan");

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

            cmdk.Fill(tbl_entity);

            plan_range centity;

            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    centity = new plan_range(dr);
                    entity_list.Add(centity);
                }
            }

            return entity_list;
        }

        /// <summary>
        /// Лист плановых диапазонов по идентификатору плана
        /// </summary>
        public List<plan_range> plan_range_by_id_plan(plan Plan)
        {
            return plan_range_by_id_plan(Plan.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_range_by_id_plan(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("plan_range_by_id_plan");
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
