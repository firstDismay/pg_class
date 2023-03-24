using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class vclass
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ГЛОБАЛЬНЫМИ СВОЙСТВАМИ КЛАССА

        #region ВЫБРАТЬ
        /// <summary>
        /// Лист глобальных свойств класса
        /// global_prop_by_id_class
        /// </summary>
        public List<global_prop> Global_prop_list_get()
        {
            return Manager.global_prop_by_id_class(this);
        }
        #endregion
        #endregion
    }
}
