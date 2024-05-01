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
        /// Лист объектов по идентификатору правила пересчета
        /// </summary>
        public List<object_general> object_by_id_unit_conversion_rule(Int32 iid_unit_conversion_rule)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_vclass = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;
            cmdk = CommandByKey("object_by_id_unit_conversion_rule");
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

            object_general o;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    o = new object_general(dr);
                    object_list.Add(o);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов по идентификатору правила пересчета
        /// </summary>
        public List<object_general> object_by_id_unit_conversion_rule(unit_conversion_rule Unit_conversion_rule)
        {
            return object_by_id_unit_conversion_rule(Unit_conversion_rule.Id);
        }

        /// <summary>
        /// Лист объектов по идентификатору правила пересчета
        /// </summary>
        public List<object_general> object_by_id_unit_conversion_rule(class_unit_conversion_rule Unit_conversion_rule)
        {
            return object_by_id_unit_conversion_rule(Unit_conversion_rule.Id_unit_conversion_rule);
        }

        /// <summary>
        /// Лист объектов по идентификатору правила пересчета
        /// </summary>
        public List<object_general> object_by_id_unit_conversion_rule(unit_conversion_rule Unit_conversion_rule, Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = object_ext_by_id_unit_conversion_rule(Unit_conversion_rule);
            }
            else
            {
                Result = object_by_id_unit_conversion_rule(Unit_conversion_rule);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_unit_conversion_rule(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_unit_conversion_rule");
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
