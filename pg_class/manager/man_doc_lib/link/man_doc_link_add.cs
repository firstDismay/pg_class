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
using System.Security.Cryptography;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод добавляет ссылку на документ для указанной сущности
        /// </summary>
        public doc_link doc_link_add( Int64 iid_document, Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            doc_link doc_link = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("doc_link_add");

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

            cmdk.Parameters["iid_document"].Value = iid_document;
            cmdk.Parameters["iid_entity"].Value = iid_entity;
            cmdk.Parameters["iid_entity_instance"].Value = iid_entity_instance;
            cmdk.Parameters["iid_sub_entity_instance"].Value = iid_sub_entity_instance;

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
                        doc_link = doc_link_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.doc_link, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (doc_link != null)
            {
                //Генерируем событие изменения 
                DocLinkChangeEventArgs e = new DocLinkChangeEventArgs(doc_link, eAction.Insert);
                DocLinkOnChange(e);
            }
            //Возвращаем Объект
            return doc_link;
        }

        /// <summary>
        /// Метод добавляет ссылку на документ для указанной сущности
        /// </summary>
        public doc_link doc_link_add(Int64 iid_document, user User)
        {
            return doc_link_add(iid_document, User.EntityID, User.Id, -1);
        }

        /// <summary>
        /// Метод добавляет ссылку на документ для указанной сущности
        /// </summary>
        public doc_link doc_link_add(Int64 iid_document, pos_temp Pos_temp)
        {
            return doc_link_add(iid_document, Pos_temp.EntityID, Pos_temp.Id, -1);
        }

        /// <summary>
        /// Метод добавляет ссылку на документ для указанной сущности
        /// </summary>
        public doc_link doc_link_add(Int64 iid_document, pos_temp_prop Pos_temp_prop)
        {
            return doc_link_add(iid_document, Pos_temp_prop.EntityID, Pos_temp_prop.Id, -1);
        }

        /// <summary>
        /// Метод добавляет ссылку на документ для указанной сущности
        /// </summary>
        public doc_link doc_link_add(Int64 iid_document, position Position)
        {
            return doc_link_add(iid_document, Position.EntityID, Position.Id, -1);
        }

        /// <summary>
        /// Метод добавляет ссылку на документ для указанной сущности
        /// </summary>
        public doc_link doc_link_add(Int64 iid_document, position_prop Position_prop)
        {
            return doc_link_add(iid_document, Position_prop.EntityID, Position_prop.Id_position_prop, Position_prop.Id_position_carrier);
        }

        /// <summary>
        /// Метод добавляет ссылку на документ для указанной сущности
        /// </summary>
        public doc_link doc_link_add(Int64 iid_document, object_general Object_general)
        {
            return doc_link_add(iid_document, Object_general.EntityID, Object_general.Id, -1);
        }

        /// <summary>
        /// Метод добавляет ссылку на документ для указанной сущности
        /// </summary>
        public doc_link doc_link_add(Int64 iid_document, object_prop Object_prop)
        {
            return doc_link_add(iid_document, Object_prop.EntityID, Object_prop.Id_class_prop, Object_prop.Id_object_carrier);
        }

        /// <summary>
        /// Метод добавляет ссылку на документ для указанной сущности
        /// </summary>
        public doc_link doc_link_add(Int64 iid_document, group Group)
        {
            return doc_link_add(iid_document, Group.EntityID, Group.Id, -1);
        }

        /// <summary>
        /// Метод добавляет ссылку на документ для указанной сущности
        /// </summary>
        public doc_link doc_link_add(Int64 iid_document, vclass Class)
        {
            return doc_link_add(iid_document, Class.EntityID, Class.Id, -1);
        }

        /// <summary>
        /// Метод добавляет ссылку на документ для указанной сущности
        /// </summary>
        public doc_link doc_link_add(Int64 iid_document, class_prop Class_prop)
        {
            return doc_link_add(iid_document, Class_prop.EntityID, Class_prop.Id, -1);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_link_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("doc_link_add");
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
