using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод добавляет ссылку для указанной записи журнала
        /// </summary>
        public log_link log_link_add(Int64 iid_log, Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            log_link log_link = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_link_add");
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

            cmdk.Parameters["iid_log"].Value = iid_log;
            cmdk.Parameters["iid_entity"].Value = iid_entity;
            cmdk.Parameters["iid_entity_instance"].Value = iid_entity_instance;
            cmdk.Parameters["iid_sub_entity_instance"].Value = iid_sub_entity_instance;
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            switch (error)
            {
                case 0:
                    id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
                    if (id > 0)
                    {
                        log_link = log_link_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.log_link, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (log_link != null)
            {
                //Генерируем событие изменения 
                LogLinkChangeEventArgs e = new LogLinkChangeEventArgs(log_link, eAction.Insert);
                LogLinkOnChange(e);
            }
            //Возвращаем сущность
            return log_link;
        }

        /// <summary>
        /// Метод добавляет ссылку для указанной записи журнала
        /// </summary>
        public log_link log_link_add(Int64 iid_log, user User)
        {
            return log_link_add(iid_log, User.EntityID, User.Id, -1);
        }

        /// <summary>
        /// Метод добавляет ссылку для указанной записи журнала
        /// </summary>
        public log_link log_link_add(Int64 iid_log, pos_temp Pos_temp)
        {
            return log_link_add(iid_log, Pos_temp.EntityID, Pos_temp.Id, -1);
        }

        /// <summary>
        /// Метод добавляет ссылку для указанной записи журнала
        /// </summary>
        public log_link log_link_add(Int64 iid_log, pos_temp_prop Pos_temp_prop)
        {
            return log_link_add(iid_log, Pos_temp_prop.EntityID, Pos_temp_prop.Id, -1);
        }

        /// <summary>
        /// Метод добавляет ссылку для указанной записи журнала
        /// </summary>
        public log_link log_link_add(Int64 iid_log, position Position)
        {
            return log_link_add(iid_log, Position.EntityID, Position.Id, -1);
        }

        /// <summary>
        /// Метод добавляет ссылку для указанной записи журнала
        /// </summary>
        public log_link log_link_add(Int64 iid_log, position_prop Position_prop)
        {
            return log_link_add(iid_log, Position_prop.EntityID, Position_prop.Id_position_prop, Position_prop.Id_position_carrier);
        }

        /// <summary>
        /// Метод добавляет ссылку для указанной записи журнала
        /// </summary>
        public log_link log_link_add(Int64 iid_log, object_general Object_general)
        {
            return log_link_add(iid_log, Object_general.EntityID, Object_general.Id, -1);
        }

        /// <summary>
        /// Метод добавляет ссылку для указанной записи журнала
        /// </summary>
        public log_link log_link_add(Int64 iid_log, object_prop Object_prop)
        {
            return log_link_add(iid_log, Object_prop.EntityID, Object_prop.Id_class_prop, Object_prop.Id_object_carrier);
        }

        /// <summary>
        /// Метод добавляет ссылку для указанной записи журнала
        /// </summary>
        public log_link log_link_add(Int64 iid_log, group Group)
        {
            return log_link_add(iid_log, Group.EntityID, Group.Id, -1);
        }

        /// <summary>
        /// Метод добавляет ссылку для указанной записи журнала
        /// </summary>
        public log_link log_link_add(Int64 iid_log, vclass Class)
        {
            return log_link_add(iid_log, Class.EntityID, Class.Id, -1);
        }

        /// <summary>
        /// Метод добавляет ссылку для указанной записи журнала
        /// </summary>
        public log_link log_link_add(Int64 iid_log, class_prop Class_prop)
        {
            return log_link_add(iid_log, Class_prop.EntityID, Class_prop.Id, -1);
        }

        /// <summary>
        /// Метод добавляет ссылку для указанной записи журнала
        /// </summary>
        public log_link log_link_add(Int64 iid_log, document Document)
        {
            return log_link_add(iid_log, Document.EntityID, Document.Id, -1);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean log_link_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_link_add");
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