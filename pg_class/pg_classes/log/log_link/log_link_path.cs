using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class log_link
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ПУТЯМИ ПОЗИЦИЙ
        string path;
        /// <summary>
        /// Свойство возвращает строковое представление фрагментов пути позиции
        /// active/history
        /// </summary>
        public String Path()
        {
            return path;
        }
        #endregion
    }
}