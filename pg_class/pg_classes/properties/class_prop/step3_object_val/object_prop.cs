using System;
using System.Collections.Generic;
using System.Data;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс свойств объекта
    /// </summary>
    public partial class object_prop
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected object_prop()
        {
            on_change = false;
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public object_prop(System.Data.DataRow row) : this()
        {

            if (row.Table.TableName == "vobject_prop")
            {
                id_class_prop = (Int64)row["id_class_prop"];
                id_object_carrier = (Int64)row["id_object_carrier"];
                timestamp_object_carrier = Convert.ToDateTime(row["timestamp_object_carrier"]);
                id_class = (Int64)row["id_class"];
                timestamp_class = Convert.ToDateTime(row["timestamp_class"]);
                on_inherit = (Boolean)row["on_inherit"];
                inheritance = (Boolean)row["inheritance"];
                id_prop_inherit = (Int64)row["id_prop_inherit"];
                timestamp_class_inherit = Convert.ToDateTime(row["timestamp_class_inherit"]);
                id_prop_type = (Int32)row["id_prop_type"];
                id_data_type = (Int32)row["id_data_type"];
                name = (String)row["name"];
                desc = (String)row["desc"];
                sort = (Int32)row["sort"];
                on_override = (Boolean)row["on_override"];
                on_val_object = (Boolean)row["on_val_object"];
                on_val_class = (Boolean)row["on_val_class"];
                id_conception = (Int64)row["id_conception"];
                id_class_definition = (Int64)row["id_class_definition"];
                if (!DBNull.Value.Equals(row["timestamp_class_definition"]))
                {
                    timestamp_class_definition = Convert.ToDateTime(row["timestamp_class_definition"]);
                }
                id_prop_definition = (Int64)row["id_prop_definition"];
                string_val = (String)row["string_val"];
                on_global = (Boolean)row["on_global"];
                id_global_prop = (Int64)row["id_global_prop"];
                tag = (String)row["tag"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }

        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через класс композитного типа
        /// </summary>
        public object_prop(pg_vobject_prop op) : this()
        {

            if (op != null)
            {
                id_class_prop = op.id_class_prop;
                id_object_carrier = op.id_object_carrier;
                timestamp_object_carrier = op.timestamp_object_carrier;
                id_class = op.id_class;
                timestamp_class = op.timestamp_class;
                on_inherit = op.on_inherit;
                inheritance = op.inheritance;
                id_prop_inherit = op.id_prop_inherit;
                timestamp_class_inherit = op.timestamp_class_inherit;
                id_prop_type = op.id_prop_type;
                id_data_type = op.id_data_type;
                name = op.name;
                desc = op.desc;
                sort = op.sort;
                on_override = op.on_override;
                on_val_object = op.on_val_object;
                on_val_class = op.on_val_class;
                id_conception = op.id_conception;
                id_class_definition = op.id_class_definition;
                timestamp_class_definition = op.timestamp_class_definition;
                id_prop_definition = op.id_prop_definition;
                string_val = op.string_val;
                on_global = op.on_global;
                id_global_prop = op.id_global_prop;
                tag = op.tag;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Переданное значение композитного типа равно нулю");
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int64 id_class_prop;
        private Int64 id_object_carrier;
        private DateTime timestamp_object_carrier;

        private Int64 id_conception = 0;
        private Int64 id_class;
        private DateTime timestamp_class;
        private Boolean on_inherit;
        private Boolean inheritance;
        private Int64 id_prop_inherit;
        private DateTime timestamp_class_inherit;
        private Int32 id_prop_type;
        private Int32 id_data_type;
        private String name;
        //private Int32 name_len;
        private String desc;
        //private Int32 desc_len;
        private Int32 sort;
        private Boolean on_override;
        private Boolean on_val_object;
        private Boolean on_val_class;

        private Int64 id_class_definition;
        private DateTime timestamp_class_definition;
        private Int64 id_prop_definition;
        private String string_val;
        private Boolean on_global;
        private Int64 id_global_prop;


        /// <summary>
        /// Идентификатор концепции свойства класса
        /// </summary>
        public Int64 Id_conception { get => id_conception; }


        /// <summary>
        /// Строковое представление значения свойства
        /// </summary>
        public String String_val { get => string_val; }

        /// <summary>
        /// Идентификатор свойства объекта(класса)
        /// </summary>
        public Int64 Id_class_prop { get => id_class_prop; }

        /// <summary>
        /// Идентификатор объекта носителя свойства
        /// </summary>
        public Int64 Id_object_carrier { get => id_object_carrier; }

        /// <summary>
        /// Штамп времени объекта носителя свойства
        /// </summary>
        public DateTime Timestamp_object_carrier { get => timestamp_object_carrier; }

        /// <summary>
        /// Идентификатор класса содержащего свойство
        /// </summary>
        public Int64 Id_class { get => id_class; }

        /// <summary>
        /// Штамп времени класса содержащего свойство
        /// </summary>
        public DateTime Timestamp_class { get => timestamp_class; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        String tag;
        /// <summary>
        /// Свойство содержит тэг для группировки свойств в литсте
        /// active/history
        /// </summary>
        public String Tag
        {
            get
            {
                return tag;
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
                DataTable tbl_pos = manager.Instance().TableByName("vclass_prop");
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
        }


        /// <summary>
        /// Максимально допустимая длинна строкового поля
        /// </summary>
        public static Int32 Desc_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_pos = manager.Instance().TableByName("vclass_prop");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["desc"].MaxLength;
                }
                return result;
            }
        }

        /// <summary>
        /// Признак связанного наследования значения свойства от наследуемого свойства
        /// </summary>
        public Boolean On_inherit
        {
            get
            {
                return on_inherit;
            }
        }

        /// <summary>
        /// Признак наследованного свойства
        /// </summary>
        public Boolean Inheritance
        {
            get
            {
                return inheritance;
            }
        }

        /// <summary>
        /// Идентификатор наследованного свойства
        /// </summary>
        public Int64 Id_prop_inherit
        {
            get
            {
                return id_prop_inherit;
            }
        }

        /// <summary>
        /// Штамп времени класса наследованного свойства
        /// </summary>
        public DateTime Timestamp_class_inherit
        {
            get
            {
                return timestamp_class_inherit;
            }
        }


        /// <summary>
        /// Идентификатор типа свойства класса
        /// </summary>
        public Int32 Id_prop_type
        {
            get
            {
                return id_prop_type;
            }
        }

        /// <summary>
        /// Тип свойства класса
        /// </summary>
        public ePropType Prop_type
        {
            get
            {
                return (ePropType)id_prop_type;
            }
        }

        /// <summary>
        /// Идентификатор типа данных свойства класса
        /// </summary>
        public Int32 Id_data_type
        {
            get
            {
                return id_data_type; ;
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
        /// Признак наследованного свойства с переопределяемым на уровне свойства значением
        /// </summary>
        public Boolean On_override
        {
            get
            {
                return on_override;
            }
        }

        /// <summary>
        /// Признак значения установленного на уровне свойства объекта STEP3
        /// </summary>
        public Boolean On_val_object
        {
            get
            {
                return on_val_object;
            }
        }

        /// <summary>
        /// Признак значения установленного на уровне свойства класса STEP2
        /// </summary>
        public Boolean On_val_class
        {
            get
            {
                return on_val_class;
            }
        }

        /// <summary>
        /// Источник значения свойства объекта
        /// </summary>
        public eSourceValue_ObjectProp SourceValue_ObjectProp
        {
            get
            {
                eSourceValue_ObjectProp Result = eSourceValue_ObjectProp.set_null;
                if (on_val_object)
                {
                    Result = eSourceValue_ObjectProp.set_object;
                }
                else
                {
                    if (on_val_class)
                    {
                        Result = eSourceValue_ObjectProp.set_class;
                    }
                }

                return Result;
            }
        }

        /// <summary>
        /// Порядок сортировки свойства класса
        /// </summary>
        public Int32 Sort
        {
            get
            {
                return sort;
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
        /// Идентификатор класса определяющего свойство
        /// </summary>
        public Int64 Id_class_definition
        {
            get
            {
                return id_class_definition;
            }
        }

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
        /// Идентификатор определяющего свойство
        /// </summary>
        public Int64 Id_prop_definition
        {
            get
            {
                return id_prop_definition;
            }
        }

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
                String Result = "";
                switch (Prop_type)
                {
                    case ePropType.PropUser:
                        Result = "object_prop_user_us";
                        break;
                    case ePropType.PropObject:
                        Result = "object_prop_object_us";
                        break;
                    case ePropType.PropEnum:
                        Result = "object_prop_enum_us";
                        break;
                    case ePropType.PropLink:
                        Result = "object_prop_link_us";
                        break;
                }
                return Result;
            }
        }

        /// <summary>
        /// Ключ выделенного объекта
        /// </summary>
        public string SelectedImageKey
        {
            get
            {
                String Result = "";
                switch (Prop_type)
                {
                    case ePropType.PropUser:
                        Result = "object_prop_user_s";
                        break;
                    case ePropType.PropObject:
                        Result = "object_prop_object_s";
                        break;
                    case ePropType.PropEnum:
                        Result = "object_prop_enum_s";
                        break;
                    case ePropType.PropLink:
                        Result = "object_prop_link_s";
                        break;
                }
                return Result;
            }
        }

        #endregion

        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Свойство определяет актуальность текущего состояния
        /// </summary>
        public eEntityState Is_actual()
        {
            return manager.Instance().object_prop_is_actual(this);
        }

        /// <summary>
        /// Объект носитель свойства
        /// </summary>
        public object_general Object_carrier_get(Boolean Extended = false)
        {
            object_general Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_id(this.Id_object_carrier);
            }
            else
            {
                Result = Manager.object_by_id(this.Id_object_carrier);
            }
            return Result;
        }


        /// <summary>
        /// Обновление представления класса из БД, для исторических представлений всегда true
        /// </summary>
        public Boolean Refresh()
        {
            object_prop temp = null;
            Boolean Result = false;

            temp = Manager.object_prop_by_id(id_object_carrier, id_class_prop);
            if (temp != null)
            {
                id_class_prop = temp.id_class_prop;
                timestamp_object_carrier = temp.Timestamp_object_carrier;
                id_class = temp.Id_class;
                timestamp_class = temp.Timestamp_class;
                on_inherit = temp.On_inherit;
                inheritance = temp.Inheritance;
                id_prop_inherit = temp.Id_prop_inherit;
                timestamp_class_inherit = temp.Timestamp_class_inherit;
                id_prop_type = temp.Id_prop_type;
                id_data_type = temp.Id_data_type;
                name = temp.Name;
                desc = temp.Desc;
                sort = temp.Sort;
                on_override = temp.On_override;
                on_val_object = temp.On_val_object;
                on_val_class = temp.On_val_class;
                string_val = temp.String_val;
                on_global = temp.On_inherit;
                id_global_prop = temp.Id_global_prop;
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
        /// Класс носитель свойства наследуемый объектом носителем свойства
        /// </summary>
        public vclass class_carrier_get()
        {
            return Manager.class_carrier_by_id_class_prop(this);
        }


        /// <summary>
        /// Свойство класса наследуемое свойством объекта
        /// </summary>
        public class_prop class_prop_snapshot_get()
        {
            return Manager.class_prop_snapshot_by_id(this);
        }

        /// <summary>
        /// Метод поиска класса определяющего свойство
        /// </summary>
        public vclass class_definition_find()
        {
            return Manager.class_definition_by_id_class_prop(this);
        }

        /// <summary>
        /// Класс определяющий свойство
        /// </summary>
        public vclass class_definition_get()
        {
            vclass Result = null;
            Result = Manager.class_snapshot_by_id(id_class_definition, timestamp_class_definition);
            return Result;
        }


        /// <summary>
        /// Метод поиска определяющего свойства по структуре данных
        /// </summary>
        public class_prop class_prop_definition_find()
        {
            return Manager.class_prop_definition_by_id_class_prop(this);
        }


        /// <summary>
        /// Определяющее свойство
        /// </summary>
        public class_prop class_prop_definition_get()
        {
            class_prop Result = null;
            Result = Manager.class_prop_snapshot_by_id(id_prop_definition, timestamp_class_definition);
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
            return Manager.сon_prop_data_type_by_id(Id_conception, Id_data_type);
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
                return Manager.con_prop_data_type_by_id_prop_type(Id_conception, Id_prop_type);
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
