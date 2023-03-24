using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс обобщенного представления объектов
    /// </summary>
    public partial class object_general
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ПРАВИЛАМИ ПЕРЕСЧЕТА ОБЪЕКТОВ

        /// <summary>
        /// Лист доступных правил пересчета объектов вещественного класса сформированный с учетом правил назначения
        /// </summary>
        public List<unit_conversion_rule> Unit_conversion_rule_list
        {
            get
            {
                return Manager.unit_conversion_rule_by_id_object(this);
            }
        }

        /// <summary>
        /// Идентификатор правила пересчета количество объекта в базовые единицы
        /// </summary>
        public Int32 Id_unit_conversion_rule
        {
            get
            {
                return id_unit_conversion_rule;
            }
        }

        /// <summary>
        /// Правило пересчета 
        /// </summary>
        public unit_conversion_rule Unit_conversion_rule
        {
            get
            {
                return Manager.unit_conversion_rule_by_id(id_unit_conversion_rule);
            }
            set
            {
                id_unit_conversion_rule = value.Id;
                mc = value.Mc;
                cunit = value.Cunit;
                //Проверка значения осуществляеться на сервере.
                cquantity = bquantity / value.Mc;
                on_change = true;
            }
        }

        /// <summary>
        /// Идентификатор измеряемой величины объекта
        /// </summary>
        public Int32 Id_unit
        {
            get
            {
                return id_unit;
            }
        }

        /// <summary>
        /// Перечисление измеряемой величины
        /// </summary>
        public eUnit Unit { get => (eUnit)id_unit; }


        /// <summary>
        /// Базовые единицы измерения объекта
        /// </summary>
        public String Unit_base { get => bunit; }

        /// <summary>
        /// Установленные единицы измерения объекта
        /// </summary>
        public String Unit_curent { get => cunit; }
        #endregion

        #region МЕТОДЫ ДЛЯ РАБОТЫ С ПРАВИЛАМИ ПЕРЕСЧЕТА ОБЪЕКТОВ
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
