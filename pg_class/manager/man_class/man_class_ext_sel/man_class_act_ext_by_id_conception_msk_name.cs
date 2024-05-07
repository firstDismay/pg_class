﻿using pg_class.pg_classes;
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
        /// Лист представлений активных классов концепции по маске имени
        /// </summary>
        public List<vclass> class_act_ext_by_id_conception_msk_name(Int64 iid_conception, String name_mask)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass_ext");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_act_ext_by_id_conception_msk_name");

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
            cmdk.Parameters["name_mask"].Value = name_mask;

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
        /// Лист представлений активных классов концепции по маске имени
        /// </summary>
        public List<vclass> class_act_ext_by_id_conception_msk_name(conception Conception, String name_mask)
        {
            return class_act_ext_by_id_conception_msk_name(Conception.Id, name_mask);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_ext_by_id_conception_msk_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_act_ext_by_id_conception_msk_name");
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
