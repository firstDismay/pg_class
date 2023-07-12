using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Добавить новое значение объектного свойства объектов снимка класса в указанной позиции
        /// </summary>
        public position object_prop_object_val_objects_set(position Position_parent, Int64 iid_class_prop, DateTime itimestamp_class,
                               Int64 iid_class_real, Int32 iid_unit_conversion_rule, Decimal icquantity, Boolean on_internal = false)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_prop_object_val_objects_set_new");
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

            cmdk.Parameters["iid_position"].Value = Position_parent.Id;
            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;
            cmdk.Parameters["on_internal"].Value = on_internal;
            cmdk.Parameters["iid_class_real"].Value = iid_class_real;
            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;
            cmdk.Parameters["icquantity"].Value = icquantity;
            cmdk.ExecuteNonQuery();

            /*if (Position_parent != null)
					{
						//Генерируем событие изменения позиции
						PositionChangeEventArgs e = new PositionChangeEventArgs(Position_parent, eAction.Update);
						PositionOnChange(e);
					}*/

            //Возвращаем сущность
            return Position_parent;
        }

        /// <summary>
        /// Добавить новое значение объектного свойства объектов снимка класса в указанной позиции
        /// </summary>
        public position object_prop_object_val_objects_set(position Position_parent, class_prop_object_val newClass_prop_object_val, Decimal icquantity, Boolean on_internal = false)
        {
            return object_prop_object_val_objects_set(Position_parent, newClass_prop_object_val.Id_class_prop, newClass_prop_object_val.Timestamp_class,
                               newClass_prop_object_val.Id_class_val, newClass_prop_object_val.Id_unit_conversion_rule, icquantity, on_internal);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_object_val_objects_set(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_prop_object_val_objects_set_new");
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
