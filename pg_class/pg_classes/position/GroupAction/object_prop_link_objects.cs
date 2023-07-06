using System;

namespace pg_class.pg_classes
{
    public partial class position
    {
        #region МЕТОДЫ РАБОТЫ СО ЗНАЧЕНИЯМИ СВОЙСТВ ССЫЛОК ОБЪЕКТОВ УКАЗАННЫХ СНИМКА И ПОЗИЦИИ
        #region ДОБАВИТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Метод добавляет новое значение свойств ссылок объектам позиции указанного снимка класса
        /// </summary>
        public void object_prop_link_val_objects_set(class_prop_link_val Class_prop_link_val, Boolean on_internal = false)
        {
            Manager.object_prop_link_val_objects_set(this, Class_prop_link_val, on_internal);
        }
        #endregion

        #region УДАЛИТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Метод удаляет новое значение свойств ссылок объектам позиции указанного снимка класса
        /// </summary>
        public void object_prop_link_val_objects_del(class_prop_link_val Class_prop_link_val, Boolean on_internal = false)
        {
            Manager.object_prop_link_val_objects_del(this, Class_prop_link_val, on_internal);
        }

        /// <summary>
        /// Метод удаляет новое значение свойств ссылок объектам позиции указанного снимка класса
        /// </summary>
        public void object_prop_link_val_objects_del(class_prop Class_prop, Boolean on_internal = false)
        {
            Manager.object_prop_link_val_objects_del(this, Class_prop, on_internal);
        }
        #endregion
        #endregion

    }
}
