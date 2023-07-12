using System.Collections.Generic;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс шаблонов позиций
    /// </summary>
    public partial class conception
    {
        #region МЕТОДЫ ДЛЯ РАБОТЫ ЗАПИСЯМИ ЖУРНАЛА
        #region ВЫБРАТЬ
        /// <summary>
        /// Лист записей журнала
        /// </summary>
        public List<log> log_list_get()
        {
            return Manager.log_by_id_conception(this.Id);
        }
        #endregion
        #endregion
    }
}