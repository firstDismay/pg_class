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
        /// Выбирает снимок представления класса по ключевым параметрам
        /// </summary>
        public vclass class_snapshot_by_id(Int64 iid_class, DateTime timestamp_class)
        {
            vclass vclass_snapshot = null;
            DataTable tbl_vclass_snapshot = TableByName("vclass");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_snapshot_by_id");
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
            cmdk.Parameters["timestamp_class"].Value = timestamp_class;
            cmdk.Fill(tbl_vclass_snapshot);

            if (tbl_vclass_snapshot.Rows.Count > 0)
            {
                vclass_snapshot = new vclass(tbl_vclass_snapshot.Rows[0]);
            }
            return vclass_snapshot;
        }

        /// <summary>
        /// Выбирает снимок представления класса по объекту
        /// </summary>
        public vclass class_snapshot_by_id(object_general Object)
        {
            return class_snapshot_by_id(Object.Id_class, Object.Timestamp_class);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_snapshot_by_id");
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