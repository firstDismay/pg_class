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
        /// Лист позиций по идентификатору позиции рекурсивно
        /// </summary>
        public List<position> position_by_id_recursive(Int64 iid)
        {
            List<position> pos_list = new List<position>();


            DataTable tbl_pos = TableByName("vposition");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_by_id_recursive");

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

            cmdk.Parameters["iid"].Value = iid;

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
        /// Лист позиций по идентификатору позиции рекурсивно
        /// </summary>
        public List<position> position_by_id_recursive(position Position)
        {
            return position_by_id_recursive(Position.Id);
        }

        /// <summary>
        /// Лист позиций по идентификатору позиции рекурсивно
        /// </summary>
        public List<position> position_by_id_recursive(Int64 id_parent, Int64 id_pos_temp)
        {
            return position_by_id_recursive(id_parent).FindAll(x => x.Id_pos_temp == id_pos_temp);
        }

        /// <summary>
        /// Лист позиций по идентификатору позиции рекурсивно
        /// </summary>
        public List<position> position_by_id_recursive(position Position, pos_temp Pos_temp)
        {
            return position_by_id_recursive(Position.Id, Pos_temp.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_by_id_recursive(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_by_id_recursive");
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