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
        /// Лист исторических представлений базовых классов по идентификатору позиции носителя объектов
        /// </summary>
        public List<vclass> class_snapshot_ext_base_by_id_position(Int64 iid_position, Boolean on_internal = false)
        {
            List<vclass> vclass_snapshot_list = new List<vclass>();
            DataTable tbl_vclass_snapshot = TableByName("vclass_ext");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_snapshot_ext_base_by_id_position");
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

            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["on_internal"].Value = on_internal;
            cmdk.Fill(tbl_vclass_snapshot);

            vclass vcs;
            if (tbl_vclass_snapshot.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass_snapshot.Rows)
                {
                    vcs = new vclass(dr, iid_position);
                    vclass_snapshot_list.Add(vcs);
                }
            }
            return vclass_snapshot_list;
        }

        /// <summary>
        /// Лист исторических представлений базовых классов по идентификатору позиции носителя объектов
        /// </summary>
        public List<vclass> class_snapshot_ext_base_by_id_position(position Position_parent, Boolean On_internal = false)
        {
            return class_snapshot_ext_base_by_id_position(Position_parent.Id, On_internal);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_ext_base_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_snapshot_ext_base_by_id_position");
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