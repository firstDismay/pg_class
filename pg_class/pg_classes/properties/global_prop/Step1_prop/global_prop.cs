using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс глобальных свойств концепции
    /// </summary>
    public partial class global_prop
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected global_prop()
        {
            on_change = false;
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public global_prop(System.Data.DataRow row) : this()
        {

            if (row.Table.TableName == "vglobal_prop")
            {
                id = (Int64)row["id"];
                id_conception = (Int64)row["id_conception"];
                id_prop_type = (Int32)row["id_prop_type"];
                id_data_type = (Int32)row["id_data_type"];
                name = (String)row["name"];
                name_len = row.Table.Columns["name"].MaxLength;
                desc = (String)row["desc"];
                desc_len = row.Table.Columns["desc"].MaxLength;
                is_use = (Boolean)row["is_use"];
                timestamp = Convert.ToDateTime(row["timestamp"]);
                id_area_val = (Int64)row["id_area_val"];
                timestamp_area_val = Convert.ToDateTime(row["timestamp_area_val"]);
                on_val = (Boolean)row["on_val"];
                ready = (Boolean)row["ready"];
                visible = (Boolean)row["visible"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        private Int64 id = 0;
        private Int64 id_conception = 0;
        private Int32 id_prop_type;
        private Int32 id_data_type;
        private String name;
        private Int32 name_len;
        private String desc;
        private Int32 desc_len;
        private Boolean is_use;
        private DateTime timestamp;
        private Boolean on_val;
        private Boolean ready;
        private Boolean visible;

        private Int64 id_area_val = 0;
        private DateTime timestamp_area_val;

        /// <summary>
        /// Идентификатор глобального свойства концепции
        /// </summary>
        public Int64 Id { get => id; }

        /// <summary>
        /// Идентификатор концепции свойства
        /// </summary>
        public Int64 Id_conception { get => id_conception; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    if (value.Length > name_len)
                    {
                        value = value.Substring(0, name_len);
                    }
                    name = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Максимально допустимая длинна строкового поля
        /// </summary>
        public static Int32 Name_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_pos = manager.Instance().TableByName("vglobal_prop");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["name"].MaxLength;
                }
                return result;
            }
        }
        /// <summary>
        /// Описание позиций
        /// </summary>
        public string Desc
        {
            get
            {
                return desc;
            }
            set
            {
                if (desc != value)
                {
                    if (value.Length > desc_len)
                    {
                        value = value.Substring(0, desc_len);
                    }
                    desc = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Максимально допустимая длинна строкового поля
        /// </summary>
        public static Int32 Desc_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_pos = manager.Instance().TableByName("vglobal_prop");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["desc"].MaxLength;
                }
                return result;
            }
        }

        /// <summary>
        /// Штамп времени глобального свойства
        /// </summary>
        public DateTime Timestamp
        {
            get
            {
                return timestamp;
            }
        }

        /// <summary>
        /// Идентификатор типа свойства
        /// </summary>
        public Int32 Id_prop_type
        {
            get
            {
                return id_prop_type;
            }
            set
            {
                if (id_prop_type != value)
                {
                    id_prop_type = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Тип свойства
        /// </summary>
        public ePropType Prop_type
        {
            get
            {
                return (ePropType)id_prop_type;
            }
        }

        /// <summary>
        /// Идентификатор типа данных свойства
        /// </summary>
        public Int32 Id_data_type
        {
            get
            {
                return id_data_type;
            }
            set
            {
                if (id_data_type != value)
                {
                    id_data_type = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Тип данных свойства
        /// </summary>
        public eDataType Datatype
        {
            get
            {
                return (eDataType)id_data_type;
            }
        }

        /// <summary>
        /// Тип данных свойства в среде Postgre SQL
        /// </summary>
        public NpgsqlTypes.NpgsqlDbType DataTypeNpgsql
        {
            get
            {
                return Manager.DataTypeNpgsql(Datatype);
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
                return Manager.DataTypeNet(Datatype); ;
            }
        }

        /// <summary>
        /// Признак используемого глобального свойства
        /// </summary>
        public Boolean Is_use
        {
            get
            {
                return is_use;
            }
        }

        /// <summary>
        /// Область значений глобального свойства определена
        /// </summary>
        public Boolean On_val
        {
            get
            {
                return on_val;
            }
        }

        /// <summary>
        /// Область значений свойства определена, свойство готово к связыванию, шаг №2
        /// </summary>
        public Boolean Ready
        {
            get
            {
                return ready;
            }
        }

        /// <summary>
        /// Определяет видимость свойства в ограниченных списках для целей поиска и навигации
        /// </summary>
        public Boolean Visible
        {
            get
            {
                return visible;
            }
            set
            {
                if (visible != value)
                {
                    visible = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Идентификатор области значений глобального свойства концепции
        /// </summary>
        public Int64 Id_area_val { get => id_area_val; }

        /// <summary>
        /// Штамп времени области значений глобального свойства применим для объектных свойств
        /// </summary>
        public DateTime Timestamp_area_val
        {
            get
            {
                return timestamp_area_val;
            }
        }

        private Boolean on_change;
        /// <summary>
        /// Свойство определяющее потребность в обновлении данных БД
        /// </summary>
        public Boolean On_change
        {
            get
            {
                return on_change;
            }
        }

        /// <summary>
        /// Ссылка на менеджера данных
        /// </summary>
        protected manager Manager
        {
            get
            {
                return manager.Instance();
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
                sb.Append("global_prop_");
                sb.Append("us");
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
                sb.Append("global_prop_");
                sb.Append("s");
                return sb.ToString();
            }
        }

        #endregion

        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Свойство определяет актуальность текущего состояния
        /// </summary>
        public eEntityState Is_actual()
        {
            return Manager.global_prop_is_actual(this);
        }

        /// <summary>
        /// Обновление глобального свойства
        /// </summary>
        public void Update()
        {
            if (on_change)
            {
                Manager.global_prop_upd(this);
                Refresh();
                on_change = false;
            }
        }

        /// <summary>
        /// Обновление данных глобального свойства
        /// </summary>
        public Boolean Refresh()
        {
            global_prop temp = null;
            Boolean Result = false;

            temp = Manager.global_prop_by_id(id);
            if (temp != null)
            {
                id = temp.Id;
                id_conception = temp.Id_conception;
                id_prop_type = temp.Id_prop_type;
                id_data_type = temp.Id_data_type;
                name = temp.Name;
                desc = temp.Desc;
                is_use = temp.Is_use;
                timestamp = temp.Timestamp;
                id_area_val = temp.Id_area_val;
                timestamp_area_val = temp.Timestamp_area_val;
                on_val = temp.On_val;
                ready = temp.Ready;
                visible = temp.Visible;
                Result = true;
                on_change = false;
            }
            else
            {
                Result = false;
            }
            return Result;
        }

        /// <summary>
        /// Тип свойства
        /// </summary>
        public prop_type prop_type_get()
        {
            return Manager.prop_type_by_id(id_prop_type);
        }

        /// <summary>
        /// Тип данных свойства
        /// </summary>
        public con_prop_data_type prop_data_type_get()
        {
            return Manager.Con_prop_data_type_by_id(Id_conception, Id_data_type);
        }

        /// <summary>
        /// Концепция свойства класса
        /// conception_by_id
        /// </summary>
        public conception Conception_get()
        {
            return Manager.conception_by_id(id_conception);
        }

        /// <summary>
        /// Метод удаляет текущее свойство
        /// global_prop_del
        /// </summary>
        public void Del()
        {
            Manager.global_prop_del(this);
        }

        #endregion

        #region СВОЙСТВА МЕТОДЫ ДЛЯ РАБОТЫ ТИПАМИ ДАННЫХ СВОЙСТВ
        /// <summary>
        /// Лист всех типов данных свойств класса
        /// </summary>
        public List<prop_data_type> Prop_data_type_all
        {
            get
            {
                return Manager.prop_data_type_by_all();
            }
        }

        /// <summary>
        /// Лист типов данных свойств класса по типу свойства
        /// </summary>
        public List<con_prop_data_type> Prop_data_type
        {
            get
            {
                return Manager.Con_prop_data_type_by_id_prop_type(Id_conception, Id_prop_type);
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
