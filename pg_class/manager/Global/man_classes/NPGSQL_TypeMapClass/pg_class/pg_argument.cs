using System;

namespace pg_class
{
    /// <summary>
    /// Композитный тип аргумента функции
    /// </summary>
    public class pg_argument
    {
        /// <summary>
        /// Наименование аргумента
        /// </summary>
        public String name { get; set; }
        /// <summary>
        /// Тип данных аргумента
        /// </summary>
        public String type { get; set; }
        /// <summary>
        /// Направление ввода/вывода
        /// </summary>
        public String mode { get; set; }
    }
}
