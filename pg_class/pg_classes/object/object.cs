using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс обобщенного представления объектов
    /// </summary>
    public partial class object_general
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected object_general()
        {
            on_change = false;
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public object_general(System.Data.DataRow row) : this()
        {
            switch (row.Table.TableName)
            {
                case "vobject_general":
                    viewname = row.Table.TableName;
                    id = (Int64)row["id"];
                    name = (String)row["name"];
                    name_len = row.Table.Columns["name"].MaxLength;
                    id_conception = (Int64)row["id_conception"];
                    id_position = (Int64)row["id_position"];
                    id_position_root = (Int64)row["id_position_root"];
                    id_group = (Int64)row["id_group"];
                    id_group_root = (Int64)row["id_group_root"];
                    id_class = (Int64)row["id_class"];
                    id_class_root = (Int64)row["id_class_root"];
                    timestamp_class = Convert.ToDateTime(row["timestamp_class"]);
                    barcode_unit = (Int64)row["barcode_unit"];
                    id_unit_conversion_rule = (Int32)row["id_unit_conversion_rule"];
                    bquantity = (Decimal)row["bquantity"];
                    bunit = (String)row["bunit"];
                    mc = (Decimal)row["mc"];
                    cquantity = (Decimal)row["cquantity"];
                    cunit = (String)row["cunit"];
                    on_technical = (Boolean)row["on_technical"];
                    on_commercial = (Boolean)row["on_commercial"];
                    on_accounting = (Boolean)row["on_accounting"];
                    timestamp = Convert.ToDateTime(row["timestamp"]);
                    on_freeze = (Boolean)row["on_freeze"];
                    id_object_carrier = (Int64)row["id_object_carrier"];
                    is_inside = (Boolean)row["is_inside"];
                    desc = (String)row["desc"];
                    id_class_prop_object_carrier = (Int64)row["id_class_prop_object_carrier"];
                    id_unit = (Int32)row["id_unit"];

                    has_user_property = (Boolean)row["has_user_property"];
                    has_enum_property = (Boolean)row["has_enum_property"];
                    has_object_property = (Boolean)row["has_object_property"];
                    has_link_property = (Boolean)row["has_link_property"];

                    in_recycle = (Boolean)row["in_recycle"];

                    name_format = (String)row["name_format"];
                    quantity_show = (Boolean)row["quantity_show"];

                    id_pos_temp_prop = (Int64)row["id_pos_temp_prop"];
                    path = (String)row["path"];
                    round = (Int32)row["round"];
                    break;

                case "vobject_general_ext":
                    viewname = row.Table.TableName;
                    id = (Int64)row["id"];
                    name = (String)row["name"];
                    name_len = row.Table.Columns["name"].MaxLength;
                    id_conception = (Int64)row["id_conception"];
                    id_position = (Int64)row["id_position"];
                    id_position_root = (Int64)row["id_position_root"];
                    id_group = (Int64)row["id_group"];
                    id_group_root = (Int64)row["id_group_root"];
                    id_class = (Int64)row["id_class"];
                    id_class_root = (Int64)row["id_class_root"];
                    timestamp_class = Convert.ToDateTime(row["timestamp_class"]);
                    barcode_unit = (Int64)row["barcode_unit"];
                    id_unit_conversion_rule = (Int32)row["id_unit_conversion_rule"];
                    bquantity = (Decimal)row["bquantity"];
                    bunit = (String)row["bunit"];
                    mc = (Decimal)row["mc"];
                    cquantity = (Decimal)row["cquantity"];
                    cunit = (String)row["cunit"];
                    on_technical = (Boolean)row["on_technical"];
                    on_commercial = (Boolean)row["on_commercial"];
                    on_accounting = (Boolean)row["on_accounting"];
                    timestamp = Convert.ToDateTime(row["timestamp"]);
                    on_freeze = (Boolean)row["on_freeze"];
                    id_object_carrier = (Int64)row["id_object_carrier"];
                    is_inside = (Boolean)row["is_inside"];
                    desc = (String)row["desc"];
                    id_class_prop_object_carrier = (Int64)row["id_class_prop_object_carrier"];
                    id_unit = (Int32)row["id_unit"];

                    has_user_property = (Boolean)row["has_user_property"];
                    has_enum_property = (Boolean)row["has_enum_property"];
                    has_object_property = (Boolean)row["has_object_property"];
                    has_link_property = (Boolean)row["has_link_property"];

                    in_recycle = (Boolean)row["in_recycle"];

                    name_format = (String)row["name_format"];
                    quantity_show = (Boolean)row["quantity_show"];

                    id_pos_temp_prop = (Int64)row["id_pos_temp_prop"];
                    path = (String)row["path"];
                    round = (Int32)row["round"];

                    property_list = new List<object_prop>();

                    if (!DBNull.Value.Equals(row["property_list"]))
                    {
                        pg_vobject_prop[] acp = (pg_vobject_prop[])row["property_list"];
                        object_prop cp;
                        foreach (pg_vobject_prop i in acp)
                        {
                            cp = new object_prop(i);
                            property_list.Add(cp);
                        }
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int64 id = 0;
        private String name;
        private Int32 name_len;
        private Int64 id_conception;
        private Int64 id_position;
        private Int64 id_position_root;
        private Int64 id_group;
        private Int64 id_group_root;
        private Int64 id_class;
        private Int64 id_class_root;
        private DateTime timestamp_class;
        private Int64 barcode_unit;
        private Int32 id_unit;
        private Int32 id_unit_conversion_rule;
        private Decimal bquantity;
        private String bunit;
        private Decimal mc;
        private Decimal cquantity;
        private String cunit;
        private Boolean on_technical;
        private Boolean on_commercial;
        private Boolean on_accounting;
        private DateTime timestamp;
        private Boolean on_freeze;
        private Int64 id_object_carrier;
        private Int64 id_class_prop_object_carrier;
        private Int64 id_pos_temp_prop;
        private Boolean is_inside;
        private String desc;
        private String path;
        private Int32 round;

        private Boolean has_user_property;
        private Boolean has_enum_property;
        private Boolean has_object_property;
        private Boolean has_link_property;

        private String name_format;
        private Boolean quantity_show;
        private Boolean in_recycle;

        private String viewname;
        /// <summary>
        /// Имя представления базы ассистента, содержащей запись об объекте
        /// </summary>
        public String Viewname { get => viewname; }


        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public Int64 Id { get => id; }

        /// <summary>
        /// Идентификатор концепции объекта
        /// </summary>
        public Int64 Id_conception { get => id_conception; }

        /// <summary>
        /// Идентификатор позиции объекта
        /// </summary>
        public Int64 Id_position { get => id_position; }

        /// <summary>
        /// Идентификатор корневой позиции объекта
        /// </summary>
        public Int64 Id_position_root { get => id_position_root; }

        /// <summary>
        /// Идентификатор группы класса объекта
        /// </summary>
        public Int64 Id_group { get => id_group; }

        /// <summary>
        /// Идентификатор корневой группы класса объекта
        /// </summary>
        public Int64 Id_group_root { get => id_group_root; }

        /// <summary>
        /// Идентификатор класса объекта
        /// </summary>
        public Int64 Id_class { get => id_class; }

        /// <summary>
        /// Идентификатор корневого класса объекта
        /// </summary>
        public Int64 Id_class_root { get => id_class_root; }


        /// <summary>
        /// Уникальный штрих-код объекта
        /// </summary>
        public Int64 Barcode_unit { get => barcode_unit; }

        /// <summary>
        /// Признак встроенного объекта
        /// </summary>
        public Boolean Is_inside { get => is_inside; }


        /// <summary>
        /// Признак установленного технического расширения объекта
        /// </summary>
        public Boolean Оn_technical { get => on_technical; }

        /// <summary>
        /// Признак установленного коммерчесого расширения объекта
        /// </summary>
        public Boolean On_commercial { get => on_commercial; }

        /// <summary>
        /// Признак установленного бухгалтерского расширения объекта
        /// </summary>
        public Boolean Оn_accounting { get => on_accounting; }

        /// <summary>
        /// Признак заблокированного объекта
        /// </summary>
        public Boolean Оn_freeze { get => on_freeze; }

        /// <summary>
        /// Штамп времени объекта
        /// </summary>
        public DateTime Timestamp { get => timestamp; }

        /// <summary>
        /// Штамп времени класса объекта
        /// </summary>
        public DateTime Timestamp_class { get => timestamp_class; }

        /// <summary>
        /// Наименование класса объекта
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

        }

        /// <summary>
        /// Описание класса объекта
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
        public static Int32 Name_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_con = manager.Instance().TableByName("vobject_general");
                if (tbl_con != null)
                {
                    result = tbl_con.Columns["name"].MaxLength;
                }
                return result;
            }
        }

        /// <summary>
        /// Признак наличия у объекта пользовательских свойств
        /// </summary>
        public Boolean Has_User_property { get => has_user_property; }
        /// <summary>
        /// Признак наличия у объекта свойств перечислений
        /// </summary>
        public Boolean Has_Enum_property { get => has_enum_property; }

        /// <summary>
        /// Признак наличия у объекта объектных свойств
        /// </summary>
        public Boolean Has_Object_property { get => has_object_property; }

        /// <summary>
        /// Признак наличия у объекта свойств-ссылок
        /// </summary>
        public Boolean Has_link_property { get => has_link_property; }


        /// <summary>
        /// Признак удаленной сущности
        /// </summary>
        public Boolean In_recycle { get => in_recycle; }


        /// <summary>
        /// Формат наименования объектов класса
        /// none имя объекта равно имени класса
        /// </summary>
        public String Name_format { get => name_format; }


        /// <summary>
        /// Признак необходимости отобажения колличества в имени объекта
        /// </summary>
        public Boolean Quantity_show { get => quantity_show; }


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
                sb.Append("object_us");
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
                sb.Append("object_s");
                return sb.ToString();
            }
        }

        #endregion

        #region МЕТОДЫ КЛАССА

        /// <summary>
        /// Свойство определяет актуальность текущего состояния объекта
        /// </summary>
        public eEntityState Is_actual()
        {
            return manager.Instance().object_is_actual(this);
        }

        /// <summary>
        /// Обновление концепции в БД
        /// </summary>
        public void Update()
        {
            if (on_change)
            {
                Manager.object_upd(this);
                Refresh();
                on_change = false;
            }
        }

        /// <summary>
        /// Метод выполняет приведение объекта к указанному снимку того же класса
        /// </summary>
        public void Cast(vclass Class_target)
        {
            if (this.Id_class == Class_target.Id)
            {
                Manager.object_cast(this, Class_target);
                Refresh();
                on_change = false;
            }
            else
            {
                throw (new pg_exceptions.PgDataException(eEntity.vclass, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                    "Указанный класс не соотвествует классу объекта!"));
            }
        }

        /// <summary>
        /// Метод копирует объект в указанную позицию
        /// object_copy
        /// </summary>
        public object_general Copy_to(position Position_target)
        {
            return Manager.object_copy(this, Position_target);
        }

        /// <summary>
        /// Метод копирует объект в указанное свойство позиции
        /// object_copy
        /// </summary>
        public object_general Copy_to(position_prop Position_prop_target)
        {
            return Manager.object_copy(this, Position_prop_target);
        }

        /// <summary>
        /// Метод копирует объект в указанное свойство объекта
        /// object_copy
        /// </summary>
        public object_general Copy_to(object_prop Object_prop_target)
        {
            return Manager.object_copy(this, Object_prop_target);
        }

        /// <summary>
        /// Метод копирует объект в текущее расположение
        /// object_copy
        /// </summary>
        public object_general Copy()
        {
            object_general Result = null;
            if (!this.Is_inside)
            {
                Result = Manager.object_copy(this.Id, (Int32)eEntity.position, this.id_position, -1);
            }
            else if (this.Id_class_prop_object_carrier > 0)
            {
                Result = Manager.object_copy(this.Id, (Int32)eEntity.object_prop, this.Id_class_prop_object_carrier, this.id_position);
            }
            else if (this.Id_pos_temp_prop_position_carrier > 0)
            {
                Result = Manager.object_copy(this.Id, (Int32)eEntity.position_prop, this.Id_pos_temp_prop_position_carrier, this.id_position);
            }
            return Result;
        }

        /// <summary>
        /// Обновление концепции из БД
        /// </summary>
        public Boolean Refresh()
        {
            object_general temp;
            Boolean Result = false;

            switch (viewname)
            {
                case "vobject_general":
                    temp = Manager.object_by_id(id);
                    if (temp != null)
                    {
                        viewname = temp.Viewname;
                        id = temp.Id;
                        name = temp.Name;
                        desc = temp.Desc;
                        id_conception = temp.Id_conception;
                        id_position = temp.Id_position;
                        id_position_root = temp.Id_position_root;
                        id_group = temp.Id_group;
                        id_group_root = temp.Id_group_root;
                        id_class = temp.Id_class;
                        id_class_root = temp.Id_class_root;
                        timestamp_class = temp.Timestamp_class;

                        id_object_carrier = temp.Id_object_carrier;
                        id_pos_temp_prop = temp.Id_pos_temp_prop_position_carrier;

                        id_class_prop_object_carrier = temp.Id_class_prop_object_carrier;
                        barcode_unit = temp.Barcode_unit;
                        id_unit_conversion_rule = temp.Id_unit_conversion_rule;
                        bquantity = temp.Quantity_base;
                        bunit = temp.Unit_base;
                        id_unit = temp.Id_unit;
                        mc = temp.MC;
                        round = temp.Round;
                        cquantity = temp.Quantity_curent;
                        cunit = temp.Unit_curent;
                        on_technical = temp.on_technical;
                        on_commercial = temp.On_commercial;
                        on_accounting = temp.on_accounting;
                        timestamp = temp.Timestamp;
                        on_freeze = temp.on_freeze;
                        has_user_property = temp.Has_User_property;
                        has_enum_property = temp.Has_Enum_property;
                        has_object_property = temp.Has_Object_property;
                        has_link_property = temp.has_link_property;
                        in_recycle = temp.In_recycle;
                        quantity_show = temp.Quantity_show;
                        path = temp.Path;
                        is_inside = temp.Is_inside;

                        name_format = temp.Name_format;
                        Result = true;
                        on_change = false;
                    }
                    else
                    {
                        Result = false;
                    }
                    break;
                case "vobject_general_ext":
                    temp = Manager.object_ext_by_id(id);
                    if (temp != null)
                    {
                        viewname = temp.Viewname;
                        id = temp.Id;
                        name = temp.Name;
                        desc = temp.Desc;
                        id_conception = temp.Id_conception;
                        id_position = temp.Id_position;
                        id_position_root = temp.Id_position_root;
                        id_group = temp.Id_group;
                        id_group_root = temp.Id_group_root;
                        id_class = temp.Id_class;
                        id_class_root = temp.Id_class_root;
                        timestamp_class = temp.Timestamp_class;

                        id_object_carrier = temp.Id_object_carrier;
                        id_pos_temp_prop = temp.Id_pos_temp_prop_position_carrier;

                        id_class_prop_object_carrier = temp.Id_class_prop_object_carrier;
                        barcode_unit = temp.Barcode_unit;
                        id_unit_conversion_rule = temp.Id_unit_conversion_rule;
                        bquantity = temp.Quantity_base;
                        bunit = temp.Unit_base;
                        id_unit = temp.Id_unit;
                        mc = temp.MC;
                        round = temp.Round;
                        cquantity = temp.Quantity_curent;
                        cunit = temp.Unit_curent;
                        on_technical = temp.on_technical;
                        on_commercial = temp.On_commercial;
                        on_accounting = temp.on_accounting;
                        timestamp = temp.Timestamp;
                        on_freeze = temp.on_freeze;
                        has_user_property = temp.Has_User_property;
                        has_enum_property = temp.Has_Enum_property;
                        has_object_property = temp.Has_Object_property;
                        has_link_property = temp.has_link_property;
                        in_recycle = temp.In_recycle;
                        quantity_show = temp.Quantity_show;
                        path = temp.Path;
                        is_inside = temp.Is_inside;
                        name_format = temp.Name_format;
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
            return Result;
        }


        /// <summary>
        /// Перенос объекта в пределах текущей концепции с cоблюдением правил вложенности
        /// </summary>
        public void Move(position TargetPosition, Decimal icquantity)
        {
            Manager.object_move(this, TargetPosition, icquantity);
            Refresh();
        }

        /// <summary>
        /// Метод удаляет текущий объект
        /// object_del
        /// </summary>
        public void Del()
        {
            Manager.object_del(this);
        }

        /// <summary>
        /// Метод удаляет текущий объект
        /// object_destroy
        /// </summary>
        public void Destroy()
        {
            Manager.object_destroy(this);
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
                object_prop cp;

                Result = format_array[0];
                for (int s = 1; s < format_array.Length; s++)
                {
                    //Ключ подстановки
                    key = "%s" + (s - 1).ToString();

                    //Текст подстановки
                    cp_id = Convert.ToInt64(format_array[s]);
                    cp = Manager.object_prop_by_id_prop_definition(this, cp_id);
                    if (cp != null)
                    {
                        pattern = "{" + cp.Name + "}";
                    }
                    else
                    {
                        pattern = "н/д";
                    }

                    //Подстановка
                    Result = Result.Replace(key, pattern);
                }
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
            return ToString(eEntityToString.DefaultName);
        }

        /// <summary>
        ///Дополнительный метод класса для работы с листами и списками
        /// </summary>
        public string ToString(eEntityToString Format)
        {
            StringBuilder Result = new StringBuilder();

            switch (Format)
            {
                case eEntityToString.DefaultName:
                    if (quantity_show)
                    {
                        Result.Append(name);
                        Result.Append(" - ");
                        Result.Append(cquantity.ToString("G", new CultureInfo("ru-RU")));
                        Result.Append(" ");
                        Result.Append(cunit);
                    }
                    else
                    {
                        Result.Append(name);
                    }
                    break;
                case eEntityToString.FullName:
                    Result.Append(name);
                    Result.Append(" - ");
                    Result.Append(cquantity.ToString("G", new CultureInfo("ru-RU")));
                    Result.Append(" ");
                    Result.Append(cunit);
                    break;
                case eEntityToString.ShortName:
                    Result.Append(name);
                    break;
            }
            return Result.ToString();
        }
        #endregion
    }
}
