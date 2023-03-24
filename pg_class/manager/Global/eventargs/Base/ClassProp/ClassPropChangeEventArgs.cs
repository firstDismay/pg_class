using pg_class.pg_classes;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения сущности
    /// </summary>
    public class ClassPropChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public ClassPropChangeEventArgs(class_prop ClassProp, eAction Action) : base()
        {
            action = Action;
            if (ClassProp != null)
            {
                class_prop = ClassProp;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        class_prop class_prop;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public class_prop ClassProp { get => class_prop; }
        #endregion
    }
}
