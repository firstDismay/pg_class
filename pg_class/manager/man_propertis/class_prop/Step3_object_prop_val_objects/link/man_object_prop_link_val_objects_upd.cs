﻿using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Изменить данные значения свойства типа ссылка объектам снимка класса в указанной позиции
        /// </summary>
        public position object_prop_link_val_objects_upd(position Position_parent, class_prop_link_val newClass_prop_link_val, Boolean on_internal = false)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;

            cmdk = CommandByKey("object_prop_link_val_objects_upd");
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
            cmdk.Parameters["iid_class_prop"].Value = newClass_prop_link_val.Id_class_prop;
            cmdk.Parameters["itimestamp_class"].Value = newClass_prop_link_val.Timestamp_class;
            cmdk.Parameters["on_internal"].Value = on_internal;
            cmdk.Parameters["iid_entity_instance"].Value = newClass_prop_link_val.Link_id_entity_instance;
            cmdk.Parameters["iid_sub_entity_instance"].Value = newClass_prop_link_val.Link_id_sub_entity_instance;
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

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_link_val_objects_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_prop_link_val_objects_upd");
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