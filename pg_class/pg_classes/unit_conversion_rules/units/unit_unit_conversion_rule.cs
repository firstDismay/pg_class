using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс измеряемой величины
    /// </summary>
    public partial class unit
    {
        #region МЕТОДЫ КЛАССА

        /// <summary>
        /// Лист правил пересчета для текущей измеряемой величины
        /// </summary>
        public List<unit_conversion_rule> Unit_conversion_rule_list(Int64 id_conception)
        {
            return Manager.unit_conversion_rule_by_id_unit(id_conception, this);
        }

        /// <summary>
        /// Базовое правило пересчета для текущей измеряемой величины
        /// </summary>
        public unit_conversion_rule Get_Base_unit_conversion_rule(Int64 id_conception)
        {
            return Manager.unit_conversion_rule_base_by_id_unit(id_conception, this);
        }

        #endregion
    }
}
