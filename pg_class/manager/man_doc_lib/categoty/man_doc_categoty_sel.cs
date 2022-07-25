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

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Категория документа по идентификатору
        /// </summary>
        public doc_category doc_category_by_id(Int64 iid)
        {
            doc_category doc_category = null;

            DataTable tbl_entity  = TableByName("vdoc_category");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("doc_category_by_id");

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
                doc_category = new doc_category(tbl_entity.Rows[0]);
            }
            return doc_category;
        }

       

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_category_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("doc_category_by_id");
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
        /// Лист категорий документов концепции по идентификатору концепции
        /// </summary>
        public List<doc_category> doc_category_by_id_conception(Int64 iid_conception)
        {
            List<doc_category>  entity_list = new List<doc_category>();
            
            DataTable tbl_entity  = TableByName("vdoc_category");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("doc_category_by_id_conception");

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

            cmdk.Parameters["iid_conception"].Value = iid_conception;

            cmdk.Fill(tbl_entity);
            
            doc_category ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new doc_category(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист влюченных категорий документов концепции по идентификатору концепции
        /// </summary>
        public List<doc_category> doc_category_on_by_id_conception(Int64 iid_conception)
        {
            List<doc_category> Result = doc_category_by_id_conception(iid_conception).FindAll(x => x.On);
            if (Result == null)
            {
                Result = new List<doc_category>();
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_category_by_id_conception(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("doc_category_by_id_conception");
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
