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
    public class PlanRangeLinkChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PlanRangeLinkChangeEventArgs(plan_range_link Plan_range_link, eAction Action) : base()
        {
            action = Action;
            if (Plan_range_link != null)
            {
                plan_range_link = Plan_range_link;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        plan_range_link plan_range_link;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action;}
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public plan_range_link Plan_range_link { get => plan_range_link; }
        #endregion
    }
}
