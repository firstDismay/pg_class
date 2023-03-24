using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод удаляет указаную ссылку документа
        /// </summary>
        public void doc_link_del(Int64 iid_doc_link)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("doc_link_del");
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

            doc_link doc_link = doc_link_by_id(iid_doc_link);

            cmdk.Parameters["iid_doc_link"].Value = iid_doc_link;
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_doc_link, eEntity.doc_link, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            if (doc_link != null)
            {
                //Генерируем событие изменения
                DocLinkChangeEventArgs e = new DocLinkChangeEventArgs(doc_link, eAction.Delete);
                DocLinkOnChange(e);
            }
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_link_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("doc_link_del");
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

        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public void doc_link_del_by_entity(Int64 iid_document, Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            Int64 iid_doc_link = -1;

            cmdk = CommandByKey("doc_link_del_by_entity");
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

            doc_link doc_link = doc_link_by_entity(iid_document, iid_entity, iid_entity_instance, iid_sub_entity_instance);
            if (doc_link != null)
            {
                iid_doc_link = doc_link.Id;
            }

            cmdk.Parameters["iid_document"].Value = iid_document;
            cmdk.Parameters["iid_entity"].Value = iid_entity;
            cmdk.Parameters["iid_entity_instance"].Value = iid_entity_instance;
            cmdk.Parameters["iid_sub_entity_instance"].Value = iid_sub_entity_instance;
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_doc_link, eEntity.doc_link, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            if (doc_link != null)
            {
                //Генерируем событие изменения
                DocLinkChangeEventArgs e = new DocLinkChangeEventArgs(doc_link, eAction.Delete);
                DocLinkOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public void doc_link_del_by_entity(Int64 iid_document, user User)
        {
            doc_link_del_by_entity(iid_document, User.EntityID, User.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public void doc_link_del_by_entity(Int64 iid_document, pos_temp Pos_temp)
        {
            doc_link_del_by_entity(iid_document, Pos_temp.EntityID, Pos_temp.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public void doc_link_del_by_entity(Int64 iid_document, pos_temp_prop Pos_temp_prop)
        {
            doc_link_del_by_entity(iid_document, Pos_temp_prop.EntityID, Pos_temp_prop.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public void doc_link_del_by_entity(Int64 iid_document, position Position)
        {
            doc_link_del_by_entity(iid_document, Position.EntityID, Position.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public void doc_link_del_by_entity(Int64 iid_document, position_prop Position_prop)
        {
            doc_link_del_by_entity(iid_document, Position_prop.EntityID, Position_prop.Id_position_prop, Position_prop.Id_position_carrier);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public void doc_link_del_by_entity(Int64 iid_document, object_general Object_general)
        {
            doc_link_del_by_entity(iid_document, Object_general.EntityID, Object_general.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public void doc_link_del_by_entity(Int64 iid_document, object_prop Object_prop)
        {
            doc_link_del_by_entity(iid_document, Object_prop.EntityID, Object_prop.Id_class_prop, Object_prop.Id_object_carrier);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public void doc_link_del_by_entity(Int64 iid_document, group Group)
        {
            doc_link_del_by_entity(iid_document, Group.EntityID, Group.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public void doc_link_del_by_entity(Int64 iid_document, vclass Class)
        {
            doc_link_del_by_entity(iid_document, Class.EntityID, Class.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public void doc_link_del_by_entity(Int64 iid_document, class_prop Class_prop)
        {
            doc_link_del_by_entity(iid_document, Class_prop.EntityID, Class_prop.Id, -1);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_link_del_by_entity(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("doc_link_del_by_entity");
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

        /// <summary>
        /// Метод удаляет все ссылки документа
        /// </summary>
        public void doc_link_del_all(Int64 iid_document)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("doc_link_del_all");
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

            cmdk.Parameters["iid_document"].Value = iid_document;
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_document, eEntity.doc_link, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_link_del_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("doc_link_del_all");
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