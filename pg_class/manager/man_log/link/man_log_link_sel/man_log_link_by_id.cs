﻿using pg_class.pg_classes;
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
        /// Ссылка записи журнала по идентификатору
        /// </summary>
        public log_link log_link_by_id(Int64 iid)
        {
            log_link log_link = null;
            DataTable tbl_entity = TableByName("vlog_link");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_link_by_id");
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
                log_link = new log_link(tbl_entity.Rows[0]);
            }
            return log_link;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean log_link_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_link_by_id");
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