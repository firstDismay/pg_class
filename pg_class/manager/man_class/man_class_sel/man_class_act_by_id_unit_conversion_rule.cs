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
        /// Лист представлений активных классов по идентификатору правила пересчета
        /// </summary>
        public List<vclass> class_act_by_id_unit_conversion_rule(Int32 iid_unit_conversion_rule)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_act_by_id_unit_conversion_rule");

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


            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;

            cmdk.Fill(tbl_vclass);

            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных классов по идентификатору правила пересчета
        /// </summary>
        public List<vclass> class_act_by_id_unit_conversion_rule(unit_conversion_rule Unit_conversion_rule)
        {
            return class_act_by_id_unit_conversion_rule(Unit_conversion_rule.Id);
        }

        /// <summary>
        /// Лист представлений активных классов по идентификатору правила пересчета
        /// </summary>
        public List<vclass> class_act_by_id_unit_conversion_rule(class_unit_conversion_rule Unit_conversion_rule)
        {
            return class_act_by_id_unit_conversion_rule(Unit_conversion_rule.Id_unit_conversion_rule);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_unit_conversion_rule(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_act_by_id_unit_conversion_rule");
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