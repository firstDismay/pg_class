using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class position
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ПУТЯМИ ПОЗИЦИЙ

        /// <summary>
        /// Свойство возвращает лист позиций отсортированных в виде пути
        /// </summary>
        public List<pos_path> Path_position_get()
        {
            return Manager.position_path_by_id_position(this);
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
