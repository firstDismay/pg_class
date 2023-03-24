using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class conception
    {
        #region МЕТОДЫ РАБОТЫ С КЛАССАМИ И СНИМКАМИ КЛАССОВ КОНЦЕПЦИИ
        /// <summary>
        /// Лист всех вещественных классов концепции
        /// class_full_real_by_id_conception
        /// </summary>
        public List<vclass> class_full_real_list_get()
        {
            return Manager.class_full_real_by_id_conception(this);
        }
        #endregion
    }
}
