using pg_class.pg_classes;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения роли пользователя
    /// </summary>
    public class RoleUserChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public RoleUserChangeEventArgs(role_user RoleUser, eAction Action) : base()
        {
            action = Action;
            role_user = RoleUser;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        role_user role_user;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }

        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public role_user RoleUser { get => role_user; }
        #endregion
    }
}
