using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Data;
using pg_class.pg_exceptions;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс свойств класса
    /// </summary>
    public partial class class_prop
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected class_prop()
        {
            on_change = false;
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public class_prop(System.Data.DataRow row) : this()
        {

            if (row.Table.TableName == "vclass_prop")
            {
                crow = row;
                id = (Int64)row["id"];
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
                on_override_prop_inherit = (Boolean)row["on_override_prop_inherit"];
                on_val = (Boolean)row["on_val"];
                string_val = (String)row["string_val"];
                
                tablename = (String)row["tablename"];
                ready = (Boolean)row["ready"];
                id_conception = (Int64)row["id_conception"];

                id_class_definition = (Int64)row["id_class_definition"];
                if (!DBNull.Value.Equals(row["timestamp_class_definition"]))
                {
                    timestamp_class_definition = Convert.ToDateTime(row["timestamp_class_definition"]);
                }
                id_prop_definition = (Int64)row["id_prop_definition"];

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
        public class_prop(pg_vclass_prop cp) : this()
        {

            if (cp != null)
            {
                id = cp.id;
                id_class = cp.id_class;
                timestamp_class = cp.timestamp_class;
                on_inherit = cp.on_inherit;
                inheritance = cp.inheritance;
                id_prop_inherit = cp.id_prop_inherit;
                timestamp_class_inherit = cp.timestamp_class_inherit;
                id_prop_type = cp.id_prop_type;
                id_data_type = cp.id_data_type;
                name = cp.name;
                desc = cp.desc;
                
                sort = cp.sort;
                on_override = cp.on_override;
                on_override_prop_inherit = cp.on_override_prop_inherit;
                on_val = cp.on_val;
                string_val = cp.string_val;

                tablename = cp.tablename;
                ready = cp.ready;
                id_conception = cp.id_conception;
                id_class_definition = cp.id_class_definition;
                timestamp_class_definition = cp.timestamp_class_definition;
                id_prop_definition = cp.id_prop_definition;
                on_global = cp.on_global;
                id_global_prop = cp.id_global_prop;
                tag = cp.tag;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Переданное значение композитного типа равно нулю");
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int64 id_conception = 0;
        private Int64 id = 0;
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
        private Boolean on_override_prop_inherit;
        private Boolean on_val;
        private String string_val;
        private String tablename;
        private Boolean ready;
        private Boolean on_global;
        private Int64 id_global_prop;

        private Int64 id_class_definition;
        private DateTime timestamp_class_definition;
        private Int64 id_prop_definition;

        /// <summary>
        /// Идентификатор концепции свойства класса
        /// </summary>
        public Int64 Id_conception { get => id_conception; }

        /// <summary>
        /// Идентификатор свойства объекта(класса)
        /// </summary>
        public Int64 Id { get => id; }

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
            set
            {
                if (name != value)
                {
                    if (value.Length > Name_len)
                    {
                        value = value.Substring(0, Name_len);
                    }
                    name = value;
                    on_change = true;
                }
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
            set
            {
                if (tag != value)
                {
                    tag = value;
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
                DataTable tbl_pos  = manager.Instance().TableByName("vclass_prop");
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
                    if (value.Length > Desc_len)
                    {
                        value = value.Substring(0, Desc_len);
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
                DataTable tbl_pos  = manager.Instance().TableByName("vclass_prop");
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
            set
            {
                if (on_inherit != value)
                {
                    on_inherit = value;
                    on_change = true;
                }
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

        /// <summary>
        /// Признак наследуемого свойства с переопределяемым на уровне свойства значением
        /// </summary>
        public Boolean On_override_prop_inherit
        {
            get
            {
                return on_override_prop_inherit;
            }
        }

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


        /// <summary>
        /// Порядок сортировки свойства класса
        /// </summary>
        public Int32 Sort
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


        /// <summary>
        /// Имя таблицы базы ассистента, содержащей запись о свойстве классе
        /// </summary>
        public String Tablename
        {
            get
            {
                return tablename;
            }
        }

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
        /// Тип хранилища данных сущности
        /// </summary>
        public eStorageType StorageType
        {
            get
            {
                String pattern = "snapshot";
                eStorageType tmp = eStorageType.Active;
                if (System.Text.RegularExpressions.Regex.IsMatch(tablename, pattern))
                {
                    tmp = eStorageType.History;
                }
                return tmp;
            }
        }

        /// <summary>
        /// Значение свойство инициализировано, готово к созданию объекта, шаг №2
        /// </summary>
        public Boolean Ready
        {
            get
            {
                return ready;
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
        public String ImageKey
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("class_prop_");
                if (Inheritance)
                {
                    sb.Append("inheritance_");
                }
                else
                {
                    sb.Append("create_");
                }
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
                sb.Append("class_prop_");
                if (Inheritance)
                {
                    sb.Append("inheritance_");
                }
                else
                {
                    sb.Append("create_");
                }
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

        #endregion

        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Свойство определяет актуальность текущего состояния
        /// </summary>
        public eEntityState Is_actual()
        {
            return manager.Instance().class_prop_is_actual(this);
        }


        /// <summary>
        /// Обновление представления класса в БД
        /// </summary>
        public void Update()
        {
            if (on_change & (StorageType == eStorageType.Active))
            {
                Manager.class_prop_upd(this);
                Refresh();
                on_change = false;
            }
        }

        /// <summary>
        /// Метод изменяет флаг переопределяемости в свойствах наследующих вещественных классов
        /// </summary>
        public void Prop_inheriting_override_set(Boolean ion_override)
        {
            if (StorageType == eStorageType.Active)
            {
                Manager.class_prop_inheriting_override_set(this, ion_override);
                Refresh();
                on_change = false;
            }
        }

        /// <summary>
        /// Обновление представления класса из БД, для исторических представлений всегда true
        /// </summary>
        public Boolean Refresh()
        {
            class_prop temp = null;
            Boolean Result = false;
            if (StorageType == eStorageType.Active)
            {
                temp = Manager.class_prop_by_id(id);
                if (temp != null)
                {
                    id = temp.Id;
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
                    on_override_prop_inherit = temp.on_override_prop_inherit;
                    on_val = temp.On_val;
                    tablename = temp.Tablename;
                    ready = temp.Ready;
                    on_global = temp.On_global;
                    id_global_prop = temp.Id_global_prop;
                    string_val = temp.string_val;
                    id_class_definition = temp.id_class_definition;
                    timestamp_class_definition = temp.timestamp_class_definition;
                    id_prop_definition = temp.id_prop_definition;
                    tag = temp.tag;

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
        public vclass class_carrier_get()
        {
            return Manager.class_carrier_by_id_class_prop(this);
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
            switch (StorageType)
            {
                case eStorageType.Active:
                    Result = Manager.class_act_by_id(id_class_definition);
                    break;
                case eStorageType.History:
                    Result = Manager.class_snapshot_by_id(id_class_definition, timestamp_class_definition);
                    break;
            }
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
            switch (StorageType)
            {
                case eStorageType.Active:
                    Result = Manager.class_prop_by_id(id_prop_definition);
                    break;
                case eStorageType.History:
                    Result = Manager.class_prop_snapshot_by_id(id_prop_definition, timestamp_class_definition);
                    break;
            }
            return Result;
        }

        /// <summary>
        /// Метод проверки свойства на целостность
        /// </summary>
        public Boolean class_prop_check()
        {
            Boolean Result = true;

            class_prop cpd = class_prop_definition_get();
            class_prop cpd_find = class_prop_definition_find();

            if (cpd != null & cpd_find != null)
            {
                if (this.StorageType == eStorageType.Active)
                {
                    if (cpd.Id != cpd_find.Id)
                    {
                        Result = false;
                    }
                }
                else
                {
                    if ((cpd.Id != cpd_find.Id) || (cpd.Timestamp_class != cpd_find.Timestamp_class))
                    {
                        Result = false;
                    }
                }
            }
            else
            {
                Result = false;
            }
            return Result;
        }

        /// <summary>
        /// Наследованное свойство
        /// </summary>
        public class_prop class_prop_inherit_get()
        {
            class_prop Result = null;
            switch (StorageType)
            {
                case eStorageType.Active:
                    Result = Manager.class_prop_by_id(Id_prop_inherit);
                    break;
                case eStorageType.History:
                    Result = Manager.class_prop_snapshot_by_id(Id_prop_inherit, timestamp_class_inherit);
                    break;
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
        /// class_prop_del_cascade
        /// </summary>
        public void Del()
        {
            Manager.class_prop_del_cascade(this);
        }

        /// <summary>
        /// Метод определяет наличие свойств вещественных классов переопределяемых по значению в объектах указанной позиции
        /// </summary>
        public Boolean Has_object_prop_override_by_id_pos(Int64 Id_position_parent, Boolean on_internal = false)
        {
            return Manager.class_prop_has_object_prop_override_by_id_pos(Id_position_parent, this, on_internal);
        }

        /// <summary>
        /// Метод определяет наличие свойств вещественных классов переопределяемых по значению в объектах указанной позиции
        /// </summary>
        public Boolean Has_object_prop_override_by_id_pos(position Position_parent, Boolean on_internal = false)
        {
            return Manager.class_prop_has_object_prop_override_by_id_pos(Position_parent, this, on_internal);
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
