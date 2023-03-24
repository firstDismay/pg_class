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
        /// Группа по идентификатору
        /// </summary>
        public group group_by_id(Int64 id)
        {
            group group = null;

            DataTable tbl_group = TableByName("vgroup");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("group_by_id");

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


            cmdk.Parameters["iid"].Value = id;

            cmdk.Fill(tbl_group);

            if (tbl_group.Rows.Count > 0)
            {
                group = new group(tbl_group.Rows[0]);
            }
            return group;
        }

        /// <summary>
        /// Позиция по объекту group_path
        /// </summary>
        public group group_by_group_path(group_path Group_path)
        {
            return group_by_id(Group_path.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean group_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("group_by_id");
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
        /// Лист групп по идентификатору родительской группы
        /// </summary>
        public List<group> group_by_id_parent(Int64 id_parent, Int64 id_con)
        {
            List<group> group_list = new List<group>();


            DataTable tbl_group = TableByName("vgroup");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("group_by_id_parent");

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


            cmdk.Parameters["iid_parent"].Value = id_parent;
            cmdk.Parameters["iid_con"].Value = id_con;

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
        /// Лист групп по идентификатору родительской группы
        /// </summary>
        public List<group> group_by_id_parent(group Group)
        {
            return group_by_id_parent(Group.Id, Group.Id_conception);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean group_by_id_parent(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("group_by_id_parent");
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
        /// Лист дочерних групп по строгому соотвествию имени
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
        /// Лист дочерних групп по строгому соотвествию имени
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
