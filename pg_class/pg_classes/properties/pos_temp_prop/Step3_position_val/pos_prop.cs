using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс свойства шаблона позиции
    /// </summary>
    public partial class position_prop
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected position_prop()
        {
        }

        
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public position_prop(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "vposition_prop")
            {
                id_conception = (Int64)row["id_conception"];
                id_position_carrier = (Int64)row["id_position_carrier"];
                id_pos_temp = (Int64)row["id_pos_temp"];
                id_pos_temp_prop = (Int64)row["id_pos_temp_prop"];
                id_prop_type = (Int32)row["id_prop_type"];
                id_data_type = (Int32)row["id_data_type"];
                name = (String)row["name"];
                name_len = row.Table.Columns["name"].MaxLength;
                desc = (String)row["desc"];
                desc_len = row.Table.Columns["desc"].MaxLength;
                sort = (Int32)row["sort"];
                on_override = (Boolean)row["on_override"];
                on_val_position = (Boolean)row["on_val_position"];
                on_val_pos_temp = (Boolean)row["on_val_pos_temp"];
                on_global = (Boolean)row["on_global"];
                id_global_prop = (Int64)row["id_global_prop"];
                string_val = (String)row["string_val"];
                timestamp_position_carrier = Convert.ToDateTime(row["timestamp_position_carrier"]);
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }

        #endregion

        #region СВОЙСТВА КЛАССА

        private DateTime timestamp_position_carrier;
        /// <summary>
        /// Штамп времени позиции носителя свойства
        /// </summary>
        public DateTime Timestamp_position_carrier
        {
            get
            {
                return timestamp_position_carrier;
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
                DataTable tbl_pos  = manager.Instance().TableByName("vpos_temp_prop");
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
                DataTable tbl_pos  = manager.Instance().TableByName("vpos_temp_prop");
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
        }

        private Int64 id_position_carrier;
        /// <summary>
        /// Идентификатор позиции носителя
        /// </summary>
        public Int64 Id_position_carrier
        {
            get
            {
                return id_position_carrier;
            }
        }

        private Int64 id_pos_temp;
        /// <summary>
        /// Идентификатор шаблона позиции
        /// </summary>
        public Int64 Id_pos_temp
        {
            get
            {
                return id_pos_temp;
            }
        }

        private Int64 id_pos_temp_prop;
        /// <summary>
        /// Идентификатор свойства шаблона
        /// </summary>
        public Int64 Id_pos_temp_prop
        {
            get
            {
                return id_pos_temp_prop;
            }
        }

        /// <summary>
        /// Идентификатор свойства шаблона
        /// </summary>
        public Int64 Id_position_prop
        {
            get
            {
                return id_pos_temp_prop;
            }
        }

        private Boolean on_val_position;
        /// <summary>
        /// Признак значения установленного на уровне свойства позиции
        /// </summary>
        public Boolean On_val_position
        {
            get
            {
                return on_val_position;
            }
        }

        private Boolean on_val_pos_temp;
        /// <summary>
        /// Признак значения установленного на уровне свойства шаблона
        /// </summary>
        public Boolean On_val_pos_temp
        {
            get
            {
                return on_val_pos_temp;
            }
        }

        /// <summary>
        /// Источник значения свойства позиции
        /// </summary>
        public eSourceValue_PositionProp SourceValue_PositionProp
        {
            get
            {
                eSourceValue_PositionProp Result = eSourceValue_PositionProp.set_null;
                if (on_val_position)
                {
                    Result = eSourceValue_PositionProp.set_position;
                }
                else
                {
                    if (on_val_pos_temp)
                    {
                        Result = eSourceValue_PositionProp.set_pos_temp;
                    }
                }
                return Result;
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
        public string ImageKey
        {
            get
            {
                String Result = "";
                switch (Prop_type)
                {
                    case ePropType.PropUser:
                        Result = "position_prop_user_us";
                        break;
                    case ePropType.PropObject:
                        Result = "position_prop_object_us";
                        break;
                    case ePropType.PropEnum:
                        Result = "position_prop_enum_us";
                        break;
                    case ePropType.PropLink:
                        Result = "position_prop_link_us";
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
                        Result = "position_prop_user_s";
                        break;
                    case ePropType.PropObject:
                        Result = "position_prop_object_s";
                        break;
                    case ePropType.PropEnum:
                        Result = "position_prop_enum_s";
                        break;
                    case ePropType.PropLink:
                        Result = "position_prop_link_s";
                        break;
                }
                return Result;
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
            return Manager.position_prop_is_actual(this);
        }

        /// <summary>
        /// Позиция носитель свойства
        /// </summary>
        public position position_carrier_get()
        {
            return Manager.pos_by_id(id_position_carrier);
        }

        /// <summary>
        /// Шаблон позиции носителя свойства
        /// </summary>
        public pos_temp pos_temp_position_carrier_get()
        {
            return Manager.pos_temp_by_id(id_pos_temp);
        }

        /// <summary>
        /// Обновление данных свойства позции
        /// </summary>
        public Boolean Refresh()
        {
            position_prop temp = null;
            Boolean Result = false;

            temp = Manager.position_prop_by_id(id_position_carrier, id_pos_temp_prop);
            if (temp != null)
            {
                id_conception = temp.Id_conception;
                id_pos_temp = temp.Id_pos_temp;
                id_prop_type = temp.Id_prop_type;
                id_data_type = temp.Id_data_type;
                name = temp.Name;
                desc = temp.Desc;
                sort = temp.Sort;
                on_override = temp.On_override;
                on_val_position = temp.On_val_position;
                on_val_pos_temp = temp.on_val_pos_temp;

                on_global = temp.On_global;
                id_global_prop = temp.Id_global_prop;
                string_val = temp.String_val;
                timestamp_position_carrier = temp.timestamp_position_carrier;
                Result = true;
                
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

        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override String ToString()
        {
            return name;
        }
        #endregion
    }
}
