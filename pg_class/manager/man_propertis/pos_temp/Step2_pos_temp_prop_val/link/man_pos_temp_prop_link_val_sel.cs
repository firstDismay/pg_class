using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using pg_class.pg_classes;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Выбрать данные значения свойства-ссылки по идентификатору свойства
        /// </summary>
        public pos_temp_prop_link_val pos_temp_prop_link_val_by_id_prop(Int64 iid_pos_temp_prop)
        {
            pos_temp_prop_link_val pos_temp_prop_link_val = null;

            DataTable tbl_entity  = TableByName("vpos_temp_prop_link_val");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("pos_temp_prop_link_val_by_id_prop");

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
            

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            cmdk.Fill(tbl_entity);
            
            if (tbl_entity.Rows.Count > 0)
            {
                pos_temp_prop_link_val = new pos_temp_prop_link_val(tbl_entity.Rows[0]);
            }
            return pos_temp_prop_link_val;
        }


        
        /// <summary>
        /// Выбрать данные значения свойства-ссылки по идентификатору свойства
        /// </summary>
        public pos_temp_prop_link_val pos_temp_prop_link_val_by_id_prop(pos_temp_prop PosTemp_prop)
        {
            return pos_temp_prop_link_val_by_id_prop(PosTemp_prop.Id);
        }

        
        /// <summary>
        /// Выбрать данные значения свойства-ссылки по идентификатору свойства
        /// </summary>
        public pos_temp_prop_link_val pos_temp_prop_link_val_by_id_prop(pos_temp_prop_link_val PosTemp_prop_link_val)
        {
            return pos_temp_prop_link_val_by_id_prop(PosTemp_prop_link_val.Id_pos_temp_prop);
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_link_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("pos_temp_prop_link_val_by_id_prop");
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
