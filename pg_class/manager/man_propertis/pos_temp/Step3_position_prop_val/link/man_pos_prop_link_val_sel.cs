using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;
using System.Data;

namespace pg_class
{

    public partial class manager
    {
        /// <summary>
        /// Выбрать данные значения свойства объекта типа ссылка по идентификатору значения свойства
        /// </summary>
        public position_prop_link_val position_prop_link_val_by_id_prop(Int64 iid_position, Int64 iid_pos_temp_prop)
        {
            position_prop_link_val position_prop_link_val = null;

            DataTable tbl_entity = TableByName("vposition_prop_link_val");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_prop_link_val_by_id_prop");

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
                position_prop_link_val = new position_prop_link_val(tbl_entity.Rows[0]);
            }
            return position_prop_link_val;
        }


        /// <summary>
        /// Выбрать данные значения свойства объекта типа ссылка по идентификатору значения свойства
        /// </summary>
        public position_prop_link_val position_prop_link_val_by_id_prop(position_prop PositionProp)
        {
            return position_prop_link_val_by_id_prop(PositionProp.Id_position_carrier, PositionProp.Id_pos_temp_prop);
        }


        /// <summary>
        /// Выбрать данные значения свойства объекта типа ссылка по идентификатору значения свойства
        /// </summary>
        public position_prop_link_val position_prop_link_val_by_id_prop(position_prop_link_val PositionPropLink_val)
        {
            return position_prop_link_val_by_id_prop(PositionPropLink_val.Id_position_carrier, PositionPropLink_val.Id_pos_temp_prop);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_prop_link_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_prop_link_val_by_id_prop");
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
