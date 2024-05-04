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
        /// Лист дочерних групп по строгому соответствию имени
        /// </summary>
        public List<group> group_by_name(Int64 iid_parent, String iname)
        {
            List<group> group_list = new List<group>();


            DataTable tbl_group = TableByName("vgroup");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("group_by_name");

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


            cmdk.Parameters["iid_parent"].Value = iid_parent;
            cmdk.Parameters["iname"].Value = iname;

            cmdk.Fill(tbl_group);

            group gt;
            if (tbl_group.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_group.Rows)
                {
                    gt = new group(dr);
                    group_list.Add(gt);
                }
            }

            return group_list;
        }

        /// <summary>
        /// Лист дочерних групп по строгому соответствию имени
        /// </summary>
        public List<group> group_by_name(group Group_parent, String iname)
        {
            return group_by_name(Group_parent.Id, iname);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean group_by_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("group_by_name");
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
