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
        /// Выбрать значение пользовательского свойства объекта по идентификатору значения свойства
        /// </summary>
        public object_prop_user_val object_prop_user_val_by_id_prop(object_prop ObjectProp)
        {
            object_prop_user_val Result = null;

            switch (ObjectProp.Datatype)
            {
                case eDataType.val_bytea:
                case eDataType.val_text:
                case eDataType.val_json:
                    Result = object_prop_user_big_val_by_id_prop(ObjectProp);
                    break;
                default:
                    Result = object_prop_user_small_val_by_id_prop(ObjectProp);
                    break;
            }
            return Result;
        }

        /// <summary>
        /// Выбрать значение пользовательского свойства объекта по идентификатору значения свойства
        /// </summary>
        public object_prop_user_val object_prop_user_val_by_id_prop(object_prop_user_val ObjectPropUserVal)
        {
            object_prop_user_val Result = null;

            switch (ObjectPropUserVal.DataType)
            {
                case eDataType.val_bytea:
                case eDataType.val_text:
                case eDataType.val_json:
                    Result = object_prop_user_big_val_by_id_prop(ObjectPropUserVal.Id_object_carrier, ObjectPropUserVal.Id_class_prop);
                    break;
                default:
                    Result = object_prop_user_small_val_by_id_prop(ObjectPropUserVal.Id_object_carrier, ObjectPropUserVal.Id_class_prop);
                    break;
            }
            return Result;
        }
    }
}
