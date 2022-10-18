using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_classes;
using pg_class.pg_classes.calendar;

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
        public eAction Action { get => action;}
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public plan_given_range_plan_link Plan_given_range_plan_link { get => plan_given_range_plan_link; }
        #endregion
    }
}
