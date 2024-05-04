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
        /// Лист позиций по идентификатору родительской позиции
        /// position_by_id_parent
        /// </summary>
        public List<position> position_root_by_id_conception(Int64 iid_conception)
        {
            List<position> pos_list = new List<position>();
            DataTable tbl_pos = TableByName("vposition");

            NpgsqlCommandKey cmdk;
            cmdk = CommandByKey("position_root_by_id_conception");

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

            cmdk.Fill(tbl_pos);

            position pt;
            if (tbl_pos.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos.Rows)
                {
                    pt = new position(dr);
                    pos_list.Add(pt);
                }
            }
            return pos_list;
        }

        /// <summary>
        /// Лист позиций по идентификатору родительской позиции
        /// position_by_id_parent
        /// </summary>
        public List<position> position_root_by_id_conception(conception Conception)
        {
            return position_root_by_id_conception(Conception.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// position_by_id_parent
        /// </summary>
        public Boolean position_root_by_id_conception(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_root_by_id_conception");
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
