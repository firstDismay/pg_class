using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс спецификатора значения свойства
    /// </summary>
    public partial class prop_val_spec
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected prop_val_spec()
        {
            imagekey = "prop_spec_us";
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public prop_val_spec(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "vcfg_prop_spec_limit2")
            {
                id_prop_data_type = (Int32)row["id_prop_data_type"];

                max_name = (String)row["max_name"];
                max_used = (Boolean)row["max_used"];
                max_limit_on = (Boolean)row["max_limit_on"];
                max_upper = (Decimal)row["max_upper"];
                max_lower = (Decimal)row["max_lower"];
                max_default = (Decimal)row["max_default"];

                min_name = (String)row["min_name"];
                min_used = (Boolean)row["min_used"];
                min_limit_on = (Boolean)row["min_limit_on"];
                min_upper = (Decimal)row["min_upper"];
                min_lower = (Decimal)row["min_lower"];
                min_default = (Decimal)row["min_default"];

                round_name = (String)row["round_name"];
                round_used = (Boolean)row["round_used"];
                round_limit_on = (Boolean)row["round_limit_on"];
                round_upper = (Int32)row["round_upper"];
                round_lower = (Int32)row["round_lower"];
                round_default = (Int32)row["round_default"];
    }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }

        #endregion

        #region СВОЙСТВА КЛАССА
        Int32 id_prop_data_type;

        String max_name;
        Boolean max_used;
        Boolean max_limit_on;
        Decimal max_upper;
        Decimal max_lower;
        Decimal max_default;

        String min_name;
        Boolean min_used;
        Boolean min_limit_on;
        Decimal min_upper;
        Decimal min_lower;
        Decimal min_default;

        String round_name;
        Boolean round_used;
        Boolean round_limit_on;
        Int32 round_upper;
        Int32 round_lower;
        Int32 round_default;

        /// <summary>
        /// Идентификатор типа данных спецификатора значения свойства
        /// </summary>
        public Int32 Id_prop_data_type
        {
            get
            {
                return id_prop_data_type;
            }
        }

        #region ДАННЫЕ СПЕЦИФИКАТОРА MAX

        /// <summary>
        /// Наименование спецификатора MAX
        /// </summary>
        public String Max_name
        {
            get
            {
                return max_name;
            }
        }

        /// <summary>
        /// Признак применения спецификатора MAX ограничивающего значение свойства
        /// </summary>
        public Boolean Max_used
        {
            get
            {
                return max_used;
            }
        }
        /// <summary>
        /// Признак ограничения значений спецификатора MAX
        /// </summary>
        public Boolean Max_limit_on
        {
            get
            {
                return max_limit_on;
            }
        }

        /// <summary>
        /// Верхний предел диапазона значений спецификатора MAX
        /// </summary>
        public Decimal Max_upper
        {
            get
            {
                return max_upper;
            }
        }

        /// <summary>
        /// Нижний предел диапазона значений спецификатора MAX
        /// </summary>
        public Decimal Max_lower
        {
            get
            {
                return max_lower;
            }
        }

        /// <summary>
        /// Значение спецификатора MAX по умолчанию
        /// </summary>
        public Decimal Max_default
        {
            get
            {
                return max_default;
            }
        }
        #endregion

        #region ДАННЫЕ СПЕЦИФИКАТОРА MIN

        /// <summary>
        /// Наименование спецификатора MIN
        /// </summary>
        public String Min_name
        {
            get
            {
                return min_name;
            }
        }

        /// <summary>
        /// Признак применения спецификатора MIN ограничивающего значение свойства
        /// </summary>
        public Boolean Min_used
        {
            get
            {
                return min_used;
            }
        }
        /// <summary>
        /// Признак ограничения значений спецификатора MIN
        /// </summary>
        public Boolean Min_limit_on
        {
            get
            {
                return min_limit_on;
            }
        }

        /// <summary>
        /// Верхний предел диапазона значений спецификатора MIN
        /// </summary>
        public Decimal Min_upper
        {
            get
            {
                return min_upper;
            }
        }

        /// <summary>
        /// Нижний предел диапазона значений спецификатора MIN
        /// </summary>
        public Decimal Min_lower
        {
            get
            {
                return min_lower;
            }
        }

        /// <summary>
        /// Значение спецификатора MIN по умолчанию
        /// </summary>
        public Decimal Min_default
        {
            get
            {
                return min_default;
            }
        }
        #endregion

        #region ДАННЫЕ СПЕЦИФИКАТОРА ROUND

        /// <summary>
        /// Наименование спецификатора ROUND
        /// </summary>
        public String Round_name
        {
            get
            {
                return round_name;
            }
        }

        /// <summary>
        /// Признак применения спецификатора ROUND ограничивающего значение свойства
        /// </summary>
        public Boolean Round_used
        {
            get
            {
                return round_used;
            }
        }
        /// <summary>
        /// Признак ограничения значений спецификатора ROUND
        /// </summary>
        public Boolean Round_limit_on
        {
            get
            {
                return round_limit_on;
            }
        }

        /// <summary>
        /// Верхний предел диапазона значений спецификатора ROUND
        /// </summary>
        public Int32 Round_upper
        {
            get
            {
                return round_upper;
            }
        }

        /// <summary>
        /// Нижний предел диапазона значений спецификатора ROUND
        /// </summary>
        public Int32 Round_lower
        {
            get
            {
                return round_lower;
            }
        }

        /// <summary>
        /// Значение спецификатора ROUND по умолчанию
        /// </summary>
        public Int32 Round_default
        {
            get
            {
                return round_default;
            }
        }
        #endregion

        /// <summary>
        /// Уникальный строковый идентификатор позиции
        /// </summary>
        public String Key
        {
            get
            {
                return "prop_val_spec_" + id_prop_data_type;
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
        /*/// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            return name;
        }*/
        #endregion

    }
}

