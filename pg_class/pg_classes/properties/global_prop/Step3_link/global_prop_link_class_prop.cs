using System.Collections.Generic;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс глобальных свойств концепции
    /// </summary>
    public partial class global_prop
    {
        #region МЕТОДЫ РАБОТЫ  СО СПИСКОМ СВОЙСТВ КЛАССА
        #region ВКЛЮЧИТЬ

        /// <summary>
        /// Метод добавляет свойство класса к глобальному свойству
        /// global_prop_link_class_prop_include
        /// </summary>
        public global_prop_link_class_prop Link_class_prop_include(class_prop ClassProp)
        {
            return Manager.global_prop_link_class_prop_include(this, ClassProp);
        }
        #endregion

        #region ИСКЛЮЧИТЬ
        /// <summary>
        /// Метод удаляет свойство класса из глобального свойства
        /// global_prop_link_class_prop_exclude
        /// </summary>
        public global_prop_link_class_prop Link_class_prop_exclude(class_prop ClassProp)
        {
            return Manager.global_prop_link_class_prop_exclude(ClassProp);
        }
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Лист ссылок глобального свойства на свойства классов по идентификатору глобального свойства
        /// global_prop_link_class_prop_by_id_global_prop
        /// </summary>
        public List<global_prop_link_class_prop> Link_class_prop_list_get()
        {
            return Manager.global_prop_link_class_prop_by_id_global_prop(this);
        }
        #endregion
        #endregion
    }
}
