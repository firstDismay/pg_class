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
    public class PlanRangeChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PlanRangeChangeEventArgs(plan_range Plan_range, eAction Action) : base()
        {
            action = Action;
            if (Plan_range != null)
            {
                plan_range = Plan_range;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        plan_range plan_range;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action;}
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public plan_range Plan_range { get => plan_range; }
        #endregion
    }
}
