using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class position
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ПОЗИЦИЯМИ

        /// <summary>
        /// Лист дочерних узлов девера позиций
        /// </summary>
        public List<position> Position_child_list
        {
            get
            {
                return manager.Instance().position_by_id_parent(this);
            }
        }
        #endregion

        #region МЕТОДЫ РАБОТЫ С ПОЗИЦИЯМИ
        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет новую позицию
        /// </summary>
        public position position_add(pos_temp pos_temp, String iname, String idesc, Int32 isort)
        {
            position pos = null;
            if (pos_temp != null)
            {
                if (this.Id_conception == pos_temp.Id_conception)
                {
                    pos = Manager.position_add(this.id, pos_temp.Id, iname, idesc, isort);
                }
                else
                {
                    throw new pg_exceptions.PgDataException(505, "Выбранный шаблон не пренадлежит текущей концепции");
                }
            }

            return pos;
        }
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет указанную позицию
        /// </summary>
        public void Position_del(position pos)
        {
            Manager.position_del(pos);
        }

        /// <summary>
        /// Метод удаляет текущую позицию
        /// </summary>
        public void Position_del()
        {
            Manager.position_del(this);
        }
        #endregion

        #region Поисковые методы позиции
        /// <summary>
        /// Лист дочерних позиций по строгому соотвествию имени 
        /// </summary>
        public List<position> Position_by_name(String iname)
        {
            return Manager.position_by_name(this, iname);
        }

        /// <summary>
        /// Лист позиций по идентификатору родительской позиции с учетом шаблона позиции
        /// position_by_id_parent
        /// </summary>
        public List<position> Position_by_id_pos_temp(Int64 id_pos_temp)
        {
            return Manager.position_by_id_parent(Id, Id_conception, id_pos_temp);
        }

        /// <summary>
        /// Лист позиций по идентификатору родительской позиции с учетом шаблона позиции
        /// position_by_id_parent
        /// </summary>
        public List<position> Position_by_id_pos_temp(pos_temp Pos_temp)
        {
            return Manager.position_by_id_parent(this, Pos_temp);
        }
        #endregion
        #endregion
    }
}
