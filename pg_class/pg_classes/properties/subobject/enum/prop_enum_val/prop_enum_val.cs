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
    public partial class prop_enum_val
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected prop_enum_val()
        {
            on_change = false;
            imagekey = "prop_enum_val_us";
            selectedimagekey = "prop_enum_val_s";
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public prop_enum_val(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "vprop_enum_val")
            {
                id_conception = (Int64)row["id_conception"];
                id_prop_enum = (Int64)row["id_prop_enum"];
                id_prop_enum_use_area = (Int32)row["id_prop_enum_use_area"];
                id_prop_enum_val = (Int64)row["id_prop_enum_val"];
                id_data_type = (Int32)row["id_data_type"];
                val_numeric = (Decimal)row["val_numeric"];
                val_varchar = (String)row["val_varchar"];
                val_varchar_len = row.Table.Columns["val_varchar"].MaxLength;
                is_use = (Boolean)row["is_use"];
                sort = (Int64)row["sort"];
                id_object_reference = (Int64)row["id_object_reference"];
                has_object_reference = (Boolean)row["has_object_reference"];
                timestamp_prop_enum = (DateTime)row["timestamp_prop_enum"];
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
        private Int64 id_prop_enum_val;
        private Int64 id_prop_enum;
        private Int32 id_prop_enum_use_area;
        private Int32 id_data_type;

        private Decimal val_numeric;
        private String val_varchar;
        private Int32 val_varchar_len;

        private Int64 sort;
        private Int64 id_object_reference;
        private Boolean is_use;
        private Boolean has_object_reference;
        private DateTime timestamp_prop_enum;
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
        /// Идентификатор элемента перечисления
        /// </summary>
        public Int64 Id_prop_enum_val { get => id_prop_enum_val; }

        /// <summary>
        /// Область применения идентификаторв
        /// </summary>
        public eProp_enum_use_area Id_prop_enum_use_area
        {
            get
            {
                return (eProp_enum_use_area)id_prop_enum_use_area;
            }
            set
            {
                if ((eProp_enum_use_area)id_prop_enum_use_area != value)
                {

                    id_prop_enum_use_area =(Int32)value;
                    on_change = true;

                }
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
        /// Идентификатор ссылочного объекта элемента перечисления
        /// </summary>
        public Int64 Sort
        {
            get
            {
                return sort; ;
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

        /// <summary>
        /// Идентификатор ссылочного объекта элемента перечисления
        /// </summary>
        public Int64 Id_object_reference
        {
            get
            {
                return id_object_reference; ;
            }
            set
            {
                if (id_object_reference != value)
                {
                    id_object_reference = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Элемент перечисления используется
        /// </summary>
        public Boolean Is_use { get => is_use; }

        /// <summary>
        /// Перечисление содержит ссылочный объект
        /// </summary>
        public Boolean Has_object_reference { get => has_object_reference; }

        /// <summary>
        /// Значение элемента перечисления типа строка
        /// </summary>
        public String Val_varchar
        {
            get
            {
                return val_varchar;
            }
            set
            {
                if (val_varchar != value)
                {
                    if (value.Length > Val_varchar_len)
                    {
                        value = value.Substring(0, Val_varchar_len);
                    }
                    val_varchar = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Максимально допустимая длинна строкового поля
        /// </summary>
        public static Int32 Val_varchar_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_pos  = manager.Instance().TableByName("vprop_enum_val");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["val_varchar"].MaxLength;
                }
                return result;
            }
        }

        /// <summary>
        /// Значение элемента перечисления типа число
        /// </summary>
        public Decimal Val_numeric
        {
            get
            {
                return val_numeric;
            }
            set
            {
                if (val_numeric != value)
                {
                    val_numeric = value;
                    on_change = true;
                }
            }
        }
        
        /// <summary>
        /// Значение элемента перечисления
        /// </summary>
        public object Val
        {
            get
            {
                object Result = null;
                switch (id_data_type)
                { 
                    case 1:
                        Result = val_varchar;
                        break;
                    case 3:
                        Result = val_numeric;
                        break;
                }
                return Result;
            }
            set
            {
                switch (id_data_type)
                {
                    case 1:
                        val_varchar = value.ToString();
                        break;
                    case 3:
                        val_numeric = System.Convert.ToDecimal(value);
                        break;
                }
            }
        }

        /// <summary>
        /// Штамп времени перечисления
        /// </summary>
        public DateTime Timestamp_prop_enum { get => timestamp_prop_enum; }

        /// <summary>
        /// Штамп времени элемента перечисления
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

        private String selectedimagekey;
        /// <summary>
        /// Ключ выделенного объекта
        /// </summary>
        public string SelectedImageKey
        {
            get
            {
                return selectedimagekey;
            }
        }

        #endregion

        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Свойство определяет актуальность текущего состояния группы
        /// </summary>
        public eEntityState Is_actual()
        {
            return Manager.prop_enum_val_is_actual(this);
        }

        /// <summary>
        /// Обновление группы в БД
        /// </summary>
        public void Update()
        {
            if (on_change)
            {
                Manager.prop_enum_val_upd(this);
                Refresh();
                on_change = false;
            }
        }

        /// <summary>
        /// Обновление группы из БД
        /// </summary>
        public Boolean Refresh()
        {
            prop_enum_val temp;
            Boolean Result = false;
            temp = Manager.prop_enum_val_by_id(id_prop_enum_val);

            if (temp != null)
            {
                id_conception = temp.Id_conception;
                id_prop_enum = temp.Id_prop_enum;
                id_prop_enum_use_area = (Int32)temp.Id_prop_enum_use_area;
                id_prop_enum_val = temp.Id_prop_enum_val;
                id_data_type = temp.Id_data_type;
                val_numeric = temp.Val_numeric;
                val_varchar = temp.Val_varchar;
                is_use = temp.Is_use;
                sort = temp.Sort;
                id_object_reference = temp.Id_object_reference;
                has_object_reference = temp.Has_object_reference;
                timestamp_prop_enum = temp.Timestamp_prop_enum;
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
        /// Метод возвращает перечисление в которое входит элемент
        /// </summary>
        public prop_enum Prop_enum_get()
        {
            return Manager.prop_enum_by_id(id_prop_enum);
        }
        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            String Result = "н/д";
            switch (id_data_type)
            {
                case 1:
                    {
                        Result = val_varchar;
                        break;
                    }
                case 3:
                    {
                        Result = val_numeric.ToString();
                        break;
                    }
            }
            return Result;
        }
        #endregion

    }
}
