using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class position
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ПРАВИЛАМИ ВЛОЖЕННОСТИ УРОВНЯ 1 ГРУППА НА ШАБЛОН

        /// <summary>
        /// Лист правил уровня 1 группа на шаблон
        /// </summary>
        public List<rulel1_group_on_pos_temp> RuleL1_group_on_pos_temp_list
        {
            get
            {
                return Manager.rulel1_group_on_pos_temp_by_id_pos_temp(this);
            }
        }

        /// <summary>
        /// Лист разрешений уровня 1 группа на шаблон
        /// </summary>
        public List<rulel1_group_on_pos_temp_access> RuleL1_group_on_pos_temp_access_list
        {
            get
            {
                return Manager.rulel1_group_on_pos_temp_access_by_id_pos_temp(this);
            }
        }
        #endregion

        #region СВОЙСТВА ДЛЯ РАБОТЫ С ГРУППАМИ РАЗРЕШЕННЫМИ ПРАВИЛАМИ ВЛОЖЕННОСТИ УРОВНЯ 1 ГРУППА НА ШАБЛОН

        /// <summary>
        /// Лист групп назначенных в шаблоне правилом уровня 1 группа на шаблон
        /// </summary>
        public List<group> Group_assigned_RL1_list
        {
            get
            {
                return Manager.group_assigned_rl1_by_id_pos_temp(this);
            }
        }

        /// <summary>
        /// Лист групп разрешенных в шаблоне правилом уровня 1 группа на шаблон
        /// </summary>
        public List<group> Group_allowed_RL1_list
        {
            get
            {
                return Manager.group_allowed_rl1_by_id_position(this);
            }
        }
        #endregion

        #region СВОЙСТВА ДЛЯ РАБОТЫ С КЛАССАМИ РАЗРЕШЕННЫМИ ПРАВИЛАМИ ВЛОЖЕННОСТИ УРОВНЯ 1 ГРУППА НА ШАБЛОН
        /// <summary>
        /// Лист классов разрешенных в шаблоне правилом уровня 1 группа на шаблон
        /// </summary>
        public List<vclass> Class_allowed_RL1_group_on_pos_temp_list
        {
            get
            {
                return Manager.class_allowed_rl1_by_id_position(this);
            }
        }

        /// <summary>
        /// Лист классов назначенных в шаблоне правилом уровня 1 группа на шаблон
        /// </summary>
        public List<vclass> Class_assigned_RL1_group_on_pos_temp_list
        {
            get
            {
                return Manager.class_assigned_rl1_by_id_position(this);
            }
        }
        #endregion
    }
}
