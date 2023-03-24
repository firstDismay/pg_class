using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс записей журнала 
    /// </summary>
    public partial class log
    {
        #region МЕТОДЫ РАБОТЫ С ДОКУМЕНТАМИ

        #region ВЫБРАТЬ

        private log_category log_category;
        /// <summary>
        /// Категория записи журнала
        /// </summary>
        public log_category log_category_get(Boolean DirectRequest = true)
        {
            if (DirectRequest || log_category == null)
            {
                log_category = Manager.log_category_by_id(Id_category);
            }
            return log_category;
        }
        #endregion
        #endregion
    }
}