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
    public class PlanChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PlanChangeEventArgs(plan Plan, eAction Action) : base()
        {
            action = Action;
            if (Plan != null)
            {
                plan = Plan;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        plan plan;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action;}
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public plan Plan { get => plan; }
        #endregion
    }
}
