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
        /// Лист снимков классов по идентификатору элемента перечисления
        /// </summary>
        public List<vclass> class_snapshot_by_id_prop_enum_val(Int64 iid_prop_enum_val)
        {
            List<vclass> vclass_list = new List<vclass>();
            DataTable tbl_vclass = TableByName("vclass");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_snapshot_by_id_prop_enum_val");
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

            cmdk.Parameters["iid_prop_enum_val"].Value = iid_prop_enum_val;
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
        /// Лист снимков классов по идентификатору элемента перечисления
        /// </summary>
        public List<vclass> class_snapshot_by_id_prop_enum_val(prop_enum_val Prop_enum_val)
        {
            return class_snapshot_by_id_prop_enum_val(Prop_enum_val.Id_prop_enum_val);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_by_id_prop_enum_val(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_snapshot_by_id_prop_enum_val");
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