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
        //ACCESS
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
    }
}
