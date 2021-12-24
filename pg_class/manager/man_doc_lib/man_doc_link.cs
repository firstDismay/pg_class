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
        #region МЕТОДЫ КЛАССА: ФАЙЛЫ ДОКУМЕНТА

        #region ДОБАВИТЬ

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

        //-=ACCESS=-***********************************************************************************
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
        //*********************************************************************************************
        
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет указаную ссылку документа
        /// </summary>
        public void doc_link_del(Int64 iid_document, Int64 iid_doc_link)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
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
            //=======================

            doc_link doc_link = doc_link_by_id(iid_doc_link);

            cmdk.Parameters["iid_document"].Value = iid_document;
            cmdk.Parameters["iid_doc_link"].Value = iid_doc_link;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
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

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_link_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
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
        //*********************************************************************************************

        /// <summary>
        /// Метод удаляет указаную ссылку документа по идентификатору сущности
        /// </summary>
        public void doc_link_del_by_entity(Int64 iid_document, Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            Int64 iid_doc_link = -1;
            //**********

            //=======================
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
            //=======================

            doc_link doc_link = doc_link_by_entity(iid_document, iid_entity, iid_entity_instance, iid_sub_entity_instance);
            if (doc_link != null)
            {
                iid_doc_link = doc_link.Id;
            }

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

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_link_del_by_entity(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
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
        //*********************************************************************************************

        /// <summary>
        /// Метод удаляет все ссылки документа
        /// </summary>
        public void doc_link_del_all(Int64 iid_document)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********

            //=======================
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
            //=======================

            cmdk.Parameters["iid_document"].Value = iid_document;


            //Начало транзакции
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_document, eEntity.doc_link, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_link_del_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
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
        //*********************************************************************************************
        #endregion

        #region ВЫБРАТЬ

        //*********************************************************************************************
        /// <summary>
        /// Ссылка документа по идентификатору
        /// </summary>
        public doc_link doc_link_by_id(Int64 iid)
        {
            doc_link doc_link = null;

            DataTable tbl_entity  = TableByName("vdoc_link");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("doc_link_by_id");

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

            cmdk.Parameters["iid"].Value = iid;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_entity);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            
            if (tbl_entity.Rows.Count > 0)
            {
                doc_link = new doc_link(tbl_entity.Rows[0]);
            }
            return doc_link;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_link_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("doc_link_by_id");
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

        
        //*********************************************************************************************
        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            doc_link doc_link = null;

            DataTable tbl_entity = TableByName("vdoc_link");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("doc_link_by_entity");

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

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_entity);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

            if (tbl_entity.Rows.Count > 0)
            {
                doc_link = new doc_link(tbl_entity.Rows[0]);
            }
            return doc_link;
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, user User)
        {
            return doc_link_by_entity(iid_document, User.EntityID, User.Id, -1);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, pos_temp Pos_temp)
        {
            return doc_link_by_entity(iid_document, Pos_temp.EntityID, Pos_temp.Id, -1);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, pos_temp_prop Pos_temp_prop)
        {
            return doc_link_by_entity(iid_document, Pos_temp_prop.EntityID, Pos_temp_prop.Id, -1);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, position Position)
        {
            return doc_link_by_entity(iid_document, Position.EntityID, Position.Id, -1);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, position_prop Position_prop)
        {
            return doc_link_by_entity(iid_document, Position_prop.EntityID, Position_prop.Id_position_prop, Position_prop.Id_position_carrier);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, object_general Object_general)
        {
            return doc_link_by_entity(iid_document, Object_general.EntityID, Object_general.Id, -1);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, object_prop Object_prop)
        {
            return doc_link_by_entity(iid_document, Object_prop.EntityID, Object_prop.Id_class_prop, Object_prop.Id_object_carrier);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, group Group)
        {
            return doc_link_by_entity(iid_document, Group.EntityID, Group.Id, -1);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, vclass Class)
        {
            return doc_link_by_entity(iid_document, Class.EntityID, Class.Id, -1);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, class_prop Class_prop)
        {
            return doc_link_by_entity(iid_document, Class_prop.EntityID, Class_prop.Id, -1);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_link_by_entity(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("doc_link_by_entity");
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

        //*********************************************************************************************
        /// <summary>
        /// Лист ссылок документа по идентификатору документа
        /// </summary>
        public List<doc_link> doc_link_by_id_document(Int64 iid_document)
        {
            List<doc_link>  entity_list = new List<doc_link>();
            
            DataTable tbl_entity  = TableByName("vdoc_link");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("doc_link_by_id_document");

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

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_entity);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            doc_link ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new doc_link(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_link_by_id_document(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("doc_link_by_id_document");
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
        #endregion

        #region СВОЙСТВА ПОЛУЧАЕМЫЕ ИЗ БД
        //*********************************************************************************************
        /// <summary>
        /// Метод определяет актуальность состояния ссылки документа
        /// </summary>
        public eEntityState doc_link_is_actual(Int64 iid)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("doc_link_is_actual");

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

            cmdk.Parameters["iid"].Value = iid;

            //Начало транзакции
            is_actual = (Int32)cmdk.ExecuteScalar();
            
            return (eEntityState)is_actual;
        }

        /// <summary>
        /// Метод определяет актуальность состояния категории документов
        /// </summary>
        public eEntityState doc_link_is_actual(doc_file Doc_file)
        {
            return doc_link_is_actual(Doc_file.Id);
        }

        #endregion
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ

        /// <summary>
        /// Делегат события изменения ссылки документа
        /// </summary>
        public delegate void DocLinkChangeEventHandler(Object sender, DocLinkChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении ссылки документа методом доступа к БД
        /// </summary>
        public event DocLinkChangeEventHandler DocLinkChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения атрибутов файла документа
        /// </summary>
        protected virtual void DocLinkOnChange(DocLinkChangeEventArgs e)
        {
            DocLinkChangeEventHandler temp = DocLinkChange;
            if (temp != null)
            {
                temp(this, e);
            }
            //Вызов события журнала
            JournalEventArgs me = new JournalEventArgs(e);
            JournalMessageOnReceived(me);
        }

        #endregion
    }
}
