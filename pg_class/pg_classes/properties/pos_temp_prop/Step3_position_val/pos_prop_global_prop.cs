namespace pg_class.pg_classes

{
    /// <summary>
    /// Класс свойства шаблона позиции
    /// </summary>
    public partial class position_prop
    {
        #region МЕТОДЫ КЛАССА
        #region ВЫБРАТЬ
        /// <summary>
        /// Глобальное свойтсво связанное со свойством шаблона
        /// global_prop_by_id_pos_temp_prop
        /// </summary>
        public global_prop Global_prop_get()
        {
            return Manager.global_prop_by_id_pos_temp_prop(this);
        }

        #endregion
        #endregion
    }
}
