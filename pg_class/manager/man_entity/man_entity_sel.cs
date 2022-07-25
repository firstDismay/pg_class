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
        /// Выбор сущности по идентификатору
        /// </summary>
        public entity entity_by_id(Int32 iid)
        {   
            entity entity = null;
            DataTable tbl_entity  = TableByName("ventity");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("entity_by_id");
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
                entity = new entity(tbl_entity.Rows[0]);
            }
            return entity;
        }

        /// <summary>
        /// Выбор сущности по идентификатору
        /// </summary>
        public entity entity_by_id(eEntity Entity)
        {
            return entity_by_id((Int32)Entity);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean entity_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("entity_by_id");
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
        /// Лист всех сущностей БД
        /// </summary>
        public List<entity> entity_by_all()
        {
            List<entity> entity_list = new List<entity>();
            DataTable tbl_entity  = TableByName("ventity");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("entity_by_all");
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

            cmdk.Fill(tbl_entity);
            
            entity en;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    en = new entity(dr);
                    entity_list.Add(en);
                }
            }
            return entity_list;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean entity_by_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("entity_by_all");
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
        /// Лист сущностей допускающих линковкуБД
        /// </summary>
        public List<entity> entity_by_can_link()
        {
            List<entity> entity_list = new List<entity>();
            DataTable tbl_entity  = TableByName("ventity");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("entity_by_can_link");
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

            cmdk.Fill(tbl_entity);
            
            entity en;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    en = new entity(dr);
                    entity_list.Add(en);
                }
            }
            return entity_list;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean entity_by_can_link(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("entity_by_can_link");
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
