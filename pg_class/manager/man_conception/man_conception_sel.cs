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
        /// Концепция по идентификатору
        /// </summary>
        public conception conception_by_id(Int64 id)
        {
            conception conception = null;
            DataTable tbl_con = TableByName("vconception");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("conception_by_id");
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

            cmdk.Parameters["iid"].Value = id;
            cmdk.Fill(tbl_con);

            if (tbl_con.Rows.Count > 0)
            {
                conception = new conception(tbl_con.Rows[0]);
            }

            return conception;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean conception_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("conception_by_id");
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
        /// Лист концепций 
        /// </summary>
        public List<conception> conception_by_all(eStatus status)
        {
            List<conception> con_list = new List<conception>();
            DataTable tbl_con = TableByName("vconception");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("conception_by_all");
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

            cmdk.Parameters["status"].Value = status.ToString("g");
            cmdk.Fill(tbl_con);

            conception con;
            if (tbl_con.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_con.Rows)
                {
                    con = new conception(dr);
                    con_list.Add(con);
                }
            }

            return con_list;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean conception_by_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("conception_by_all");
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
        /// Концепция по умолчанию
        /// </summary>
        public conception conception_by_default()
        {
            conception conception = null;
            DataTable tbl_con = TableByName("vconception");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("conception_by_default");
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

            cmdk.Fill(tbl_con);
            if (tbl_con.Rows.Count > 0)
            {
                conception = new conception(tbl_con.Rows[0]);
            }

            return conception;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean conception_by_default(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("conception_by_default");
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
