using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial class conception
    {
        #region МЕТОДЫ РАБОТЫ С ПРАВИЛАМИ ПЕРЕСЧЕТА КОНЦЕПЦИИ

        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет правило пересчета единиц измерения колличества объектов
        /// unit_conversion_rule_add
        /// </summary>
        public unit_conversion_rule Unit_conversion_rule_add(Int32 iid_unit, String icunit, Decimal imc, Boolean ion_single, Int32 iround, String idesc)
        {
            return Manager.unit_conversion_rule_add(Id, iid_unit, icunit, imc, ion_single, iround, idesc);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Unit_conversion_rule_add(out eAccess Access)
        {
            return Manager.unit_conversion_rule_add(out Access);
        }
        //*************************************************************************************
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет правило пересчета единиц измерения колличества объектов
        /// unit_conversion_rule_del
        /// </summary>
        public void Unit_conversion_rule_del(unit_conversion_rule Rule)
        {
            Manager.unit_conversion_rule_del(Rule.Id);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Unit_conversion_rule_del(out eAccess Access)
        {
            return Manager.unit_conversion_rule_del(out Access);
        }
        //*************************************************************************************

        /// <summary>
        /// Метод удаляет правило пересчета единиц измерения колличества объектов
        /// unit_conversion_rule_del
        /// </summary>
        public void unit_conversion_rule_del(Int32 Id_Rule)
        {
            Manager.unit_conversion_rule_del(Id_Rule);
        }
        //*************************************************************************************
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Базовое правило пересчета по идентификатору измеряемой величины
        /// unit_conversion_rule_base_by_id_unit
        /// </summary>
        public unit_conversion_rule Get_unit_conversion_rule_base(Int32 iid_unit)
        {
            return Manager.unit_conversion_rule_base_by_id_unit(Id, iid_unit);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Get_unit_conversion_rule_base(out eAccess Access)
        {
            return Manager.unit_conversion_rule_base_by_id_unit(out Access);
        }
        //*************************************************************************************

        /// <summary>
        /// Базовое правило пересчета по идентификатору измеряемой величины
        /// unit_conversion_rule_base_by_id_unit
        /// </summary>
        public unit_conversion_rule Get_unit_conversion_rule_base(unit Unit)
        {
            return Manager.unit_conversion_rule_base_by_id_unit(Id, Unit);
        }

        /// <summary>
        /// Лист правил пересчета по идентификатору величины измерения
        /// unit_conversion_rule_by_id_unit
        /// </summary>
        public List<unit_conversion_rule> Get_unit_conversion_rules(Int32 iid_unit)
        {
            return Manager.unit_conversion_rule_by_id_unit(Id, iid_unit);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Get_unit_conversion_rules(out eAccess Access)
        {
            return Manager.unit_conversion_rule_by_id_unit(out Access);
        }
        //*************************************************************************************

        /// <summary>
        /// Лист правил пересчета по идентификатору величины измерения
        /// unit_conversion_rule_by_id_unit
        /// </summary>
        public List<unit_conversion_rule> Get_unit_conversion_rules(unit Unit)
        {
            return Manager.unit_conversion_rule_by_id_unit(Id, Unit);
        }
        //*************************************************************************************
        #endregion
        #endregion
    }
}
