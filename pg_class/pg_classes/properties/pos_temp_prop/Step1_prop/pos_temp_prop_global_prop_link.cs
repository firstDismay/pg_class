using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Модуль взаимодействия сущности и ссылки на документ
    /// </summary>
    public partial class pos_temp_prop
    {
        /// <summary>
        /// Метод добавляет ссылку на глобальное свойство
        /// </summary>
        public void global_prop_link_include(long Id_global_prop)
        {
            Manager.global_prop_link_pos_temp_prop_include(Id_global_prop, this.Id);
        }

        /// <summary>
        /// Метод удаляет ссылку на глобальное свойство
        /// </summary>
        public void global_prop_link_exclude()
        {
            Manager.global_prop_link_pos_temp_prop_exclude(this.Id);
        }

        /// <summary>
        /// Глобальное свойство связанное со свойством шаблона
        /// global_prop_by_id_pos_temp_prop
        /// </summary>
        public global_prop global_prop_get()
        {
            return Manager.global_prop_by_id_pos_temp_prop(this);
        }
    }
}
