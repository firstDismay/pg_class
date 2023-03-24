namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс свойства шаблона позиции
    /// </summary>
    public partial class pos_temp_prop
    {
        /// <summary>
        /// Метод изменяет сортировку свойства активного класса поднимая свойство вверх
        /// pos_temp_prop_sort_top
        /// </summary>
        public void Sort_top()
        {
            Manager.pos_temp_prop_sort_top(this);
        }

        /// <summary>
        /// Метод изменяет сортировку свойства активного класса на один уровень вверх
        /// pos_temp_prop_sort_up
        /// </summary>
        public void Sort_up()
        {
            Manager.pos_temp_prop_sort_up(this);
        }

        /// <summary>
        /// Метод изменяет сортировку свойства активного класса на один уровень вниз
        /// pos_temp_prop_sort_down
        /// </summary>
        public void Sort_down()
        {
            Manager.pos_temp_prop_sort_down(this);
        }

        /// <summary>
        /// Метод изменяет сортировку свойства активного класса опуская свойство вниз
        /// pos_temp_prop_sort_bottom
        /// </summary>
        public void Sort_bottom()
        {
            Manager.pos_temp_prop_sort_bottom(this);
        }
    }
}
