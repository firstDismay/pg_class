using System;
using System.Collections.Generic;

namespace pg_class.pg_classes.calendar
{
    /// <summary>
    /// Класс планов 
    /// </summary>
    public partial class plan
    {
        #region МЕТОДЫ РАБОТЫ СО ССылками ПЛАНА

        #region ДОБАВИТЬ
        /// <summary>
        /// Метод добавляет новую ссылку плана
        /// </summary>
        public plan_link plan_link_add(Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            return Manager.plan_link_add(Id, iid_entity, iid_entity_instance, iid_sub_entity_instance);
        }
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет указанную ссылку плана
        /// </summary>
        public void plan_link_del(Int64 iid_plan_link)
        {
            Manager.plan_link_del(Id, iid_plan_link);
        }

        /// <summary>
        /// Метод удаляет указанную ссылку плана
        /// </summary>
        public void plan_link_del(plan_link Plan_link)
        {
            Manager.plan_link_del(Id, Plan_link.Id);
        }
        #endregion

        #region ВЫБРАТЬ

        List<plan_link> plan_link_list;
        /// <summary>
        /// Лист ссылок плана по идентификатору плана
        /// </summary>
        public List<plan_link> plan_link_by_id_plan(Boolean DirectRequest = true)
        {
            if (DirectRequest || plan_link_list == null)
            {
                plan_link_list = Manager.plan_link_by_id_plan(Id);
            }
            return plan_link_list;
        }
        #endregion
        #endregion
    }
}
