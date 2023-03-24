using System.Collections.Generic;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс перечислений для свойств типа перечисление
    /// </summary>
    public partial class con_prop_data_type
    {
        /// <summary>
        /// Лист позиций по идентификатору данных свойства концепции
        /// position_by_id_prop_data_type
        /// </summary>
        public List<position> Position_using_list_get()
        {
            return Manager.position_by_id_prop_data_type(this);
        }
    }
}
