using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class group
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ГРУППАМИ

        /// <summary>
        /// Лист дочерних узлов девера групп
        /// </summary>
        public List<group> Group_child_list
        {
            get
            {
                return manager.Instance().group_by_id_parent(this);
            }
        }
        #endregion

        #region МЕТОДЫ РАБОТЫ С ГРУППАМИ
        #region ДОБАВИТЬ



        /// <summary>
        /// Метод добавляет новую группу
        /// </summary>
        public group group_add(String iname, String idesc, Boolean ion_class, Int32 isort)
        {
            return Manager.group_add(this.id, this.Id_conception, iname, idesc, ion_class, isort);
        }

        /// <summary>
        /// Метод копирует текущую группу в указанную группу
        /// </summary>
        public group group_copy(group Parent)
        {
            return Manager.group_copy(this, Parent);
        }
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет указанную группу
        /// </summary>
        public void group_del(group group)
        {
            Manager.group_del(group);
        }
        #endregion


        #region Поисковые методы группы
        /// <summary>
        /// Лист дочерних групп по строгому соотвествию имени 
        /// </summary>
        public List<group> Group_by_name(String iname)
        {
            return Manager.group_by_name(this, iname);
        }
        #endregion
        #endregion
    }
}
