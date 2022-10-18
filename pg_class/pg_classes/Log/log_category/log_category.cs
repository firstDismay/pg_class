using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Data;
using System.Security.Cryptography;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс файла документов 
    /// </summary>
    public partial class log_category
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected log_category()
        {
            on_change = false;
        }

        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public log_category(System.Data.DataRow row) : this()
        {

            if (row.Table.TableName == "vlog_category")
            {
                id = (Int64)row["id"];
                id_conception = (Int64)row["id_conception"];
                name = (String)row["name"];
                name_len = row.Table.Columns["name"].MaxLength;
                desc = (String)row["desc"];
                desc_len = row.Table.Columns["desc"].MaxLength;
                on = (Boolean)row["on"];
                level= (Int32)row["level"];
                timestamp = Convert.ToDateTime(row["timestamp"]);
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }

        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через сурогатный класс
        /// </summary>
        public log_category(pg_clog_category lc) : this()
        {

            if (lc != null)
            {
                /*id = dc.id;
                id_conception = dc.id_conception;
                name = dc.name;
                name_len = dc.name.Length;
                desc = dc.desc;
                desc_len = dc.desc.Length;
                on = dc.on;
                on_grouping = dc.on_grouping;
                log_count = dc.log_count;
                is_use = dc.is_use;
                timestamp = dc.timestamp;*/
            }
            else
            {
                throw new ArgumentOutOfRangeException("Переданное значение композитного типа равно нулю");
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        private Int64 id;
        private Int64 id_conception;
        private String name;
        private Int32 name_len;
        private String desc;
        private Int32 desc_len;
		private Int32 level;
		private Boolean on;
        private DateTime timestamp;

        /// <summary>
        /// Идентификатор категории документов
        /// </summary>
        public Int64 Id { get => id; }

        /// <summary>
        /// Идентификатор концепции документа
        /// </summary>
        public Int64 Id_conception { get => id_conception; }
        
        /// <summary>
        /// Наименование категории документов
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
        /// Максимально допустимая длинна строкового поля
        /// </summary>
        public static Int32 Name_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_pos  = manager.Instance().TableByName("vlog_category");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["name"].MaxLength;
                }
                return result;
            }
        }

        /// <summary>
        /// Описание категории документв
        /// </summary>
        public String Desc
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
                DataTable tbl_pos = manager.Instance().TableByName("vlog_category");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["desc"].MaxLength;
                }
                return result;
            }
        }
        
        /// <summary>
        /// Признак доступности категории документов к использованию
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
        /// Признак доступности режима пакета документов для документов данной категории
        /// </summary>
        public Int32 Level
        {
            get
            {
                return level;
            }

            set
            {
                if (level != value)
                {
                    level = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Признак использования указанной категории документов в концепции
        /// </summary>
        public Boolean Is_use()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Штамп времени документа
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

        /// <summary>
        /// Ключ объекта
        /// </summary>
        public string ImageKey
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("log_category");

                if (on)
                {
                    sb.Append("_on_us");
                }
                else
                {
                    sb.Append("_off_us");
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
                sb.Append("log_category");
                
                if (on)
                {
                    sb.Append("_on_s");
                }
                else
                {
                    sb.Append("_off_s");
                }
                return sb.ToString();
            }
        }


        #endregion

        #region МЕТОДЫ КЛАССА

        /// <summary>
        /// Свойство определяет актуальность текущего состояния категории документа
        /// </summary>
        public eEntityState Is_actual()
        {
            //return Manager.log_category_is_actual(this);
            throw new NotImplementedException();
        }


        /// <summary>
        /// Обновление категории документа в БД
        /// </summary>
        public void Update()
        {
            throw new NotImplementedException();
            /*
            if (on_change)
            {             
                Manager.log_category_upd(this);
                Refresh();
                on_change = false;
            }*/
        }

        /// <summary>
        /// Обновление категории документов из БД
        /// </summary>
        public Boolean Refresh()
        {
            
            /*log_category temp;
            Boolean Result = false;
            temp = Manager.log_category_by_id(id);

            if (temp != null)
            {
                id = temp.Id;
                id_conception = temp.Id_conception;
                name = temp.Name;
                desc = temp.Desc;
                on = temp.On;
                on_grouping = temp.On_grouping;
                log_count = temp.log_count;
                is_use = temp.Is_use;
                timestamp = temp.Timestamp;
                Result = true;
                on_change = false;
            }
            else
            {
                Result = false;
            }
            return Result;*/

            throw new NotImplementedException();
        }

        /// <summary>
        /// удаление документа и вложенных файлов
        /// group_del
        /// </summary>
        public void Del()
        {
            //Manager.log_category_del(Id);
            throw new NotImplementedException();
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