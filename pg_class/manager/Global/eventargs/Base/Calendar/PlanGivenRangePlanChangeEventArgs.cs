using pg_class.pg_classes.calendar;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения сущности
    /// </summary>
    public class PlanGivenRangePlanChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PlanGivenRangePlanChangeEventArgs(plan_given_range_plan Plan_given_range_plan, eAction Action) : base()
        {
            action = Action;
            if (Plan_given_range_plan != null)
            {
                plan_given_range_plan = Plan_given_range_plan;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        plan_given_range_plan plan_given_range_plan;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public plan_given_range_plan Plan_given_range_plan { get => plan_given_range_plan; }
        #endregion
    }
}
