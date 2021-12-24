using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс глобальных свойств концепции
    /// </summary>
    public partial class global_prop
    {
        #region МЕТОДЫ РАБОТЫ  СО СПИСКОМ СВОЙСТВ ШАБЛОНА
        #region ВКЛЮЧИТЬ

        /// <summary>
        /// Метод добавляет свойство шаблона к глобальному свойству
        /// global_prop_link_pos_temp_prop_include
        /// </summary>
        public global_prop_link_pos_temp_prop Link_pos_temp_prop_include(pos_temp_prop PosTemmpProp)
        {
            return Manager.global_prop_link_pos_temp_prop_include(this, PosTemmpProp);
        }
        #endregion

        #region ИСКЛЮЧИТЬ
        /// <summary>
        /// Метод удаляет свойство шаблона из глобального свойства
        /// global_prop_link_class_prop_exclude
        /// </summary>
        public global_prop_link_pos_temp_prop Link_pos_temp_prop_exclude(pos_temp_prop PosTemmpProp)
        {
            return Manager.global_prop_link_pos_temp_prop_exclude(this, PosTemmpProp);
        }
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Лист ссылок глобального свойства на свойства классов по идентификатору глобального свойства
        /// global_prop_link_pos_temp_prop_by_id_global_prop
        /// </summary>
        public List<global_prop_link_pos_temp_prop> Link_pos_temp_prop_list_get()
        {
            return Manager.global_prop_link_pos_temp_prop_by_id_global_prop(this);
        }
        #endregion
        #endregion
    }
}
