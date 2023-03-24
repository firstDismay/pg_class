using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class vclass
    {

        #region МЕТОДЫ РАБОТЫ C ПРАВИЛАМИ ВЛОЖЕННОСТИ УРОВНЯ 2 КЛАСС НА ПОЗИЦИЮ

        #region ВЫБРАТЬ
        /// <summary>
        /// Лист позиций с учетом разрешения уровня 2 класс на позицию по идентификатору класса
        /// </summary>
        public List<position> Position_allowed_RL2_class_on_position_list
        {
            get
            {
                return Manager.Position_allowed_rl2_by_id_class(this);
            }
        }
        #endregion


        /// <summary>
        /// Метод возвращает классы назначенные с учетом правил уровня 2 класс на позицию для выбранной группы по идентификатору позиции
        /// </summary>
        public List<vclass> Get_Class_allowed_rl2_by_id_position(position Position)
        {
            return Manager.class_allowed_rl2_for_class_by_id_position(Position, this);
        }
        #endregion
    }
}
