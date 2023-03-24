using pg_class.pg_classes;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения позиций
    /// </summary>
    public class PositionChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PositionChangeEventArgs(position Position, eAction Action) : base()
        {
            action = Action;
            if (Position != null)
            {
                position = Position;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        position position;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public position Position { get => position; }
        #endregion
    }
}
