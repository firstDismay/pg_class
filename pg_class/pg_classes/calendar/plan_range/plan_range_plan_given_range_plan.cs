using NpgsqlTypes;
using System;
using System.Collections.Generic;

namespace pg_class.pg_classes.calendar
{
    /// <summary>
    /// Класс плановых  диапазонов
    /// </summary>
    public partial class plan_range
    {
        #region МЕТОДЫ РАБОТЫ С ВЫДЕЛЕННЫМИ ДИАПАЗОНАМИ ПЛАНОВОГО ДИАПАЗОНА

        #region ДОБАВИТЬ
        /// <summary>
        /// Метод добавляет новый выделенный диапазон планового диапазона
        /// </summary>
        public plan_given_range_plan plan_given_range_plan_add(NpgsqlRange<DateTime> irange_plan)
        {
            return Manager.plan_given_range_plan_add(Id_plan, Id, irange_plan);
        }
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет выделенный диапазон планового диапазона
        /// </summary>
        public void plan_given_range_plan_del(Int64 iid)
        {
            Manager.plan_given_range_plan_del(iid);
        }

        /// <summary>
        /// Метод удаляет выделенный диапазон планового диапазона
        /// </summary>
        public void plan_given_range_plan_del(plan_given_range_plan plan_given_range_plan)
        {
            Manager.plan_given_range_plan_del(plan_given_range_plan.Id);
        }
        #endregion

        #region ВЫБРАТЬ

        List<plan_given_range_plan> plan_given_range_plan_list;
        /// <summary>
        /// Лист плановых диапазонов
        /// </summary>
        public List<plan_given_range_plan> plan_given_range_plan_list_get(Boolean DirectRequest = true)
        {
            if (DirectRequest || plan_given_range_plan_list == null)
            {
                plan_given_range_plan_list = Manager.plan_given_range_plan_by_id_plan_range(Id);
            }
            return plan_given_range_plan_list;
        }
        #endregion
        #endregion

    }
}
