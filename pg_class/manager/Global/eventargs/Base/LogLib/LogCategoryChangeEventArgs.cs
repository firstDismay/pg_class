using pg_class.pg_classes;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения категории записей журнала
    /// </summary>
    public class LogCategoryChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public LogCategoryChangeEventArgs(log_category LogCategory, eAction Action) : base()
        {
            action = Action;
            if (LogCategory != null)
            {
                log_category = LogCategory;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        log_category log_category;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public log_category LogCategory { get => log_category; }
        #endregion
    }
}
