namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс обобщенного представления объектов
    /// </summary>
    public partial class object_general
    {
        #region МЕТОДЫ ДЛЯ РАБОТЫ С НАСЛЕДУЕМЫМИ ПРЕДСТАВЛЕНИЯМИ КЛАССОВ

        /// <summary>
        /// Метод возвращает активное представление класса породившего объект, при наличии
        /// </summary>
        public vclass Class_act_get()
        {
            return Manager.class_act_by_id(this.Id_class);
        }

        /// <summary>
        /// Метод восстанавливает активное представлние вещественного класса объекта и всю цепь наследования до корневого класса
        /// </summary>
        public vclass Class_act_restore()
        {
            return Manager.class_act_restore(this);
        }

        #endregion

    }
}
