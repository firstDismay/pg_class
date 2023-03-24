using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения правил назначения методов пересчета колличества объектоввещественных классов
    /// </summary>
    public class ClassUnitConversionRuleChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public ClassUnitConversionRuleChangeEventArgs(Int64 Id_class, eAction Action) : base()
        {
            id_class = Id_class;
            action = Action;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        private eAction action;
        private Int64 id_class;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }

        /// <summary>
        /// Идентификатор класса правила назначения методов пересчета
        /// </summary>
        public Int64 Id_class { get => id_class; }

        #endregion
    }
}
