using pg_class.pg_classes;
using System;
namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения свойств позиций
    /// </summary>
    public class PositionPropChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PositionPropChangeEventArgs(position_prop PosProp, eAction Action) : base()
        {
            action = Action;
            if (PosProp != null)
            {
                position_prop = PosProp;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        position_prop position_prop;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public position_prop PosProp { get => position_prop; }
        #endregion
    }
}
