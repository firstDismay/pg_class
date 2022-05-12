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
        /// Выбрать значение пользовательского свойства активного представления класса по идентификатору значения свойства
        /// </summary>
        public class_prop_user_val class_prop_user_val_snapshot_by_id_prop(class_prop ClassProp)
        {
            class_prop_user_val Result = null;

            switch (ClassProp.Datatype)
            {
                case eDataType.val_bytea:
                case eDataType.val_text:
                case eDataType.val_json:
                    Result = class_prop_user_big_val_snapshot_by_id_prop(ClassProp.Id, ClassProp.Timestamp_class);
                    break;
                default:
                    Result = class_prop_user_small_val_snapshot_by_id_prop(ClassProp.Id, ClassProp.Timestamp_class);
                    break;
            }
            return Result;
        }

        /// <summary>
        /// Выбрать значение пользовательского свойства активного представления класса по идентификатору значения свойства
        /// </summary>
        public class_prop_user_val class_prop_user_val_snapshot_by_id_prop(class_prop_user_val ClassPropUserVal)
        {
            class_prop_user_val Result = null;

            switch (ClassPropUserVal.DataType)
            {
                case eDataType.val_bytea:
                case eDataType.val_text:
                case eDataType.val_json:
                    Result = class_prop_user_big_val_snapshot_by_id_prop(ClassPropUserVal.Id_class_prop, ClassPropUserVal.Timestamp_class);
                    break;
                default:
                    Result = class_prop_user_small_val_snapshot_by_id_prop(ClassPropUserVal.Id_class_prop, ClassPropUserVal.Timestamp_class);
                    break;
            }
            return Result;
        }
    }
}
