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
        /// Лист вещественных классов по идентификатору концепции
        /// </summary>
        public List<vclass> class_full_real_by_id_conception(Int64 iid_conception)
        {
            List<vclass> vclass_snapshot_list = new List<vclass>();


            DataTable tbl_vclass_snapshot = TableByName("vclass");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_full_real_by_id_conception");

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

            cmdk.Fill(tbl_vclass_snapshot);

            vclass vcs;
            if (tbl_vclass_snapshot.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass_snapshot.Rows)
                {
                    vcs = new vclass(dr);
                    vclass_snapshot_list.Add(vcs);
                }
            }
            return vclass_snapshot_list;
        }

        /// <summary>
        /// Лист вещественных классов по идентификатору концепции
        /// </summary>
        public List<vclass> class_full_real_by_id_conception(conception Conception)
        {
            return class_full_real_by_id_conception(Conception.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_full_real_by_id_conception(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_full_real_by_id_conception");
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
