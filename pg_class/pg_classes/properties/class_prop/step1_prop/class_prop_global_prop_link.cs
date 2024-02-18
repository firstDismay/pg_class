using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Модуль взаимодействия с глобальными свойствами
    /// </summary>
    public partial class class_prop
    {
        /// <summary>
        /// Метод добавляет ссылку на глобальное свойство
        /// </summary>
        public void global_prop_link_include(long Id_global_prop)
        {
            Manager.global_prop_link_class_prop_include(Id_global_prop, this.Id_prop_definition);
        }

        /// <summary>
        /// Метод удаляет ссылку на глобальное свойство
        /// </summary>
        public void global_prop_link_exclude()
        {
            Manager.global_prop_link_class_prop_exclude(this.Id_prop_definition);
        }

        /// <summary>
        /// Глобальное свойство связанное со свойством класса
        /// global_prop_by_id_class_prop_definition
        /// </summary>
        public global_prop global_prop_get()
        {
            return Manager.global_prop_by_id_class_prop_definition(this);
        }

        /// <summary>
        /// Метод определяет готовность свойства к линковке с глобальными свойствами
        /// </summary>
        public ePropStateForGlobalPropLink State_for_global_prop_link()
        {
            return Manager.class_prop_state_for_global_prop_link(this);
        }
    }
}
