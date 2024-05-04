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
    }
}
