using pg_class.pg_classes;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения элемента перечисления для свойств
    /// </summary>
    public class PropEnumValChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PropEnumValChangeEventArgs(prop_enum_val Prop_enum_val, eAction Action) : base()
        {
            action = Action;
            prop_enum_val = Prop_enum_val;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        prop_enum_val prop_enum_val;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public prop_enum_val PropEnumVal { get => prop_enum_val; }
        #endregion
    }
}
