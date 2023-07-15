﻿namespace pg_class.pg_classes
{
    public partial class position_prop
    {
        #region МЕТОДЫ РАБОТЫ СО ЗНАЧЕНИЯМИ ПОЛЬЗОВАТЕЛЬСКИХ СВОЙСТВ КЛАССА
        #region ДОБАВИТЬ ЗНАЧЕНИЕ

        /// <summary>
        /// Метод добавляет новое значение свойства-перечисления шаг №3
        /// </summary>
        public position_prop_enum_val enum_data_set(position_prop_enum_val PositionPropEnumVal)
        {
            return Manager.position_prop_enum_val_set(PositionPropEnumVal);
        }
        #endregion

        #region УДАЛИТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Метод удаляет значение свойства-перечисления шаг №3
        /// </summary>
        public void enum_data_del()
        {
            Manager.position_prop_enum_val_del(this);
        }
        #endregion

        #region ВЫБРАТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Метод выбирает данные значение свойства-перечисления шаг №3
        /// </summary>
        public position_prop_enum_val enum_data_get()
        {
            return Manager.position_prop_enum_val_by_id_prop(this);
        }
        #endregion
        #endregion

    }
}
