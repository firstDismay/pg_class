namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс перечислений для свойств типа перечисление
    /// </summary>
    public partial class prop_enum_val
    {
        /// <summary>
        /// Метод изменяет сортировку свойства активного класса поднимая свойство вверх
        /// prop_enum_val_sort_top
        /// </summary>
        public void Sort_top()
        {
            Manager.prop_enum_val_sort_top(this);
        }

        /// <summary>
        /// Метод изменяет сортировку свойства активного класса на один уровень вверх
        /// prop_enum_val_sort_up
        /// </summary>
        public void Sort_up()
        {
            Manager.prop_enum_val_sort_up(this);
        }

        /// <summary>
        /// Метод изменяет сортировку свойства активного класса на один уровень вниз
        /// prop_enum_val_sort_down
        /// </summary>
        public void Sort_down()
        {
            Manager.prop_enum_val_sort_down(this);
        }

        /// <summary>
        /// Метод изменяет сортировку свойства активного класса опуская свойство вниз
        /// prop_enum_val_sort_bottom
        /// </summary>
        public void Sort_bottom()
        {
            Manager.prop_enum_val_sort_bottom(this);
        }
    }
}
