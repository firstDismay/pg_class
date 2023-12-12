namespace pg_class.pg_classes
{
    public partial class global_prop
    {
        #region МЕТОДЫ РАБОТЫ С ДАННЫМИ ОБЛАСТИ ЗНАЧЕНИЙ ГЛОБАЛЬНЫХ СВОЙСТВ
        #region УСТАНОВИТЬ ЗНАЧЕНИЕ

        /// <summary>
        /// Метод устанавливает новые данные области значения глобального свойства
        /// global_prop_area_val_set
        /// </summary>
        public global_prop_area_val area_data_set(prop_enum PropEnum)
        {
            return Manager.global_prop_area_val_set(this, PropEnum);
        }

        /// <summary>
        /// Метод устанавливает новые данные области значения глобального свойства
        /// global_prop_area_val_set
        /// </summary>
        public global_prop_area_val area_data_set(vclass ClassVal)
        {
            return Manager.global_prop_area_val_set(this, ClassVal);
        }

        /// <summary>
        /// Метод устанавливает новые данные области значения глобального свойства
        /// global_prop_area_val_set
        /// </summary>
        public global_prop_area_val area_data_set(entity EntityVal)
        {
            return Manager.global_prop_area_val_set(this, EntityVal);
        }
        #endregion

        #region УДАЛИТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Удалить данные значения свойства типа перечисление, Шаг №2
        /// global_prop_area_val_del
        /// </summary>
        public void area_data_del()
        {
            Manager.global_prop_area_val_del(this);
        }
        #endregion

        #region ВЫБРАТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Выбрать данные значения свойства типа перечисление, Шаг №2
        /// global_prop_area_val_by_id_prop
        /// </summary>
        public global_prop_area_val area_data_get()
        {
            return Manager.global_prop_area_val_by_id_prop(this);
        }
        #endregion
        #endregion
    }
}
