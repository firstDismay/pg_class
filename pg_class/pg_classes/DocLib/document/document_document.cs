using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial class document
    {
        #region МЕТОДЫ РАБОТЫ С ДОКУМЕНТАМИ

        #region ДОБАВИТЬ
        /// <summary>
        /// Метод добавляет новый документ в пакет текущего документа
        /// </summary>
        public document document_add(Int64 iid_category, String iname, String idesc, String iregnum, DateTime iregdate)
        {
            return Manager.document_add(iid_category, iname, idesc, iregnum, iregdate, this);
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
        List<document> document_list;
        /// <summary>
        /// Лист документов по идентификатору документа
        /// </summary>
        public List<document> document_list_get(Boolean DirectRequest = true)
        {
            if (DirectRequest || document_list == null)
            {
                return Manager.document_by_id_parent(Id);
            }
            return document_list;
        }
        #endregion
        #endregion
    }
}
