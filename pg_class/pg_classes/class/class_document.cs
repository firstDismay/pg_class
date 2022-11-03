using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using pg_class.pg_exceptions;
using System.Data;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс шаблонов позиций
    /// </summary>
    public partial class vclass
    {
        #region МЕТОДЫ ДЛЯ РАБОТЫ С ДОКУМЕНТАМИ
        #region ДОБАВИТЬ [ФАЙЛ МАССИВ]

        /// <summary>
        /// Метод добавляет новый документ
        /// </summary>
        public document document_add(Int64 iid_category, Int64 iid_parent,
                                     String iname, String idesc, String iregnum, DateTime iregdate)
        {
            return Manager.document_add(iid_category, iid_parent,
                                     iname, idesc, iregnum, iregdate,
                                     this);
        }
        
        #endregion
        

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет указанный документ и все его файлы
        /// </summary>
        public void document_del(Int64 iid_document)
        {
            Manager.document_del(iid_document);
        }

        /// <summary>
        /// Метод удаляет указанный документ и все его файлы
        /// </summary>
        public void document_del(document Document)
        {
            Manager.document_del(Document.Id);
        }
        //*************************************************************************************
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Лист документов класса
        /// document_ext_by_id_class
        /// document_by_id_class
        /// </summary>
        public List<document> document_list_get(Boolean object_on, Boolean recursive_on, Boolean Extended = false)
        {
            List<document> Result = null;
            if (Extended)
            {
                Result = Manager.document_ext_by_id_class(this, object_on, recursive_on);
            }
            else
            {
                Result = Manager.document_by_id_class(this, object_on, recursive_on);
            }
            return Result;
        }
        #endregion

        #region СЛУЖЕБНЫЕ МЕТОДЫ БИБЛИОТЕКИ ДОКУМЕНТОВ
        /// <summary>
        /// Лист расширений файлов документов по идентификатору концепции
        /// </summary>
        public List<String> doc_file_extension_list_get()
        {
            return Manager.doc_file_extension_by_id_conception(Id_conception);
        }
        #endregion
#endregion
    }
}
