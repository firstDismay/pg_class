using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class pos_temp
    {
        #region МЕТОДЫ РАБОТЫ С ПРАВИЛА УРОВНЯ 1 ГРУППА НА ШАБЛОН
        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет правило уровня 1 группа на шаблон
        /// </summary>
        public void rulel1_group_on_pos_temp_add(group Group)
        {
            Manager.rulel1_group_on_pos_temp_add(Group, this);
        }

        /// <summary>
        /// Метод добавляет правило уровня 1 группа на шаблон
        /// </summary>
        public void rulel1_group_on_pos_temp_add(rulel1_group_on_pos_temp RuleL1)
        {
            Manager.rulel1_group_on_pos_temp_add(RuleL1);
        }

        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет правило уровня 1 группа на шаблон
        /// </summary>
        public void rulel1_group_on_pos_temp_del(group Group)
        {
            Manager.rulel1_group_on_pos_temp_del(Group, this);
        }

        /// <summary>
        /// Метод удаляет правило вложенности объектов
        /// </summary>
        public void rulel1_group_on_pos_temp_del(rulel1_group_on_pos_temp RuleL1)
        {
            Manager.rulel1_group_on_pos_temp_del(RuleL1);
        }
        #endregion
        #endregion

        #region СВОЙСТВА ДЛЯ РАБОТЫ С ПРАВИЛАМИ ВЛОЖЕННОСТИ ОБЪЕКТОВ ГРУППА - ПОЗИЦИЯ

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
        /// Лист групп разрешенных в шаблоне правилом уровня 1 группа на шаблон
        /// </summary>
        public List<group> Group_allowed_RL1_list
        {
            get
            {
                return Manager.group_allowed_rl1_by_id_pos_temp(this);
            }
        }

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
        #endregion
    }
}
