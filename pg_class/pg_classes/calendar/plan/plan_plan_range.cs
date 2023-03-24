using NpgsqlTypes;
using System;
using System.Collections.Generic;

namespace pg_class.pg_classes.calendar
{
    /// <summary>
    /// Класс планов 
    /// </summary>
    public partial class plan
    {

        #region МЕТОДЫ РАБОТЫ С ПЛАНОВЫМИ ДИАПАЗОНАМИ

        #region ДОБАВИТЬ
        /// <summary>
        /// Метод добавляет новый плановый диапазон
        /// </summary>
        public plan_range plan_range_add(NpgsqlRange<DateTime> irange_plan)
        {
            return Manager.plan_range_add(Id, irange_plan);
        }
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет плановый диапазон
        /// </summary>
        public void plan_range_del(Int64 iid)
        {
            Manager.plan_range_del(iid);
        }

        /// <summary>
        /// Метод удаляет плановый диапазон
        /// </summary>
        public void plan_range_del(plan_range Plan_range)
        {
            Manager.plan_range_del(Plan_range.Id);
        }
        #endregion

        #region ВЫБРАТЬ

        List<plan_range> plan_range_list;
        /// <summary>
        /// Лист плановых диапазонов
        /// </summary>
        public List<plan_range> plan_range_list_get(Boolean DirectRequest = true)
        {
            if (DirectRequest || plan_range_list == null)
            {
                plan_range_list = Manager.plan_range_by_id_plan(Id);
            }
            return plan_range_list;
        }
        #endregion
        #endregion

    }
}
