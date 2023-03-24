namespace pg_class.pg_classes
{
    public partial class pos_temp_prop
    {
        #region МЕТОДЫ РАБОТЫ СО ЗНАЧЕНИЯМИ ПОЛЬЗОВАТЕЛЬСКИХ СВОЙСТВ ШАБЛОНА
        #region ДОБАВИТЬ ЗНАЧЕНИЕ

        /// <summary>
        /// Добавить новое значение пользовательского свойства шаблона, Шаг №2 
        /// pos_temp_prop_user_val_add
        /// </summary>
        public pos_temp_prop_user_val user_data_add(pos_temp_prop_user_val PosTempPropUserVal)
        {
            return Manager.pos_temp_prop_user_val_add(PosTempPropUserVal);
        }
        #endregion

        #region УДАЛИТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Метод удаляет значение объектного свойства шаблона, Шаг №2 
        /// pos_temp_prop_user_val_del
        /// </summary>
        public void user_data_del()
        {
            Manager.pos_temp_prop_user_val_del(this);
        }
        #endregion

        #region ВЫБРАТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Выбрать значение пользовательского свойства шаблона по идентификатору значения свойства, Шаг №2 
        /// pos_temp_prop_user_small_val_by_id_prop
        /// </summary>
        public pos_temp_prop_user_val user_data_get()
        {
            return Manager.pos_temp_prop_user_val_by_id_prop(this);
        }
        #endregion
        #endregion

    }
}
