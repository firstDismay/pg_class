using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Удалить значение свойств типа ссылка объектам снимка класса в указанной позиции
        /// </summary>
        public void object_prop_link_val_objects_del(Int64 iid_position, Int64 iid_class_prop, DateTime itimestamp_class, Boolean on_internal = false)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_prop_link_val_objects_del");
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

            //Предварительный запрос данных
            position Position_parent = position_by_id(iid_position);

            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;
            cmdk.Parameters["on_internal"].Value = on_internal;
            cmdk.ExecuteNonQuery();

            /*if (Position_parent != null)
		            {
				        //Генерируем событие изменения позиции
						PositionChangeEventArgs e = new PositionChangeEventArgs(Position_parent, eAction.Update);
						PositionOnChange(e);
					}*/
        }

        /// <summary>
        /// Удалить значение свойств типа ссылка объектам снимка класса в указанной позиции
        /// </summary>
        public void object_prop_link_val_objects_del(position Position_parent, class_prop ClassProp, Boolean on_internal = false)
        {
            object_prop_link_val_objects_del(Position_parent.Id, ClassProp.Id, ClassProp.Timestamp_class, on_internal);
        }

        /// <summary>
        /// Удалить значение свойств типа ссылка объектам снимка класса в указанной позиции
        /// </summary>
        public void object_prop_link_val_objects_del(position Position_parent, class_prop_link_val Class_prop_link_val, Boolean on_internal = false)
        {
            object_prop_link_val_objects_del(Position_parent.Id, Class_prop_link_val.Id_class_prop, Class_prop_link_val.Timestamp_class, on_internal);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_link_val_objects_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_prop_link_val_objects_del");
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