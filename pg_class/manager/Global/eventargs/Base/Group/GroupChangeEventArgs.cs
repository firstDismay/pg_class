using pg_class.pg_classes;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения группы
    /// </summary>
    public class GroupChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public GroupChangeEventArgs(group Group, eAction Action) : base()
        {
            action = Action;
            if (Group != null)
            {
                group = Group;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        group group;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public group Group { get => group; }
        #endregion
    }
}
