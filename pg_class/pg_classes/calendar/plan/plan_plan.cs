using System;
using System.Collections.Generic;

namespace pg_class.pg_classes.calendar
{
    /// <summary>
    /// Класс планов 
    /// </summary>
    public partial class plan
    {

        #region МЕТОДЫ РАБОТЫ С ВЛОЖЕННЫМИ ПЛАНАМИ

        #region ДОБАВИТЬ
        /// <summary>
        /// Метод добавляет новый вложенный план
        /// </summary>
        public plan plan_add(String iname, String idesc, Boolean ion, Boolean ion_crossing, Int32 iplan_max, Int32 irange_max, Boolean ion_freeze)
        {
            return Manager.plan_add(Id_conception, Id, iname, idesc, ion, ion_crossing, iplan_max, irange_max, ion_freeze);
        }
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет указанный вложенный план
        /// </summary>
        public void plan_del(Int64 iid)
        {
            Manager.plan_del(iid);
        }

        /// <summary>
        /// Метод удаляет указанный вложенный план
        /// </summary>
        public void plan_del(plan Plan)
        {
            Manager.plan_del(Plan.Id);
        }
        
        #endregion

        #region ВЫБРАТЬ

        List<plan> plan_list;
        /// <summary>
        /// Лист вложенных планов
        /// </summary>
        public List<plan> plan_list_get(Boolean DirectRequest = true)
        {
            if (DirectRequest || plan_list == null)
            {
                plan_list = Manager.plan_by_id_parent(Id);
            }
            return plan_list;
        }
        #endregion
        #endregion

    }
}
