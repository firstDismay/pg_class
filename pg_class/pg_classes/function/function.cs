using System;

namespace pg_class.pg_classes
{ /// <summary>
  /// Класс используемый для формирования списка доступных функций БД ассистента
  /// </summary>
    public class function
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected function()
        {
            imagekey = "func_us";
            selectedimagekey = "func_s";
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public function(System.Data.DataRow row) : this()
        {

            //if (Модуль.Table is ТаблицаМодулей)
            if (row.Table.TableName == "cfg_v_initproc_base_desc")
            {
                oid = Convert.ToUInt32(row["oid"]);
                name = Convert.ToString(row["proname"]);
                args = Convert.ToInt32(row["proargs"]);
                argsignature = Convert.ToString(row["argsignature"]);
                access = Convert.ToBoolean(row["access"]);
                description = Convert.ToString(row["description"]);
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private UInt32 oid;
        private String name;
        private Int32 args;
        private String argsignature;
        private Boolean access;
        private String description;


        /// <summary>
        /// Уникальный идентификатор учетной записи
        /// </summary>
        public UInt32 Oid
        {
            get
            {
                return oid;
            }
        }

        /// <summary>
        /// Системное наименование функции
        /// </summary>
        public String Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Количество аргументов функции
        /// </summary>
        public Int32 Args
        {
            get
            {
                return args;
            }
        }

        /// <summary>
        /// Системная сигнатура вызова функции
        /// </summary>
        public String Argsignature
        {
            get
            {
                return argsignature;
            }
        }

        /// <summary>
        /// Параметр доступа на выполнение функции у текущего пользователя
        /// </summary>
        public Boolean Access
        {
            get
            {
                return access;
            }
        }

        /// <summary>
        /// Системное описание функции
        /// </summary>
        public String Desc
        {
            get
            {
                return description;
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

        private String selectedimagekey;
        /// <summary>
        /// Ключ выделенного объекта
        /// </summary>
        public string SelectedImageKey
        {
            get
            {
                return selectedimagekey;
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
