using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс типа данных свойства
    /// </summary>
    public partial class prop_data_type
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected prop_data_type()
        {
            imagekey = "prop_data_type_us";
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public prop_data_type(System.Data.DataRow row) : this()
        {
         
            if (row.Table.TableName == "vprop_data_type" || row.Table.TableName == "vcon_prop_data_type")
            {
                id = (Int32)row["id"];
                datatype = (eDataType)row["id"];
                name = (String)row["name"];
                desc = (String)row["desc"];
                usrdesc = (String)row["usrdesc"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }

        #endregion

        #region СВОЙСТВА КЛАССА
        private Int32 id;
        private eDataType datatype;
        private String name;
        private String desc;
        private String usrdesc;

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
        /// Пользовательское описание типа данных свойства
        /// </summary>
        public string UserDesc
        {
            get
            {
                return usrdesc;
            }
        }

        /// <summary>
        /// Лист расширений двоичных данных доступных типу данных свойства
        /// </summary>
        public virtual List<prop_data_bin_ext>  Data_bin_ext_list
        {
            get
            {
                return Manager.prop_data_bin_ext_by_id_data_type(id);
            }
        }

        /// <summary>
        /// Определение типа данных свойства, индекс поля в БД 1-14
        /// </summary>
        public eDataType DataType
        {
            get
            {
                return datatype;
            }
        }

        /// <summary>
        /// Тип данных свойства в среде Postgre SQL
        /// </summary>
        public NpgsqlTypes.NpgsqlDbType DataTypeNpgsql
        {
            get
            {
                return Manager.DataTypeNpgsql(datatype);
            }
        }


        ///////**************************
        /// <summary>
        /// Тип данных свойства в среде .Net 
        /// </summary>
        public eDataTypeNet DataTypeNet
        {
            get
            {
                return Manager.DataTypeNet(datatype); ;
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

        #region МЕТОДЫ КЛАССА
        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            return desc;
        }
        #endregion

    }
}

