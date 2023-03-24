﻿using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class group
    {
        #region МЕТОДЫ РАБОТЫ С ПРАВИЛАМИ УРОВНЯ 1 ГРУППА НА ШАБЛОН
        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет правило уровня 1 группа на шаблон
        /// </summary>
        public void rulel1_group_on_pos_temp_add(pos_temp Pos_temp)
        {
            Manager.rulel1_group_on_pos_temp_add(this, Pos_temp);
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
        public void rulel1_group_on_pos_temp_del(pos_temp Pos_temp)
        {
            Manager.rulel1_group_on_pos_temp_del(this, Pos_temp);
        }

        /// <summary>
        /// Метод удаляет правило вложенности объектов
        /// </summary>
        public void rulel1_group_on_pos_temp_del(rulel1_group_on_pos_temp RuleL1)
        {
            Manager.rulel1_group_on_pos_temp_del(RuleL1);
        }
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Лист правил уровня 1 группа на шаблон
        /// </summary>
        public List<rulel1_group_on_pos_temp> RuleL1_group_on_pos_temp_list
        {
            get
            {
                return Manager.rulel1_group_on_pos_temp_by_id_group(this);
            }
        }

        /// <summary>
        /// Лист разрешений уровня 1 группа на шаблон
        /// </summary>
        public List<rulel1_group_on_pos_temp_access> RuleL1_group_on_pos_temp_access_list
        {
            get
            {
                return Manager.rulel1_group_on_pos_temp_access_by_id_group(this);
            }
        }
        #endregion
        #endregion

        #region СВОЙСТВА ДЛЯ РАБОТЫ С ШАБЛОНАМИ РАЗРЕШЕННЫМИ ПРАВИЛАМИ ВЛОЖЕННОСТИ УРОВНЯ 1 ГРУППА НА ШАБЛОН
        /// <summary>
        /// Лист групп разрешенных в шаблоне правилом уровня 1 группа на шаблон
        /// </summary>
        public List<pos_temp> Pos_temp_allowed_RL1_list
        {
            get
            {
                return Manager.pos_temp_allowed_rl1_by_id_group(this);
            }
        }

        /// <summary>
        /// Лист групп назначенных в шаблоне правилом уровня 1 группа на шаблон
        /// </summary>
        public List<pos_temp> Pos_temp_assigned_RL1_list
        {
            get
            {
                return Manager.pos_temp_assigned_rl1_by_id_group(this);
            }
        }
        #endregion
    }
}
