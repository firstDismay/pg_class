namespace pg_class.pg_classes
{
    /// <summary>
    /// Управление сортировкой
    /// </summary>
    public partial class class_prop
    {
        /// <summary>
        /// Метод изменяет сортировку свойства активного класса поднимая свойство вверх
        /// class_prop_sort_top
        /// </summary>
        public void Sort_top()
        {
            Manager.class_prop_sort_top(this);
        }

        /// <summary>
        /// Метод изменяет сортировку свойства активного класса на один уровень вверх
        /// class_prop_sort_up
        /// </summary>
        public void Sort_up()
        {
            Manager.class_prop_sort_up(this);
        }

        /// <summary>
        /// Метод изменяет сортировку свойства активного класса на один уровень вниз
        /// class_prop_sort_down
        /// </summary>
        public void Sort_down()
        {
            Manager.class_prop_sort_down(this);
        }

        /// <summary>
        /// Метод изменяет сортировку свойства активного класса опуская свойство вниз
        /// class_prop_sort_bottom
        /// </summary>
        public void Sort_bottom()
        {
            Manager.class_prop_sort_bottom(this);
        }
    }

}
