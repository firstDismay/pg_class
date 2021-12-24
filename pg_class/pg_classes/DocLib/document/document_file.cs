using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Data;
using System.Security.Cryptography;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс документов 
    /// </summary>
    public partial class document
    {
        #region МЕТОДЫ ДЛЯ РАБОТЫ С ФАЙЛАМИ ДОКУМЕНТА
        #region ДОБАВИТЬ
        /// <summary>
        /// Метод добавляет новый файл документа
        /// </summary>
        public doc_file doc_file_add(String ifilename, String iversion, DateTime iversiondate, String iextension, Byte[] file_data, Boolean ifulltxtsrch_on, eSizeTransferPage isizepage = eSizeTransferPage.Size200Mb)
        {
            return Manager.doc_file_add(id, ifilename, iversion, iversiondate, iextension, file_data, ifulltxtsrch_on, isizepage);
        }

        /// <summary>
        /// Метод добавляет новый файл документа
        /// </summary>
        public doc_file doc_file_add(String iversion, DateTime iversiondate, String Path, Boolean ifulltxtsrch_on, eSizeTransferPage isizepage = eSizeTransferPage.Size200Mb)
        {
            return Manager.doc_file_add(id, iversion, iversiondate, Path, ifulltxtsrch_on, isizepage);
        }
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет указанный файл документа
        /// </summary>
        public void doc_file_del(Int64 iid_doc_file)
        {
            Manager.doc_file_del(iid_doc_file);
        }

        /// <summary>
        /// Метод удаляет указанный файл документа
        /// </summary>
        public void doc_file_del(doc_file Doc_file)
        {
            Manager.doc_file_del(Doc_file.Id);
        }
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Лист файлов документа по идентификатору документа
        /// </summary>
        public List<doc_file> doc_file_list_get(Boolean DirectRequest = true)
        {
            if (DirectRequest || doc_file_list == null)
            {
                doc_file_list = Manager.doc_file_by_id_document(Id);
            }
            return doc_file_list;
        }
        #endregion

        #region СОХРАНИПТЬ ФАЙЛЫ ДОКУМЕНТА
        /// <summary>
        /// Метод извлекает из каталога двоичные данные файла документа и сохраняет их в указанный каталог
        /// </summary>
        public Boolean doc_file_data_save(String Path, eSizeTransferPage isizepage)
        {
            Boolean Result = false;
            List<doc_file> file_list = doc_file_list_get();

            if (file_list.Count > 0)
            {
                foreach (doc_file f in file_list)
                {
                    f.doc_file_save(Path, isizepage);
                }
                Result = true;
            }
            return Result;
        }
        #endregion
        #endregion
    }
}
