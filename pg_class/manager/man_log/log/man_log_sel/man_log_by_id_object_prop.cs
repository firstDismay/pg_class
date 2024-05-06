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
        /// Лист записей журнала по идентификатору свойства объекта
        /// </summary>
        public List<log> log_by_id_object_prop(Int64 iid_class_prop, Int64 iid_object)
        {
            List<log> entity_list = new List<log>();
            DataTable tbl_entity = TableByName("vlog");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_by_id_object_prop");
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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.Parameters["iid_object"].Value = iid_object;
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
        /// Лист записей журнала по идентификатору свойства класса
        /// </summary>
        public List<log> log_by_id_object_prop(object_prop Object_prop)
        {
            return log_by_id_object_prop(Object_prop.Id_class_prop, Object_prop.Id_object_carrier);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean log_by_id_object_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_by_id_object_prop");
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