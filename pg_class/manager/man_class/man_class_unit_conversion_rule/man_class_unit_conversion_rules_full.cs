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
        /// Полный список доступных назначений правил пересчета объектов вещественного класса
        /// </summary>
        public List<class_unit_conversion_rule> class_unit_conversion_rules_full(Int64 iid_class)
        {
            List<class_unit_conversion_rule> rule_list = new List<class_unit_conversion_rule>();
            DataTable tbl_rule_list = TableByName("vclass_unit_conversion_rules");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_unit_conversion_rules_full");
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

            cmdk.Parameters["iid_class"].Value = iid_class;
            cmdk.Fill(tbl_rule_list);

            class_unit_conversion_rule rule;
            if (tbl_rule_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rule_list.Rows)
                {
                    rule = new class_unit_conversion_rule(dr);
                    rule_list.Add(rule);
                }
            }
            return rule_list;
        }

        /// <summary>
        /// Полный список доступных назначений правил пересчета объектов вещественного класса
        /// </summary>
        public List<class_unit_conversion_rule> class_unit_conversion_rules_full(vclass Class)
        {
            return class_unit_conversion_rules_full(Class.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_unit_conversion_rules_full(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_unit_conversion_rules_full");
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
