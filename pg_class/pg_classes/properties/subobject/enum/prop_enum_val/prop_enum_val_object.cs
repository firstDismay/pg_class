using System.Collections.Generic;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс элементов перечислений для свойств типа перечисление
    /// </summary>
    public partial class prop_enum_val
    {
        /// <summary>
        /// Лист объектов по идентификатору перечисления
        /// object_by_id_prop_enum
        /// </summary>
        public List<object_general> Object_get()
        {
            return Manager.object_by_id_prop_enum_val(this);
        }
    }
}
