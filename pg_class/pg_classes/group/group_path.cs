using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial  class group
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ПУТЯМИ ГРУПП
         
        /// <summary>
        /// Свойство возвращает лист групп отсортированных в виде пути
        /// </summary>
        public List<group_path> Path_group_get()
        {
            
            return Manager.group_path_by_id_group(this);
            
        }

        string path;
        /// <summary>
        /// Свойство возвращает строковое представление фрагментов пути группы
        /// active/history
        /// </summary>
        public String Path()
        {
            return path;
        }
        #endregion

    }
}
