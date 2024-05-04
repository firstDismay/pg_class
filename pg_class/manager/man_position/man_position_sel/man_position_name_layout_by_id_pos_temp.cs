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
        /// Лист макетов наименований позиций по идентификатору шаблона позиции
        /// </summary>
        public List<String> position_name_layout_by_id_pos_temp(Int64 iid_pos_temp)
        {
            List<String> pos_list = new List<String>();
            DataTable tbl_pos = new DataTable();


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_name_layout_by_id_pos_temp");

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

            cmdk.Fill(tbl_pos);

            String pt;
            if (tbl_pos.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos.Rows)
                {
                    pt = (String)dr[0];
                    pos_list.Add(pt);
                }
            }

            return pos_list;
        }

        /// <summary>
        /// Лист макетов наименований позиций по идентификатору шаблона позиции
        /// </summary>
        public List<String> position_name_layout_by_id_pos_temp(pos_temp pos_temp)
        {
            return position_name_layout_by_id_pos_temp(pos_temp.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_name_layout_by_id_pos_temp(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_name_layout_by_id_pos_temp");
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
