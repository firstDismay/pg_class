using System;

namespace pg_class.pg_classes
{
    public partial class position
    {
        #region МЕТОДЫ РАБОТЫ СО ЗНАЧЕНИЯМИ ПОЛЬЗОВАТЕЛЬСКИХ СВОЙСТВ ОБЪЕКТОВ УКАЗАННЫХ СНИМКА И ПОЗИЦИИ
        #region ДОБАВИТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Метод добавляет новое значение пользовательских свойств объектам позиции указанного снимка класса
        /// </summary>
        public void object_prop_user_val_objects_set(class_prop_user_val ClassPropUserVal, Boolean on_internal = false)
        {
            Manager.objects_prop_user_val_objects_set(this, ClassPropUserVal, on_internal);
        }
        #endregion

        #region УДАЛИТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Метод удаляет значение пользовательских свойств объектам позиции указанного снимка класса
        /// </summary>
        public void object_prop_user_val_objects_del(class_prop_user_val Class_prop_user_val, Boolean on_internal = false)
        {
            Manager.object_prop_user_val_objects_del(this, Class_prop_user_val, on_internal);
        }

        /// <summary>
        /// Метод удаляет значение пользовательских свойств объектам позиции указанного снимка класса
        /// </summary>
        public void object_prop_user_val_objects_del(class_prop Class_prop, Boolean on_internal = false)
        {
            Manager.object_prop_user_val_objects_del(this, Class_prop, on_internal);
        }
        #endregion
        #endregion
    }
}
