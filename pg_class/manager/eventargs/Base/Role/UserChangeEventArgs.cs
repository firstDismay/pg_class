using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_classes;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения пользователя
    /// </summary>
    public class UserChangeEventArgs:EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public UserChangeEventArgs(user User, eAction Action) : base()
        {
            action = Action;
            user = User;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        user user;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action;}
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public user User { get => user;}
        #endregion
    }
}
