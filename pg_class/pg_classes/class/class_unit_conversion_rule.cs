using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class vclass
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ПРАВИЛАМИ ПЕРЕСЧЕТА КЛАССА

        /// <summary>
        /// Лист доступных правил пересчета объектов класса сформированный с учетом правил назначения для вещественных классов или полный для абстрактных
        /// </summary>
        public List<unit_conversion_rule> Unit_conversion_rule_list
        {
            get
            {
                List<unit_conversion_rule> Result = null;
                if (On_abstraction)
                {
                    Result = Manager.unit_conversion_rule_by_id_unit(Id_conception, Id_unit);
                }
                else
                {
                    Result = Manager.unit_conversion_rule_by_id_class(this);
                }
                return Result;
            }
        }

        /// <summary>
        /// Базовое правило пересчета вещественного класса назначенное по умолчанию для вновь создаваемых объектов
        /// </summary>
        public unit_conversion_rule Unit_conversion_rule_base
        {
            get
            {
                return Manager.unit_conversion_rule_base_by_id_unit(Id_conception, id_unit);
            }
        }
        #endregion

        #region МЕТОДЫ ДЛЯ РАБОТЫ С ПРАВИЛАМИ ПЕРЕСЧЕТА КЛАССА
        /// <summary>
        /// Измеряемая величина
        /// </summary>
        public unit Unit_get()
        {
            return Manager.units_by_id(id_unit);
        }
        #endregion
    }
}
