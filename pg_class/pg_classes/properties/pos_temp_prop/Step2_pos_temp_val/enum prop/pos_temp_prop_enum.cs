namespace pg_class.pg_classes
{
    public partial class pos_temp_prop
    {
        #region МЕТОДЫ РАБОТЫ СО ЗНАЧЕНИЯМИ СВОЙСТВ-ПЕРЕЧИСЛЕНИЙ
        #region ДОБАВИТЬ ЗНАЧЕНИЕ

        /// <summary>
        /// Добавить данные значения свойства типа перечисление, Шаг №2
        /// pos_temp_prop_enum_val_add
        /// </summary>
        public pos_temp_prop_enum_val enum_data_add(pos_temp_prop_enum_val PosTemp_prop_enum_val)
        {
            return Manager.pos_temp_prop_enum_val_add(PosTemp_prop_enum_val);
        }

        /// <summary>
        /// Добавить данные значения свойства типа перечисление, Шаг №2
        /// pos_temp_prop_enum_val_add
        /// </summary>
        public pos_temp_prop_enum_val enum_data_add(prop_enum_val PropEnumVal)
        {
            return Manager.pos_temp_prop_enum_val_add(this.Id, PropEnumVal.Id_prop_enum, PropEnumVal.Id_prop_enum_val);
        }

        #endregion

        #region УДАЛИТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Удалить данные значения свойства типа перечисление, Шаг №2
        /// pos_temp_prop_enum_val_del
        /// </summary>
        public void enum_data_del()
        {
            Manager.pos_temp_prop_enum_val_del(this);
        }
        #endregion

        #region ВЫБРАТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Выбрать данные значения свойства типа перечисление, Шаг №2
        /// </summary>
        public pos_temp_prop_enum_val enum_data_get()
        {
            return Manager.pos_temp_prop_enum_val_by_id_prop(this);
        }
        #endregion
        #endregion

    }
}
