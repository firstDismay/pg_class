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
    /// Класс перечислений для свойств типа перечисление
    /// </summary>
    public partial class prop_enum
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected prop_enum()
        {
            on_change = false;
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public prop_enum(System.Data.DataRow row) : this()
        {

            if (row.Table.TableName == "vprop_enum")
            {
                id_conception = (Int64)row["id_conception"];
                id_prop_enum = (Int64)row["id_prop_enum"];
                id_prop_enum_use_area = (Int32)row["id_prop_enum_use_area"];
                id_data_type = (Int32)row["id_data_type"];
                name = (String)row["name"];
                name_len = row.Table.Columns["name"].MaxLength;
                desc = (String)row["desc"];
                desc_len = row.Table.Columns["desc"].MaxLength;
                is_use = (Boolean)row["is_use"];
                has_items = (Boolean)row["has_items"];
                timestamp = (DateTime)row["timestamp"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int64 id_conception;
        private Int64 id_prop_enum;
        private Int32 id_prop_enum_use_area;
        private Int32 id_data_type;
        private String name;
        private Int32 name_len;
        private String desc;
        private Int32 desc_len;
        private Boolean is_use;
        private Boolean has_items;
        private DateTime timestamp;

        /// <summary>
        /// Идентификатор концепции
        /// </summary>
        public Int64 Id_conception { get => id_conception; }

        /// <summary>
        /// Идентификатор перечисления
        /// </summary>
        public Int64 Id_prop_enum { get => id_prop_enum; }

        /// <summary>
        /// Область применения идентификаторв
        /// </summary>
        public Int32 Id_prop_enum_use_area
        {
            get
            {
                return id_prop_enum_use_area;
            }
            set
            {
                if (id_prop_enum_use_area != value)
                {
                    id_prop_enum_use_area =(Int32)value;
                    on_change = true;
                }
            }
        }      

        /// <summary>
        /// Область применения идентификаторв
        /// </summary>
        public eProp_enum_use_area prop_enum_use_area
        {
            get
            {
                return (eProp_enum_use_area)id_prop_enum_use_area;
            }
        }

        /// <summary>
        /// Идентификатор типа данных перечисления
        /// </summary>
        public Int32 Id_data_type
        {
            get
            {
                return id_data_type; ;
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

            set
            {
                if ((eDataType)id_data_type != value)
                {
                    id_data_type = (Int32)value;
                    on_change = true;
                }
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
        /// Перечисление используется
        /// </summary>
        public Boolean Is_use { get => is_use; }
        
        /// <summary>
        /// Перечисление содержит элементы
        /// </summary>
        public Boolean Has_items { get => has_items; }

        /// <summary>
        /// Наименование перечисления
        /// </summary>
        public string NameEnum
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
        public static Int32 NameEnum_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_pos  = manager.Instance().TableByName("vprop_enum");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["name"].MaxLength;
                }
                return result;
            }
        }

        /// <summary>
        /// Описание перечисления
        /// </summary>
        public String Desc
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
                DataTable tbl_pos  = manager.Instance().TableByName("vprop_enum");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["desc"].MaxLength;
                }
                return result;
            }
        }

        /// <summary>
        /// Штамп времени перечисления
        /// </summary>
        public DateTime Timestamp { get => timestamp; }

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
        private manager Manager
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
                sb.Append("prop_enum_");

                switch (id_data_type)
                {
                    case 1:
                        sb.Append("char_");
                        break;
                    case 3:
                        sb.Append("numeric_");
                        break;
                }
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
                sb.Append("prop_enum_");

                switch (id_data_type)
                {
                    case 1:
                        sb.Append("char_");
                        break;
                    case 3:
                        sb.Append("numeric_");
                        break;
                }
                sb.Append("s");
                return sb.ToString();
            }
        }
        #endregion

        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Свойство определяет актуальность текущего состояния группы
        /// </summary>
        public eEntityState Is_actual()
        {
            return Manager.prop_enum_is_actual(this);
        }

        /// <summary>
        /// Обновление группы в БД
        /// </summary>
        public void Update()
        {
            if (on_change)
            {
                Manager.prop_enum_upd(this);
                Refresh();
                on_change = false;
            }
        }

        /// <summary>
        /// Обновление группы из БД
        /// </summary>
        public Boolean Refresh()
        {
            prop_enum temp;
            Boolean Result = false;
            temp = Manager.prop_enum_by_id(Id_prop_enum);
            
            if (temp != null)
            {
                id_conception = temp.Id_conception;
                id_prop_enum = temp.Id_prop_enum;
                id_prop_enum_use_area = (Int32)temp.Id_prop_enum_use_area;
                id_data_type = temp.Id_data_type;
                name = temp.NameEnum;
                desc = temp.Desc;
                is_use = temp.Is_use;
                has_items = temp.Has_items;
                timestamp = temp.Timestamp;
                Result = true;
            }
            else
            {
                Result = false;
            }
            return Result;
        }

        /// <summary>
        /// Копировать перечисление в указанную концепцию
        /// </summary>
        public prop_enum prop_enum_copy_to(conception Conception)
        {
            return Manager.prop_enum_copy_to(this, Conception);
        }

        /// <summary>
        /// Метод возвращает общее количество элементов в перечислении
        /// </summary>
        public Int32 Items_count_get()
        {
            return Manager.prop_enum_count_val_by_id(this);
        }
        #endregion

        #region МЕТОДЫ КЛАССА ДЛЯ ДОСТУПА К ДАННЫМ ОБЛАСТЕЙ ПРИМЕНЕНИЯ ПЕРЕЧИСЛЕНИЯ

        /// <summary>
        /// Метод возвращает назначенный класс области применения перечисления
        /// </summary>
        public prop_enum_use_area prop_enum_use_area_get()
        {
            return Manager.prop_enum_use_area_by_id(id_prop_enum_use_area);
        }

        /// <summary>
        /// Метод возвращает лист классов областей применения перечисления
        /// </summary>
        public List<prop_enum_use_area> prop_enum_use_area_list_get()
        {
            return Manager.prop_enum_use_area_by_all();
        }

        #endregion    

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(name);
            switch (prop_enum_use_area)
            {
                case eProp_enum_use_area.none:
                    sb.Append(" []");
                    break;
                case eProp_enum_use_area.objects:
                    sb.Append(" [О]");
                    break;
                case eProp_enum_use_area.objects_and_positions:
                    sb.Append(" [ОП]");
                    break;
                case eProp_enum_use_area.positions:
                    sb.Append(" [П]");
                    break;
            }

            return sb.ToString();
        }
        #endregion

    }
}
