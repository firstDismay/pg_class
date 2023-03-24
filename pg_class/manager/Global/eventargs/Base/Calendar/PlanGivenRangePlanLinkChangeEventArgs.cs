using pg_class.pg_classes.calendar;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения сущности
    /// </summary>
    public class PlanGivenRangePlanLinkChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PlanGivenRangePlanLinkChangeEventArgs(plan_given_range_plan_link Plan_given_range_plan_link, eAction Action) : base()
        {
            action = Action;
            if (Plan_given_range_plan_link != null)
            {
                plan_given_range_plan_link = Plan_given_range_plan_link;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        plan_given_range_plan_link plan_given_range_plan_link;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public plan_given_range_plan_link Plan_given_range_plan_link { get => plan_given_range_plan_link; }
        #endregion
    }
}
