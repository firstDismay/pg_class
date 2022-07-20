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
using Newtonsoft.Json;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод копирует объект в указанное расположение
        /// </summary>
        public object_general object_copy(Int64 iid_object_pattern, Int32 iid_entity_target, Int64 iid_entity_instance_target, Int64 iid_sub_entity_instance_target)
        {
            object_general Object_copy = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("object_copy");

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

            cmdk.Parameters["iid_object_pattern"].Value = iid_object_pattern;
            cmdk.Parameters["iid_entity_target"].Value = iid_entity_target;
            cmdk.Parameters["iid_entity_instance_target"].Value = iid_entity_instance_target;
            cmdk.Parameters["iid_sub_entity_instance_target"].Value = iid_sub_entity_instance_target;
            cmdk.Parameters["on_check_nested_rule"].Value = true;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
                    if (id > 0)
                    {
                        Object_copy = object_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.vobject, error, desc_error, eAction.Copy, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (Object_copy != null)
            {
                //Генерируем событие изменения 
                ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object_copy, eAction.Copy);
                ObjectOnChange(e);
                //Возвращаем Объект
            }
            return Object_copy;
        }

        /// <summary>
        /// Метод копирует объект в указанное расположение
        /// </summary>
        public object_general object_copy(object_general Object_pattern, position Position_target)
        {
            return object_copy(Object_pattern.Id, Position_target.EntityID, Position_target.Id, -1);
        }

        /// <summary>
        /// Метод копирует объект в указанное расположение
        /// </summary>
        public object_general object_copy(object_general Object_pattern, position_prop Position_prop_target)
        {
            return object_copy(Object_pattern.Id, Position_prop_target.EntityID, Position_prop_target.Id_pos_temp_prop, Position_prop_target.Id_position_carrier);
        }

        /// <summary>
        /// Метод копирует объект в указанное расположение
        /// </summary>
        public object_general object_copy(object_general Object_pattern, object_prop Object_prop_target)
        {
            return object_copy(Object_pattern.Id, Object_prop_target.EntityID, Object_prop_target.Id_class_prop, Object_prop_target.Id_object_carrier);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_copy(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_copy");
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
