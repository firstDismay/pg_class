using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;
using System.Collections.Generic;
using System.Data;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Ссылка записи журнала по идентификатору сущности
        /// </summary>
        public log_link log_link_by_entity(Int64 iid_log, Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            log_link log_link = null;
            DataTable tbl_entity = TableByName("vlog_link");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_link_by_entity");
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
            cmdk.Fill(tbl_entity);

            if (tbl_entity.Rows.Count > 0)
            {
                log_link = new log_link(tbl_entity.Rows[0]);
            }
            return log_link;
        }

        /// <summary>
        /// Ссылка записи журнала по идентификатору сущности
        /// </summary>
        public log_link log_link_by_entity(Int64 iid_log, user User)
        {
            return log_link_by_entity(iid_log, User.EntityID, User.Id, -1);
        }

        /// <summary>
        /// Ссылка записи журнала по идентификатору сущности
        /// </summary>
        public log_link log_link_by_entity(Int64 iid_log, pos_temp Pos_temp)
        {
            return log_link_by_entity(iid_log, Pos_temp.EntityID, Pos_temp.Id, -1);
        }

        /// <summary>
        /// Ссылка записи журнала по идентификатору сущности
        /// </summary>
        public log_link log_link_by_entity(Int64 iid_log, pos_temp_prop Pos_temp_prop)
        {
            return log_link_by_entity(iid_log, Pos_temp_prop.EntityID, Pos_temp_prop.Id, -1);
        }

        /// <summary>
        /// Ссылка записи журнала по идентификатору сущности
        /// </summary>
        public log_link log_link_by_entity(Int64 iid_log, position Position)
        {
            return log_link_by_entity(iid_log, Position.EntityID, Position.Id, -1);
        }

        /// <summary>
        /// Ссылка записи журнала по идентификатору сущности
        /// </summary>
        public log_link log_link_by_entity(Int64 iid_log, position_prop Position_prop)
        {
            return log_link_by_entity(iid_log, Position_prop.EntityID, Position_prop.Id_position_prop, Position_prop.Id_position_carrier);
        }

        /// <summary>
        /// Ссылка записи журнала по идентификатору сущности
        /// </summary>
        public log_link log_link_by_entity(Int64 iid_log, object_general Object_general)
        {
            return log_link_by_entity(iid_log, Object_general.EntityID, Object_general.Id, -1);
        }

        /// <summary>
        /// Ссылка записи журнала по идентификатору сущности
        /// </summary>
        public log_link log_link_by_entity(Int64 iid_log, object_prop Object_prop)
        {
            return log_link_by_entity(iid_log, Object_prop.EntityID, Object_prop.Id_class_prop, Object_prop.Id_object_carrier);
        }

        /// <summary>
        /// Ссылка записи журнала по идентификатору сущности
        /// </summary>
        public log_link log_link_by_entity(Int64 iid_log, group Group)
        {
            return log_link_by_entity(iid_log, Group.EntityID, Group.Id, -1);
        }

        /// <summary>
        /// Ссылка записи журнала по идентификатору сущности
        /// </summary>
        public log_link log_link_by_entity(Int64 iid_log, vclass Class)
        {
            return log_link_by_entity(iid_log, Class.EntityID, Class.Id, -1);
        }

        /// <summary>
        /// Ссылка записи журнала по идентификатору сущности
        /// </summary>
        public log_link log_link_by_entity(Int64 iid_log, class_prop Class_prop)
        {
            return log_link_by_entity(iid_log, Class_prop.EntityID, Class_prop.Id, -1);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean log_link_by_entity(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_link_by_entity");
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