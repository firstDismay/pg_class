using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс представления сведений о расширении двоичного свойства 
    /// </summary>
    public class prop_data_bin_ext
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected prop_data_bin_ext()
        {
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public prop_data_bin_ext(System.Data.DataRow row) : this()
        {

            if (row.Table.TableName == "prop_data_bin_ext")
            {
                id = (Int32)row["id"];       
                name = (String)row["name"];
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
        
        /// <summary>
        /// Идентификатор расширения бинарного свойства
        /// </summary>
        public Int32 Id
        { get
            {
                return id;
            }
        }

        /// <summary>
        /// Обозначение расширения бинарного свойства
        /// </summary>
        public string Name
        {
            get
            {
                return name;
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
