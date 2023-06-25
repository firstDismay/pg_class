using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class conception
    {
        #region МЕТОДЫ РАБОТЫ С КАТЕГОРИЯМИ ДОКУМЕНТОВ

        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет новую категорию документов
        /// doc_category_add
        /// </summary>
        public doc_category doc_category_add(String iname, String idesc, Boolean ion_grouping, Boolean ion)
        {
            return Manager.doc_category_add(Id, iname, idesc, ion_grouping, ion);
        }
        //*************************************************************************************
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет указанную категорию документов
        /// </summary>
        public void doc_category_del(Int64 iid)
        {
            Manager.doc_category_del(iid);
        }

        /// <summary>
        /// Метод удаляет указанную категорию документов
        /// doc_category_del
        /// </summary>
        public void doc_category_del(doc_category Doc_category)
        {
            Manager.doc_category_del(Doc_category.Id);
        }
        //*************************************************************************************
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Лист категорий документов концепции по идентификатору концепции
        /// doc_category_by_id_conception
        /// </summary>
        public List<doc_category> doc_category_list_get()
        {
            return Manager.doc_category_by_id_conception(Id);
        }
        //*************************************************************************************

        /// <summary>
        /// Лист включенных категорий документов концепции по идентификатору концепции
        /// doc_category_by_id_conception
        /// </summary>
        public List<doc_category> doc_category_on_list_get()
        {
            return Manager.doc_category_on_by_id_conception(Id);
        }
        //*************************************************************************************
        #endregion
        #endregion
    }
}
