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
        /// Выбрать значение пользовательского свойства позиции по идентификатору значения свойства
        /// </summary>
        public position_prop_user_val position_prop_user_val_by_id_prop(position_prop PositiontProp)
        {
            position_prop_user_val Result = null;

            switch (PositiontProp.Datatype)
            {
                case eDataType.val_bytea:
                case eDataType.val_text:
                case eDataType.val_json:
                    Result = position_prop_user_big_val_by_id_prop(PositiontProp);
                    break;
                default:
                    Result = position_prop_user_small_val_by_id_prop(PositiontProp);
                    break;
            }
            return Result;
        }

        /// <summary>
        /// Выбрать значение пользовательского свойства объекта по идентификатору значения свойства
        /// </summary>
        public position_prop_user_val position_prop_user_val_by_id_prop(position_prop_user_val PositionPropUserVal)
        {
            position_prop_user_val Result = null;

            switch (PositionPropUserVal.DataType)
            {
                case eDataType.val_bytea:
                case eDataType.val_text:
                case eDataType.val_json:
                    Result = position_prop_user_big_val_by_id_prop(PositionPropUserVal.Id_position_carrier, PositionPropUserVal.Id_pos_temp_prop);
                    break;
                default:
                    Result = position_prop_user_small_val_by_id_prop(PositionPropUserVal.Id_position_carrier, PositionPropUserVal.Id_pos_temp_prop);
                    break;
            }
            return Result;
        }
    }
}
