using System.Collections.Generic;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс элементов перечислений для свойств типа перечисление
    /// </summary>
    public partial class prop_enum_val
    {
        /// <summary>
        /// Лист шаблонов позиций по идентификатору элемента перечисления
        /// pos_temp_by_id_prop_enum_val
        /// </summary>
        public List<pos_temp> Pos_temp_using_list_get()
        {
            return Manager.pos_temp_by_id_prop_enum_val(this);
        }
    }
}
