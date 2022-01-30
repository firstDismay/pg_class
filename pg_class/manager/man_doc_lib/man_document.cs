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
using System.IO;

namespace pg_class
{
    public partial class manager
    {
        #region МЕТОДЫ КЛАССА: ФАЙЛЫ ДОКУМЕНТА

        #region ДОБАВИТЬ [ФАЙЛ МАССИВ]
        
        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_category, Int64 iid_parent, 
                                     String iname, String idesc, String iregnum, DateTime iregdate, 
                                     Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            document document = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("document_add");

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

            cmdk.Parameters["iid_category"].Value = iid_category;
            cmdk.Parameters["iid_parent"].Value = iid_parent;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["iregnum"].Value = iregnum;
            cmdk.Parameters["iregdate"].Value = iregdate;

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
                        document = document_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.document, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (document != null)
            {
                //Генерируем событие изменения 
                DocumentChangeEventArgs e = new DocumentChangeEventArgs(document, eAction.Insert);
                DocumentOnChange(e);
            }
            //Возвращаем Объект
            return document;
        }

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_category, Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate,
                                     user User)
        {
            return document_add(iid_category, iid_parent,
                                     iname,idesc, iregnum, iregdate,
                                     User.EntityID, User.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_category, Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate,
                                     pos_temp Pos_temp)
        {
            return document_add(iid_category, iid_parent,
                                     iname, idesc, iregnum, iregdate,
                                     Pos_temp.EntityID, Pos_temp.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_category, Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate,
                                     pos_temp_prop Pos_temp_prop)
        {
            return document_add(iid_category, iid_parent,
                                     iname, idesc, iregnum, iregdate,
                                     Pos_temp_prop.EntityID, Pos_temp_prop.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_category, Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate,
                                     position Position)
        {
            return document_add(iid_category, iid_parent,
                                     iname, idesc, iregnum, iregdate,
                                     Position.EntityID, Position.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_category, Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate,
                                     position_prop Position_prop)
        {
            return document_add(iid_category, iid_parent,
                                     iname, idesc, iregnum, iregdate,
                                     Position_prop.EntityID, Position_prop.Id_position_prop, Position_prop.Id_position_carrier);
        }

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_category, Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate,
                                     object_general Object_general)
        {
            return document_add(iid_category, iid_parent,
                                     iname, idesc, iregnum, iregdate,
                                     Object_general.EntityID, Object_general.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_category, Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate,
                                     object_prop Object_prop)
        {
            return document_add(iid_category, iid_parent,
                                     iname, idesc, iregnum, iregdate,
                                     Object_prop.EntityID, Object_prop.Id_class_prop, Object_prop.Id_object_carrier);
        }

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_category, Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate,
                                     group Group)
        {
            return document_add(iid_category, iid_parent,
                                     iname, idesc, iregnum, iregdate,
                                     Group.EntityID, Group.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_category, Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate,
                                     vclass Class)
        {
            return document_add(iid_category, iid_parent,
                                     iname, idesc, iregnum, iregdate,
                                     Class.EntityID, Class.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_category, Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate,
                                     class_prop Class_prop)
        {
            return document_add(iid_category, iid_parent,
                                     iname, idesc, iregnum, iregdate,
                                     Class_prop.EntityID, Class_prop.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_category, 
                                     String iname, String idesc, String iregnum, DateTime iregdate,
                                     document document_parent)
        {
            return document_add(iid_category, document_parent.Id,
                                     iname, idesc, iregnum, iregdate,
                                     -1, -1, -1);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("document_add");
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

        #region ИЗМЕНИТЬ
        /// <summary>
        /// Метод изменяет атрибуты документа
        /// </summary>
        public document document_upd(Int64 iid_document, Int64 iid_category, String iname, String idesc, String iregnum, DateTime iregdate)
        {
            document document = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("document_upd");

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
            cmdk.Parameters["iid_category"].Value = iid_category;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["iregnum"].Value = iregnum;
            cmdk.Parameters["iregdate"].Value = iregdate;            

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    document = document_by_id(iid_document);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_document, eEntity.document, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (document != null)
            {
                //Генерируем событие изменения
                DocumentChangeEventArgs e = new DocumentChangeEventArgs(document, eAction.Update);
                DocumentOnChange(e);
            }
            //Возвращаем Объект
            return document;
        }

        /// <summary>
        /// Метод изменяет атрибуты документа
        /// </summary>
        public document document_upd(document Document)
        {
            return document_upd(Document.Id, Document.Id_category, Document.Name, Document.Desc, Document.Regnum, Document.Regdate);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("document_upd");
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
        /// Метод добавляет документ в пакет документов
        /// </summary>
        public document document_include_in_pack(Int64 iid_document_pack, Int64 iid_document)
        {
            document document = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********

            //=======================
            cmdk = CommandByKey("document_include_in_pack");

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

            cmdk.Parameters["iid_document_pack"].Value = iid_document_pack;
            cmdk.Parameters["iid_document"].Value = iid_document;

            //Начало транзакции
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    document = document_by_id(iid_document);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_document, eEntity.document, error, desc_error, eAction.Include, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (document != null)
            {
                //Генерируем событие изменения
                DocumentChangeEventArgs e = new DocumentChangeEventArgs(document, eAction.Include);
                DocumentOnChange(e);
            }
            //Возвращаем Объект
            return document;
        }

        /// <summary>
        /// Метод добавляет документ в пакет документов
        /// </summary>
        public document document_include_in_pack(document DocumentPack, document Document)
        {
            return document_include_in_pack(DocumentPack.Id, Document.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_include_in_pack(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("document_include_in_pack");
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
        /// Метод исключает документ из пакета документов
        /// </summary>
        public document document_exclude_from_pack(Int64 iid_document)
        {
            document document = null;
            document document_old = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********

            //=======================
            cmdk = CommandByKey("document_exclude_from_pack");

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
            
            //Запрос потенциально удаляемой сущности
            document_old = document_by_id(iid_document);

            //Начало транзакции
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    document = document_by_id(iid_document);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_document, eEntity.document, error, desc_error, eAction.Exclude, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения файла документов
            if (document != null)
            {
                DocumentChangeEventArgs e = new DocumentChangeEventArgs(document, eAction.Exclude);
                DocumentOnChange(e);
            }
            else
            {
                DocumentChangeEventArgs e = new DocumentChangeEventArgs(document_old, eAction.Delete);
                DocumentOnChange(e);
            }
            //Возвращаем Объект
            return document;
        }

        /// <summary>
        /// Метод исключает документ из пакета документов
        /// </summary>
        public document document_exclude_from_pack(document Document)
        {
            return document_exclude_from_pack(Document.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_exclude_from_pack(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("document_exclude_from_pack");
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

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет документ указанный по идентификатору
        /// </summary>
        public void document_del(Int64 iid_document)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("document_del");

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

            //Запрос удаляемой сущности
            document document = document_by_id(iid_document);

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_document, eEntity.document, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие изменения концепции
            if (document != null)
            {
                DocumentChangeEventArgs e = new DocumentChangeEventArgs(document, eAction.Delete);
                DocumentOnChange(e);
            }
        }
        

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("document_del");
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
        /// Метод удаляет документ и все вложенные документы по идентификатору документа
        /// </summary>
        public void document_del_all(Int64 iid_document)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********

            //=======================
            cmdk = CommandByKey("document_del_all");

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

            document document = document_by_id(iid_document);

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
                JournalEventArgs me = new JournalEventArgs(iid_document, eEntity.document, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие изменения концепции
            if (document != null)
            {
                DocumentChangeEventArgs e = new DocumentChangeEventArgs(document, eAction.Delete);
                DocumentOnChange(e);
            }
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_del_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("document_del_all");
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
        /// Документ по идентификатору
        /// </summary>
        public document document_by_id(Int64 iid)
        {
            document document = null;

            DataTable tbl_entity  = TableByName("vdocument");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("document_by_id");

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

            cmdk.Fill(tbl_entity);
            
            if (tbl_entity.Rows.Count > 0)
            {
                document = new document(tbl_entity.Rows[0]);
            }
            return document;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("document_by_id");
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
        /// Лист документов по идентификатору пакета документов документа
        /// </summary>
        public List<document> document_by_id_parent(Int64 iid_parent)
        {
            List<document>  entity_list = new List<document>();
            
            DataTable tbl_entity  = TableByName("vdocument");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("document_by_id_parent");

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

            cmdk.Parameters["iid_parent"].Value = iid_parent;

            cmdk.Fill(tbl_entity);
            
            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_parent(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("document_by_id_parent");
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
        /// Лист документов по идентификатору концепции
        /// </summary>
        public List<document> document_by_id_conception(Int64 iid_conception)
        {
            List<document> entity_list = new List<document>();

            DataTable tbl_entity = TableByName("vdocument");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("document_by_id_conception");

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

            cmdk.Parameters["iid_conception"].Value = iid_conception;

            cmdk.Fill(tbl_entity);
            
            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_conception(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("document_by_id_conception");
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
        /// Лист документов по идентификатору категории документов
        /// </summary>
        public List<document> document_by_id_category(Int64 iid_category)
        {
            List<document> entity_list = new List<document>();

            DataTable tbl_entity = TableByName("vdocument");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("document_by_id_category");

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

            cmdk.Parameters["iid_category"].Value = iid_category;

            cmdk.Fill(tbl_entity);
            
            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_category(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("document_by_id_category");
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
        /// Лист документов по идентификатору шаблона позиции
        /// </summary>
        public List<document> document_by_id_pos_temp(Int64 iid_entity_instatce, Boolean position_on, Boolean object_on, Boolean recursive_on)
        {
            List<document> entity_list = new List<document>();

            DataTable tbl_entity = TableByName("vdocument");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("document_by_id_pos_temp");

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

            cmdk.Parameters["iid_entity_instatce"].Value = iid_entity_instatce;
            cmdk.Parameters["position_on"].Value = position_on;
            cmdk.Parameters["object_on"].Value = object_on;
            cmdk.Parameters["recursive_on"].Value = recursive_on;

            cmdk.Fill(tbl_entity);
            
            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист документов по идентификатору шаблона позиции
        /// </summary>
        public List<document> document_by_id_pos_temp(pos_temp Pos_temp, Boolean position_on, Boolean object_on, Boolean recursive_on)
        {
            return document_by_id_pos_temp(Pos_temp.Id, position_on, object_on, recursive_on);
        }
        
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_pos_temp(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("document_by_id_pos_temp");
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
        /// Лист документов по идентификатору позиции
        /// </summary>
        public List<document> document_by_id_position(Int64 iid_entity_instatce, Boolean object_on, Boolean recursive_on)
        {
            List<document> entity_list = new List<document>();

            DataTable tbl_entity = TableByName("vdocument");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("document_by_id_position");

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

            cmdk.Parameters["iid_entity_instatce"].Value = iid_entity_instatce;
            cmdk.Parameters["object_on"].Value = object_on;
            cmdk.Parameters["recursive_on"].Value = recursive_on;

            cmdk.Fill(tbl_entity);
            
            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист документов по идентификатору позиции
        /// </summary>
        public List<document> document_by_id_position(position Position, Boolean object_on, Boolean recursive_on)
        {
            return document_by_id_position(Position.Id, object_on, recursive_on);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("document_by_id_position");
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
        /// Лист документов по идентификатору пользователя
        /// </summary>
        public List<document> document_by_id_user(Int64 iid_entity_instatce)
        {
            List<document> entity_list = new List<document>();

            DataTable tbl_entity = TableByName("vdocument");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("document_by_id_user");

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

            cmdk.Parameters["iid_entity_instatce"].Value = iid_entity_instatce;
            
            cmdk.Fill(tbl_entity);
            
            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист документов по идентификатору пользователя
        /// </summary>
        public List<document> document_by_id_user(user User)
        {
            return document_by_id_user(User.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_user(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("document_by_id_user");
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
        /// Лист документов по идентификатору свойства позиции
        /// </summary>
        public List<document> document_by_id_position_prop(Int64 iid_entity_instatce, Int64 iid_sub_entity_instatce)
        {
            List<document> entity_list = new List<document>();

            DataTable tbl_entity = TableByName("vdocument");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("document_by_id_position_prop");

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

            cmdk.Parameters["iid_entity_instatce"].Value = iid_entity_instatce;
            cmdk.Parameters["iid_sub_entity_instatce"].Value = iid_sub_entity_instatce;

            cmdk.Fill(tbl_entity);
            
            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист документов по идентификатору свойства позиции
        /// </summary>
        public List<document> document_by_id_position_prop(position_prop Position_prop)
        {
            return document_by_id_position_prop(Position_prop.Id_position_prop, Position_prop.Id_position_carrier);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_position_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("document_by_id_position_prop");
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
        /// Лист документов по идентификатору свойства шаблона позиции
        /// </summary>
        public List<document> document_by_id_pos_temp_prop(Int64 iid_entity_instatce)
        {
            List<document> entity_list = new List<document>();

            DataTable tbl_entity = TableByName("vdocument");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("document_by_id_pos_temp_prop");

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

            cmdk.Parameters["iid_entity_instatce"].Value = iid_entity_instatce;

            cmdk.Fill(tbl_entity);
            
            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист документов по идентификатору свойства шаблона позиции
        /// </summary>
        public List<document> document_by_id_pos_temp_prop(pos_temp_prop Pos_temp_prop)
        {
            return document_by_id_pos_temp_prop(Pos_temp_prop.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_pos_temp_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("document_by_id_pos_temp_prop");
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
        /// Лист документов по идентификатору группы классов
        /// </summary>
        public List<document> document_by_id_group(Int64 iid_entity_instatce, Boolean class_on, Boolean object_on , Boolean recursive_on)
        {
            List<document> entity_list = new List<document>();

            DataTable tbl_entity = TableByName("vdocument");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("document_by_id_group");

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

            cmdk.Parameters["iid_entity_instatce"].Value = iid_entity_instatce;
            cmdk.Parameters["class_on"].Value = class_on;
            cmdk.Parameters["object_on"].Value = object_on;
            cmdk.Parameters["recursive_on"].Value = recursive_on;

            cmdk.Fill(tbl_entity);
            
            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист документов по идентификатору группы классов
        /// </summary>
        public List<document> document_by_id_group(group Group, Boolean class_on, Boolean object_on, Boolean recursive_on)
        {
            return document_by_id_group(Group.Id, class_on, object_on, recursive_on);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("document_by_id_group");
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
        /// Лист документов по идентификатору класса
        /// </summary>
        public List<document> document_by_id_class(Int64 iid_entity_instatce, Boolean object_on, Boolean recursive_on)
        {
            List<document> entity_list = new List<document>();

            DataTable tbl_entity = TableByName("vdocument");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("document_by_id_class");

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

            cmdk.Parameters["iid_entity_instatce"].Value = iid_entity_instatce;
            cmdk.Parameters["object_on"].Value = object_on;
            cmdk.Parameters["recursive_on"].Value = recursive_on;

            cmdk.Fill(tbl_entity);
            
            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист документов по идентификатору класса
        /// </summary>
        public List<document> document_by_id_class(vclass Class, Boolean object_on, Boolean recursive_on)
        {
            return document_by_id_class(Class.Id, object_on, recursive_on);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("document_by_id_class");
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
        /// Лист документов по идентификатору свойства класса
        /// </summary>
        public List<document> document_by_id_class_prop(Int64 iid_entity_instatce)
        {
            List<document> entity_list = new List<document>();

            DataTable tbl_entity = TableByName("vdocument");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("document_by_id_class_prop");

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

            cmdk.Parameters["iid_entity_instatce"].Value = iid_entity_instatce;

            cmdk.Fill(tbl_entity);
            
            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист документов по идентификатору свойства класса
        /// </summary>
        public List<document> document_by_id_class_prop(class_prop Class_prop)
        {
            return document_by_id_class_prop(Class_prop.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_class_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("document_by_id_class_prop");
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
        /// Лист документов по идентификатору объекта
        /// </summary>
        public List<document> document_by_id_object(Int64 iid_entity_instatce, Boolean class_on, Boolean group_on, Boolean recursive_on)
        {
            List<document> entity_list = new List<document>();

            DataTable tbl_entity = TableByName("vdocument");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("document_by_id_object");

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

            cmdk.Parameters["iid_entity_instatce"].Value = iid_entity_instatce;
            cmdk.Parameters["class_on"].Value = class_on;
            cmdk.Parameters["group_on"].Value = group_on;
            cmdk.Parameters["recursive_on"].Value = recursive_on;

            cmdk.Fill(tbl_entity);
            
            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист документов по идентификатору объекта
        /// </summary>
        public List<document> document_by_id_object(object_general Object_general, Boolean class_on, Boolean group_on, Boolean recursive_on)
        {
            return document_by_id_object(Object_general.Id, class_on, group_on, recursive_on);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_object(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("document_by_id_object");
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
        /// Лист документов по идентификатору свойства объекта
        /// </summary>
        public List<document> document_by_id_object_prop(Int64 iid_entity_instatce, Int64 iid_sub_entity_instatce)
        {
            List<document> entity_list = new List<document>();

            DataTable tbl_entity = TableByName("vdocument");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("document_by_id_object_prop");

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

            cmdk.Parameters["iid_entity_instatce"].Value = iid_entity_instatce;
            cmdk.Parameters["iid_sub_entity_instatce"].Value = iid_sub_entity_instatce;

            cmdk.Fill(tbl_entity);
            
            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист документов по идентификатору свойства класса
        /// </summary>
        public List<document> document_by_id_object_prop(object_prop Object_prop)
        {
            return document_by_id_object_prop(Object_prop.Id_class_prop, Object_prop.Id_object_carrier);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_object_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("document_by_id_object_prop");
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
        /// Лист документов концепции по маске имени документа
        /// </summary>
        public List<document> document_by_msk_name_from_conception(String iname, Int64 iid_conception)
        {
            List<document> entity_list = new List<document>();

            DataTable tbl_entity = TableByName("vdocument");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("document_by_msk_name_from_conception");

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

            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["iid_conception"].Value = iid_conception;

            cmdk.Fill(tbl_entity);
            
            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_msk_name_from_conception(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("document_by_msk_name_from_conception");
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
        /// Лист документов категории по маске имени документа
        /// </summary>
        public List<document> document_by_msk_name_from_category(String iname, Int64 iid_category)
        {
            List<document> entity_list = new List<document>();

            DataTable tbl_entity = TableByName("vdocument");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("document_by_msk_name_from_category");

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

            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["iid_category"].Value = iid_category;

            cmdk.Fill(tbl_entity);
            
            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_msk_name_from_category(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("document_by_msk_name_from_category");
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
        /// Метод определяет актуальность состояния документа
        /// </summary>
        public eEntityState document_is_actual(Int64 iid, DateTime itimestamp)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("document_is_actual");

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
            cmdk.Parameters["itimestamp"].Value = itimestamp;

            //Начало транзакции
            is_actual = (Int32)cmdk.ExecuteScalar();
            
            return (eEntityState)is_actual;
        }

        /// <summary>
        /// Метод определяет актуальность состояния категории документов
        /// </summary>
        public eEntityState document_is_actual(document Document)
        {
            return document_is_actual(Document.Id, Document.Timestamp);
        }

        #endregion
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ

        /// <summary>
        /// Делегат события изменения атрибутов документа
        /// </summary>
        public delegate void DocumentChangeEventHandler(Object sender, DocumentChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении атрибутов документа методом доступа к БД
        /// </summary>
        public event DocumentChangeEventHandler DocumentChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения атрибутов документа
        /// </summary>
        protected virtual void DocumentOnChange(DocumentChangeEventArgs e)
        {
            DocumentChangeEventHandler temp = DocumentChange;
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