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
    /// Класс глобальных свойств концепции
    /// </summary>
    public partial class global_prop_area_val
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected global_prop_area_val()
        {
            on_change = false;
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public global_prop_area_val(System.Data.DataRow row) : this()
        {

            if (row.Table.TableName == "vglobal_prop_area_val")
            {
                id_conception = (Int64)row["id_conception"];
                id_global_prop = (Int64)row["id_global_prop"];
                timestamp_global_prop = Convert.ToDateTime(row["timestamp_global_prop"]);
                id_prop_type = (Int32)row["id_prop_type"];
                id_data_type = (Int32)row["id_data_type"];

                id_area_val = (Int64)row["id_area_val"];
                timestamp_area_val = Convert.ToDateTime(row["timestamp_area_val"]);
                on_val = (Boolean)row["on_val"];
                is_use = (Boolean)row["is_use"];
                ready = (Boolean)row["ready"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        private Int64 id_global_prop = 0;
        private Int64 id_conception = 0;
        private Int32 id_prop_type;
        private Int32 id_data_type;
        private Boolean is_use;
        private DateTime timestamp_global_prop;
        private Boolean on_val;
        private Boolean ready;

        private Int64 id_area_val = 0;
        private DateTime timestamp_area_val;

        /// <summary>
        /// Идентификатор глобального свойства концепции
        /// </summary>
        public Int64 Id_global_prop { get => id_global_prop; }

        /// <summary>
        /// Идентификатор концепции свойства
        /// </summary>
        public Int64 Id_conception { get => id_conception; }

        /// <summary>
        /// Штамп времени глобального свойства
        /// </summary>
        public DateTime Timestamp_global_prop
        {
            get
            {
                return timestamp_global_prop;
            }
        }

        /// <summary>
        /// Идентификатор типа свойства
        /// </summary>
        public Int32 Id_prop_type
        {
            get
            {
                return id_prop_type;
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

        /// <summary>
        /// Идентификатор типа данных свойства
        /// </summary>
        public Int32 Id_data_type
        {
            get
            {
                return id_data_type;
            }
        }

        /// <summary>
        /// Тип данных свойства
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
        /// Признак используемого глобального свойства
        /// </summary>
        public Boolean Is_use
        {
            get
            {
                return is_use;
            }
        }

        /// <summary>
        /// Область значений глобального свойства определена
        /// </summary>
        public Boolean On_val
        {
            get
            {
                return on_val;
            }
        }

        /// <summary>
        /// Область значений свойства определена, свойство готово к связыванию, шаг №2
        /// </summary>
        public Boolean Ready
        {
            get
            {
                return ready;
            }
        }

        /// <summary>
        /// Идентификатор области значений глобального свойства концепции
        /// </summary>
        public Int64 Id_area_val
        {
            get
            {

                return id_area_val;
            }
            set
            {
                if (id_area_val != value)
                {
                    id_area_val = value;
                    on_change = true;
                }
            }
        }
    
        /// <summary>
        /// Штамп времени области значений глобального свойства применим для объектных свойств
        /// </summary>
        public DateTime Timestamp_area_val
        {
            get
            {
                return timestamp_area_val;
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
                StringBuilder sb = new StringBuilder();
                sb.Append("global_prop_area_val_");
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
                sb.Append("global_prop_area_val_");
                sb.Append("s");
                return sb.ToString();
            }
        }

        #endregion

        #region МЕТОДЫ КЛАССА

        /// <summary>
        /// Обновление области значений глобального свойства
        /// </summary>
        public void Update()
        {
            if (on_change)
            {
                Manager.global_prop_area_val_upd(this);
                Refresh();
                on_change = false;
            }
        }

        /// <summary>
        /// Обновление данных глобального свойства
        /// </summary>
        public Boolean Refresh()
        {
            global_prop_area_val temp = null;
            Boolean Result = false;
            
            temp = Manager.global_prop_area_val_by_id_prop(id_global_prop);
             if (temp != null)
             {
                id_global_prop = temp.Id_global_prop;
                id_conception = temp.Id_conception;
                id_prop_type = temp.Id_prop_type;
                id_data_type = temp.Id_data_type;
                is_use = temp.Is_use;
                timestamp_global_prop = temp.Timestamp_global_prop;
                id_area_val = temp.Id_area_val;
                timestamp_area_val = temp.Timestamp_area_val;
                on_val = temp.On_val;
                ready = temp.Ready;
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
        /// Концепция свойства класса
        /// conception_by_id
        /// </summary>
        public conception Conception_get()
        {
            return Manager.conception_by_id(id_conception);
        }

        /// <summary>
        /// Метод удаляет текущее свойство
        /// global_prop_del
        /// </summary>
        public void Del()
        {
            Manager.global_prop_area_val_del(this);
        }

        #endregion

        #region МЕТОДЫ ПОЛУЧЕНИЯ ОБЛАСТИ ЗНАЧЕНИЯ
        /// <summary>
        /// Метод возвращает сущность определяющую область значений глобального свойства типа пользовательское
        /// </summary>
        public con_prop_data_type Prop_area_user_prop_get()
        {
            con_prop_data_type Result = null;
            if (id_prop_type == 1)
            {
                Result = Manager.Con_prop_data_type_by_id(id_conception, id_data_type); ;
            }
            else
            {
                throw (new PgDataException(eEntity.global_prop_area_val, eAction.Select, eSubClass_ErrID.SCE3_Violation_Rules, "Сущность области значений не соотвествует типу свойства!"));
            }
            return Result;
        }

        /// <summary>
        /// Метод возвращает сущность определяющую область значений глобального свойства типа ссылка
        /// </summary>
        public prop_enum Prop_area_enum_prop_get()
        {
            prop_enum Result = null;
            if (id_prop_type == 2)
            {
                Result =  Manager.prop_enum_by_id(id_area_val);
            }
            else
            {
                throw (new PgDataException(eEntity.global_prop_area_val, eAction.Select, eSubClass_ErrID.SCE3_Violation_Rules, "Сущность области значений не соотвествует типу свойства!"));
            }
            return Result;
        }

        /// <summary>
        /// Метод возвращает сущность определяющую область значений глобального свойства типа объектное
        /// </summary>
        public vclass Prop_area_object_prop_get()
        {
            vclass Result = null;
            if (id_prop_type == 3)
            {
                Result = Manager.class_act_by_id(id_area_val);
            }
            else
            {
                throw (new PgDataException(eEntity.global_prop_area_val, eAction.Select, eSubClass_ErrID.SCE3_Violation_Rules, "Сущность области значений не соотвествует типу свойства!"));
            }
            return Result;
        }

        /// <summary>
        /// Метод возвращает сущность определяющую область значений глобального свойства типа ссылка
        /// </summary>
        public entity Prop_area_link_prop_get()
        {
            entity Result = null;
            if (id_prop_type == 4)
            {
                Result = Manager.entity_by_id(Convert.ToInt32(id_area_val));
            }
            else
            {
                throw (new PgDataException(eEntity.global_prop_area_val, eAction.Select, eSubClass_ErrID.SCE3_Violation_Rules, "Сущность области значений не соотвествует типу свойства!"));
            }
            return Result;
        }

        /// <summary>
        /// Метод возвращает сущность определяющую область значений глобального свойства
        /// </summary>
        public Object Prop_area_get()
        {
            Object Result = null;
            switch (id_prop_type)
            {
                case 1:
                    Result = Manager.Con_prop_data_type_by_id(id_conception, id_data_type);
                    break;
                case 2:
                    Result = Manager.prop_enum_by_id(id_area_val);
                    break;
                case 3:
                    Result = Manager.class_act_by_id(id_area_val);
                    break;
                case 4:
                    Result = Manager.entity_by_id(Convert.ToInt32(id_area_val));
                    break;
                default:
                    Result = null;
                    break;
            }
            return Result;
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
            String Result = "Область значений: н/д";
            switch (id_prop_type)
            {
                case 1:
                    con_prop_data_type av = Manager.Con_prop_data_type_by_id(id_conception, id_data_type);
                    if (av != null)
                    {
                        Result = String.Format("Тип данных: {0}", av.ToString());
                    }
                    break;
                case 2:
                    prop_enum ea = Manager.prop_enum_by_id(id_area_val);
                    if (ea != null)
                    {
                        Result = String.Format("Перечисление: {0}", ea.ToString());
                    }
                    break;
                case 3:
                    vclass ca = Manager.class_act_by_id(id_area_val);
                    if (ca != null)
                    {
                        Result = String.Format("Класс: {0}", ca.ToString());
                    }
                    break;
                case 4:
                    entity e = Manager.entity_by_id(Convert.ToInt32(id_area_val));
                    if (e != null)
                    {
                        Result = String.Format("Класс: {0}", e.ToString());
                    }
                    break;
                default:
                    Result = "Область значений: н/д";
                    break;
            }

            return Result;
        }
        #endregion

    }
}
