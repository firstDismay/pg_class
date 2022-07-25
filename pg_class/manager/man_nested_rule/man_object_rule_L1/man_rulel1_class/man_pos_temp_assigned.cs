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
        /// Метод возвращает список шаблонов которым назнечена указанная группа 
        /// на основе разрешений уровня 1 группа на шаблон по идентификатору шаблона
        /// </summary>
        public List<pos_temp> pos_temp_assigned_rl1_by_id_class(Int64 iid_class)
        {
            List<pos_temp> pos_temp_list = new List<pos_temp>();
            DataTable tbl_pos_temp  = TableByName("vpos_temp");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_assigned_rl1_by_id_class");
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
            cmdk.Fill(tbl_pos_temp);
            
            pos_temp pt;
            if (tbl_pos_temp.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos_temp.Rows)
                {
                    pt = new pos_temp(dr);
                    pos_temp_list.Add(pt);
                }
            }
            return pos_temp_list;
        }

        /// <summary>
        /// Метод возвращает список шаблонов которым назнечена указанная группа 
        /// на основе разрешений уровня 1 группа на шаблон по идентификатору шаблона
        /// </summary>
        public List<pos_temp> pos_temp_assigned_rl1_by_id_class(vclass Class)
        {
            return pos_temp_assigned_rl1_by_id_group(Class.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_assigned_rl1_by_id_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_assigned_rl1_by_id_class");
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
