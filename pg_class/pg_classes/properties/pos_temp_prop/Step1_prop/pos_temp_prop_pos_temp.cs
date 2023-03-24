namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс свойств шаблона
    /// </summary>
    public partial class pos_temp_prop
    {
        #region МЕТОДЫ КЛАССА
        #region ВЫБРАТЬ
        /// <summary>
        /// Шаблон носитель свойства
        /// pos_temp_by_id
        /// </summary>
        public pos_temp pos_temp_carrier_get()
        {
            return Manager.pos_temp_by_id(id_pos_temp);
        }
        #endregion
        #endregion
    }
}
