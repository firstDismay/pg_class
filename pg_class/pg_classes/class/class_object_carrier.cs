using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class vclass
    {
        #region ВЫБРАТЬ ОБЪЕКТЫ КЛАССА
        /// <summary>
        /// Лист объектов носителей объектов вещественных классов (рекурсивный)
        /// </summary>
        public List<object_general> Object_carrier_object_class_list_full_get(Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_ext_carrier_by_object_class_recursive(this);
            }
            else
            {
                Result = Manager.object_carrier_by_object_class_recursive(this);
            }
            return Result;
        }
        #endregion
    }
}