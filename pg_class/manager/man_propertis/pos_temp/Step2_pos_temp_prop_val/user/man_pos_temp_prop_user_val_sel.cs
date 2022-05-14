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
        /// Выбрать значение пользовательского свойства шаблона по идентификатору значения свойства
        /// </summary>
        public pos_temp_prop_user_val pos_temp_prop_user_val_by_id_prop(pos_temp_prop PosTempProp)
        {
            pos_temp_prop_user_val Result = null;

            switch (PosTempProp.Datatype)
            {
                case eDataType.val_bytea:
                case eDataType.val_text:
                case eDataType.val_json:
                    Result = pos_temp_prop_user_big_val_by_id_prop(PosTempProp.Id);
                    break;
                default:
                    Result = pos_temp_prop_user_small_val_by_id_prop(PosTempProp.Id);
                    break;
            }
            return Result;
        }

        /// <summary>
        /// Выбрать значение пользовательского свойства шаблона по идентификатору значения свойства
        /// </summary>
        public pos_temp_prop_user_val pos_temp_prop_user_val_by_id_prop(pos_temp_prop_user_val PosTempPropUserVal)
        {
            pos_temp_prop_user_val Result = null;

            switch (PosTempPropUserVal.DataType)
            {
                case eDataType.val_bytea:
                case eDataType.val_text:
                case eDataType.val_json:
                    Result = pos_temp_prop_user_big_val_by_id_prop(PosTempPropUserVal.Id_pos_temp_prop);
                    break;
                default:
                    Result = pos_temp_prop_user_small_val_by_id_prop(PosTempPropUserVal.Id_pos_temp_prop);
                    break;
            }
            return Result;
        }
    }
}
