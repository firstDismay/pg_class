using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс измеряемой величины
    /// </summary>
    public partial class unit_conception
    {
        #region МЕТОДЫ КЛАССА

        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет правило пересчета единиц измерения колличества объектов
        /// </summary>
        public unit_conversion_rule unit_conversion_rule_add(String icunit, Decimal imc, Boolean ion_single, Int32 iround, String idesc)
        {
            return Manager.unit_conversion_rule_add(id_conception, base.Id, icunit, imc, ion_single, iround, idesc);
        }
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет правило пересчета единиц измерения колличества объектов
        /// </summary>
        public void unit_conversion_rule_del(unit_conversion_rule Rule)
        {
            Manager.unit_conversion_rule_del(Rule.Id);
        }

        /// <summary>
        /// Метод удаляет правило пересчета единиц измерения колличества объектов
        /// </summary>
        public void unit_conversion_rule_del(Int32 Id_Rule)
        {
            Manager.unit_conversion_rule_del(Id_Rule);
        }
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Лист правил пересчета для текущей измеряемой величины
        /// </summary>
        public List<unit_conversion_rule> Get_unit_conversion_rule_list()
        {
            return Manager.unit_conversion_rule_by_id_unit(id_conception, this);
        }

        /// <summary>
        /// Базовое правило пересчета для текущей измеряемой величины
        /// </summary>
        public unit_conversion_rule Get_Base_unit_conversion_rule()
        {
            return Manager.unit_conversion_rule_base_by_id_unit(id_conception, this);
        }
        #endregion
        #endregion
    }
}
