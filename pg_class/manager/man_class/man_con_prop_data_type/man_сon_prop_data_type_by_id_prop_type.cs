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
        /// Метод возвращает список назначений типов данных для указанной концепции по идентификатору типа свойства
        /// </summary>
        public List<con_prop_data_type> con_prop_data_type_by_id_prop_type(Int64 iid_conception, Int32 iid_prop_type)
        {
            List<con_prop_data_type> rule_list = new List<con_prop_data_type>();
            DataTable tbl_rule_list = TableByName("vcon_prop_data_type");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("con_prop_data_type_by_id_prop_type");
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
            cmdk.Parameters["iid_prop_type"].Value = iid_prop_type;
            cmdk.Fill(tbl_rule_list);

            con_prop_data_type rule;
            if (tbl_rule_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rule_list.Rows)
                {
                    rule = new con_prop_data_type(dr);
                    rule_list.Add(rule);
                }
            }
            return rule_list;
        }

        /// <summary>
        /// Метод возвращает список назначений типов данных для указанной концепции по идентификатору типа свойства
        /// </summary>
        public List<con_prop_data_type> con_prop_data_type_by_id_prop_type(conception Conception, prop_type Prop_type)
        {
            return con_prop_data_type_by_id_prop_type(Conception.Id, Prop_type.Id);
        }

        /// <summary>
        /// Метод возвращает список назначений типов данных для указанной концепции по идентификатору типа свойства
        /// </summary>
        public List<con_prop_data_type> con_prop_data_type_by_id_prop_type(Int64 iid_conception, prop_type Prop_type)
        {
            return con_prop_data_type_by_id_prop_type(iid_conception, Prop_type.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean con_prop_data_type_by_id_prop_type(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("con_prop_data_type_by_id_prop_type");
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