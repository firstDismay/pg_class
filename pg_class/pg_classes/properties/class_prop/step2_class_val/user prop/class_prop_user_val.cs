using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using pg_class.pg_exceptions;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс данных значения пользовательского свойства класса
    /// </summary>
    public partial class class_prop_user_val
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected class_prop_user_val()
        {
            imagekey = "class_prop_user_val_us";
            
            val_text = null;
            val_bytea = null;
            val_json = null;

            min_used = false;
            min_on = false;
            min_val = 0;

            max_used = false;
            max_on = false;
            max_val = 0;

            round_used = false;
            round_on = false;
            round = 3;

            val_varchar = null;
            val_int = 0;
            val_numeric = 0;
            val_real = 0;
            val_double = 0;
            val_money = 0;
            val_boolean = false;
            val_date = DateTime.MinValue;
            val_time = new TimeSpan(0,0,0,0,0);
            val_interval = new TimeSpan(0, 0, 0, 0, 0);
            val_timestamp = DateTime.MinValue; 
            val_bigint = 0;
        }
        /// <summary>
        /// Полный конструктор значения пользовательского свойства BIG
        /// </summary>
        public class_prop_user_val(System.Data.DataRow row) : this()
        {

            entitysource = eEntitySource.Server;
            switch (row.Table.TableName)
            {
                case "vclass_prop_user_big_val":
                    datasize = eDataSize.BigData;

                    id_class = (Int64)row["id_class"];
                    timestamp_class = (DateTime)row["timestamp_class"];
                    id_class_prop = (Int64)row["id_class_prop"];
                    data_type = (eDataType)row["id_data_type"];
                    inheritance = (Boolean)row["inheritance"];

                    id_class_definition = (Int64)row["id_class_definition"];
                    id_prop_definition = (Int64)row["id_prop_definition"];
                    timestamp_class_definition = (DateTime)row["timestamp_class_definition"];

                    if (!DBNull.Value.Equals(row["min_used"]))
                    {
                        min_used = (Boolean)row["min_used"];
                    }

                    if (!DBNull.Value.Equals(row["min_on"]))
                    {
                        min_on = (Boolean)row["min_on"];
                    }

                    if (!DBNull.Value.Equals(row["min_val"]))
                    {
                        min_val = (Decimal)row["min_val"];
                    }

                    if (!DBNull.Value.Equals(row["max_used"]))
                    {
                        max_used = (Boolean)row["max_used"];
                    }

                    if (!DBNull.Value.Equals(row["max_on"]))
                    {
                        max_on = (Boolean)row["max_on"];
                    }

                    if (!DBNull.Value.Equals(row["max_val"]))
                    {
                        max_val = (Decimal)row["max_val"];
                    }

                    if (!DBNull.Value.Equals(row["val_text"]))
                    {
                        val_text = (String)row["val_text"];
                    }
                    
                    if (!DBNull.Value.Equals(row["val_bytea"]))
                    {
                        val_bytea = (Byte[])row["val_bytea"];
                    }
                    
                    if (!DBNull.Value.Equals(row["val_json"]))
                    {
                        val_json = (String)row["val_json"];
                    }

                    tablename = (String)row["tablename"];
                    on_val = (Boolean)row["on_val"];
                    break;
                case "vclass_prop_user_small_val":
                    datasize = eDataSize.SmallData;

                    id_class = (Int64)row["id_class"];
                    timestamp_class = (DateTime)row["timestamp_class"];
                    id_class_prop = (Int64)row["id_class_prop"];
                    data_type = (eDataType)row["id_data_type"];
                    inheritance = (Boolean)row["inheritance"];

                    id_class_definition = (Int64)row["id_class_definition"];
                    id_prop_definition = (Int64)row["id_prop_definition"];
                    timestamp_class_definition = (DateTime)row["timestamp_class_definition"];

                    if (!DBNull.Value.Equals(row["min_used"]))
                    {
                        min_used = (Boolean)row["min_used"];
                    }

                    if (!DBNull.Value.Equals(row["min_on"]))
                    {
                        min_on = (Boolean)row["min_on"];
                    }

                    if (!DBNull.Value.Equals(row["min_val"]))
                    {
                        min_val = (Decimal)row["min_val"];
                    }

                    if (!DBNull.Value.Equals(row["max_used"]))
                    {
                        max_used = (Boolean)row["max_used"];
                    }

                    if (!DBNull.Value.Equals(row["max_on"]))
                    {
                        max_on = (Boolean)row["max_on"];
                    }

                    if (!DBNull.Value.Equals(row["max_val"]))
                    {
                        max_val = (Decimal)row["max_val"];
                    }

                    if (!DBNull.Value.Equals(row["round_used"]))
                    {
                        round_used = (Boolean)row["round_used"];
                    }

                    if (!DBNull.Value.Equals(row["round_on"]))
                    {
                        round_on = (Boolean)row["round_on"];
                    }

                    if (!DBNull.Value.Equals(row["round"]))
                    {
                        round = (Int32)row["round"];
                    }

                    if (!DBNull.Value.Equals(row["val_varchar"]))
                    {
                        val_varchar = (String)row["val_varchar"];
                    }
                    
                    if (!DBNull.Value.Equals(row["val_int"]))
                    {
                        val_int = (Int32)row["val_int"];
                    }
                    
                    if (!DBNull.Value.Equals(row["val_numeric"]))
                    {
                        val_numeric = (Decimal)row["val_numeric"];
                    }
                    
                    if (!DBNull.Value.Equals(row["val_real"]))
                    {
                        val_real = (Single)row["val_real"];
                    }
                    
                    if (!DBNull.Value.Equals(row["val_double"]))
                    {
                        val_double = (Double)row["val_double"];
                    }
                    
                    if (!DBNull.Value.Equals(row["val_money"]))
                    {
                        val_money = (Decimal)row["val_money"];
                    }
                    
                    if (!DBNull.Value.Equals(row["val_boolean"]))
                    {
                        val_boolean = (Boolean)row["val_boolean"];
                    }
                    
                    if (!DBNull.Value.Equals(row["val_date"]))
                    {
                        val_date = (DateTime)row["val_date"];
                    }
                    
                    if (!DBNull.Value.Equals(row["val_time"]))
                    {
                        val_time = (TimeSpan)row["val_time"];
                    }
                    
                    if (!DBNull.Value.Equals(row["val_interval"]))
                    {
                        val_interval = (TimeSpan)row["val_interval"];
                    }
                    
                    if (!DBNull.Value.Equals(row["val_timestamp"]))
                    {
                        val_timestamp = (DateTime)row["val_timestamp"];
                    }
                    
                    if (!DBNull.Value.Equals(row["val_bigint"]))
                    {
                        val_bigint = (Int64)row["val_bigint"];
                    }

                    tablename = (String)row["tablename"];
                    on_val = (Boolean)row["on_val"];
                    break;
                default:
                    throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }

        #endregion

        #region СВОЙСТВА КЛАССА ОСНОВНЫЕ

        private Boolean inheritance;

        /// <summary>
        /// Признак значения наследованного от родительского стоящего класса
        /// </summary>
        public Boolean Inheritance
        {
            get
            {
                return inheritance;
            }
        }

        private eDataType data_type;
        /// <summary>
        /// Тип данных значения свойства
        /// </summary>
        public eDataType DataType
        {
            get
            {
                return data_type;
            }
        }

        /// <summary>
        /// Тип данных свойства в среде Postgre SQL
        /// </summary>
        public NpgsqlTypes.NpgsqlDbType DataTypeNpgsql
        {
            get
            {
                return Manager.DataTypeNpgsql(DataType);
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
                return Manager.DataTypeNet(DataType); ;
            }
        }

        private eDataSize datasize;
        /// <summary>
        /// Свойство определяет размер данных значения свойства
        /// </summary>
        public eDataSize DataSize
        {
            get
            {
                return datasize;
            }
        }


        private eEntitySource entitysource;
        /// <summary>
        /// Свойство определяет источник сущности
        /// </summary>
        public eEntitySource EntitySource
        {
            get
            {
                return entitysource;
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

        private DateTime timestamp_class;
        /// <summary>
        /// Штам времени класса носителя свойства
        /// </summary>
        public DateTime Timestamp_class
        {
            get
            {
                return timestamp_class;
            }
        }

        private Int64 id_class;
        /// <summary>
        /// Идентификатор класса носителя свойства
        /// </summary>
        public Int64 Id_class
        {
            get
            {
                return id_class;
            }
        }

        private Int64 id_class_prop;
        /// <summary>
        /// Идентификатор свойства класса
        /// </summary>
        public Int64 Id_class_prop
        {
            get
            {
                return id_class_prop;
            }
        }

        Int64 id_class_definition;
        /// <summary>
        /// Идентификатор класса определяющего текущее свойство
        /// </summary>
        public Int64 Id_class_definition
        {
            get
            {
                return id_class_definition;
            }
        }

        Int64 id_prop_definition;
        /// <summary>
        /// Идентификатор свойства класса определяющего текущее свойство
        /// </summary>
        public Int64 Id_prop_definition
        {
            get
            {
                return id_prop_definition;
            }
        }

        DateTime timestamp_class_definition;
        /// <summary>
        /// Штамп времени класса определяющего свойство
        /// </summary>
        public DateTime Timestamp_class_definition
        {
            get
            {
                return timestamp_class_definition;
            }
        }

        /// <summary>
        /// Тип свойства
        /// </summary>
        public ePropType Prop_type
        {
            get
            {
                return ePropType.PropUser;
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
        /// Тип хранилища данных сущности
        /// </summary>
        public eStorageType StorageType
        {
            get
            {
                String pattern1 = "snapshot";
                String pattern2 = "notsaved";
                eStorageType tmp = eStorageType.Active;
                if (System.Text.RegularExpressions.Regex.IsMatch(tablename, pattern1))
                {
                    tmp = eStorageType.History;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(tablename, pattern2))
                {
                    tmp = eStorageType.NotSaved;
                }
                return tmp;
            }
        }

        private String tablename;
        /// <summary>
        /// Имя таблицы базы ассистента, содержащей запись о значении свойства класса
        /// </summary>
        public String Tablename
        {
            get
            {
                return tablename;
            }
        }


        private Boolean on_val;
        /// <summary>
        /// Признак установленного значения свойства
        /// </summary>
        public Boolean On_val
        {
            get
            {
                return on_val;
            }
        }
        #endregion

        #region ЗНАЧЕНИЯ СВОЙСТВА BIG


        /// <summary>
        /// Лист доступных к загрузке расширений файлов двоичного свойства
        /// </summary>
        public List<prop_data_bin_ext> data_bin_ext_list_get()
        {
            List<prop_data_bin_ext> Result = new List<prop_data_bin_ext>();
            if (data_type == eDataType.val_bytea)
            {
                Result = Manager.prop_data_bin_ext_by_all();
            }
            return Result;
        }

        /// <summary>
        /// Лист доступных к загрузке расширений файлов двоичного свойства
        /// </summary>
        public List<String> data_bin_ext_list_get2()
        {
            List<String> Result = new List<String>();
            if (data_type == eDataType.val_bytea)
            {
                Result = Manager.prop_data_bin_ext_by_all2();
            }
            return Result;
        }



        private String val_text;
        /// <summary>
        /// Значение свойства типа Text
        /// </summary>
        public String Val_text
        {
            get
            {
                return val_text;
            }
            set
            {
                if(data_type==eDataType.val_text)
                { 
                    val_text = value;
                }
                else
                {
                throw new PgDataException(eEntity.class_prop_user_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                    "Тип данных свойства не соотвествует типу данных переданного значения", eSourceError.ClassFuncVer2);
                }
            }
        }

        private String val_json;
        /// <summary>
        /// Значение свойства типа Json
        /// </summary>
        public String Val_json
        {
            get
            {
                return val_json;
            }
            set
            {
                if (data_type == eDataType.val_json)
                {
                    val_json = value;
                    on_change = true;
                }
                else
                {
                    throw new PgDataException(eEntity.class_prop_user_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Тип данных свойства не соотвествует типу данных переданного значения", eSourceError.ClassFuncVer2);
                }
            }
        }

        private Byte[] val_bytea;
        /// <summary>
        /// Значение свойства типа Byte[]
        /// </summary>
        public Byte[] Val_bytea
        {
            get
            {
                return val_bytea;
            }
            set
            {
                if (data_type == eDataType.val_bytea)
                {
                    val_bytea = value;
                    on_change = true;
                }
                else
                {
                    throw new PgDataException(eEntity.class_prop_user_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Тип данных свойства не соотвествует типу данных переданного значения", eSourceError.ClassFuncVer2);
                }
            }

        }
        #endregion

        #region ЗНАЧЕНИЯ СВОЙСТВА SMALL

        String val_varchar;
        /// <summary>
        /// Значение свойства типа varchar
        /// </summary>
        public String Val_varchar
        {
            get
            {
                return val_varchar;
            }
            set
            {
                if (data_type == eDataType.val_varchar)
                {
                    val_varchar = value;
                    on_change = true;
                }
                else
                {
                    throw new PgDataException(eEntity.class_prop_user_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Тип данных свойства не соотвествует типу данных переданного значения", eSourceError.ClassFuncVer2);
                }
            }
        }

        Int32 val_int;
        /// <summary>
        /// Значение свойства типа int
        /// </summary>
        public Int32 Val_int
        {
            get
            {
                return val_int;
            }
            set
            {
                if (data_type == eDataType.val_int)
                {
                    val_int = value;
                    on_change = true;
                }
                else
                {
                    throw new PgDataException(eEntity.class_prop_user_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Тип данных свойства не соотвествует типу данных переданного значения", eSourceError.ClassFuncVer2);
                }
            }
        }

        Decimal val_numeric;
        /// <summary>
        /// Значение свойства типа int
        /// </summary>
        public Decimal Val_numeric
        {
            get
            {
                return val_numeric;
            }
            set
            {
                if (data_type == eDataType.val_numeric)
                {
                    val_numeric = value;
                    on_change = true;
                }
                else
                {
                    throw new PgDataException(eEntity.class_prop_user_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Тип данных свойства не соотвествует типу данных переданного значения", eSourceError.ClassFuncVer2);
                }
            }
        }

        Single val_real;
        /// <summary>
        /// Значение свойства типа real
        /// </summary>
        public Single Val_real
        {
            get
            {
                return val_real;
            }
            set
            {
                if (data_type == eDataType.val_real)
                {
                    val_real = value;
                    on_change = true;
                }
                else
                {
                    throw new PgDataException(eEntity.class_prop_user_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Тип данных свойства не соотвествует типу данных переданного значения", eSourceError.ClassFuncVer2);
                }
            }
        }

        Double val_double;
        /// <summary>
        /// Значение свойства типа double
        /// </summary>
        public Double Val_double
        {
            get
            {
                return val_double;
            }
            set
            {
                if (data_type == eDataType.val_double)
                {
                    val_double = value;
                    on_change = true;
                }
                else
                {
                    throw new PgDataException(eEntity.class_prop_user_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Тип данных свойства не соотвествует типу данных переданного значения", eSourceError.ClassFuncVer2);
                }
            }
        }

        Decimal val_money;
        /// <summary>
        /// Значение свойства типа money
        /// </summary>
        public Decimal Val_money
        {
            get
            {
                return val_money;
            }
            set
            {
                if (data_type == eDataType.val_money)
                {
                    val_money = value;
                    on_change = true;
                }
                else
                {
                    throw new PgDataException(eEntity.class_prop_user_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Тип данных свойства не соотвествует типу данных переданного значения", eSourceError.ClassFuncVer2);
                }
            }
        }

        Boolean val_boolean;
        /// <summary>
        /// Значение свойства типа boolean
        /// </summary>
        public Boolean Val_boolean
        {
            get
            {
                return val_boolean;
            }
            set
            {
                if (data_type == eDataType.val_boolean)
                {
                    val_boolean = value;
                    on_change = true;
                }
                else
                {
                    throw new PgDataException(eEntity.class_prop_user_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Тип данных свойства не соотвествует типу данных переданного значения", eSourceError.ClassFuncVer2);
                }
            }
        }

        DateTime val_date;
        /// <summary>
        /// Значение свойства типа date
        /// </summary>
        public DateTime Val_date
        {
            get
            {
                return val_date;
            }
            set
            {
                if (data_type == eDataType.val_date)
                {
                    val_date = value;
                    on_change = true;
                }
                else
                {
                    throw new PgDataException(eEntity.class_prop_user_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Тип данных свойства не соотвествует типу данных переданного значения", eSourceError.ClassFuncVer2);
                }
            }
        }

        TimeSpan val_time;
        /// <summary>
        /// Значение свойства типа time
        /// </summary>
        public TimeSpan Val_time
        {
            get
            {
                return val_time;
            }
            set
            {
                if (data_type == eDataType.val_time)
                {
                    val_time = value;
                    on_change = true;
                }
                else
                {
                    throw new PgDataException(eEntity.class_prop_user_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Тип данных свойства не соотвествует типу данных переданного значения", eSourceError.ClassFuncVer2);
                }
            }
        }

        TimeSpan val_interval;
        /// <summary>
        /// Значение свойства типа interval
        /// </summary>
        public TimeSpan Val_interval
        {
            get
            {
                return val_interval;
            }
            set
            {
                if (data_type == eDataType.val_interval)
                {
                    val_interval = value;
                    on_change = true;
                }
                else
                {
                    throw new PgDataException(eEntity.class_prop_user_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Тип данных свойства не соотвествует типу данных переданного значения", eSourceError.ClassFuncVer2);
                }
            }
        }

        DateTime val_timestamp;
        /// <summary>
        /// Значение свойства типа timestamp
        /// </summary>
        public DateTime Val_timestamp
        {
            get
            {
                return val_timestamp;
            }
            set
            {
                if (data_type == eDataType.val_timestamp)
                {
                    val_timestamp = value;
                    on_change = true;
                }
                else
                {
                    throw new PgDataException(eEntity.class_prop_user_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Тип данных свойства не соотвествует типу данных переданного значения", eSourceError.ClassFuncVer2);
                }
            }
        }

        Int64 val_bigint;
        /// <summary>
        /// Значение свойства типа bigint
        /// </summary>
        public Int64 Val_bigint
        {
            get
            {
                return val_bigint;
            }
            set
            {
                if (data_type == eDataType.val_bigint)
                {
                    val_bigint = value;
                    on_change = true;
                }
                else
                {
                    throw new PgDataException(eEntity.class_prop_user_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Тип данных свойства не соотвествует типу данных переданного значения", eSourceError.ClassFuncVer2);
                }
            }
        }

        #endregion

        #region ОГРАНИЧЕНИЯ ЗНАЧЕНИЙ СВОЙСТВ
        Decimal min_val;
        /// <summary>
        /// Минимум диапазона значений свойства
        /// </summary>
        public Decimal Min_val
        {
            get
            {
                return min_val;
            }
            set
            {
                if (min_on)
                {
                    min_val = value;
                    on_change = true;
                }
            }
        }

        Boolean min_on;
        /// <summary>
        /// Минимум диапазона значений свойства включен/выключен
        /// </summary>
        public Boolean Min_on
        {
            get
            {
                return min_on;
            }
            set
            {
                min_on = value;
                on_change = true;
            }
        }

        Boolean min_used;
        /// <summary>
        /// Минимум диапазона значений свойства применим к типу данных
        /// </summary>
        public Boolean Min_used
        {
            get
            {
                return min_used;
            }
        }

        Decimal max_val;
        /// <summary>
        /// Максимум диапазона значений свойства
        /// </summary>
        public Decimal Max_val
        {
            get
            {
                return max_val;
            }
            set
            {
                if (max_on)
                {
                    max_val = value;
                    on_change = true;
                }
            }
        }

        Boolean max_on;
        /// <summary>
        /// Максимум диапазона значений свойства включен/выключен
        /// </summary>
        public Boolean Max_on
        {
            get
            {
                return max_on;
            }
            set
            {
                max_on = value;
                on_change = true;
            }
        }

        Boolean max_used;
        /// <summary>
        /// Максимум диапазона значений свойства применим к типу данных
        /// </summary>
        public Boolean Max_used
        {
            get
            {
                return max_used;
            }
        }

        Int32 round;
        /// <summary>
        /// Округление значеия свойства, ноль округление до целых
        /// </summary>
        public Int32 Round_val
        {
            get
            {
                return round;
            }
            set
            {
                if (round_on)
                {
                    round = value;
                    on_change = true;
                }
            }
        }

        Boolean round_on;
        /// <summary>
        /// Округление значеия свойства включенo/выключенj
        /// </summary>
        public Boolean Round_on
        {
            get
            {
                return round_on;
            }
            set
            {
                round_on = value;
                on_change = true;
            }
        }

        Boolean round_used;
        /// <summary>
        /// Округление значеия свойства включенo/выключенj
        /// </summary>
        public Boolean Round_used
        {
            get
            {
                return round_used;
            }
        }

        #endregion

        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Свойство определяет актуальность текущего состояния
        /// </summary>
        public eEntityState Is_actual()
        {
            return Manager.class_prop_user_val_is_actual(this);
        }

        /// <summary>
        /// Обновление данных значения свойства
        /// </summary>
        public void Update()
        {
            if (on_change )
            {
                if (this.StorageType != eStorageType.History)
                {
                    if (this.StorageType == eStorageType.NotSaved)
                    {
                        Manager.class_prop_user_val_add(this);
                    }
                    else
                    {
                        Manager.class_prop_user_val_upd(this);
                    }
                     Refresh();
                     on_change = false;
                }
                else
                {
                    throw new PgDataException(eEntity.class_prop_user_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Метод обновления данных значения свойства класса не применим к историческому представлению класса!");
                }
            }
        }

        /// <summary>
        /// Удаление значения из данных значения свойства
        /// </summary>
        public void DelVal()
        {
            if (this.StorageType != eStorageType.History)
            {
                Manager.class_prop_user_val_del(this);
                Refresh();
            }
            else
            {
                throw new PgDataException(eEntity.class_prop_user_val, eAction.Delete, eSubClass_ErrID.SCE3_Violation_Rules,
                    "Метод удаления значения не применим к историческому представлению класса!");
            }
        }

        /// <summary>
        /// Обновление представления класса из БД
        /// </summary>
        public Boolean Refresh()
        {

            class_prop_user_val temp = null;
            Boolean Result = false;
            if (StorageType != eStorageType.History)
            {
                temp = Manager.class_prop_user_val_by_id_prop(this);
                if (temp != null)
                {
                    min_val = temp.Min_val;
                    min_on = temp.Min_on;
                    max_val = temp.Max_val;
                    max_on = temp.Max_on;
                    round = temp.Round_val;
                    round_on = temp.Round_on;

                    timestamp_class_definition = temp.Timestamp_class_definition;
                    id_class_definition = temp.Id_class_definition;
                    id_prop_definition = temp.id_prop_definition;

                    val_text = temp.Val_text;
                    val_bytea = temp.Val_bytea;
                    val_json = temp.Val_json;

                    val_varchar = temp.Val_varchar;
                    val_int = temp.Val_int;
                    val_numeric = temp.Val_numeric;
                    val_real = temp.Val_real;
                    val_double = temp.Val_double;
                    val_money = temp.Val_money;
                    val_boolean = temp.Val_boolean;
                    val_date = temp.Val_date;
                    val_time = temp.Val_time;
                    val_interval = temp.Val_interval;
                    val_timestamp = temp.Val_timestamp;
                    val_bigint = temp.Val_bigint;
                    on_val = temp.On_val;
                    Result = true;
                    on_change = false;
                }
                else
                {
                    Result = false;
                }
            }
            else
            {
                Result = true;
            }

            return Result;
        }

        /// <summary>
        /// Класс носитель свойства
        /// </summary>
        public vclass GetClassCarrier()
        {
            vclass Result = null;

            switch (StorageType)
            {
                case eStorageType.Active:
                    Result = Manager.class_act_by_id(id_class);
                    break;
                case eStorageType.History:
                    Result = Manager.class_snapshot_by_id(id_class, Timestamp_class);
                    break;
            }
            return Result;
        }

        /// <summary>
        /// Значение пользовательского свойства
        /// </summary>
        public Object value_get()
        {
            Object Result = null;

            switch (DataType)
            {
                case eDataType.val_varchar:
                    Result = val_varchar;                    
                    break;
                case eDataType.val_int:
                    Result = val_int;
                    break;
                case eDataType.val_numeric:
                    Result = val_numeric;
                    break;
                case eDataType.val_real:
                    Result = val_real;
                    break;
                case eDataType.val_double:
                    Result = val_double;
                    break;
                case eDataType.val_money:
                    Result = val_money;
                    break;
                case eDataType.val_text:
                    Result = val_text;
                    break;
                case eDataType.val_bytea:
                    Result = val_bytea;
                    break;
                case eDataType.val_boolean:
                    Result = val_boolean;
                    break;
                case eDataType.val_date:
                    Result = val_date;
                    break;
                case eDataType.val_time:
                    Result = val_time;
                    break;
                case eDataType.val_interval:
                    Result = val_interval;
                    break;
                case eDataType.val_timestamp:
                    Result = val_timestamp;
                    break;
                case eDataType.val_json:
                    Result = val_json;
                    break;
                case eDataType.val_bigint:
                    Result = val_bigint;
                    break;
            }
            return Result;
        }

        /// <summary>
        /// Значение пользовательского свойства установить
        /// </summary>
        public Object value_set(Object newVal)
        {
            Object Result = null;
            if (newVal != null)
            {
                Result = newVal;
                on_val = true;
                try
                {
                    switch (DataType)
                    {
                        case eDataType.val_varchar:
                            Val_varchar = Convert.ToString(newVal, new CultureInfo("ru-RU"));
                            break;
                        case eDataType.val_int:
                            Val_int = Convert.ToInt32(newVal, new CultureInfo("ru-RU"));
                            break;
                        case eDataType.val_numeric:
                            Val_numeric = Convert.ToDecimal(newVal, new CultureInfo("ru-RU"));
                            break;
                        case eDataType.val_real:
                            Val_real = Convert.ToSingle(newVal, new CultureInfo("ru-RU"));
                            break;
                        case eDataType.val_double:
                            Val_double = Convert.ToDouble(newVal, new CultureInfo("ru-RU"));
                            break;
                        case eDataType.val_money:
                            Val_money = Convert.ToDecimal(newVal, new CultureInfo("ru-RU"));
                            break;
                        case eDataType.val_text:
                            Val_text = Convert.ToString(newVal, new CultureInfo("ru-RU"));
                            break;
                        case eDataType.val_bytea:
                            Val_bytea = (Byte[])newVal;
                            break;
                        case eDataType.val_boolean:
                            Val_boolean = Convert.ToBoolean(newVal, new CultureInfo("ru-RU"));
                            break;
                        case eDataType.val_date:
                            Val_date = Convert.ToDateTime(newVal, new CultureInfo("ru-RU"));
                            break;
                        case eDataType.val_time:
                            Val_time = (TimeSpan)newVal;
                            break;
                        case eDataType.val_interval:
                            Val_interval = (TimeSpan)newVal;
                            break;
                        case eDataType.val_timestamp:
                            Val_timestamp = Convert.ToDateTime(newVal, new CultureInfo("ru-RU"));
                            break;
                        case eDataType.val_json:
                            Val_json = (String)newVal;
                            break;
                        case eDataType.val_bigint:
                            Val_bigint = Convert.ToInt64(newVal, new CultureInfo("ru-RU"));
                            break;
                    }
                }
                catch (Exception e)
                {
                    throw new PgDataException(eEntity.class_prop_user_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                    String.Format("Ошибка изменения значения свойства: {0}", e.Message));
                }
            }
            return Result;
        }

        /// <summary>
        /// Свойство которому пренадлежит текущее значеие
        /// </summary>
        public class_prop class_prop_get()
        {
            class_prop Result = null;
       
            switch (StorageType)
            {
                case eStorageType.Active:
                    Result = Manager.class_prop_by_id(id_class_prop); 
                    break;
                case eStorageType.History:
                    Result = Manager.class_prop_snapshot_by_id(id_class_prop, Timestamp_class);
                    break;
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
            String Result = "н/д";
            String F = "F";
            if (Round_on)
            {
                F = "F" + round.ToString();
            }
            else
            {
                F = "G";
            }
            if (on_val)
            {
                switch (DataType)
                {
                    case eDataType.val_varchar:
                        Result = val_varchar;
                        break;
                    case eDataType.val_int:
                        Result = val_int.ToString();
                        break;
                    case eDataType.val_numeric:

                        Result = val_numeric.ToString(F, new CultureInfo("ru-RU"));
                        break;
                    case eDataType.val_real:
                        Result = val_real.ToString(F, new CultureInfo("ru-RU"));
                        break;
                    case eDataType.val_double:
                        Result = val_double.ToString(F, new CultureInfo("ru-RU"));
                        break;
                    case eDataType.val_money:
                        Result = val_money.ToString(F, new CultureInfo("ru-RU"));
                        break;
                    case eDataType.val_text:
                        Result = val_text;
                        break;
                    case eDataType.val_bytea:
                        Result = "Двоичные данные";
                        break;
                    case eDataType.val_boolean:
                        if (val_boolean)
                        {
                            Result = "Да";
                        }
                        else
                        {
                            Result = "Нет";
                        }
                        break;
                    case eDataType.val_date:
                        Result = val_date.ToString("dd.MM.yyyy", new CultureInfo("ru-RU"));
                        break;
                    case eDataType.val_time:
                        Result = val_time.ToString(); //"hh:mm:ss", new CultureInfo("ru-RU")
                        break;
                    case eDataType.val_interval:
                        Result = String.Format("{0} д. {1}:{2}:{3}", val_interval.Days,
                                val_interval.Hours.ToString("00"),
                                val_interval.Minutes.ToString("00"),
                                val_interval.Seconds.ToString("00"));
                        break;
                    case eDataType.val_timestamp:
                        Result = val_timestamp.ToString("dd.MM.yyyy HH:mm:ss.fff", new CultureInfo("ru-RU"));
                        break;
                    case eDataType.val_json:
                        Result = val_json;
                        break;
                    case eDataType.val_bigint:
                        Result = val_bigint.ToString();
                        break;
                }
            }
            return Result;
        }
        #endregion

        #region СПЕЦИФИКАТОРЫ ЗНАЧЕНИЯ СВОЙСТВА
        /// <summary>
        /// Список спецификаторов значения свойства, зависит от типа данных
        /// </summary>
        public prop_val_spec prop_val_spec_get()
        {
            return Manager.prop_val_spec_by_id_data_type(data_type);
        }

        #endregion
    }
}

