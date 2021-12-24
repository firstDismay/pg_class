using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Data;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс измеряемой величины
    /// </summary>
    public partial class unit
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected unit()
        {
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public unit(System.Data.DataRow row) : this()
        {

            if (row.Table.TableName == "vunits")
            {
                id = (Int32)row["id"];
                name = (String)row["name"];
                desc = (String)row["desc"];
                not_fractional = (Boolean)row["not_fractional"];
                is_entity = (Boolean)row["is_entity"];
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
        private Boolean not_fractional;
        private Boolean is_entity;


        /// <summary>
        /// Идентификатор измеряемой величины
        /// </summary>
        public Int32 Id { get => id; }

        /// <summary>
        /// Тип измеряемой величины
        /// </summary>
        public eUnit Unit { get => (eUnit)id; }
        
        /// <summary>
        /// Наименование измеряемой величины
        /// </summary>
        public String Name { get => name; }

        /// <summary>
        /// Описание измеряемой величины
        /// </summary>
        public String Desc { get => desc; }


        /// <summary>
        /// Признак запрета дробных значений измеряемой величины
        /// </summary>
        public Boolean Not_fractional { get => not_fractional; }

        /// <summary>
        /// Учет сущностей БД 
        /// </summary>
        public Boolean Is_Entity { get => is_entity; }


        /// <summary>
        /// Уникальный строковый идентификатор
        /// </summary>
        public String Key
        {
            get
            {
                return String.Format("unit_{0}", id);
            }
        }
        /// <summary>
        /// Ключ объекта
        /// </summary>
        public string ImageKey
        {
            get
            {
                return String.Format("{0}_us", Unit.ToString("g"));
            }
        }

        /// <summary>
        /// Ключ выделенного объекта
        /// </summary>
        public string SelectedImageKey
        {
            get
            {
                return String.Format("{0}_s", Unit.ToString("g"));
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
