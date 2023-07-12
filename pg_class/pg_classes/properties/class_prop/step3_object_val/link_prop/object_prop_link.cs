namespace pg_class.pg_classes
{
    public partial class object_prop
    {
        #region МЕТОДЫ РАБОТЫ СО ЗНАЧЕНИЯМИ ПОЛЬЗОВАТЕЛЬСКИХ СВОЙСТВ КЛАССА
        #region ДОБАВИТЬ ЗНАЧЕНИЕ

        /// <summary>
        /// Метод добавляет новое значение свойства-ссылки объекта
        /// </summary>
        public object_prop_link_val link_data_set(object_prop_link_val ObjectPropLinkVal)
        {
            object_prop_link_val Result = null;
            Result = Manager.object_prop_link_val_set(ObjectPropLinkVal);
            return Result;
        }
        #endregion

        #region УДАЛИТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Метод удаляет значение свойства-ссылки объекта
        /// </summary>
        public void link_data_del()
        {
            Manager.object_prop_link_val_del(this);
        }
        #endregion

        #region ВЫБРАТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Метод выбирает данные значение свойства-ссылки шаг №3
        /// </summary>
        public object_prop_link_val link_data_get()
        {
            object_prop_link_val Result = null;
            Result = Manager.object_prop_link_val_by_id_prop(this);
            return Result;
        }
        #endregion
        #endregion

    }
}
