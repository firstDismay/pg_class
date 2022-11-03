using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_classes.calendar;

namespace pg_class.pg_classes
{
    public partial class conception
    {
        #region МЕТОДЫ РАБОТЫ С ПЛАНАМИ

        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет новый план
        /// </summary>
        public plan plan_add( Int64 iid_parent, String iname, String idesc, Boolean ion, Boolean ion_crossing, Int32 iplan_max, Int32 irange_max, Boolean ion_freeze)
        {
            return Manager.plan_add(Id, iid_parent, iname, idesc, ion, ion_crossing, iplan_max, irange_max, ion_freeze);
        }
        
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет план
        /// </summary>
        public void plan_del(Int64 iid)
        {
            Manager.plan_del(iid);
        }

        /// <summary>
        /// Метод удаляет план
        /// </summary>
        public void plan_del(plan Plan)
        {
            Manager.plan_del(Plan.Id);
        }
        //*************************************************************************************
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Лист планов по идентификатору концепции
        /// plan_by_id_conception
        /// </summary>
        public List<plan> plan_list_get()
        {
            return Manager.plan_by_id_conception(Id);
        }
        //*************************************************************************************

       
        #endregion
        
        #endregion
    }
}
