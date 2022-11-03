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
        /// Выбрать значение свойства позиции типа перечисление по идентификатору значения свойства
        /// </summary>
        public position_prop_enum_val position_prop_enum_val_by_id_prop(Int64 iid_position, Int64 iid_pos_temp_prop)
        {
            position_prop_enum_val position_prop_enum_val = null;

            DataTable tbl_entity  = TableByName("vposition_prop_enum_val");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("position_prop_enum_val_by_id_prop");

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
            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            cmdk.Fill(tbl_entity);
            
            if (tbl_entity.Rows.Count > 0)
            {
                position_prop_enum_val = new position_prop_enum_val(tbl_entity.Rows[0]);
            }
            return position_prop_enum_val;
        }

        
        /// <summary>
        /// Выбрать значение свойства позиции типа перечисление по идентификатору значения свойства
        /// </summary>
        public position_prop_enum_val position_prop_enum_val_by_id_prop(position_prop PositionProp)
        {
            return position_prop_enum_val_by_id_prop(PositionProp.Id_position_carrier, PositionProp.Id_pos_temp_prop);
        }

        
        /// <summary>
        /// Выбрать значение свойства позиции типа перечисление по идентификатору значения свойства
        /// </summary>
        public position_prop_enum_val position_prop_enum_val_by_id_prop(position_prop_enum_val PositionPropEnum_val)
        {
            return position_prop_enum_val_by_id_prop(PositionPropEnum_val.Id_position_carrier, PositionPropEnum_val.Id_pos_temp_prop);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_prop_enum_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("position_prop_enum_val_by_id_prop");
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
