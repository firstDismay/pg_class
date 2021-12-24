using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс разрешающего правила уровня 2 класс на позицию
    /// </summary>
    public partial class rulel2_class_on_position
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected rulel2_class_on_position()
        {
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public rulel2_class_on_position(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "vrulel2_class_on_position")
            {
                id_class = (Int64)row["id_class"];
                id_position = (Int64)row["id_position"];
                name_rule = (String)row["name_rule"];
                is_use = (Boolean)row["is_use"];
                is_create = (Boolean)row["is_create"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion
        
        #region СВОЙСТВА КЛАССА

        private Int64 id_class;
        private Int64 id_position;
        private String name_rule;
        private Boolean is_use;
        private Boolean is_create;

        /// <summary>
        /// Идентификатор класса включенного в разрешающее правило уровня 2 класс на позицию
        /// </summary>
        public Int64 Id_class { get => id_class; }

        /// <summary>
        /// Идентификатор позиции включенной в разрешающее правило уровня 2 класс на позицию
        /// </summary>
        public Int64 Id_position { get => id_position; }


        /// <summary>
        /// Признак правила используемого объектами
        /// </summary>
        public Boolean Is_use { get => is_use; }

        /// <summary>
        /// Признак правила добавленного в таблицу правил БД
        /// </summary>
        public Boolean Is_create { get => is_create; }

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

        /// <summary>
        /// Класс включенный в разрешающее правило уровня 2 класс на позицию
        /// </summary>
        public vclass Class_rule
        {
            get
            {
                return Manager.class_act_by_id(id_class);
            }
        }

        /// <summary>
        /// Позиция включенная в разрешающее правило уровня 2 класс на позицию
        /// </summary>
        public position Position_rule
        {
            get
            {
                return Manager.pos_by_id(id_position);
            }
        }

        
        /// <summary>
        /// Ключ объекта
        /// </summary>
        public string ImageKey
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("rulel2_class_on_position");
                if (is_use)
                {
                    sb.Append("_is_used");
                }

                if (is_create)
                {
                    sb.Append("_is_create");
                }

                sb.Append("_us");
                
                return sb.ToString();
            }
        }



        /// <summary>
        /// Ключ выделенного объекта
        /// </summary>
        public string SelectedImageKey
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("rulel2_class_on_position");
                if (is_use)
                {
                    sb.Append("_is_used");
                }

                if (is_create)
                {
                    sb.Append("_is_create");
                }

                sb.Append("_s");

                return sb.ToString();
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
            return name_rule;
        }
        #endregion

        
    }
}
