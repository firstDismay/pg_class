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
        /// Лист объектов path определяющих путь до группы
        /// </summary>
        public List<group_path> group_path_by_id_group(Int64 iid_group)
        {
            List<group_path> group_path_list = new List<group_path>();
            DataTable tbl_group_path = TableByName("path");


            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("group_path");

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


            cmdk.Parameters["iid_group"].Value = iid_group;

            cmdk.Fill(tbl_group_path);

            group_path gp;
            if (tbl_group_path.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_group_path.Rows)
                {
                    gp = new group_path(dr);
                    group_path_list.Add(gp);
                }
            }

            return group_path_list;
        }

        /// <summary>
        /// Лист объектов path определяющих путь до группы
        /// </summary>
        public List<group_path> group_path_by_id_group(group Group)
        {
            return group_path_by_id_group(Group.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean group_path_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("group_path");
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
