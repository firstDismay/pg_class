using pg_class.pg_classes;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения сущности
    /// </summary>
    public class PlanGivenRangeFactChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PlanGivenRangeFactChangeEventArgs(vclass Vclass, eAction Action) : base()
        {
            action = Action;
            if (Vclass != null)
            {
                vclass = Vclass;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        vclass vclass;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public vclass Vclass { get => vclass; }
        #endregion
    }
}
