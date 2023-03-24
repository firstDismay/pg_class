using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class pos_temp
    {
        #region МЕТОДЫ РАБОТЫ С ПРАВИЛА УРОВНЯ 1 КЛАСС НА ШАБЛОН
        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет правило уровня 1 класс на шаблон
        /// </summary>
        public void rulel1_class_on_pos_temp_add(vclass Class)
        {
            Manager.rulel1_class_on_pos_temp_add(Class, this);
        }

        /// <summary>
        /// Метод добавляет правило уровня 1 класс на шаблон
        /// </summary>
        public void rulel1_class_on_pos_temp_add(rulel1_class_on_pos_temp RuleL1)
        {
            Manager.rulel1_class_on_pos_temp_add(RuleL1);
        }

        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет правило уровня 1 класс на шаблон
        /// </summary>
        public void rulel1_class_on_pos_temp_del(vclass Class)
        {
            Manager.rulel1_class_on_pos_temp_del(Class, this);
        }

        /// <summary>
        /// Метод удаляет правило уровня 1 класс на шаблон
        /// </summary>
        public void rulel1_class_on_pos_temp_del(rulel1_class_on_pos_temp RuleL1)
        {
            Manager.rulel1_class_on_pos_temp_del(RuleL1);
        }
        #endregion
        #endregion

        #region СВОЙСТВА ДЛЯ РАБОТЫ С ПРАВИЛАМИ ВЛОЖЕННОСТИ ОБЪЕКТОВ ГРУППА - ПОЗИЦИЯ

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
                return Manager.rulel1_class_on_pos_temp_access_by_id_pos_temp(this);
            }
        }

        #endregion


        #region СВОЙСТВА ДЛЯ РАБОТЫ С КЛАССАМИ РАЗРЕШЕННЫМИ ПРАВИЛАМИ ВЛОЖЕННОСТИ УРОВНЯ 1 ГРУППА НА ШАБЛОН
        /// <summary>
        /// Лист классов назначенных в шаблоне правилом уровня 1 класс на шаблон
        /// </summary>
        public List<vclass> Class_assigned_RL1_list
        {
            get
            {
                return Manager.class_assigned_rl1_by_id_pos_temp(this);
            }
        }

        /// <summary>
        /// Лист классов разрешенных в шаблоне правилом уровня 1 класс на шаблон
        /// </summary>
        public List<vclass> Class_allowed_RL1_list
        {
            get
            {
                return Manager.class_allowed_rl1_by_id_pos_temp(this);
            }
        }
        #endregion
    }
}
