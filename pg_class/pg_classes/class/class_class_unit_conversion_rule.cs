using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class vclass
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С НАЗНАЧЕНИЯМИ ПРАВИЛ ПЕРЕСЧЕТА КЛАССУ

        /// <summary>
        /// Лист правил назначения правил пересчета объектов активного представления вещественного класса
        /// </summary>
        public List<class_unit_conversion_rule> Class_Unit_conversion_rule_list
        {
            get
            {
                return Manager.class_unit_conversion_rules(this);
            }
        }

        /// <summary>
        /// Лист доступных правил назначения правил пересчета объектов класса
        /// </summary>
        public List<class_unit_conversion_rule> Class_Unit_conversion_rule_list_full
        {
            get
            {
                List<class_unit_conversion_rule> Result = null;

                if (On_abstraction)
                {
                    Result = Manager.class_unit_conversion_rules_by_unit(Id_unit);
                }
                else
                {
                    Result = Manager.class_unit_conversion_rules_full(this);
                }
                return Result;
            }
        }

        #endregion

        #region МЕТОДЫ РАБОТЫ СО СПИСКАМИ НАЗНАЧЕНИЙ ПРАВИЛ ПЕРЕСЧЕТА
        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет правило пересчета в список правил вещественного класса
        /// </summary>
        public void class_unit_conversion_rules_add(unit_conversion_rule Rule)
        {
            Manager.class_unit_conversion_rules_add(this, Rule);
            this.Refresh();
        }

        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет правило пересчета из списока правил вещественного класса
        /// </summary>
        public void class_unit_conversion_rules_del(unit_conversion_rule Rule)
        {
            Manager.class_unit_conversion_rules_del(this, Rule);
            this.Refresh();
        }
        #endregion
        #endregion
    }
}
