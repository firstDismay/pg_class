using System;

namespace pg_class.pg_classes
{
    public partial class pos_temp
    {
        #region МЕТОДЫ ПРОВЕРКИ РАЗРЕШЕНИЙ

        /// <summary>
        /// Метод определяет наличие разрешения RL1 класс на шаблон для переданной пары
        /// </summary>
        public Boolean rulel1_class_on_pos_temp_check_access(vclass Class)
        {
            return Manager.rulel1_class_on_pos_temp_check_access(this.Id, Class.Id);
        }

        /// <summary>
        /// Метод определяет наличие разрешения RL1 группа на шаблон для переданной пары
        /// </summary>
        public Boolean rulel1_group_on_pos_temp_check_access(group Group)
        {
            return Manager.rulel1_group_on_pos_temp_check_access(this.Id, Group.Id);
        }
        #endregion
    }
}
