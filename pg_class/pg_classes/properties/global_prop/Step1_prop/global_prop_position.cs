using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс глобальных свойств концепции
    /// </summary>
    public partial class global_prop
    {
        #region ВЫБРАТЬ
        /// <summary>
        /// Лист позиций использующих глобальное свойство
        /// position_by_id_global_prop
        /// </summary>
        public List<position> Position_using_list_get(Boolean Extended = false)
        {
            return Manager.position_by_id_global_prop(this); ;
        }
        #endregion
    }
}
