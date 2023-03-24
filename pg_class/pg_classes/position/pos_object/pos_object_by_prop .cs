using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class position
    {
        #region МЕТОДЫ ДЛЯ РАБОТЫ С ОБЪЕКТАМИ
        /// <summary>
        ///  Лист объектов указанной позиции по маске значения глобального свойства
        /// object_by_array_prop
        /// </summary>
        public List<object_general> Object_by_prop(PropSearchСondition prop_search_condition, Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_prop(prop_search_condition, Id);
            }
            else
            {
                Result = Manager.object_by_prop(prop_search_condition, Id);
            }
            return Result;
        }
        #endregion
    }
}
