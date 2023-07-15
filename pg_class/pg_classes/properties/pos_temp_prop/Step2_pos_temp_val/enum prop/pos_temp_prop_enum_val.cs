using System;
using System.Collections.Generic;
using System.Data;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс данных значения свойства шаблона типа перечисление
    /// </summary>
    public partial class pos_temp_prop_enum_val
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected pos_temp_prop_enum_val()
        {
            on_change = false;
            imagekey = "pos_temp_prop_enum_val_us";
            selectedimagekey = "pos_temp_prop_enum_val_s";

        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public pos_temp_prop_enum_val(System.Data.DataRow row) : this()
        {

            if (row.Table.TableName == "vpos_temp_prop_enum_val")
            {
                id_conception = (Int64)row["id_conception"];
                id_pos_temp = (Int64)row["id_pos_temp"];
                id_pos_temp_prop = (Int64)row["id_pos_temp_prop"];
                id_data_type = (Int32)row["id_data_type"];

                id_prop_enum = (Int64)row["id_prop_enum"];
                id_prop_enum_val = (Int64)row["id_prop_enum_val"];

                val_numeric = (Decimal)row["val_numeric"];
                val_varchar = (String)row["val_varchar"];
                val_varchar_len = row.Table.Columns["val_varchar"].MaxLength;
                is_use = (Boolean)row["is_use"];

                id_object_reference = (Int64)row["id_object_reference"];
                has_object_reference = (Boolean)row["has_object_reference"];
                tablename = (String)row["tablename"];
                on_val = (Boolean)row["on_val"];
                timestamp = Convert.ToDateTime(row["timestamp"]);
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int64 id_conception;
        private Int64 id_pos_temp;
        private Int64 id_pos_temp_prop;

        private Int64 id_prop_enum_val;
        private Int64 id_prop_enum;
        private Int32 id_data_type;

        private Decimal val_numeric;
        private String val_varchar;
        private Int32 val_varchar_len;

        private Int64 id_object_reference;
        private Boolean is_use;
        private Boolean has_object_reference;


        /// <summary>
        /// Идентификатор концепции
        /// </summary>
        public Int64 Id_conception { get => id_conception; }

        /// <summary>
        /// Идентификатор шаблона носителя свойства
        /// </summary>
        public Int64 Id_pos_temp { get => id_pos_temp; }

        /// <summary>
        /// Идентификатор свойства шаблона носителя свойства
        /// </summary>
        public Int64 Id_pos_temp_prop { get => id_pos_temp_prop; }

        /// <summary>
        /// Идентификатор типа данных перечисления
        /// </summary>
        public Int32 Id_data_type
        {
            get
            {
                return id_data_type;
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
        /// Идентификатор перечисления
        /// </summary>
        public Int64 Id_prop_enum
        {
            get
            {
                return id_prop_enum;
            }
            set
            {
                if (id_prop_enum != value)
                {
                    id_prop_enum = value;
                    on_change = true;
                }
            }
        }
        /// <summary>
        /// Идентификатор элемента перечисления
        /// </summary>
        public Int64 Id_prop_enum_val
        {
            get
            {
                return id_prop_enum_val;
            }
            set
            {
                if (id_prop_enum_val != value)
                {
                    id_prop_enum_val = value;
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
                return id_object_reference;
            }

        }

        /// <summary>
        /// Перечисление используется
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
        }

        /// <summary>
        /// Максимально допустимая длинна строкового поля
        /// </summary>
        public static Int32 Val_varchar_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_pos = manager.Instance().TableByName("vprop_enum_val");
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

        private DateTime timestamp;
        /// <summary>
        /// Штамп времени шаблона позиции
        /// </summary>
        public DateTime Timestamp
        {
            get
            {
                return timestamp;
            }
        }

        /// <summary>
        /// Тип свойства
        /// </summary>
        public ePropType Prop_type
        {
            get
            {
                return ePropType.PropEnum;
            }
        }
        #endregion

        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Свойство определяет актуальность текущего состояния данных значения свойства
        /// </summary>
        public eEntityState Is_actual()
        {
            return manager.Instance().pos_temp_is_actual(id_pos_temp, timestamp);
        }

        /// <summary>
        /// Обновление данных значения свойства
        /// </summary>
        public void Update()
        {
            if (on_change)
            {
                Manager.pos_temp_prop_enum_val_set(this);
                Refresh();
                on_change = false;
            }
        }

        /// <summary>
        /// Удаление значения из данных значения свойства
        /// </summary>
        public void DelVal()
        {
            Manager.pos_temp_prop_enum_val_del(this);
            Refresh();
        }


        /// <summary>
        /// Обновление группы из БД
        /// </summary>
        public Boolean Refresh()
        {
            pos_temp_prop_enum_val temp;
            Boolean Result = false;
            temp = Manager.pos_temp_prop_enum_val_by_id_prop(this);

            if (temp != null)
            {
                id_data_type = temp.Id_data_type;
                id_prop_enum = temp.Id_prop_enum;
                id_prop_enum_val = temp.Id_prop_enum_val;
                val_numeric = temp.Val_numeric;
                val_varchar = temp.Val_varchar;
                is_use = temp.Is_use;
                id_object_reference = temp.Id_object_reference;
                has_object_reference = temp.Has_object_reference;
                tablename = temp.Tablename;
                on_val = temp.On_val;
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
        /// Метод возвращает перечисление в которое входит элемент
        /// </summary>
        public prop_enum Prop_enum_get()
        {
            return Manager.prop_enum_by_id(id_prop_enum);
        }

        /// <summary>
        /// Метод возвращает элементы перечисления в которое входит элемент
        /// </summary>
        public List<prop_enum_val> Prop_enum_val_get()
        {
            return Manager.prop_enum_val_by_id_prop_enum(id_prop_enum);
        }


        /// <summary>
        /// Значение свойства типа перечисление установить
        /// </summary>
        public void value_set(prop_enum_val Val)
        {
            id_prop_enum = Val.Id_prop_enum;
            id_prop_enum_val = Val.Id_prop_enum_val;
        }

        /// <summary>
        /// Значение свойства типа перечисление установить
        /// </summary>
        public void value_set(prop_enum Val)
        {
            id_prop_enum = Val.Id_prop_enum;
            id_prop_enum_val = -1;
        }
        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            String prop_enum = "н/д";
            String prop_enum_val = "н/д";

            prop_enum tmp = Prop_enum_get();
            if (tmp != null)
            {
                prop_enum = tmp.NameEnum;
            }

            switch (id_data_type)
            {
                case 1:
                    {
                        prop_enum_val = val_varchar;
                        break;
                    }
                case 3:
                    {
                        prop_enum_val = val_numeric.ToString();
                        break;
                    }
            }
            return String.Format("{0}: {1}", prop_enum, prop_enum_val);
        }
        #endregion

    }
}
