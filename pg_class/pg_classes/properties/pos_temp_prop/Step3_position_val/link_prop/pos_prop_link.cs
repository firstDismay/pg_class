namespace pg_class.pg_classes
{
    public partial class position_prop
    {
        #region МЕТОДЫ РАБОТЫ СО ЗНАЧЕНИЯМИ ПОЛЬЗОВАТЕЛЬСКИХ СВОЙСТВ КЛАССА
        #region ДОБАВИТЬ ЗНАЧЕНИЕ

        /// <summary>
        /// Метод добавляет новое значение свойства-ссылки позиции
        /// </summary>
        public position_prop_link_val link_data_add(position_prop_link_val PositionPropLinkVal)
        {
            return Manager.position_prop_link_val_add(PositionPropLinkVal);
        }
        #endregion

        #region УДАЛИТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Метод удаляет значение свойства-ссылки позиции
        /// </summary>
        public void link_data_del()
        {
            Manager.position_prop_link_val_del(this);
        }
        #endregion

        #region ВЫБРАТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Метод выбирает данные значение свойства-ссылки шаг №3
        /// </summary>
        public position_prop_link_val link_data_get()
        {
            return Manager.position_prop_link_val_by_id_prop(this);
        }
        #endregion
        #endregion

    }
}
