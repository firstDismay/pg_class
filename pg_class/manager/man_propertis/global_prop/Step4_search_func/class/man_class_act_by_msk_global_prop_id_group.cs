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
        /// Лист представлений активных классов по маске значения глобального свойства
        /// </summary>
        public List<vclass> class_act_by_msk_global_prop_id_group(Int64 iid_global_prop, Int64 iid_group, String find_mask, Boolean class_real_only)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_act_by_msk_global_prop_id_group");

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


            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;
            cmdk.Parameters["iid_group"].Value = iid_group;
            cmdk.Parameters["find_mask"].Value = find_mask;
            cmdk.Parameters["class_real_only"].Value = class_real_only;

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
        /// Лист представлений активных классов по маске значения глобального свойства
        /// </summary>
        public List<vclass> class_act_by_msk_global_prop_id_group(global_prop Global_prp, group Group, String find_mask, Boolean class_real_only)
        {
            return class_act_by_msk_global_prop_id_group(Global_prp.Id, Group.Id, find_mask, class_real_only);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_msk_global_prop_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_act_by_msk_global_prop_id_group");
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
