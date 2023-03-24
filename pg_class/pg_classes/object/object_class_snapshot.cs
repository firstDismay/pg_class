using System.Collections.Generic;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс обобщенного представления объектов
    /// </summary>
    public partial class object_general
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С НАСЛЕДУЮЩИМИ ПРЕДСТАВЛЕНИЯМИ КЛАССОВ

        /// <summary>
        /// Снимок класса, породившего объект
        /// </summary>
        public vclass Class_snapshot_get()
        {
            return manager.Instance().class_snapshot_by_id(this);
        }

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