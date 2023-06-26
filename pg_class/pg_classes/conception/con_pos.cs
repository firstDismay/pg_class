using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class conception
    {
        #region МЕТОДЫ РАБОТЫ С ПОЗИЦИЯМИ
        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет новую позиций
        /// position_add
        /// </summary>
        public position position_add(pos_temp pos_temp, String iname, String idesc, Int32 isort)
        {
            position pos = null;
            if (pos_temp != null)
            {
                if (this.id == pos_temp.Id_conception)
                {
                    pos = Manager.position_add(0, pos_temp.Id, iname, idesc, isort);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        "Выбранный шаблон не пренадлежит текущей концепции");
                }
            }
            return pos;
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_add(out eAccess Access)
        {
            return Manager.position_add(out Access);
        }
        //*************************************************************************************

        #endregion

        #region ИЗМЕНИТЬ
        /// <summary>
        /// Метод изменяет сортировку корневых позиций на сортировку по имени
        /// position_sort_by_name
        /// </summary>
        public void Sort_position_root_by_name()
        {
            Manager.position_root_sort_by_name(this);
        }
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет указанный указанный позиций
        /// position_del
        /// </summary>
        public void Position_del(position pos)
        {
            Manager.position_del(pos);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Position_del(out eAccess Access)
        {
            return Manager.position_del(out Access);
        }
        //*************************************************************************************
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Лист позиции концепции
        /// position_root_by_id_conception
        /// </summary>
        public List<position> Position_list_get()
        {
            return Manager.position_root_by_id_conception(id);
        }
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Position_list_get(out eAccess Access)
        {
            return Manager.position_root_by_id_conception(out Access);
        }
        //*************************************************************************************
        #endregion
        #endregion
    }
}
