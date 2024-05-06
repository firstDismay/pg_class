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
        /// Лист записей журнала по идентификатору группы классов
        /// </summary>
        public List<log> log_by_id_group(Int64 iid_group, Boolean class_on, Boolean object_on, Boolean recursive_on)
        {
            List<log> entity_list = new List<log>();
            DataTable tbl_entity = TableByName("vlog");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_by_id_group");
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

            cmdk.Parameters["iid_group"].Value = iid_group;
            cmdk.Parameters["class_on"].Value = class_on;
            cmdk.Parameters["object_on"].Value = object_on;
            cmdk.Parameters["recursive_on"].Value = recursive_on;
            cmdk.Fill(tbl_entity);

            log ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new log(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист записей журнала по идентификатору группы классов
        /// </summary>
        public List<log> log_by_id_group(group Group, Boolean class_on, Boolean object_on, Boolean recursive_on)
        {
            return log_by_id_group(Group.Id, class_on, object_on, recursive_on);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean log_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_by_id_group");
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