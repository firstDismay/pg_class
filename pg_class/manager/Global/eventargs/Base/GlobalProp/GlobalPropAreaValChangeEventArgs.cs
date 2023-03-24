using pg_class.pg_classes;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения сущности
    /// </summary>
    public class GlobalPropAreaValChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public GlobalPropAreaValChangeEventArgs(global_prop_area_val GlobalPropAreaVal, eAction Action) : base()
        {
            action = Action;
            if (GlobalPropAreaVal != null)
            {
                global_prop_area_val = GlobalPropAreaVal;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        global_prop_area_val global_prop_area_val;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Сущность подвергшаяся модификации
        /// </summary>
        public global_prop_area_val GlobalPropAreaVal { get => global_prop_area_val; }
        #endregion
    }
}
