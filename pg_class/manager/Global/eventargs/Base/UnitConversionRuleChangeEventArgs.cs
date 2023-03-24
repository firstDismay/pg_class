using pg_class.pg_classes;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения правил пересчета колличества объектов
    /// </summary>
    public class UnitConversionRuleChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public UnitConversionRuleChangeEventArgs(Int32 IdUnitConversionRule, eAction Action) : base()
        {
            action = Action;
            idunitconversionrule = IdUnitConversionRule;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        Int32 idunitconversionrule;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Идентификатор объекта подвергшийся модификации
        /// </summary>
        public Int32 IdUnitConversionRule { get => idunitconversionrule; }

        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public unit_conversion_rule UnitConversionRule
        {
            get
            {
                return Manager.unit_conversion_rule_by_id(idunitconversionrule);
            }
        }



        /// <summary>
        /// Ссылка на менеджера данных
        /// </summary>
        private manager Manager
        {
            get
            {
                return manager.Instance();
            }
        }
        #endregion
    }
}
