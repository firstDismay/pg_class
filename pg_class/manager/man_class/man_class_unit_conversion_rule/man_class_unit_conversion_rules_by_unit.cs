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
        /// Полный список доступных назначений правил пересчета объектов вещественного класса по идентификатору измеряемой величины
        /// </summary>
        public List<class_unit_conversion_rule> class_unit_conversion_rules_by_unit(Int32 iid_unit)
        {
            List<class_unit_conversion_rule> rule_list = new List<class_unit_conversion_rule>();
            DataTable tbl_rule_list = TableByName("vclass_unit_conversion_rules");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_unit_conversion_rules_by_unit");
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

            cmdk.Parameters["iid_unit"].Value = iid_unit;
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
        /// Полный список доступных назначений правил пересчета объектов вещественного класса по идентификатору измеряемой величины
        /// </summary>
        public List<class_unit_conversion_rule> class_unit_conversion_rules_by_unit(unit Unit)
        {
            return class_unit_conversion_rules_by_unit(Unit.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_unit_conversion_rules_by_unit(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_unit_conversion_rules_by_unit");
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
