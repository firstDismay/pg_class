namespace pg_class.pg_classes
{
    public partial class position_prop
    {
        #region МЕТОДЫ РАБОТЫ СО ЗНАЧЕНИЯМИ ПОЛЬЗОВАТЕЛЬСКИХ СВОЙСТВ КЛАССА
        #region ДОБАВИТЬ ЗНАЧЕНИЕ

        /// <summary>
        /// Метод добавляет новое значение пользовательского свойства позиции
        /// </summary>
        public position_prop_user_val user_data_set(position_prop_user_val ObjectPropUserVal)
        {
            position_prop_user_val Result = null;
            Result = Manager.position_prop_user_val_set(ObjectPropUserVal);
            return Result;
        }

        #endregion

        #region УДАЛИТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Метод удаляет значение пользовательского свойства позиции
        /// </summary>
        public void user_data_del()
        {
            Manager.position_prop_user_val_del(this);
        }
        #endregion

        #region ВЫБРАТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Значение пользовательского свойства, шаг №3
        /// </summary>
        public position_prop_user_val user_data_get()
        {
            position_prop_user_val Result = null;
            Result = Manager.position_prop_user_val_by_id_prop(this);
            return Result;
        }
        #endregion
        #endregion

    }
}
