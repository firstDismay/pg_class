using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class conception
    {
        #region МЕТОДЫ РАБОТЫ С ВИДАМИ СУЩНОСТЕЙ

        /// <summary>
        /// Лист сущностей допускающих линковкуБД
        /// entity_by_can_link
        /// </summary>
        public List<entity> entity_by_can_link()
        {
            return Manager.entity_by_can_link();
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean entity_by_can_link(out eAccess Access)
        {
            return Manager.entity_by_can_link(out Access);
        }
        

        /// <summary>
        /// Лист сущностей 
        /// entity_by_all
        /// </summary>
        public List<entity> entity_by_all()
        {
            return Manager.entity_by_all();
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean entity_by_all(out eAccess Access)
        {
            return Manager.entity_by_all(out Access);
        }
        

        #endregion
    }
}
