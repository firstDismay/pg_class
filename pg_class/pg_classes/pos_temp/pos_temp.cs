using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using pg_class.pg_exceptions;
using System.Data;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс шаблонов позиций
    /// </summary>
    public partial class pos_temp
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>4
        protected pos_temp()
        {
            on_change = false;
            nested_status = eStatus.on;
            ActionPosTempNestedList = eActionPosTempNestedList.none; 
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public pos_temp(System.Data.DataRow row) : this()
        {
            if (row.Table.TableName == "vpos_temp")
            {
                id = (Int64)row["id"];
                on = (Boolean)row["on"];
                on_root = (Boolean)row["on_root"];
                on_this = (Boolean)row["on_this"];
                on_pos = (Boolean)row["on_pos"];
                on_obj = (Boolean)row["on_obj"];
                name = (String)row["name"];
                name_len = row.Table.Columns["name"].MaxLength;
                desc = (String)row["desc"];
                desc_len = row.Table.Columns["desc"].MaxLength;
                id_con = (Int64)row["id_con"];
                id_prototype = (Int32)row["id_prototype"];
                nested_limit = (Boolean)row["on_nested_limit"];
                on_service = (Boolean)row["on_service"];
                timestamp = Convert.ToDateTime(row["timestamp"]);
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        private Int64 id = 0;
        private Boolean on;
        private String name;
        private Int32 name_len;
        private String desc;
        private Int32 desc_len;
        private Int64 id_con;
        private Int32 id_prototype;
        private Boolean nested_limit;
        private Boolean on_service;
        private DateTime timestamp;
        private eStatus nested_status;
        private eActionPosTempNestedList ActionPosTempNestedList;

        private Boolean on_root;
        private Boolean on_this;
        private Boolean on_pos;
        private Boolean on_obj;

        /// <summary>
        /// Идентификатор шаблона позиций
        /// </summary>
        public Int64 Id
        {
            get
            {
                return id;
            }
        }


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
        /// Состояние шаблона позиций, определяет доступность создания позиций от данного шаблона
        /// </summary>
        public bool On
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
        /// Наименование шаблона позиции совпадает с именем узла дерева
        /// </summary>
        public string Name_pos_temp
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
        public static  Int32 Name_pos_temp_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_con  = manager.Instance().TableByName("vpos_temp");
                if (tbl_con != null)
                {
                    result = tbl_con.Columns["name"].MaxLength;
                }
                return result;
            }
        }

        /// <summary>
        /// Описание шаблона позиций
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
        public static Int32 Desc_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_con  = manager.Instance().TableByName("vpos_temp");
                if (tbl_con != null)
                {
                    result = tbl_con.Columns["desc"].MaxLength;
                }
                return result;
            }
        }

        /// <summary>
        /// Идентификатор концепции шаблона позиции
        /// </summary>
        public long Id_conception { get => id_con; }

        /// <summary>
        /// Идентификатор прототипа шаблона позиции
        /// </summary>
        public int Id_prototype { get => id_prototype; }
       

        /// <summary>
        /// Включение отключения режима ограничения списка доступных шаблонов позиции
        /// </summary>
        public bool Nested_limit
        {
            get
            {
                return nested_limit;
            }
            set
            {
                if (nested_limit != value)
                {
                    nested_limit = value;
                    on_change = true;
                    //Определяем действие над листом
                    if (nested_limit)
                    {
                        ActionPosTempNestedList = eActionPosTempNestedList.on;
                    }
                    else
                    {
                        ActionPosTempNestedList = eActionPosTempNestedList.off;
                    }
                 
                }
                
            }
        }


        /// <summary>
        /// Поле определяет режим фильтрации вкладываемых шаблонов
        /// </summary>
        public eStatus Nested_status { get => nested_status; set => nested_status = value; }

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
        /// Признак сервисного шаблона позиций
        /// </summary>
        public Boolean On_Service { get => on_service; }

        /// <summary>
        /// Допускает создание корневых позиций
        /// </summary>
        public Boolean On_root { get => on_root; }
        
        /// <summary>
        /// Допускает вложение позиций основанных на одном прототипе
        /// </summary>
        public Boolean On_this { get => on_this; }

        /// <summary>
        /// Допускает вложение позиций
        /// </summary>
        public Boolean On_position { get => on_pos; }

        /// <summary>
        /// Допускает вложение объектов
        /// </summary>
        public Boolean On_object { get => on_obj; }

        /// <summary>
        /// Ключ объекта
        /// </summary>
        public string ImageKey
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (on_service)
                {
                    sb.Append("pos_temp_service_us");
                }
                else
                {

                    sb.Append("pos_temp_");
                    if (on)
                    {
                        sb.Append("on_");
                    }
                    else
                    {
                        sb.Append("off_");
                    }

                    if (nested_limit)
                    {
                        sb.Append("nl_on_us");
                    }
                    else
                    {
                        sb.Append("nl_off_us");

                    }
                }
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
                if (on_service)
                {
                    sb.Append("pos_temp_service_s");
                }
                else
                {
                    sb.Append("pos_temp_");
                    if (on)
                    {
                        sb.Append("on_");
                    }
                    else
                    {
                        sb.Append("off_");
                    }

                    if (nested_limit)
                    {
                        sb.Append("nl_on_s");
                    }
                    else
                    {
                        sb.Append("nl_off_s");
                    }
                }
                return sb.ToString();
            }
        }
        #endregion

        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Свойство определяет актуальность текущего состояния шаблона позиции
        /// </summary>
        public eEntityState Is_actual()
        {
            return manager.Instance().pos_temp_is_actual(this);
        }

        /// <summary>
        /// Обновление шаблона позиции в БД
        /// </summary>
        public void Update()
        {
            if (on_change)
            {            
                //Вносим изменения в БД
                Manager.pos_temp_upd(this);
                Refresh();
                on_change = false;
            }
        }

        /// <summary>
        /// Копирование шаблона позиции в БД
        /// </summary>
        public pos_temp Copy()
        {
           //Вносим изменения в БД
           return Manager.pos_temp_copy(this);
        }
        /// <summary>
        /// Обновление шаблона из БД
        /// </summary>
        public Boolean Refresh()
        {
            pos_temp temp;
            Boolean Result = false;
            temp = Manager.pos_temp_by_id(id);
            if (temp != null)
            {
                id = temp.Id;
                on = temp.On;
                name = temp.Name_pos_temp;
                name_len = temp.name_len;
                desc = temp.Desc;
                desc_len = temp.desc_len;
                id_con = temp.Id_conception;
                id_prototype = temp.Id_prototype;
                nested_limit = temp.Nested_limit;
                on_root = temp.On_root;
                on_this = on_root = temp.On_this;
                on_pos = on_root = temp.On_position;
                on_obj = on_root = temp.On_object;
                on_service = temp.On_Service;
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
        /// Метод удаляет текущий шаблон
        /// pos_temp_del
        /// </summary>
        public void Del()
        {
            Manager.pos_temp_del(this);
        }

        #endregion


        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        /// Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            return String.Format("{0}:[{1}]",
               name,
               Pos_prototype.Sort);
        }
        #endregion
    }
}
