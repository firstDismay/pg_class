using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class position
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ПРАВИЛАМИ ВЛОЖЕННОСТИ ОБЪЕКТОВ КЛАСС - ПОЗИЦИЯ

        /// <summary>
        /// Лист правил уровня 1 класс на шаблон
        /// </summary>
        public List<rulel1_class_on_pos_temp> RuleL1_class_on_pos_temp_list
        {
            get
            {
                return Manager.rulel1_class_on_pos_temp_by_id_pos_temp(this);
            }
        }

        /// <summary>
        /// Лист разрешений уровня 1 класс на шаблон
        /// </summary>
        public List<rulel1_class_on_pos_temp_access> RuleL1_class_on_pos_temp_access_list
        {
            get
            {
                return Manager.rulel1_class_on_pos_temp_access_by_id_position(this);
            }
        }

        #endregion


        #region СВОЙСТВА ДЛЯ РАБОТЫ С КЛАССАМИ РАЗРЕШЕННЫМИ ПРАВИЛАМИ ВЛОЖЕННОСТИ УРОВНЯ 1 ПОЗИЦИЯ НА ШАБЛОН
        /// <summary>
        /// Лист классов назначенных в шаблоне правилом уровня 1 класс на шаблон
        /// </summary>
        public List<vclass> Class_assigned_RL1_list
        {
            get
            {
                return Manager.class_assigned_rl1_by_id_position(this);
            }
        }

        /// <summary>
        /// Лист классов разрешенных в шаблоне правилом уровня 1 класс на шаблон
        /// </summary>
        public List<vclass> Class_allowed_RL1_list
        {
            get
            {
                return Manager.class_allowed_rl1_by_id_position(this);
            }
        }
        #endregion
    }
}
