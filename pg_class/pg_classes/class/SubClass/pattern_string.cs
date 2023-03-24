using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс строковых паттернов для редактора формата имен объектов классов
    /// </summary>
    public class pattern_string
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected pattern_string()
        {
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public pattern_string(System.Data.DataRow row) : this()
        {

            if (row.Table.TableName == "vpattern_string")
            {
                sort = (Int32)row["sort"];
                pattern = (String)row["pattern"];
                name = (String)row["name"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int32 sort;
        private String pattern;
        private String name;

        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public Int32 Id { get => sort; }

        /// <summary>
        /// Паттерн строки подстановка
        /// </summary>
        public String Pattern { get => pattern; }

        /// <summary>
        /// Наименование строки подстановки
        /// </summary>
        public String Name { get => name; }
        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            return name;
        }
        #endregion

    }
}
