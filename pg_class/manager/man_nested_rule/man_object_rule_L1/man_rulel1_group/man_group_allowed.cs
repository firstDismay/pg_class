using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Npgsql;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using pg_class.pg_classes;

namespace pg_class
{
    public partial class manager
    {   
        /// <summary>
        /// Лист разрешенных групп на основе разрешения уровня 1 группа на шаблон по идентификатору позиции
        /// </summary>
        public List<group> group_allowed_rl1_by_id_position(Int64 iid_position)
        {
            List<group> group_list = new List<group>();
            DataTable tbl_group  = TableByName("vgroup");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("group_allowed_rl1_by_id_position");
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
        /// Лист разрешенных групп на основе разрешения уровня 1 группа на шаблон по идентификатору позиции
        /// </summary>
        public List<group> group_allowed_rl1_by_id_position(position Position)
        {
            return group_allowed_rl1_by_id_position(Position.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean group_allowed_rl1_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            cmdk = CommandByKey("group_allowed_rl1_by_id_position");
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
        /// Лист разрешенных групп на основе разрешения уровня 1 группа на шаблон по идентификатору шаблона позиции
        /// </summary>
        public List<group> group_allowed_rl1_by_id_pos_temp(Int64 iid_pos_temp)
        {
            List<group> group_list = new List<group>();
            DataTable tbl_group  = TableByName("vgroup");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("group_allowed_rl1_by_id_pos_temp");
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

            cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;
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
        /// Лист разрешенных групп на основе разрешения уровня 1 группа на шаблон по идентификатору шаблона позиции
        /// </summary>
        public List<group> group_allowed_rl1_by_id_pos_temp(pos_temp Pos_temp)
        {
            return group_allowed_rl1_by_id_pos_temp(Pos_temp.Id);
        }
                

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean group_allowed_rl1_by_id_pos_temp(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            cmdk = CommandByKey("group_allowed_rl1_by_id_pos_temp");
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
