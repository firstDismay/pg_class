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
        /// Данные значения объектного свойства позиции
        /// </summary>
        public position_prop_object_val position_prop_object_val_by_id_prop(Int64 iid_position, Int64 iid_pos_temp_prop)
        {
            position_prop_object_val position_prop_object_val = null;

            DataTable tbl_object  = TableByName("vposition_prop_object_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("position_prop_object_val_by_id_prop");

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
            //=======================

            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            cmdk.Fill(tbl_object);
            
            if (tbl_object.Rows.Count > 0)
            {
                position_prop_object_val = new position_prop_object_val(tbl_object.Rows[0]);
            }
            return position_prop_object_val;
        }

        /// <summary>
        /// Данные значения объектного свойства позиции
        /// </summary>
        public position_prop_object_val position_prop_object_val_by_id_prop(position Position_carrier, pos_temp_prop Pos_temp_prop)
        {
            return position_prop_object_val_by_id_prop(Position_carrier.Id, Pos_temp_prop.Id);
        }

        /// <summary>
        /// Данные значения объектного свойства позиции
        /// </summary>
        public position_prop_object_val position_prop_object_val_by_id_prop(position Position_carrier, position_prop Pos_prop)
        {
            return position_prop_object_val_by_id_prop(Position_carrier.Id, Pos_prop.Id_pos_temp_prop);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_prop_object_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_prop_object_val_by_id_prop");
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
