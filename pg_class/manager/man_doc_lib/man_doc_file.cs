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

        #region ДОБАВИТЬ
        
        /// <summary>
        /// Метод добавляет новый файл документа
        /// </summary>
        public doc_file doc_file_add( Int64 iid_document, String ifilename, String iversion, DateTime iversiondate, String iextension, Byte[] file_data, Boolean ifulltxtsrch_on, eSizeTransferPage isizepage)
        {
            doc_file doc_file = null;
            String imd5 = "";
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            NpgsqlCommandKey cmdk_next;
            //**********
            //=======================
            cmdk = CommandByKey("doc_file_add");
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
            
            cmdk_next = CommandByKey("doc_file_add_next");
            if (cmdk_next != null)
            {
                if (!cmdk_next.Access)
                {
                    throw new AccessDataBaseException(404, String.Format(@"Отказано в доступе к методу: {0}!", cmdk_next.CommandText));
                }
            }
            else
            {
                throw new AccessDataBaseException(405, String.Format(@"Не найден метод: {0}!", cmdk_next.CommandText));
            }
            //=======================
            //=======================
            Int32 SizePage;
            Int32 SizeEndPage;
            Int32 CountPage;
            Byte[] buffer;
            MemoryStream ms;

            if (file_data == null || file_data.Length == 0)
            {
                String err = String.Format("Передан пустой массив данных!");
                throw new PgManagerException(101, err, err);
            }

            ms = new MemoryStream(file_data);
            if (file_data.Length > (Int32)isizepage)
            {
                SizePage = (Int32)isizepage;
                CountPage = Math.DivRem(file_data.Length, SizePage, out SizeEndPage);
                
                buffer = new Byte[SizePage];
                ms.Read(buffer, 0, SizePage);
            }
            else
            {
                SizePage = 0;
                SizeEndPage = 0;
                CountPage = 0;
                buffer = file_data;
            }

            //Расчитываем чексумму массива
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] checkSum = md5.ComputeHash(file_data);
            imd5 = BitConverter.ToString(checkSum).Replace("-", String.Empty);

            // Подготавливаем имя файла документа
            char[] charInvalidFileChars = Path.GetInvalidFileNameChars();
            foreach (char charInvalid in charInvalidFileChars)
            {
                ifilename = ifilename.Replace(charInvalid, ' ');
            }
            ifilename = ifilename.Replace(';', ' ');
            ifilename = ifilename.Replace("  ", " ");

            //Инициализируем методы первичной записи
            cmdk.Parameters["iid_document"].Value = iid_document;
            cmdk.Parameters["ifilename"].Value = ifilename;
            cmdk.Parameters["iversion"].Value = iversion;
            cmdk.Parameters["iversiondate"].Value = iversiondate;
            cmdk.Parameters["iextension"].Value = iextension;
            cmdk.Parameters["file_data"].Size = buffer.Length;
            cmdk.Parameters["file_data"].Value = buffer;

            cmdk.Parameters["imd5"].Value = imd5;
            cmdk.Parameters["ifulltxtsrch_on"].Value = ifulltxtsrch_on;

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
                        //Этап №02 Циклическая дозаливка документа
                        if (CountPage > 1)
                        {
                            for (int i = 1; i < CountPage; i++)
                            {
                                buffer = new Byte[SizePage];
                                ms.Position = i * SizePage;
                                ms.Read(buffer, 0, SizePage);

                                cmdk_next.Parameters["iid_doc_file"].Value = id;
                                cmdk_next.Parameters["file_data"].Size = buffer.Length;
                                cmdk_next.Parameters["file_data"].Value = buffer;
                                cmdk_next.ExecuteNonQuery();
                            }
                        }

                        //Этап №03 Заливка остатка документа
                        if (SizeEndPage > 0)
                        {
                            buffer = new Byte[SizeEndPage];
                            ms.Position = CountPage * SizePage;
                            ms.Read(buffer, 0, SizeEndPage);

                            cmdk_next.Parameters["iid_doc_file"].Value = id;
                            cmdk_next.Parameters["file_data"].Size = buffer.Length;
                            cmdk_next.Parameters["file_data"].Value = buffer;
                            cmdk_next.ExecuteNonQuery();
                        }

                        doc_file = doc_file_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.doc_file, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (doc_file != null)
            {
                //Генерируем событие изменения 
                DocFileChangeEventArgs e = new DocFileChangeEventArgs(doc_file, eAction.Insert);
                DocFileOnChange(e);
            }
            //Возвращаем Объект
            return doc_file;
        }

        /// <summary>
        /// Метод добавляет новый файл документа
        /// </summary>
        public doc_file doc_file_add(Int64 iid_document, String iversion, DateTime iversiondate, String Path, Boolean ifulltxtsrch_on, eSizeTransferPage isizepage)
        {
            doc_file Result = null;
            Byte[] file_data = null;
            String ifilename = "";
            String iextension = "";
            using (FileStream fs = System.IO.File.OpenRead(Path))
            {
                file_data = new byte[fs.Length];
                fs.Read(file_data, 0, (Int32)fs.Length);
                ifilename = System.IO.Path.GetFileNameWithoutExtension(Path);
                iextension = System.IO.Path.GetExtension(Path);
                Result = doc_file_add(iid_document, ifilename, iversion, iversiondate, iextension, file_data, ifulltxtsrch_on, isizepage);
            }
            return Result;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_file_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("doc_file_add");
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
        /// Метод изменяет атрибуты файла документа
        /// </summary>
        public doc_file doc_file_upd(Int64 iid_doc_file, String ifilename, String iversion, DateTime iversiondate, String iextension,  Boolean ifulltxtsrch_on)
        {
            doc_file doc_file = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("doc_file_upd");

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
            // Подготавливаем имя файла документа
            char[] charInvalidFileChars = Path.GetInvalidFileNameChars();

            foreach (char charInvalid in charInvalidFileChars)
            {
                ifilename = ifilename.Replace(charInvalid, ' ');
            }
            ifilename = ifilename.Replace(';', ' ');
            ifilename = ifilename.Replace("  ", " ");

            cmdk.Parameters["iid_doc_file"].Value = iid_doc_file;
            cmdk.Parameters["ifilename"].Value = ifilename;
            cmdk.Parameters["iversion"].Value = iversion;
            cmdk.Parameters["iversiondate"].Value = iversiondate;
            cmdk.Parameters["iextension"].Value = iextension;
            cmdk.Parameters["ifulltxtsrch_on"].Value = ifulltxtsrch_on;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    doc_file = doc_file_by_id(iid_doc_file);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_doc_file, eEntity.doc_file, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (doc_file != null)
            {
                //Генерируем событие изменения файла документов
                DocFileChangeEventArgs e = new DocFileChangeEventArgs(doc_file, eAction.Update);
                DocFileOnChange(e);
            }
            //Возвращаем Объект
            return doc_file;
        }

        /// <summary>
        /// Метод изменяет атрибуты файла документа
        /// </summary>
        public doc_file doc_file_upd(doc_file Doc_file)
        {
            return doc_file_upd(Doc_file.Id, Doc_file.Name, Doc_file.Version, Doc_file.Versiondate, Doc_file.Extension, Doc_file.Fulltxtsrch_on);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_file_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            //=======================
            cmdk = CommandByKey("doc_file_upd");
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
        /// Метод заменяет файл документа
        /// </summary>
        public doc_file doc_file_change(Int64 iid_doc_file,  String ifilename, String iversion, DateTime iversiondate, String iextension, Byte[] file_data, eSizeTransferPage isizepage)
        {
            doc_file doc_file = null;
            String imd5 = "";
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            NpgsqlCommandKey cmdk_next;
            //**********
            //=======================
            cmdk = CommandByKey("doc_file_change");

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
            cmdk_next = CommandByKey("doc_file_add_next");
            if (cmdk_next != null)
            {
                if (!cmdk_next.Access)
                {
                    throw new AccessDataBaseException(404, String.Format(@"Отказано в доступе к методу: {0}!", cmdk_next.CommandText));
                }
            }
            else
            {
                throw new AccessDataBaseException(405, String.Format(@"Не найден метод: {0}!", cmdk_next.CommandText));
            }
            //=======================
            //=======================
            Int32 SizePage;
            Int32 SizeEndPage;
            Int32 CountPage;
            Byte[] buffer;
            MemoryStream ms;

            if (file_data == null || file_data.Length == 0)
            {
                String err = String.Format("Передан пустой массив данных!");
                throw new PgManagerException(101, err, err);
            }

            ms = new MemoryStream(file_data);
            if (file_data.Length > (Int32)isizepage)
            {
                SizePage = (Int32)isizepage;
                CountPage = Math.DivRem(file_data.Length, SizePage, out SizeEndPage);

                buffer = new Byte[SizePage];
                ms.Read(buffer, 0, SizePage);
            }
            else
            {
                SizePage = 0;
                SizeEndPage = 0;
                CountPage = 0;
                buffer = file_data;
            }

            //Расчитываем чексумму массива
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] checkSum = md5.ComputeHash(file_data);
            imd5 = BitConverter.ToString(checkSum).Replace("-", String.Empty);

            //Инициализируем методы первичной записи
            cmdk.Parameters["iid_doc_file"].Value = iid_doc_file;
            cmdk.Parameters["ifilename"].Value = ifilename;
            cmdk.Parameters["iversion"].Value = iversion;
            cmdk.Parameters["iversiondate"].Value = iversiondate;
            cmdk.Parameters["iextension"].Value = iextension;
            cmdk.Parameters["file_data"].Size = buffer.Length;
            cmdk.Parameters["file_data"].Value = buffer;
            cmdk.Parameters["imd5"].Value = imd5;

            //Начало транзакции
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    //Этап №02 Циклическая дозаливка документа
                    if (CountPage > 1)
                    {
                        for (int i = 1; i < CountPage; i++)
                        {
                            buffer = new Byte[SizePage];
                            ms.Position = i * SizePage;
                            ms.Read(buffer, 0, SizePage);

                            cmdk_next.Parameters["iid_doc_file"].Value = iid_doc_file;
                            cmdk_next.Parameters["file_data"].Size = buffer.Length;
                            cmdk_next.Parameters["file_data"].Value = buffer;
                            cmdk_next.ExecuteNonQuery();
                        }
                    }

                    //Этап №03 Заливка остатка документа
                    if (SizeEndPage > 0)
                    {
                        buffer = new Byte[SizeEndPage];
                        ms.Position = CountPage * SizePage;
                        ms.Read(buffer, 0, SizeEndPage);

                        cmdk_next.Parameters["iid_doc_file"].Value = iid_doc_file;
                        cmdk_next.Parameters["file_data"].Size = buffer.Length;
                        cmdk_next.Parameters["file_data"].Value = buffer;
                        cmdk_next.ExecuteNonQuery();
                    }
                    doc_file = doc_file_by_id(iid_doc_file);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_doc_file, eEntity.doc_file, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (doc_file != null)
            {
                //Генерируем событие изменения файла документов
                DocFileChangeEventArgs e = new DocFileChangeEventArgs(doc_file, eAction.Update);
                DocFileOnChange(e);
            }
            //Возвращаем Объект
            return doc_file;
        }

        /// <summary>
        /// Метод заменяет файл документа
        /// </summary>
        public doc_file doc_file_change(doc_file Doc_file, String ifilename, Byte[] file_data, String iversion, DateTime iversiondate,  String iextension, eSizeTransferPage isizepage)
        {
            return doc_file_change(Doc_file.Id, ifilename, iversion, iversiondate, iextension, file_data, isizepage);
        }

        /// <summary>
        /// Метод заменяет файл документа
        /// </summary>
        public doc_file doc_file_change(Int64 iid_doc_file, String iversion, DateTime iversiondate, String Path, eSizeTransferPage isizepage)
        {
            doc_file Result = null;
            Byte[] file_data = null;
            String iextension = "";
            String ifilename = "";
            using (FileStream fs = System.IO.File.OpenRead(Path))
            {
                file_data = new byte[fs.Length];
                fs.Read(file_data, 0, (int)fs.Length);
                iextension = System.IO.Path.GetExtension(Path);
                ifilename = System.IO.Path.GetFileNameWithoutExtension(Path);
                Result = doc_file_change(iid_doc_file, ifilename, iversion, iversiondate, iextension, file_data, isizepage);
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_file_change(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("doc_file_change");
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
        /// Метод удаляет указанный файл документа
        /// </summary>
        public void doc_file_del(Int64 iid_doc_file)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("doc_file_del");
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

            doc_file doc_file = doc_file_by_id(iid_doc_file);

            cmdk.Parameters["iid_doc_file"].Value = iid_doc_file;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_doc_file, eEntity.doc_file, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            if (doc_file != null)
            {
                //Генерируем событие изменения файла документа
                DocFileChangeEventArgs e = new DocFileChangeEventArgs(doc_file, eAction.Delete);
                DocFileOnChange(e);
            }
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_file_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("doc_file_del");
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
        /// Файл документа по идентификатору
        /// </summary>
        public doc_file doc_file_by_id(Int64 iid)
        {
            doc_file doc_file = null;

            DataTable tbl_entity  = TableByName("vdoc_file");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("doc_file_by_id");

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
                doc_file = new doc_file(tbl_entity.Rows[0]);
            }
            return doc_file;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_file_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("doc_file_by_id");
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
        /// Лист файлов документа по идентификатору документа
        /// </summary>
        public List<doc_file> doc_file_by_id_document(Int64 iid_document)
        {
            List<doc_file>  entity_list = new List<doc_file>();
            
            DataTable tbl_entity  = TableByName("vdoc_file");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("doc_file_by_id_document");

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
            doc_file ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new doc_file(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_file_by_id_document(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("doc_file_by_id_document");
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
        /// Лист файлов документа по идентификатору документа и хэшу
        /// </summary>
        public List<doc_file> doc_file_by_md5(Int64 iid_document, String imd5)
        {
            List<doc_file> entity_list = new List<doc_file>();

            DataTable tbl_entity = TableByName("vdoc_file");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("doc_file_by_md5");

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
            cmdk.Parameters["imd5"].Value = imd5;

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
            doc_file ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new doc_file(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_file_by_md5(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("doc_file_by_md5");
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
        /// Метод извлекает из каталога двоичные данные файла документа
        /// </summary>
        public Byte[] doc_file_data_by_id(Int64 iid_doc_file, eSizeTransferPage isizepage)
        {
            doc_file doc_file = null;
            Byte[] Result = null;
            //=======================
            NpgsqlCommandKey cmdk;
            NpgsqlCommandKey cmdk_next;
            //**********
            //=======================
            cmdk = CommandByKey("doc_file_data_by_id");
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
            
            cmdk_next = CommandByKey("doc_file_data_read_by_id");
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
            //=======================
            Int32 SizePage;
            Int32 SizeEndPage;
            Int32 CountPage;
            Byte[] buffer;
            doc_file = doc_file_by_id(iid_doc_file);

            if (doc_file != null)
            {
                if (doc_file.Data_length > (Int32)isizepage)
                {
                    Result = new byte[doc_file.Data_length];
                    SizePage = (Int32)isizepage;
                    CountPage = Math.DivRem(Convert.ToInt32(doc_file.Data_length), SizePage, out SizeEndPage);
                    
                    cmdk_next.Parameters["iid_doc_file"].Value = iid_doc_file;
                    cmdk_next.Parameters["iseek"].Value = 0;
                    cmdk_next.Parameters["icount"].Value = SizePage;

                    object tmp = cmdk_next.ExecuteScalar();
                    if (tmp != DBNull.Value)
                    {
                        buffer = (Byte[])tmp;
                        buffer.CopyTo(Result, 0);
                    }
                }
                else
                {
                    SizePage = 0;
                    SizeEndPage = 0;
                    CountPage = 0;

                    cmdk.Parameters["iid_doc_file"].Value = iid_doc_file;
                    object tmp = cmdk.ExecuteScalar();
                    if (tmp != DBNull.Value)
                    {
                        Result = (Byte[])tmp;
                    }
                }
                //Этап №02 Циклическая дозаливка документа
                if (CountPage > 1)
                {
                    Int32 iseek;
                    for (int i = 1; i < CountPage; i++)
                    {
                        iseek = i * SizePage;
                        cmdk_next.Parameters["iid_doc_file"].Value = iid_doc_file;
                        cmdk_next.Parameters["iseek"].Value = iseek;
                        cmdk_next.Parameters["icount"].Value = SizePage;

                        object tmp = cmdk_next.ExecuteScalar();
                        if (tmp != DBNull.Value)
                        {
                            buffer = (Byte[])tmp;
                            buffer.CopyTo(Result, iseek);
                        }
                    }
                }

                //Этап №03 Заливка остатка документа
                if (SizeEndPage > 0)
                {
                    Int32 iseek;
                    iseek = CountPage * SizePage;

                    cmdk_next.Parameters["iid_doc_file"].Value = iid_doc_file;
                    cmdk_next.Parameters["iseek"].Value = iseek;
                    cmdk_next.Parameters["icount"].Value = SizeEndPage;

                    object tmp = cmdk_next.ExecuteScalar();
                    if (tmp != DBNull.Value)
                    {
                        buffer = (Byte[])tmp;
                        buffer.CopyTo(Result, iseek);
                    }
                }
            }
            return Result;
        }

        /// <summary>
        /// Метод извлекает из каталога двоичные данные файла документа
        /// </summary>
        public Byte[] doc_file_data_by_id(doc_file Doc_file, eSizeTransferPage isizepage)
        {
            return doc_file_data_by_id(Doc_file.Id, isizepage);
        }
        #endregion

        #region СВОЙСТВА ПОЛУЧАЕМЫЕ ИЗ БД
        //*********************************************************************************************
        /// <summary>
        /// Метод определяет актуальность состояния файла документа
        /// </summary>
        public eEntityState doc_file_is_actual(Int64 iid, DateTime itimestamp)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("doc_file_is_actual");

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
        public eEntityState doc_file_is_actual(doc_file Doc_file)
        {
            return doc_file_is_actual(Doc_file.Id, Doc_file.Timestamp);
        }


        //*********************************************************************************************
        /// <summary>
        /// Метод выполняет проверку хеша файла, выполняя сравнение данных в базе с фактическим значением
        /// </summary>
        public Boolean doc_file_hash_md5_check(Int64 iid_doc_file, eSizeTransferPage isizepage = eSizeTransferPage.Size4Mb)
        {
            Boolean result = false;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********

            //=======================
            cmdk = CommandByKey("doc_file_hash_md5_check");

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

            cmdk.Parameters["iid_doc_file"].Value = iid_doc_file;
            cmdk.Parameters["isizepage"].Value = (Int32)isizepage;

            //Начало транзакции
            result = (Boolean)cmdk.ExecuteScalar();
            return result;
        }

        /// <summary>
        /// Метод выполняет проверку хеша файла, выполняя сравнение данных в базе с фактическим значением
        /// </summary>
        public Boolean doc_file_hash_md5_check(doc_file Doc_file, eSizeTransferPage isizepage = eSizeTransferPage.Size4Mb)
        {
            return doc_file_hash_md5_check(Doc_file.Id, isizepage);
        }

        //*********************************************************************************************
        /// <summary>
        /// Лист расширений файлов документов по идентификатору концепции
        /// </summary>
        public List<String> doc_file_extension_by_id_conception(Int64 iid_conception)
        {
            List<String> entity_list = new List<String>();

            DataTable tbl_entity = new DataTable();
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("doc_file_extension_by_id_conception");

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
            String ext;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ext = (String)dr[0];
                    entity_list.Add(ext);
                }
            }
            return entity_list;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_file_extension_by_id_conception(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("doc_file_extension_by_id_conception");
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
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ

        /// <summary>
        /// Делегат события изменения атрибутов файла документа
        /// </summary>
        public delegate void DocFileChangeEventHandler(Object sender, DocFileChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении атрибутов файла документа методом доступа к БД
        /// </summary>
        public event DocFileChangeEventHandler DocFileChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения атрибутов файла документа
        /// </summary>
        protected virtual void DocFileOnChange(DocFileChangeEventArgs e)
        {
            DocFileChangeEventHandler temp = DocFileChange;
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
