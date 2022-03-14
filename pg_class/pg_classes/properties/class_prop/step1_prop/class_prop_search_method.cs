using System;
using System.Collections.Generic;
using System.Data;
using pg_class;


namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс свойств классов
    /// </summary>
    public partial class class_prop
    {
        /// <summary>
        /// Метод возвращает список методов сложного поиска по идентификатору свойства
        /// class_search_method_by_id_class_prop2
        /// </summary>
        public List<eSearchMethods> search_method_list_get()
        {
            return Manager.class_search_method_by_id_class_prop2(id);
        }
    }
}
