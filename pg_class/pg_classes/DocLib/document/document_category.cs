using System;

namespace pg_class.pg_classes
{
    public partial class document
    {
        #region МЕТОДЫ РАБОТЫ С ДОКУМЕНТАМИ

        #region ВЫБРАТЬ

        doc_category doc_category;
        /// <summary>
        /// Категория документа
        /// </summary>
        public doc_category doc_category_get(Boolean DirectRequest = true)
        {
            if (DirectRequest || doc_category == null)
            {
                doc_category = Manager.doc_category_by_id(Id_category);
            }
            return doc_category;
        }
        #endregion
        #endregion
    }
}