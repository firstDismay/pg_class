using System;
using System.Collections.Generic;
using System.Data;
using pg_class;


namespace pg_class.pg_classes
{
	/// <summary>
	/// Класс глобальных свойств концепции
	/// </summary>
	public partial class global_prop
	{
        /// <summary>
        /// Метод возвращает список методов сложного поиска по идентификатору свойства
        /// class_search_method_by_id_global_prop
        /// </summary>
        public List<SearchMetodObject> search_method_list_get()
        {
            return Manager.class_prop_search_method_by_id_global_prop3(id);
        }
    }
}
