using pg_class.pg_classes.calendar;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения сущности
    /// </summary>
    public class PlanLinkChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PlanLinkChangeEventArgs(plan_link Plan_link, eAction Action) : base()
        {
            action = Action;
            if (Plan_link != null)
            {
                plan_link = Plan_link;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        plan_link plan_link;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public plan_link Plan_link { get => plan_link; }
        #endregion
    }
}
