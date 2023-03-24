namespace pg_class.pg_classes
{
    public partial class global_prop
    {
        #region МЕТОДЫ РАБОТЫ С ДАННЫМИ ОБЛАСТИ ЗНАЧЕНИЙ ГЛОБАЛЬНЫХ СВОЙСТВ
        #region ДОБАВИТЬ ЗНАЧЕНИЕ

        /// <summary>
        /// Метод добавляет новые данные области значения глобального свойства
        /// global_prop_area_val_add
        /// </summary>
        public global_prop_area_val area_data_add(prop_enum PropEnum)
        {
            return Manager.global_prop_area_val_add(this, PropEnum);
        }

        /// <summary>
        /// Метод добавляет новые данные области значения глобального свойства
        /// global_prop_area_val_add
        /// </summary>
        public global_prop_area_val area_data_add(vclass ClassVal)
        {
            return Manager.global_prop_area_val_add(this, ClassVal);
        }

        /// <summary>
        /// Метод добавляет новые данные области значения глобального свойства
        /// global_prop_area_val_add
        /// </summary>
        public global_prop_area_val area_data_add(entity EntityVal)
        {
            return Manager.global_prop_area_val_add(this, EntityVal);
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
