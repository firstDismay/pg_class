using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс области применения перечисления концепции
    /// </summary>
    public partial class prop_enum_use_area
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected prop_enum_use_area()
        {
            imagekey = "prop_type_us";
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public prop_enum_use_area(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "vprop_enum_use_area")
            {
                id = (Int32)row["id"];
                name = (String)row["name"];
                desc = (String)row["desc"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        private Int32 id;
        private String name;
        private String desc;


        /// <summary>
        /// Идентификатор типа данных свойства
        /// </summary>
        public Int32 Id
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// Тип свойства класса
        /// </summary>
        public eProp_enum_use_area Prop_enum_use_area
        {
            get
            {
                return (eProp_enum_use_area)id;
            }
        }

        /// <summary>
        /// Наименование области применения перечисления
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Описание области применения перечисления
        /// </summary>
        public String Desc
        {
            get
            {
                return desc;
            }
        }


        private String imagekey;
        /// <summary>
        /// Ключ объекта
        /// </summary>
        public string ImageKey
        {
            get
            {
                return imagekey;
            }
        }

        /// <summary>
        /// Ссылка на менеджера данных
        /// </summary>
        private manager Manager
        {
            get
            {
                return manager.Instance();
            }
        }

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

