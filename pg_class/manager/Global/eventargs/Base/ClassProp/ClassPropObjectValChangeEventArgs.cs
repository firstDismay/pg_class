using pg_class.pg_classes;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения значения объектного свойства класса
    /// </summary>
    public class ClassPropObjectValChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public ClassPropObjectValChangeEventArgs(class_prop_object_val ClassPropObjectVal, eAction Action) : base()
        {
            action = Action;
            if (ClassPropObjectVal != null)
            {
                class_prop_oject_val = ClassPropObjectVal;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        class_prop_object_val class_prop_oject_val;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public class_prop_object_val ClassPropObjectVal { get => class_prop_oject_val; }
        #endregion
    }
}
