namespace pg_class.pg_classes
{
    /// <summary>
    /// Управление сортировкой
    /// </summary>
    public partial class position
    {
        /// <summary>
        /// Метод изменяет сортировку позиции поднимая вверх
        /// position_sort_top
        /// </summary>
        public void Sort_top()
        {
            Manager.position_sort_top(this);
        }

        /// <summary>
        /// Метод изменяет сортировку позиции на один уровень вверх
        /// position_sort_up
        /// </summary>
        public void Sort_up()
        {
            Manager.position_sort_up(this);
        }

        /// <summary>
        /// Метод изменяет сортировку позиции на один уровень вниз
        /// position_sort_down
        /// </summary>
        public void Sort_down()
        {
            Manager.position_sort_down(this);
        }

        /// <summary>
        /// Метод изменяет сортировку позиции опуская вниз
        /// position_sort_bottom
        /// </summary>
        public void Sort_bottom()
        {
            Manager.position_sort_bottom(this);
        }

        /// <summary>
        /// Метод изменяет сортировку дочерних позиций на сортировку по имени
        /// position_sort_by_name
        /// </summary>
        public void Sort_child_by_name()
        {
            Manager.position_sort_by_name(this);
        }
    }
}
