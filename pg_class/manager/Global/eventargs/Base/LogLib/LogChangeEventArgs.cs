using pg_class.pg_classes;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения записи журнала
    /// </summary>
    public class LogChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public LogChangeEventArgs(log Log, eAction Action) : base()
        {
            action = Action;
            if (Log != null)
            {
                log = Log;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        log log;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public log Log { get => log; }
        #endregion
    }
}
