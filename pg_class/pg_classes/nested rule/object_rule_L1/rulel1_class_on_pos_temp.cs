using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс правила разрешения уровня 1 класс на шаблон определяющего доступность вложения объектов в позиции
    /// </summary>
    public partial class rulel1_class_on_pos_temp
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected rulel1_class_on_pos_temp()
        {
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public rulel1_class_on_pos_temp(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "vrulel1_class_on_pos_temp")
            {
                id_class = (Int64)row["id_class"];
                id_group = (Int64)row["id_group"];
                id_pos_temp = (Int64)row["id_pos_temp"];
                name_rule = (String)row["name_rule"];
                is_create = (Boolean)row["is_create"];
                is_use = (Boolean)row["is_use"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int64 id_class;
        private Int64 id_group;
        private Int64 id_pos_temp;
        private String name_rule;
        private Boolean is_create;
        private Boolean is_use;

        /// <summary>
        /// Идентификатор класс включенной в правило вложенности уровня 1
        /// </summary>
        public Int64 Id_class { get => id_class; }

        /// <summary>
        /// Идентификатор группы включенной в правило вложенности уровня 1
        /// </summary>
        public Int64 Id_group { get => id_group; }

        /// <summary>
        /// Идентификатор шаблона позиции включенного в правило вложенности уровня 1
        /// </summary>
        public Int64 Id_pos_temp { get => id_pos_temp; }

        /// <summary>
        /// Признак правила используемого объектами
        /// </summary>
        public Boolean Is_use { get => is_use; }

        /// <summary>
        /// Признак правила созданного в таблице правил
        /// </summary>
        public Boolean Is_create { get => is_create; }

        /// <summary>
        /// Описаетльное наименование правила вложенности уровня 1
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
        /// Класс назначенная правилом
        /// </summary>
        public vclass Class_assigned
        {
            get
            {
                return Manager.class_act_by_id(id_class);
            }
        }

        /// <summary>
        /// Группа назначенная правилом
        /// </summary>
        public group Group_assigned
        {
            get
            {
                return Manager.group_by_id(id_group);
            }
        }

        /// <summary>
        /// Шаблон позиции правила
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
                sb.Append("rulel1");
                if (is_use)
                {
                    sb.Append("_is_used_us");
                }
                else
                {
                    sb.Append("_us");
                }
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
                sb.Append("nested_rule");
                if (is_use)
                {
                    sb.Append("_is_used_s");
                }
                else
                {
                    sb.Append("_s");
                }
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
