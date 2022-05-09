using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using pg_class.pg_classes;
using pg_class.pg_classes.calendar;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Ссылка плана по идентификатору
        /// </summary>
        public plan_given_range_plan_link plan_given_range_plan_link_by_id(Int64 iid)
        {
            plan_given_range_plan_link plan_given_range_plan_link = null;

            DataTable tbl_entity  = TableByName("vplan_given_range_plan_link");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("plan_given_range_plan_link_by_id");

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
            //=======================

            cmdk.Parameters["iid"].Value = iid;

            cmdk.Fill(tbl_entity);
            
            if (tbl_entity.Rows.Count > 0)
            {
                plan_given_range_plan_link = new plan_given_range_plan_link(tbl_entity.Rows[0]);
            }
            return plan_given_range_plan_link;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_given_range_plan_link_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("plan_given_range_plan_link_by_id");
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
        //*********************************************************************************************

        //*********************************************************************************************
        /// <summary>
        /// Лист ссылок плана по идентификатору плана
        /// </summary>
        public List<plan_given_range_plan_link> plan_given_range_plan_link_by_id_plan_given_range_plan(Int64 iid_plan_given_range_plan)
        {
            List<plan_given_range_plan_link>  entity_list = new List<plan_given_range_plan_link>();

            
            DataTable tbl_entity  = TableByName("vplan_given_range_plan_link");
            
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("plan_given_range_plan_link_by_id_plan_given_range_plan");

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
            //=======================

            cmdk.Parameters["iid_plan_given_range_plan"].Value = iid_plan_given_range_plan;

            cmdk.Fill(tbl_entity);

            plan_given_range_plan_link centity;
            
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    centity = new plan_given_range_plan_link(dr);
                    entity_list.Add(centity);
                }
            }

            return entity_list;
        }

        /// <summary>
        /// Лист ссылок плана по идентификатору плана
        /// </summary>
        public List<plan_given_range_plan_link> plan_given_range_plan_link_by_id_plan_given_range_plan(plan Plan)
        {
            return plan_given_range_plan_link_by_id_plan_given_range_plan(Plan.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_given_range_plan_link_by_id_plan_given_range_plan(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("plan_given_range_plan_link_by_id_plan_given_range_plan");
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

        //*********************************************************************************************
        /// <summary>
        /// Лист ссылок выделенного диапазона плана по идентификатору сущности
        /// </summary>
        public plan_given_range_plan_link plan_given_range_plan_link_by_entity(Int64 iid_plan_given_range_plan, Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            plan_given_range_plan_link plan_given_range_plan_link = null;

            DataTable tbl_entity = TableByName("vplan_given_range_plan_link");

            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("plan_given_range_plan_link_by_entity");

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
            //=======================

            cmdk.Parameters["iid_plan_given_range_plan"].Value = iid_plan_given_range_plan;
            cmdk.Parameters["iid_entity"].Value = iid_entity;
            cmdk.Parameters["iid_entity_instance"].Value = iid_entity_instance;
            cmdk.Parameters["iid_sub_entity_instance"].Value = iid_sub_entity_instance;

            cmdk.Fill(tbl_entity);

            if (tbl_entity.Rows.Count > 0)
            {
                plan_given_range_plan_link = new plan_given_range_plan_link(tbl_entity.Rows[0]);
            }
            return plan_given_range_plan_link;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_given_range_plan_link_by_entity(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("plan_given_range_plan_link_by_entity");
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
