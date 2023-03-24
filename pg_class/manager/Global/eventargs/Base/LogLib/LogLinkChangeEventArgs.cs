using pg_class.pg_classes;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения ссылки на запись журнала
    /// </summary>
    public class LogLinkChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public LogLinkChangeEventArgs(log_link Loglink, eAction Action) : base()
        {
            action = Action;
            if (Loglink != null)
            {
                log_link = Loglink;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        log_link log_link;


        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public log_link LogLink { get => log_link; }
        #endregion
    }
}
