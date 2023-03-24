using pg_class.pg_classes;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения данных свойства типа перечисление
    /// </summary>
    public class ClassPropEnumValChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public ClassPropEnumValChangeEventArgs(class_prop_enum_val Class_prop_enum_val, eAction Action) : base()
        {
            action = Action;
            if (Class_prop_enum_val != null)
            {
                class_prop_enum_val = Class_prop_enum_val;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        class_prop_enum_val class_prop_enum_val;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public class_prop_enum_val ClassPropEnumVal { get => class_prop_enum_val; }
        #endregion
    }
}
