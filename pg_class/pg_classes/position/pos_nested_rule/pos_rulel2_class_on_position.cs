using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class position
    {
        #region МЕТОДЫ РАБОТЫ С ПРАВИЛАМИ УРОВНЯ 2 КЛАСС НА ПОЗИЦИЮ
        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет правило уровня 2 класс на позицию
        /// </summary>
        public void Rulel2_class_on_position_add(vclass Class)
        {
            Manager.Rulel2_class_on_position_add(Class, this);
        }

        /// <summary>
        /// Метод добавляет правило уровня 2 класс на позицию
        /// </summary>
        public void Rulel2_class_on_position_add(rulel2_class_on_position RuleL2)
        {
            Manager.Rulel2_class_on_position_add(RuleL2);
        }

        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет правило  уровня 2 класс на позицию
        /// </summary>
        public void Rulel2_class_on_position_del(vclass Class)
        {
            Manager.Rulel2_class_on_position_del(Class, this);
        }

        /// <summary>
        /// Метод удаляет правило  уровня 2 класс на позицию
        /// </summary>
        public void Rulel2_class_on_position_del(rulel2_class_on_position RuleL2)
        {
            Manager.Rulel2_class_on_position_del(RuleL2);
        }

        /// <summary>
        /// Метод удаляет все правила  уровня 2 класс на позицию
        /// </summary>
        public void Rulel2_class_on_position_all_del()
        {
            Manager.Rulel2_class_on_position_all_del(this);
        }
        #endregion

        #region ВЫБРАТЬ

        /// <summary>
        /// Список правил уровня 2 класс на позицию по идентификатору позиции
        /// </summary>
        public List<rulel2_class_on_position> RuleL2_class_on_position_list
        {
            get
            {
                return Manager.Rulel2_class_on_position_by_id_position(this);
            }
        }

        #endregion

        #endregion

        #region МЕТОДЫ РАБОТЫ С КЛАССАМИ НАЗНАЧЕННЫМИ С УЧЕТОМ ПРАВИЛ УРОВНЯ 2 КЛАСС НА ПОЗИЦИЮ
        /// <summary>
        /// Список классов назначенных с учетом правил уровня 2 класс на позицию по идентификатору позиции
        /// </summary>
        public List<vclass> Class_assigned_RL2_list
        {
            get
            {
                return Manager.Class_assigned_rl2_by_id_position(this);
            }
        }

        /// <summary>
        /// Список классов разрешенных с учетом правил уровня 2 класс на позицию по идентификатору позиции
        /// </summary>
        public List<vclass> Class_allowed_RL2_list
        {
            get
            {
                return Manager.Class_allowed_rl2_by_id_position(this);
            }
        }
        #endregion
    }
}
