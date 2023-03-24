using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс свойства шаблона позиции
    /// </summary>
    public partial class pos_temp_prop
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected pos_temp_prop()
        {
            on_change = false;
        }


        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public pos_temp_prop(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "vpos_temp_prop")
            {
                id = (Int64)row["id"];
                id_conception = (Int64)row["id_conception"];
                id_pos_temp = (Int64)row["id_pos_temp"];
                id_prop_type = (Int32)row["id_prop_type"];
                id_data_type = (Int32)row["id_data_type"];
                name = (String)row["name"];
                name_len = row.Table.Columns["name"].MaxLength;
                desc = (String)row["desc"];
                desc_len = row.Table.Columns["desc"].MaxLength;
                sort = (Int32)row["sort"];
                on_override = (Boolean)row["on_override"];
                on_val = (Boolean)row["on_val"];
                ready = (Boolean)row["ready"];
                on_global = (Boolean)row["on_global"];
                id_global_prop = (Int64)row["id_global_prop"];
                string_val = (String)row["string_val"];
                timestamp = Convert.ToDateTime(row["timestamp"]);
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }

        #endregion

        #region СВОЙСТВА КЛАССА


        private DateTime timestamp;
        /// <summary>
        /// Штамп времени свойства шаблона позиции
        /// </summary>
        public DateTime Timestamp
        {
            get
            {
                return timestamp;
            }
        }

        private Int64 id = 0;
        /// <summary>
        /// Идентификатор свойства
        /// </summary>
        public Int64 Id
        {
            get
            {
                return id;
            }
        }

        private Int64 id_conception;
        /// <summary>
        /// Идентификатор концепции
        /// </summary>
        public Int64 Id_conception
        {
            get
            {
                return id_conception;
            }
        }
        private Int32 id_prop_type;
        /// <summary>
        /// Идентификатор типа свойства класса
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

        private Int32 id_data_type;
        /// <summary>
        /// Идентификатор типа данных свойства класса
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
        /// Тип данных свойства класса
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

        private Boolean on_override;
        /// <summary>
        /// Признак наследованного свойства с переопределяемым на уровне свойства значением
        /// </summary>
        public Boolean On_override
        {
            get
            {
                return on_override;
            }
            set
            {
                if (on_override != value)
                {
                    on_override = value;
                    on_change = true;
                }
            }
        }

        private String name;
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

        private Int32 name_len;
        /// <summary>
        /// Максимально допустимая длинна строкового поля
        /// </summary>
        public static Int32 Name_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_pos = manager.Instance().TableByName("vpos_temp_prop");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["name"].MaxLength;
                }
                return result;
            }
        }

        private String desc;
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
                    if (value.Length > name_len)
                    {
                        value = value.Substring(0, name_len);
                    }
                    desc = value;
                    on_change = true;
                }
            }
        }

        private Int32 desc_len;
        /// <summary>
        /// Максимально допустимая длинна строкового поля
        /// </summary>
        public static Int32 Desc_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_pos = manager.Instance().TableByName("vpos_temp_prop");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["desc"].MaxLength;
                }
                return result;
            }
        }


        private Int32 sort;
        /// <summary>
        /// Поле сортировки свойств позиций/шаблонов позиций
        /// </summary>
        public int Sort
        {
            get
            {
                return sort;
            }
            set
            {
                if (sort != value)
                {
                    sort = value;
                    on_change = true;
                }
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

        private Int64 id_pos_temp;
        /// <summary>
        /// Ид шаблона позиции
        /// </summary>
        public long Id_pos_temp
        {
            get
            {
                return id_pos_temp;
            }
        }

        private Boolean on_val;
        /// <summary>
        /// Признак значения установленного на уровне свойства
        /// </summary>
        public Boolean On_val
        {
            get
            {
                return on_val;
            }
        }

        private Boolean ready;
        /// <summary>
        /// Значение свойство инициализировано, готово к созданию позиции, шаг №2
        /// </summary>
        public Boolean Ready
        {
            get
            {
                return ready;
            }
        }

        private Boolean on_global;
        /// <summary>
        /// Признак глобального свойства
        /// </summary>
        public Boolean On_global
        {
            get
            {
                return on_global;
            }
        }

        private Int64 id_global_prop;
        /// <summary>
        /// Идентификатор глобального свойства
        /// </summary>
        public Int64 Id_global_prop
        {
            get
            {
                return id_global_prop;
            }
        }

        private String string_val;
        /// <summary>
        /// Строковое представление текущего значения свойства
        /// </summary>
        public String String_val
        {
            get
            {
                return string_val;
            }
        }

        /// <summary>
        /// Ключ объекта
        /// </summary>
        public String ImageKey
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("pos_temp_prop_");
                if (On_override)
                {
                    sb.Append("override_");
                }
                if (On_val)
                {
                    sb.Append("valon_");
                }
                else
                {
                    sb.Append("valoff_");
                }
                if (On_global)
                {
                    sb.Append("on_global_");
                }
                sb.Append("us");
                return sb.ToString();
            }
        }

        /// <summary>
        /// Ключ выделенного объекта
        /// </summary>
        public String SelectedImageKey
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("pos_temp_prop_");
                if (On_override)
                {
                    sb.Append("override_");
                }
                if (On_val)
                {
                    sb.Append("valon_");
                }
                else
                {
                    sb.Append("valoff_");
                }
                if (On_global)
                {
                    sb.Append("on_global_");
                }
                sb.Append("s");
                return sb.ToString();
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
        /// <summary>
        /// Свойство определяет актуальность текущего состояния
        /// </summary>
        public eEntityState Is_actual()
        {
            return Manager.pos_temp_prop_is_actual(this);
        }

        /// <summary>
        /// Обновление концепции в БД
        /// </summary>
        public void Update()
        {
            if (on_change)
            {
                Manager.pos_temp_prop_upd(this);
                Refresh();
                on_change = false;
            }
        }

        /// <summary>
        /// Обновление представления класса из БД, для исторических представлений всегда true
        /// </summary>
        public Boolean Refresh()
        {
            pos_temp_prop temp = null;
            Boolean Result = false;
            temp = Manager.pos_temp_prop_by_id(id);
            if (temp != null)
            {
                id = temp.Id;
                id_conception = temp.Id_conception;
                id_pos_temp = temp.Id_pos_temp;
                id_prop_type = temp.Id_prop_type;
                id_data_type = temp.Id_data_type;
                name = temp.Name;
                desc = temp.Desc;
                sort = temp.Sort;
                on_override = temp.On_override;
                on_val = temp.On_val;
                ready = temp.Ready;
                on_global = temp.On_global;
                id_global_prop = temp.Id_global_prop;
                string_val = temp.String_val;
                timestamp = temp.Timestamp;
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
        /// Лист доступных к загрузке расширений файлов двоичного свойства
        /// </summary>
        public List<prop_data_bin_ext> prop_data_bin_ext_list_get()
        {
            List<prop_data_bin_ext> Result = new List<prop_data_bin_ext>();
            if (id_data_type == 8)
            {
                Result = Manager.prop_data_bin_ext_by_all();
            }
            return Result;
        }

        /// <summary>
        /// Лист доступных к загрузке расширений файлов двоичного свойства
        /// </summary>
        public List<String> prop_data_bin_ext_list_get2()
        {
            List<String> Result = new List<String>();
            if (id_data_type == 8)
            {
                Result = Manager.prop_data_bin_ext_by_all2();
            }
            return Result;
        }
        /// <summary>
        /// Концепция свойства класса
        /// </summary>
        public conception GetConception()
        {
            return Manager.conception_by_id(id_conception);
        }

        /// <summary>
        /// Метод удаляет текущее свойство
        /// class_prop_del
        /// </summary>
        public void Del()
        {
            Manager.pos_temp_prop_del(this);
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
