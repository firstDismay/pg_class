using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_commands;
using pg_class.pg_classes;
using Npgsql;
using System.Data;
using pg_class.pg_exceptions;

namespace pg_class
{
    public partial class manager
    {
        #region ВЫБРАТЬ
        
        /// <summary>
        /// Лист объектов path определяющих путь до позиции в дереве позиций
        /// </summary>
        public List<pos_path> position_path_by_id_position(Int64 iid_position)
        {
            List<pos_path> pos_path_list = new List<pos_path>();
            DataTable tbl_pos_path  = TableByName("path4");

            
            
            NpgsqlCommandKey cmdk;
            
            cmdk = CommandByKey("position_path_by_id_position");

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

            cmdk.Fill(tbl_pos_path);
            
            pos_path pp;
            if (tbl_pos_path.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos_path.Rows)
                {
                    pp = new pos_path(dr);
                    pos_path_list.Add(pp);
                }
            }
            return pos_path_list;
        }

        /// <summary>
        /// Лист объектов path определяющих путь до позиции в дереве позиций
        /// </summary>
        public List<pos_path> position_path_by_id_position(position Position)
        {
            return position_path_by_id_position(Position.Id);
        }

        /// <summary>
        /// Лист объектов path определяющих путь до позиции в дереве позиций
        /// </summary>
        public List<pos_path> position_path_by_id_position(object_general object_general)
        {
            return position_path_by_id_position(object_general.Id_position);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_path_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("position_path_by_id_position");
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
        

        #endregion
    }
}
