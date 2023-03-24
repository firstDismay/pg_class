using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class conception
    {
        #region МЕТОДЫ РАБОТЫ С ГРУППАМИ

        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет новую группу
        /// group_add
        /// </summary>
        public group group_add(String iname, String idesc, Boolean ion_class, Int32 isort)
        {
            return Manager.group_add(0, id, iname, idesc, ion_class, isort);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean group_add(out eAccess Access)
        {
            return Manager.group_add(out Access);
        }
        //*************************************************************************************
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет указанную группу
        /// group_del
        /// </summary>
        public void Group_del(group Group)
        {
            Manager.group_del(Group);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Group_del(out eAccess Access)
        {
            return Manager.group_del(out Access);
        }
        //*************************************************************************************
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Метод возвращает лист групп концепции
        /// group_by_id_parent
        /// </summary>
        public List<group> Group_list_get()
        {
            return Manager.group_by_id_parent(0, id);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Group_list_get(out eAccess Access)
        {
            return Manager.group_by_id_parent(out Access);
        }
        //*************************************************************************************
        #endregion
        #endregion
    }
}
