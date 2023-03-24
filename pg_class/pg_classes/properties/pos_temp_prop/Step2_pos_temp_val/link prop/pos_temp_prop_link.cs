namespace pg_class.pg_classes
{
    public partial class pos_temp_prop
    {
        #region МЕТОДЫ РАБОТЫ СО ЗНАЧЕНИЯМИ СВОЙСТВ-ССЫЛОК
        #region ДОБАВИТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Добавить данные значения свойства типа ссылка, Шаг №2
        /// pos_temp_prop_link_val_add
        /// </summary>
        public pos_temp_prop_link_val link_data_add(pos_temp_prop_link_val PosTemp_prop_link_val)
        {
            return Manager.pos_temp_prop_link_val_add(PosTemp_prop_link_val);
        }
        #endregion

        #region УДАЛИТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Удалить данные значения свойства типа ссылка, Шаг №2
        /// pos_temp_prop_link_val_del
        /// </summary>
        public void link_data_del()
        {
            Manager.pos_temp_prop_link_val_del(this);
        }
        #endregion

        #region ВЫБРАТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Выбрать данные значения свойства типа ссылка, Шаг №2
        /// </summary>
        public pos_temp_prop_link_val link_data_get()
        {
            return Manager.pos_temp_prop_link_val_by_id_prop(this); ;
        }
        #endregion
        #endregion

    }
}
