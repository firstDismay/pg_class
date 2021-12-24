using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Data;
using pg_class.pg_exceptions;
using pg_class.pg_classes;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс классов
    /// </summary>
    public partial class vclass
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected vclass()
        {
            on_change = false;
            ready = false;
            id_position_parent_object = -1;
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public vclass(System.Data.DataRow row) : this()
        {
            switch (row.Table.TableName)
            {
                case "vclass":
                    crow = row;
                    id = (Int64)row["id"];
                    timestamp = Convert.ToDateTime(row["timestamp"]);
                    id_con = (Int64)row["id_con"];
                    id_group = (Int64)row["id_group"];
                    id_group_root = (Int64)row["id_group_root"];
                    id_parent = (Int64)row["id_parent"];
                    timestamp_parent = Convert.ToDateTime(row["timestamp_parent"]);
                    id_root = (Int64)row["id_root"];
                    timestamp_root = Convert.ToDateTime(row["timestamp_root"]);
                    level = (Int32)row["level"];
                    name = (String)row["name"];
                    name_len = row.Table.Columns["name"].MaxLength;
                    desc = (String)row["desc"];
                    desc_len = row.Table.Columns["desc"].MaxLength;
                    on = (Boolean)row["on"];
                    on_extensible = (Boolean)row["on_extensible"];
                    on_abstraction = (Boolean)row["on_abstraction"];
                    id_unit = (Int32)row["id_unit"];
                    id_unit_conversion_rule = (Int32)row["id_unit_conversion_rule"];
                    barcode_manufacturer = (Int64)row["barcode_manufacturer"];
                    barcode_local = (Int64)row["barcode_local"];
                    include_child_class = (Boolean)row["include_child_class"];
                    include_child_abstract_class = (Boolean)row["include_child_abstract_class"];
                    include_child_real_class = (Boolean)row["include_child_real_class"];
                    include_child_object = (Boolean)row["include_child_object"];

                    tablename = (String)row["tablename"];
                    viewname = row.Table.TableName;
                    is_root = (Boolean)row["is_root"];
                    has_active = (Boolean)row["has_active"];
                    timestamp_child_change = Convert.ToDateTime(row["timestamp_child_change"]);
                    child_count = (Int64)row["child_count"];

                    name_format = (String)row["name_format"];
                    quantity_show = (Boolean)row["quantity_show"];
                    in_recycle = (Boolean)row["in_recycle"];
                    on_freeze = (Boolean)row["on_freeze"];
                    ready = (Boolean)row["ready"];
                    path = (String)row["path"];
                    
                    break;
                case "vclass_ext":
                    crow = row;
                    id = (Int64)row["id"];
                    timestamp = Convert.ToDateTime(row["timestamp"]);
                    id_con = (Int64)row["id_con"];
                    id_group = (Int64)row["id_group"];
                    id_group_root = (Int64)row["id_group_root"];
                    id_parent = (Int64)row["id_parent"];
                    timestamp_parent = Convert.ToDateTime(row["timestamp_parent"]);
                    id_root = (Int64)row["id_root"];
                    timestamp_root = Convert.ToDateTime(row["timestamp_root"]);
                    level = (Int32)row["level"];
                    name = (String)row["name"];
                    name_len = row.Table.Columns["name"].MaxLength;
                    desc = (String)row["desc"];
                    desc_len = row.Table.Columns["desc"].MaxLength;
                    on = (Boolean)row["on"];
                    on_extensible = (Boolean)row["on_extensible"];
                    on_abstraction = (Boolean)row["on_abstraction"];
                    id_unit = (Int32)row["id_unit"];
                    id_unit_conversion_rule = (Int32)row["id_unit_conversion_rule"];
                    barcode_manufacturer = (Int64)row["barcode_manufacturer"];
                    barcode_local = (Int64)row["barcode_local"];
                    include_child_class = (Boolean)row["include_child_class"];
                    include_child_abstract_class = (Boolean)row["include_child_abstract_class"];
                    include_child_real_class = (Boolean)row["include_child_real_class"];
                    include_child_object = (Boolean)row["include_child_object"];

                    tablename = (String)row["tablename"];
                    viewname = row.Table.TableName;
                    is_root = (Boolean)row["is_root"];
                    has_active = (Boolean)row["has_active"];
                    timestamp_child_change = Convert.ToDateTime(row["timestamp_child_change"]);
                    child_count = (Int64)row["child_count"];

                    name_format = (String)row["name_format"];
                    quantity_show = (Boolean)row["quantity_show"];
                    in_recycle = (Boolean)row["in_recycle"];
                    on_freeze = (Boolean)row["on_freeze"];
                    ready = (Boolean)row["ready"];

                    property_list = new List<class_prop>();
                    if (!DBNull.Value.Equals(row["property_list"]))
                    {
                        pg_vclass_prop[] acp = (pg_vclass_prop[])row["property_list"];
                        class_prop cp;
                        foreach (pg_vclass_prop i in acp)
                        {
                            cp = new class_prop(i);
                            property_list.Add(cp);
                        }
                    }
                    path = (String)row["path"];
                    break;
                default:
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }

        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы, используется в функциях формирующих списки классов объектов позиций
        /// </summary>
        public vclass(System.Data.DataRow row, Int64 Id_position_parent_object) : this(row)
        {
            id_position_parent_object = Id_position_parent_object;
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int64 id = 0;
        private Int64 id_con;
        private Int64 id_group;
        private Int64 id_group_root;
        private Int64 id_parent;
        private DateTime timestamp_parent;
        private DateTime timestamp_root;
        private Int64 id_root;
        private Int32 level;
        private String name;
        private Int32 name_len;
        private String desc;
        private Int32 desc_len;
        private Boolean on;
        private Boolean on_extensible;
        private Boolean on_abstraction;
        private Int32 id_unit;
        private Int32 id_unit_conversion_rule;
        private Int64 barcode_manufacturer;
        private Int64 barcode_local;
        private Boolean include_child_class;
        private Boolean include_child_real_class;
        private Boolean include_child_abstract_class;
        private Boolean include_child_object;
        private DateTime timestamp;
        private String tablename;
        private String viewname;
        private Boolean is_root;
        private Boolean has_active;
        private DateTime timestamp_child_change;
        private Int64 child_count;

        private String name_format;
        private Boolean quantity_show;
        private Boolean in_recycle;
        private Boolean on_freeze;
        private Boolean ready;

        Int64 id_position_parent_object;
        /// <summary>
        /// Идентификатор позиции носителя объектов класса, свойство активно при получении списка классов позиции в режиме дерева метаданных концепции
        /// </summary>
        public Int64 Id_position_parent_object { get => id_position_parent_object; }

        /// <summary>
        /// Штамп времени изменения колличественного состава потомков
        /// </summary>
        public DateTime Timestamp_child_change { get => timestamp_child_change; }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Int64 Id { get => id;}

        /// <summary>
        /// Идентификатор концепции
        /// </summary>
        public Int64 Id_conception { get => id_con; }

        /// <summary>
        /// Идентификатор группы
        /// </summary>
        public Int64 Id_group { get => id_group; }

        /// <summary>
        /// Идентификатор корневой группы
        /// </summary>
        public Int64 Id_group_root { get => id_group_root; }

        /// <summary>
        /// Штамп времени
        /// </summary>
        public DateTime Timestamp { get => timestamp; }

       

        /// <summary>
        /// Идентификатор родительского узла
        /// </summary>
        public Int64 Id_parent { get => id_parent;}


        /// <summary>
        /// Штамп времени родительского узла
        /// </summary>
        public DateTime Timestamp_parent { get => timestamp_parent; }


        /// <summary>
        /// Штамп времени корневого узла
        /// </summary>
        public DateTime Timestamp_root { get => timestamp_root; }


        /// <summary>
        /// Идентификатор корневого узла
        /// </summary>
        public Int64 Id_root { get => id_root;}

        
        /// <summary>
        /// Признак наличия у историчского класса, активного класса. Всегда true если класс является активным
        /// </summary>
        public Boolean Has_active { get => has_active; }

        /// <summary>
        /// Наименование
        /// </summary>
        public String Name
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
        /// Формат наименования объектов класса
        /// none имя объекта равно имени класса
        /// </summary>
        public String Name_format { get => name_format; }

        /// <summary>
        /// Формат наименования объектов класса установлен
        /// </summary>
        public Boolean Name_format_default
        { get
            {
                Boolean Result = false;
                if (name_format == "none")
                {
                    Result = true;
                }
                return Result;
            }
        }

        /// <summary>
        /// Признак необходимости доавить количество объекта к имени объекта
        /// </summary>
        public Boolean Quantity_show { get => quantity_show; }
        
        /// <summary>
        /// Максимально допустимая длинна строкового поля
        /// </summary>
        public static Int32 NameClass_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_pos  = manager.Instance().TableByName("vclass");
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
        public static  Int32 Desc_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_pos  = manager.Instance().TableByName("vclass");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["desc"].MaxLength;
                }
                return result;
            }
        }
        
        /// <summary>
        /// Доступность создания объектов для неабстрактных классов
        /// </summary>
        public Boolean On
        {
            get
            {
                return on;
            }
            set
            {
                if (on != value)
                {
                    on = value;
                    on_change = true;

                }
            }
        }

        /// <summary>
        /// Доступность создания расширенных свойств определяемых в классе
        /// </summary>
        public Boolean On_extensible
        {
            get
            {
                return on_extensible;
            }
            set
            {
                if (on_extensible != value)
                {
                    on_extensible = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Признак абстрактного класса
        /// </summary>
        public Boolean On_abstraction
        {
            get
            {
                return on_abstraction;
            }
            set
            {
                if (on_abstraction != value)
                {
                    on_abstraction = value;
                    on_change = true;

                }
            }
        }

        /// <summary>
        /// Признак наличия наследующих вещественных классов
        /// </summary>
        public Boolean Include_child_real_class
        {
            get
            {
                return include_child_real_class;
            }
        }

        /// <summary>
        /// Признак наличия наследующих абстрактных классов
        /// </summary>
        public Boolean Include_child_abstract_class
        {
            get
            {
                return include_child_abstract_class;
            }
        }

        /// <summary>
        /// Обобщенный признак наличия наследующих классов
        /// </summary>
        public Boolean Include_child_class
        {
            get
            {
                //Refresh();
                return include_child_class;
            }
        }

        /// <summary>
        /// Класс допускает вложение вещественных классов
        /// </summary>
        public Boolean Allowed_real
        {
            get
            {
                Boolean Result = false;

                if (On_abstraction)
                {
                    if (!Include_child_class)
                    {
                        Result = true;
                    }
                    else
                    {
                        if (Include_child_real_class)
                        {
                            Result = true;
                        }
                    }
                }
                return Result;
            }
        }

        /// <summary>
        /// Класс допускает вложение абстрактных классов
        /// </summary>
        public Boolean Allowed_abstraction
        {
            get
            {
                Boolean Result = false;

                if (On_abstraction)
                {
                    if (!Include_child_class)
                    {
                        Result = true;
                    }
                    else
                    {
                        if (Include_child_abstract_class)
                        {
                            Result = true;
                        }

                    }
                }

                return Result;
            }
        }

        /// <summary>
        /// Иерархический уровень класса в цепи наследования
        /// </summary>
        public eClassLevel ClassLevel
        {
            get
            {
                eClassLevel Result = eClassLevel.Real;
                if (On_abstraction)
                {
                    Result = eClassLevel.Abstraction;
                }

                if (level == 0 & On_abstraction)
                {
                    Result = eClassLevel.Base;
                }
                return Result;
            }
        }

        /// <summary>
        /// Описание иерархического уровеня класса в цепи наследования
        /// </summary>
        public String ClassLevelDesc
        {
            get 
            {
                String Result = "н/д";
                switch (ClassLevel)
                {
                    case eClassLevel.Abstraction:
                        Result = "Абстрактный";
                        break;
                    case eClassLevel.Base:
                        Result = "Базоый";
                        break;
                    case eClassLevel.Real:
                        Result = "Вещественный";
                        break;
                }
                return Result;
            }

        }


        /// <summary>
        /// Общее колличество дочерних классов
        /// </summary>
        public Int64 Child_count
        {
            get
            {
                return child_count;
            }
        }

        /// <summary>
        /// Признак наличия наследующих объектов
        /// </summary>
        public Boolean Include_child_object
        {
            get
            {
                return include_child_object;
            }
        }

        /// <summary>
        /// Признак базового абстрактного класса
        /// </summary>
        public Boolean Is_base
        {
            get
            {
                return is_root;
            }
        }

        /// <summary>
        /// Признак удаленной сущности
        /// </summary>
        public Boolean In_recycle { get => in_recycle; }

        /// <summary>
        /// Признак заблокированной сущности
        /// </summary>
        public Boolean On_freeze { get => on_freeze; }


        /// <summary>
        /// Признак вещественного класса допускающего создание объектов
        /// </summary>
        public Boolean Ready { get => ready; }

        /// <summary>
        /// Идентификатор правила конвертации количественной оценки объектов класса
        /// </summary>
        public Int32 Id_unit_conversion_rule
        {
            get
            {
                return id_unit_conversion_rule;
            }
            set
            {
                if (id_unit_conversion_rule != value)
                {
                    id_unit_conversion_rule = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Идентификатор измеряемой величины
        /// </summary>
        public Int32 Id_unit
        {
            get
            {
                return id_unit;
            }
            set
            {
                if (id_unit != value)
                {
                    id_unit = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Перечисление измеряемой величины
        /// </summary>
        public eUnit Unit { get => (eUnit)id_unit; }

        /// <summary>
        /// Штрихкод производителя 
        /// </summary>
        public Int64 Barcode_manufacturer
        {
            get
            {
                return barcode_manufacturer;
            }
            set
            {
                if (barcode_manufacturer != value)
                {
                    Boolean Chek = Manager.Barcode_EAN13_checksum_check(value);
                    if (Chek)
                    {
                        barcode_manufacturer = value;
                        on_change = true;
                    }
                    else
                    {
                        throw new PgDataException(100103, "Указан не действительный штрихкод производителя!");
                    }
                }
            }
        }

        /// <summary>
        /// Штрихкод производителя проверка
        /// </summary>
        public Boolean Barcode_manufacturer_check
        {
            get
            {
                return Manager.Barcode_EAN13_checksum_check(barcode_manufacturer);
            }
        }
        /// <summary>
        /// Штрихкод локальный определяемый на уровне бизнесассистента
        /// </summary>
        public Int64 Barcode_local
        {
            get
            {
                return barcode_local;
            }
        }

        /// <summary>
        /// Уровень вложенности узла
        /// </summary>
        public Int32 LevelClass { get => level;}

        /// <summary>
        /// Имя таблицы базы ассистента, содержащей запись о классе
        /// </summary>
        public String Tablename
        {
            get
            {
                return tablename;
            }
        }

        /// <summary>
        /// Имя представления базы ассистента, содержащей запись об объекте
        /// </summary>
        public String Viewname { get => viewname; }

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

        private String ImageKey_status()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("vclass_");
            if (On_abstraction)
            {
                sb.Append("abs_");
                if (On)
                {
                    sb.Append("on_");
                }
                else
                {
                    sb.Append("off_");
                }
            }
            else
            {
                sb.Append("real_");
                if (On)
                {
                    sb.Append("on_");
                    if (Ready)
                    {
                        if (Include_child_object)
                        {
                            sb.Append("obj_");
                        }
                    }
                    else
                    {
                        sb.Append("notready_");
                    }
                }
                else
                {
                    sb.Append("off_");
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Ключ объекта
        /// </summary>
        public String ImageKey
        {
            get
            {
                return String.Format("{0}us", ImageKey_status()); ;
            }
        }

        /// <summary>
        /// Ключ выделенного объекта
        /// </summary>
        public string SelectedImageKey
        {
            get
            {
                return String.Format("{0}s", ImageKey_status()); ;
            }
        }
        #endregion

        #region МЕТОДЫ КЛАССА

        /// <summary>
        /// Свойство определяет актуальность текущего состояния
        /// </summary>
        public eEntityState Is_actual()
        {
            return Manager.class_is_actual(this);
        }

        /// <summary>
        /// Обновление представления класса в БД
        /// </summary>
        public Boolean Update()
        {
            Boolean Result = false;
            if (on_change)
            {
                Manager.class_upd(this);
                Refresh();
                on_change = false;
                Result = true;
            }
            return Result;
        }


        /// <summary>
        /// Восстанавливает текущее представление класса по указанному снимку
        /// </summary>
        public void Rollback(vclass Vclass)
        {
            if (on_change)
            {
                Manager.class_rollback(Vclass);
                on_change = false;
            }
        }

        /// <summary>
        /// Перенос представления класса в новую группу
        /// </summary>
        public void Move(group ParentGroup)
        {
            Manager.class_move_to_group(this, ParentGroup);
        }

        /// <summary>
        /// Копирование представления класса в указанную группу
        /// </summary>
        public void Copy_to(group ParentGroup)
        {
            Manager.class_copy_to_group(this, ParentGroup,true);
        }


        /// <summary>
        /// Копирование представления класса в указанный класс
        /// </summary>
        public void Copy_to(vclass ParentClass)
        {
            Manager.class_copy_to_class(this, ParentClass, true);
        }

        /// <summary>
        /// Копирование представления класса в текущем расположении
        /// </summary>
        public void Copy()
        {
            if (this.Is_base)
            {
                Manager.class_copy_to_group(id, id_group, true);
            }
            else
            {
                Manager.class_copy_to_class(id, id_parent, true);
            }
        }

        /// <summary>
        /// Обновление активного представления класса из БД, для исторических представлений всегда true
        /// </summary>
        public Boolean Refresh()
        {
            vclass temp;
            Boolean Result = false;
            if (StorageType == eStorageType.Active)
            {
                switch (viewname)
                {
                    case "vclass":
                        temp = Manager.class_act_by_id(id);
                        if (temp != null)
                        {
                            id = temp.id;
                            id_con = temp.id_con;
                            id_group = temp.id_group;
                            id_group_root = temp.id_group_root;
                            id_parent = temp.id_parent;
                            timestamp_parent = temp.Timestamp_parent;
                            id_root = temp.Id_root;
                            timestamp_root = temp.Timestamp_root;
                            level = temp.LevelClass;
                            name = temp.Name;
                            desc = temp.Desc;
                            desc_len = temp.desc_len;
                            on = temp.On;
                            on_extensible = temp.On_extensible;
                            on_abstraction = temp.On_abstraction;
                            id_unit = temp.Id_unit;
                            id_unit_conversion_rule = temp.Id_unit_conversion_rule;
                            barcode_manufacturer = temp.Barcode_manufacturer;
                            barcode_local = temp.Barcode_local;
                            include_child_class = temp.Include_child_class;
                            include_child_abstract_class = temp.Include_child_abstract_class;
                            include_child_real_class = temp.Include_child_real_class;
                            include_child_object = temp.Include_child_object;
                            timestamp = temp.Timestamp;
                            tablename = temp.Tablename;
                            viewname = temp.Viewname;
                            is_root = temp.Is_base;
                            has_active = temp.Has_active;
                            timestamp_child_change = temp.Timestamp_child_change;
                            child_count = temp.Child_count;
                            in_recycle = temp.In_recycle;
                            on_freeze = temp.On_freeze;
                            ready = temp.Ready;
                            path = temp.Path;
                            Result = true;
                            on_change = false;
                        }
                        else
                        {
                            Result = false;
                        }
                        break;
                    case "vclass_ext":
                        temp = Manager.class_act_ext_by_id(id);
                        if (temp != null)
                        {
                            id = temp.id;
                            id_con = temp.id_con;
                            id_group = temp.id_group;
                            id_group_root = temp.id_group_root;
                            id_parent = temp.id_parent;
                            timestamp_parent = temp.Timestamp_parent;
                            id_root = temp.Id_root;
                            timestamp_root = temp.Timestamp_root;
                            level = temp.LevelClass;
                            name = temp.Name;
                            desc = temp.Desc;
                            desc_len = temp.desc_len;
                            on = temp.On;
                            on_extensible = temp.On_extensible;
                            on_abstraction = temp.On_abstraction;
                            id_unit = temp.Id_unit;
                            id_unit_conversion_rule = temp.Id_unit_conversion_rule;
                            barcode_manufacturer = temp.Barcode_manufacturer;
                            barcode_local = temp.Barcode_local;
                            include_child_class = temp.Include_child_class;
                            include_child_abstract_class = temp.Include_child_abstract_class;
                            include_child_real_class = temp.Include_child_real_class;
                            include_child_object = temp.Include_child_object;
                            timestamp = temp.Timestamp;
                            tablename = temp.Tablename;
                            viewname = temp.Viewname;
                            is_root = temp.Is_base;
                            has_active = temp.Has_active;
                            timestamp_child_change = temp.Timestamp_child_change;
                            child_count = temp.Child_count;
                            in_recycle = temp.In_recycle;
                            on_freeze = temp.On_freeze;
                            ready = temp.Ready;
                            path = temp.Path;

                            property_list = temp.Property_list_get(false);

                            Result = true;
                            on_change = false;
                        }
                        else
                        {
                            Result = false;
                        }
                        break;
                }
            }
            else
            {
                Result = true;
            }
            return Result;
        }

        /// <summary>
        /// Метод удаляет текущий класс
        /// class_del
        /// </summary>
        public void Del()
        {
            Manager.class_del(this);
        }


        /// <summary>
        /// Метод возвращает подготовленный экземпляр построителя формата имен объектов
        /// </summary>
        public class_name_format_builder Format_builder_get()
        {
            class_name_format_builder Result = null;

            if (StorageType == eStorageType.Active)
            {
                Result = new class_name_format_builder(this);
            }
            else
            {
                throw new PgDataException(eEntity.vclass, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                    "Построитель формата имен объектов не доступен в историческом представлении класса!");
            }
            return Result;
        }

        /// <summary>
        /// Макет наименования объектов класса
        /// </summary>
        public String Name_layout_get()
        {
            String Result;
            String Class_name_layout = "Наименование класса";
            String[] format_array;

            //Определяем массив раделителей
            char[] charSeparators = new char[] { ',' };
            
            //Определяем макет в отсуствии формата
            Result = "{" + Class_name_layout + "}";

            if (name_format != "none")
            {   //Полуаем массив строк формата
                format_array = name_format.Split(charSeparators);

                //Обрабатываем массив строк формата
                String key;
                String pattern;
                Int64 cp_id;
                class_prop cp;

                Result = format_array[0].Substring(1, format_array[0].Length-2);
                for (int s = 1; s < format_array.Length; s++)
                {
                    //Ключ подстановки
                    key = "%s" + (s - 1).ToString();

                    //Текст подстановки
                    cp_id = Convert.ToInt64(format_array[s]);
                    cp = Manager.class_prop_by_id(cp_id);
                    if (cp != null)
                    {
                        pattern = "{" + cp.Name + "}";
                    }
                    else
                    {
                        pattern = "{н/д}";
                    }

                    //Подстановка
                    Result = Result.Replace(key, pattern);
                }

                //Ключ подстановки
                key = "%c";
                pattern = "{" + Class_name_layout + "}";
                //Подстановка
                Result = Result.Replace(key, pattern);
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
            return name;
        }
        #endregion

    }
}
