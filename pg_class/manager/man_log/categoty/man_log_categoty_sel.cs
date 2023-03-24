using pg_class.pg_classes;
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
        /// Категория записей журнала по идентификатору
        /// </summary>
        public log_category log_category_by_id(Int64 iid)
        {
            log_category log_category = null;
            DataTable tbl_entity = TableByName("vlog_category");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_category_by_id");
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
                log_category = new log_category(tbl_entity.Rows[0]);
            }
            return log_category;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean log_category_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_category_by_id");
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
        /// Лист категорий записей журнала по идентификатору концепции
        /// </summary>
        public List<log_category> log_category_by_id_conception(Int64 iid_conception)
        {
            List<log_category> entity_list = new List<log_category>();
            DataTable tbl_entity = TableByName("vlog_category");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_category_by_id_conception");
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

            cmdk.Parameters["iid_conception"].Value = iid_conception;
            cmdk.Fill(tbl_entity);

            log_category ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new log_category(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист влюченных категорий записей журнала по идентификатору концепции
        /// </summary>
        public List<log_category> log_category_on_by_id_conception(Int64 iid_conception)
        {
            List<log_category> Result = log_category_by_id_conception(iid_conception).FindAll(x => x.On);
            if (Result == null)
            {
                Result = new List<log_category>();
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean log_category_by_id_conception(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_category_by_id_conception");
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