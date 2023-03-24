using System.Collections.Generic;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс перечислений для свойств типа перечисление
    /// </summary>
    public partial class con_prop_data_type
    {
        /// <summary>
        /// Лист шаблонов по идентификатору данных свойства концепции
        /// pos_temp_by_id_prop_data_type
        /// </summary>
        public List<pos_temp> Pos_temp_using_list_get()
        {
            return Manager.pos_temp_by_id_prop_data_type(this);
        }
    }
}
