using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_exceptions;

namespace pg_class.pg_classes
{
    public partial class vclass
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С НАСЛЕДУЮЩИМИ ПРЕДСТАВЛЕНИЯМИ КЛАССОВ

        /// <summary>
        /// Лист снимков класса, без учета активного представления класса
        /// </summary>
        public List<vclass> Class_snapshot_list_get()
        {
            return manager.Instance().class_snapshot_by_id_class(this);
        }

        /// <summary>
        /// Лист снимков класса, с учетом активного представления класса
        /// </summary>
        public List<vclass> Class_snapshot_full_list_get()
        {
            return manager.Instance().class_snapshot_full_by_id_class(this);
        }
        #endregion
    }
}
