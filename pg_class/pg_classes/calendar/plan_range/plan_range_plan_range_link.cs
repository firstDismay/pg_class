using System;
using System.Collections.Generic;

namespace pg_class.pg_classes.calendar
{
    /// <summary>
    /// Класс планов 
    /// </summary>
    public partial class plan_range
    {
        #region МЕТОДЫ РАБОТЫ СО ССЫЛКАМИ ПЛАНОВОГО ДИАПАЗОНА

        #region ДОБАВИТЬ
        /// <summary>
        /// Метод добавляет новую ссылку планового диапазона
        /// </summary>
        public plan_range_link plan_range_link_add(Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            return Manager.plan_range_link_add(Id, iid_entity, iid_entity_instance, iid_sub_entity_instance);
        }
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет указанную ссылку планового диапазона
        /// </summary>
        public void plan_range_link_del(Int64 iid_plan_range_link)
        {
            Manager.plan_range_link_del(Id, iid_plan_range_link);
        }

        /// <summary>
        /// Метод удаляет указанную ссылку планового диапазона
        /// </summary>
        public void plan_range_link_del(plan_range_link plan_range_link)
        {
            Manager.plan_range_link_del(Id, plan_range_link.Id);
        }
        #endregion

        #region ВЫБРАТЬ

        List<plan_range_link> plan_range_link_list;
        /// <summary>
        /// Лист ссылок планового диапазона
        /// </summary>
        public List<plan_range_link> plan_range_link_by_id_plan_range(Boolean DirectRequest = true)
        {
            if (DirectRequest || plan_range_link_list == null)
            {
                plan_range_link_list = Manager.plan_range_link_by_id_plan_range(Id);
            }
            return plan_range_link_list;
        }
        #endregion
        #endregion
    }
}
