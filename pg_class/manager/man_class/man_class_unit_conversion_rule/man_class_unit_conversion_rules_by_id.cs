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
        /// Правило назначения правила пересчета объектов вещественного класса по ключу
        /// </summary>
        public class_unit_conversion_rule class_unit_conversion_rules_by_id(Int64 iid_class, Int32 iid_unit_conversion_rule)
        {
            class_unit_conversion_rule class_unit_conversion_rule = null;
            DataTable tbl_rule = TableByName("vclass_unit_conversion_rules");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_unit_conversion_rules_by_id");
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
            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;
            cmdk.Fill(tbl_rule);

            if (tbl_rule.Rows.Count > 0)
            {
                class_unit_conversion_rule = new class_unit_conversion_rule(tbl_rule.Rows[0]);
            }

            return class_unit_conversion_rule;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_unit_conversion_rules_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_unit_conversion_rules_by_id");
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
