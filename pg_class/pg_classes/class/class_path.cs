using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial  class vclass
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ПУТЯМИ ПРЕДСТАВЛЕНИЙ КЛАССОВ

        /// <summary>
        /// Свойство возвращает лист групп отсортированных в виде пути
        /// </summary>
        public List<group_path> Path_group_get()
        {

            return Manager.group_path_by_id_group(id_group);

        }

        /// <summary>
        /// Свойство возвращает лист фрагментов пути представлений классов отсортированных от корня
        /// active/history
        /// </summary>
        public List<class_path> Path_class_get()
        {
            if (StorageType == eStorageType.Active)
            {
                return Manager.class_act_path_by_id_class(this);
            }
            else
            {
                return Manager.class_snapshot_path_by_id_class(this);
            }
        }
        String path;
        /// <summary>
        /// Свойство возвращает строковое представление фрагментов пути класса
        /// active/history
        /// </summary>
        public String Path
        {
            get
            {
                return path;
            } 
        }
        #endregion

    }
}
