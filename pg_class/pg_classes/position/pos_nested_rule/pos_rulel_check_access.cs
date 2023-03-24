using System;

namespace pg_class.pg_classes
{
    public partial class position
    {
        #region МЕТОДЫ ПРОВЕРКИ РАЗРЕШЕНИЙ

        /// <summary>
        /// Метод определяет наличие разрешения RL1 класс на шаблон для переданной пары
        /// </summary>
        public Boolean rulel1_class_on_pos_temp_check_access(vclass Class)
        {
            return Manager.rulel1_class_on_pos_temp_check_access(this.Id_pos_temp, Class.Id);
        }

        /// <summary>
        /// Метод определяет наличие разрешения RL1 группа на шаблон для переданной пары
        /// </summary>
        public Boolean rulel1_group_on_pos_temp_check_access(group Group)
        {
            return Manager.rulel1_group_on_pos_temp_check_access(this.Id_pos_temp, Group.Id);
        }

        /// <summary>
        /// Метод определяет наличие разрешения RL2 класс на позицию для переданной пары
        /// </summary>
        public Boolean rulel2_class_on_position_check_access(vclass Class)
        {
            return Manager.rulel2_class_on_position_check_access(this, Class);
        }

        #endregion
    }
}
