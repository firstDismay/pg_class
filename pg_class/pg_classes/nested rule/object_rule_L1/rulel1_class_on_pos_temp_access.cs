using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс разрешения правил уровня 1 группа на шаблон определяющего доступность вложения объектов в позиции
    /// </summary>
    public partial class rulel1_class_on_pos_temp_access
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected rulel1_class_on_pos_temp_access()
        {
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public rulel1_class_on_pos_temp_access(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "vrulel1_class_on_pos_temp_tbl_access")
            {
                id_con = (Int64)row["id_con"];
                id_class = (Int64)row["id_class"];
                id_group = (Int64)row["id_group"];
                id_pos_temp = (Int64)row["id_pos_temp"];
                id_class_assigned = (Int64)row["id_class_assigned"];
                class_level = (Int32)row["class_level"];
                on_assigned = (Boolean)row["on_assigned"];
                name_rule = (String)row["name_rule"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int64 id_con;
        private Int64 id_class;
        private Int64 id_group;
        private Int64 id_class_assigned;
        private Int64 id_pos_temp;
        private Int32 class_level;
        private Boolean on_assigned;
        private String name_rule;

        /// <summary>
        /// Идентификатор концепции текущего разрешения правила вложенности уровня 1
        /// </summary>
        public Int64 Id_conception { get => id_con; }

        /// <summary>
        /// Идентификатор группы текущего разрешения правила вложенности уровня 1
        /// </summary>
        public Int64 Id_class { get => id_class; }

        /// <summary>
        /// Идентификатор группы текущего разрешения правила вложенности уровня 1
        /// </summary>
        public Int64 Id_group { get => id_group; }

        /// <summary>
        /// Идентификатор класс включенного в правило вложенности уровня 1 определяющего текущее разрешение
        /// </summary>
        public Int64 Id_class_assigned { get => id_class_assigned; }

        /// <summary>
        /// Абсолютный уровень вложенности класса входящего в разрешение
        /// </summary>
        public Int32 Class_level { get => class_level; }

        /// <summary>
        /// Идентификатор шаблона позиции текущего разрешения правила вложенности уровня 1
        /// </summary>
        public Int64 Id_pos_temp { get => id_pos_temp; }

        /// <summary>
        /// Признак прямого разрешения созданного на основе правила вложенности уровня 1
        /// true - правило
        /// false - разрешение на основе правила
        /// </summary>
        public Boolean On_assigned { get => on_assigned; }

        /// <summary>
        /// Описательное наименование текущего разрешения правила вложенности уровня 1
        /// </summary>
        public String Name_rule { get => name_rule; }

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
        /// Класс назначенный правилом определяющим текущее разрешение
        /// </summary>
        public vclass Class_assigned
        {
            get
            {
                return Manager.class_act_by_id(id_class_assigned);
            }
        }

        /// <summary>
        /// Группа текущего разрешения
        /// </summary>
        public group Group_allowed
        {
            get
            {
                return Manager.group_by_id(id_group);
            }
        }

        /// <summary>
        /// Шаблон позиции текущего разрешения
        /// </summary>
        public pos_temp Pos_temp
        {
            get
            {
                return Manager.pos_temp_by_id(id_pos_temp);
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
                sb.Append("accessl1_group_on_pos_temp_us");
                
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
                sb.Append("accessl1_group_on_pos_temp_s");
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
