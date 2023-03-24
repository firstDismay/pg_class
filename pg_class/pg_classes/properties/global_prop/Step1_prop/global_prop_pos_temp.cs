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
        /// Лист шаблонов позиций использующих глобальное свойство
        /// </summary>
        public List<pos_temp> Pos_temp_using_list_get(Boolean Extended = false)
        {
            return Manager.pos_temp_by_id_global_prop(this); ;
        }
        #endregion
    }
}
