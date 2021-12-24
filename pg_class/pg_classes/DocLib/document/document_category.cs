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

        #region ВЫБРАТЬ
        /// <summary>
        /// Категория документа
        /// </summary>
        public doc_category category_get(Boolean DirectRequest = true)
        {
            if (DirectRequest || doc_category == null)
            {
                doc_category = Manager.doc_category_by_id(Id_category);
            }
            return doc_category;
        }
        //*************************************************************************************
        #endregion
        #endregion
    }
}