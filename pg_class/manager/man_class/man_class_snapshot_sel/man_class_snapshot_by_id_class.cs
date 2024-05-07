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
        /// Лист снимков класса по идентификатору класса. без учета активного представлеиня
        /// </summary>
        public List<vclass> class_snapshot_by_id_class(Int64 iid_class)
        {
            List<vclass> vclass_snapshot_list = new List<vclass>();
            DataTable tbl_vclass_snapshot = TableByName("vclass");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_snapshot_by_id_class");
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
        /// Лист снимков класса по идентификатору класса. без учета активного представлеиня
        /// </summary>
        public List<vclass> class_snapshot_by_id_class(vclass Vclass)
        {
            return class_snapshot_by_id_class(Vclass.Id);
        }

        /// <summary>
        /// Лист снимков класса по идентификатору класса. без учета активного представлеиня
        /// </summary>
        public List<vclass> class_snapshot_by_id_class(object_general Object)
        {
            return class_snapshot_by_id_class(Object.Id_class);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_by_id_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_snapshot_by_id_class");
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