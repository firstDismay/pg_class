using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class log
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ПУТЯМИ ПОЗИЦИЙ

        /// <summary>
        /// Свойство возвращает лист сущностей отсортированных в виде пути
        /// </summary>
        public List<pos_path> Path_log_get()
        {
            throw new NotImplementedException();
            //return Manager.log_path_by_id_log(this);
        }

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