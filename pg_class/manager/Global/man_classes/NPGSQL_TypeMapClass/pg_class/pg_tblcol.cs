using System;

namespace pg_class
{
    /// <summary>
    /// Композитный тип данных столбца таблицы
    /// </summary>
    public class pg_tblcol2
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public String name { get; set; }
        /// <summary>
        /// Тип данных
        /// </summary>
        public String type { get; set; }

        /// <summary>
        /// Категория данных
        /// </summary>
        public String typcategory { get; set; }
        /// <summary>
        /// Длинна для строковых типов
        /// </summary>
        public Int32 length { get; set; }
    }
}


