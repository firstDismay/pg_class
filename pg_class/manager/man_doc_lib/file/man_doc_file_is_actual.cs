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

            cmdk.Fill(tbl_entity);
            
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

        //ACCESS
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
    }
}
