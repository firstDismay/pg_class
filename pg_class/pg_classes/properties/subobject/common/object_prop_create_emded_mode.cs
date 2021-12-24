using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Режим создания встроенных объектов при создании объектного свойства объекта
    /// </summary>
    public partial class object_prop_create_emded_mode
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected object_prop_create_emded_mode()
        {
            imagekey = "object_prop_create_emded_mode_us";
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public object_prop_create_emded_mode(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "vobject_prop_create_emded_mode")
            {
                id = (Int32)row["id"];
                name = (String)row["name"];
                desc = (String)row["desc"];
                on = (Boolean)row["on"];
                sort = (Int32)row["sort"];
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
        private Boolean on;
        private Int32 sort;

        /// <summary>
        /// Идентификатор режима объектов при создании объектного свойства объекта
        /// </summary>
        public Int32 Id_mode
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// Идентификатор режима объектов при создании объектного свойства объекта
        /// </summary>
        public eObjectPropCreateEmdedMode Mode
        {
            get
            {
                return (eObjectPropCreateEmdedMode)id;
            }
        }

        /// <summary>
        /// Тип свойства класса
        /// </summary>
        public ePropType Prop_type
        {
            get
            {
                return (ePropType)id;
            }
        }

        /// <summary>
        /// Наименование типа данных свойства
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Описание типа данных свойства
        /// </summary>
        public string Desc
        {
            get
            {
                return desc;
            }
        }

        /// <summary>
        /// Признак доступности типа свойства
        /// </summary>
        public Boolean On
        {
            get
            {
                return on;
            }
        }

        /// <summary>
        /// Порядок сортировки типа свойства
        /// </summary>
        public Int32 Sort
        {
            get
            {
                return sort;
            }
        }


        /// <summary>
        /// Уникальный строковый идентификатор позиции
        /// </summary>
        public String Key
        {
            get
            {
                return "prop_type" + id.ToString();
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

