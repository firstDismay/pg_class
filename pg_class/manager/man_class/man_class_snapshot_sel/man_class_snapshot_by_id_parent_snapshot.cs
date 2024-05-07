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
        /// Лист исторических представлений классов по идентификатору снмика родительского класса
        /// </summary>
        public List<vclass> class_snapshot_by_id_parent_snapshot(Int64 iid_parent_snapshot, DateTime itimestamp_parent_snapshot)
        {
            List<vclass> vclass_snapshot_list = new List<vclass>();
            DataTable tbl_vclass_snapshot = TableByName("vclass");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_snapshot_by_id_parent_snapshot");
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

            cmdk.Parameters["iid_parent_snapshot"].Value = iid_parent_snapshot;
            cmdk.Parameters["itimestamp_parent_snapshot"].Value = itimestamp_parent_snapshot;
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
        /// Лист исторических представлений классов по идентификатору снимка родительского класса
        /// </summary>
        public List<vclass> class_snapshot_by_id_parent_snapshot(vclass Vclass_parent)
        {
            List<vclass> Result = null;
            switch (Vclass_parent.StorageType)
            {
                case eStorageType.History:
                    Result = class_snapshot_by_id_parent_snapshot(Vclass_parent.Id, Vclass_parent.Timestamp);
                    break;
                case eStorageType.Active:
                    throw new ArgumentOutOfRangeException("Тип представления класса не соответствует сигнатуре функции, требуется историческое представление класса!");
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_by_id_parent_snapshot(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_snapshot_by_id_parent_snapshot");
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