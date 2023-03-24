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
        /// Файл документа по идентификатору
        /// </summary>
        public doc_file doc_file_by_id(Int64 iid)
        {
            doc_file doc_file = null;

            DataTable tbl_entity = TableByName("vdoc_file");


            NpgsqlCommandKey cmdk;


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


            cmdk.Parameters["iid"].Value = iid;

            cmdk.Fill(tbl_entity);

            if (tbl_entity.Rows.Count > 0)
            {
                doc_file = new doc_file(tbl_entity.Rows[0]);
            }
            return doc_file;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_file_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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


        /// <summary>
        /// Лист файлов документа по идентификатору документа
        /// </summary>
        public List<doc_file> doc_file_by_id_document(Int64 iid_document)
        {
            List<doc_file> entity_list = new List<doc_file>();

            DataTable tbl_entity = TableByName("vdoc_file");


            NpgsqlCommandKey cmdk;


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


            cmdk.Parameters["iid_document"].Value = iid_document;

            cmdk.Fill(tbl_entity);

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

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_file_by_id_document(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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


        /// <summary>
        /// Лист файлов документа по идентификатору документа и хэшу
        /// </summary>
        public List<doc_file> doc_file_by_md5(Int64 iid_document, String imd5)
        {
            List<doc_file> entity_list = new List<doc_file>();

            DataTable tbl_entity = TableByName("vdoc_file");


            NpgsqlCommandKey cmdk;


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


            cmdk.Parameters["iid_document"].Value = iid_document;
            cmdk.Parameters["imd5"].Value = imd5;

            cmdk.Fill(tbl_entity);

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

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_file_by_md5(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


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


        /// <summary>
        /// Метод извлекает из каталога двоичные данные файла документа
        /// </summary>
        public Byte[] doc_file_data_by_id(Int64 iid_doc_file, eSizeTransferPage isizepage)
        {
            doc_file doc_file = null;
            Byte[] Result = null;

            NpgsqlCommandKey cmdk;
            NpgsqlCommandKey cmdk_next;
            //**********

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
    }
}
