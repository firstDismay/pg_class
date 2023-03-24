using System;
using System.Text;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс правила белого списка шаблонов позиций
    /// </summary>
    public partial class pos_temp_nested_rule
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected pos_temp_nested_rule()
        {
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public pos_temp_nested_rule(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "vpos_temp_nested_rule")
            {
                id_con = (Int64)row["id_con"];
                id_pos_temp = (Int64)row["id_pos_temp"];
                id_pos_temp_nested = (Int64)row["id_pos_temp_nested"];
                on_limit = (Boolean)row["on_limit"];
                limit_max = (Int32)row["limit_max"];
                limit_min = (Int32)row["limit_min"];
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

        private Int64 id_con;
        private Int64 id_pos_temp;
        private Int64 id_pos_temp_nested;
        private Int32 limit_max;
        private Int32 limit_min;
        private Boolean on_limit;
        private Boolean is_use;
        private Boolean is_create;

        /// <summary>
        /// Идентификатор концепции правила
        /// </summary>
        public Int64 Id_conception { get => id_con; }

        /// <summary>
        /// Идентификатор шаблона позиции допускающего вложение
        /// </summary>
        public Int64 Id_pos_temp { get => id_pos_temp; }

        /// <summary>
        /// Идентификатор вкладываемого шаблона позиций
        /// </summary>
        public Int64 Id_pos_temp_nested { get => id_pos_temp_nested; }

        /// <summary>
        /// Верхний предел правила для вкдадываемого шаблона
        /// </summary>
        public Int32 Limit_max
        {
            get
            {
                return limit_max;
            }
            set
            {
                limit_max = value;
            }
        }

        /// <summary>
        /// Нижний предел правила для вкдадываемого шаблона
        /// </summary>
        public Int32 Limit_min
        {
            get
            {
                return limit_min;
            }
        }

        /// <summary>
        /// Признак правила используемого объектами
        /// </summary>
        public Boolean Is_use { get => is_use; }


        /// <summary>
        /// Признак включенного численного ограничения вкладываемых шаблонов
        /// </summary>
        public Boolean On_limit { get => on_limit; }

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
        /// Шаблон позиции вкладываемый, согласно текущего правила
        /// </summary>
        public pos_temp Pos_temp_nested
        {
            get
            {
                return Manager.pos_temp_by_id(id_pos_temp_nested);
            }
        }

        /// <summary>
        /// Шаблон позиции допускающий вложение согласно текущего правила
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
                sb.Append("white_list");
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
                sb.Append("white_list");
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

        /// <summary>
        /// Обновление представления правила в БД
        /// </summary>
        public void Update()
        {
            Manager.pos_temp_nested_include(id_pos_temp, id_pos_temp_nested, limit_max);
            Refresh();
        }

        /// <summary>
        /// Обновление представления правила из БД
        /// </summary>
        public Boolean Refresh()
        {
            pos_temp_nested_rule temp;
            Boolean Result = false;
            temp = Manager.pos_temp_nested_whitelist_by_id(id_pos_temp, id_pos_temp_nested);

            if (temp != null)
            {
                id_con = temp.Id_conception;
                id_pos_temp = temp.Id_pos_temp;
                id_pos_temp_nested = temp.Id_pos_temp_nested;
                on_limit = temp.On_limit;
                limit_max = temp.Limit_max;
                limit_min = temp.Limit_min;
                is_create = temp.Is_create;
                is_use = temp.Is_use;
                Result = true;
            }
            else
            {
                Result = false;
            }
            return Result;
        }

        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Правило: ");
            sb.Append(Pos_temp.ToString());
            sb.Append(" - ");
            sb.Append(Pos_temp_nested.ToString());
            return sb.ToString();
        }
        #endregion


    }
}
