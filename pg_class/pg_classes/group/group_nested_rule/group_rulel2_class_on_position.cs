using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class group
    {
        #region МЕТОДЫ РАБОТЫ С ПРАВИЛАМИ УРОВНЯ 2 КЛАСС НА ПОЗИЦИЮ

        #region ВЫБРАТЬ

        /// <summary>
        /// Метод возвращает классы назначенные с учетом правил уровня 2 класс на позицию для выбранной группы по идентификатору позиции
        /// </summary>
        public List<vclass> Get_Class_allowed_rl2_by_id_position(position Position)
        {
            return Manager.Class_allowed_rl2_for_group_by_id_position(Position, this);
        }
        #endregion
        #endregion
    }
}
