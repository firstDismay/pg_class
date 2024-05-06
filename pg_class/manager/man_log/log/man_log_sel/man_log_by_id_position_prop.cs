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
        /// Лист записей журнала по идентификатору свойства позиции
        /// </summary>
        public List<log> log_by_id_position_prop(Int64 iid_pos_temp_prop, Int64 iid_position)
        {
            List<log> entity_list = new List<log>();
            DataTable tbl_entity = TableByName("vlog");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_by_id_position_prop");
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

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;
            cmdk.Parameters["iid_position"].Value = iid_position;
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
        /// Лист записей журнала по идентификатору свойства позиции
        /// </summary>
        public List<log> log_by_id_position_prop(position_prop Position_prop)
        {
            return log_by_id_position_prop(Position_prop.Id_position_prop, Position_prop.Id_position_carrier);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean log_by_id_position_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_by_id_position_prop");
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