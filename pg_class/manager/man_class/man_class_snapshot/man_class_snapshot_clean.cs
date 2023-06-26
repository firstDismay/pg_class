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
        /// Метод удаляет снимки концепции не содержащие каскадно наследующие объекты и классы значения свойств
        /// </summary>
        public Int64 class_snapshot_clear(Int64 iid_conception)
        {
            Int64 Result = 0;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_snapshot_clear");
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

            conception conception = conception_by_id(iid_conception);
            cmdk.Parameters["iid_conception"].Value = iid_conception;
            Result = (Int64)cmdk.ExecuteScalar();
            return Result;
        }

        /// <summary>
        /// Метод удаляет снимки концепции не содержащие каскадно наследующие объекты и классы значения свойств
        /// </summary>
        public Int64 class_snapshot_clear(conception Conception)
        {
            return class_snapshot_clear(Conception.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_clear(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_snapshot_clear");
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

        /// <summary>
        /// Лист неиспользуемых снимков классов концепции по идентификатору концепции
        /// </summary>
        public List<vclass> class_snapshot_clear_info(Int64 iid_conception)
        {
            List<vclass> vclass_snapshot_list = new List<vclass>();
            DataTable tbl_vclass_snapshot = TableByName("vclass");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_snapshot_clear_info");
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
        /// Лист неиспользуемых снимков классов концепции по идентификатору концепции
        /// </summary>
        public List<vclass> class_snapshot_clear_info(conception Conception)
        {
            return class_snapshot_clear_info(Conception.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_clear_info(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_snapshot_clear_info");
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