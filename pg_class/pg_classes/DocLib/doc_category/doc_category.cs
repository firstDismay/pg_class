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
    /// Класс категории документов
    /// </summary>
    public partial class doc_category
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected doc_category()
        {
            on_change = false;
        }

        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public doc_category(System.Data.DataRow row) : this()
        {

            if (row.Table.TableName == "vdoc_category")
            {
                id = (Int64)row["id"];
                id_conception = (Int64)row["id_conception"];
                name = (String)row["name"];
                name_len = row.Table.Columns["name"].MaxLength;
                desc = (String)row["desc"];
                desc_len = row.Table.Columns["desc"].MaxLength;
                on = (Boolean)row["on"];
                on_grouping = (Boolean)row["on_grouping"];
                doc_count = (Int64)row["doc_count"];
                is_use = (Boolean)row["is_use"];
                timestamp = Convert.ToDateTime(row["timestamp"]);
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }

        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через класс композитного типа
        /// </summary>
        public doc_category(pg_vdoc_category dc) : this()
        {

            if (dc != null)
            {
                id = dc.id;
                id_conception = dc.id_conception;
                name = dc.name;
                name_len = dc.name.Length;
                desc = dc.desc;
                desc_len = dc.desc.Length;
                on = dc.on;
                on_grouping = dc.on_grouping;
                doc_count = dc.doc_count;
                is_use = dc.is_use;
                timestamp = dc.timestamp;
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
        private Boolean on;
        private Boolean on_grouping;
        private Int64 doc_count;
        private Boolean is_use;
        private DateTime timestamp;

        /// <summary>
        /// Идентификатор категории
        /// </summary>
        public Int64 Id { get => id; }

        /// <summary>
        /// Идентификатор концепции
        /// </summary>
        public Int64 Id_conception { get => id_conception; }
        
        /// <summary>
        /// Наименование категории
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
                DataTable tbl_pos  = manager.Instance().TableByName("vdoc_category");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["name"].MaxLength;
                }
                return result;
            }
        }

        /// <summary>
        /// Описание категории
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
                DataTable tbl_pos = manager.Instance().TableByName("vdoc_category");
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
        public Boolean On_grouping
        {
            get
            {
                return on_grouping;
            }

            set
            {
                if (on_grouping != value)
                {
                    on_grouping = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Признак использования указанной категории документов в концепции
        /// </summary>
        public Boolean Is_use
        {
            get
            {
                return is_use;
            }
        }

        /// <summary>
        /// Общее количество документов концепции использующих указанную категорию
        /// </summary>
        public Int64 Doc_count
        {
            get
            {
                return doc_count;
            }
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
                sb.Append("doc_category");
                if (on_grouping)
                {
                    sb.Append("_on_grouping");
                }
                else
                {
                    sb.Append("_off_grouping");
                }

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
                sb.Append("doc_category");
                if (on_grouping)
                {
                    sb.Append("_on_grouping");
                }
                else
                {
                    sb.Append("_off_grouping");
                }

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
        /// Свойство определяет актуальность текущего состояния категории
        /// </summary>
        public eEntityState Is_actual()
        {
            return Manager.doc_category_is_actual(this);
        }


        /// <summary>
        /// Обновление категории документов в БД
        /// </summary>
        public void Update()
        {
            if (on_change)
            {             
                Manager.doc_category_upd(this);
                Refresh();
                on_change = false;
            }
        }

        /// <summary>
        /// Обновление категории документов из БД
        /// </summary>
        public Boolean Refresh()
        {
            
            doc_category temp;
            Boolean Result = false;
            temp = Manager.doc_category_by_id(id);

            if (temp != null)
            {
                id = temp.Id;
                id_conception = temp.Id_conception;
                name = temp.Name;
                desc = temp.Desc;
                on = temp.On;
                on_grouping = temp.On_grouping;
                doc_count = temp.Doc_count;
                is_use = temp.Is_use;
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
        /// Удаление категории
        /// </summary>
        public void Del()
        {
            Manager.doc_category_del(Id);
        }

        #endregion

        #region МЕТОДЫ ДЛЯ РАБОТЫ С ФАЙЛАМИ ДОКУМЕНТА
        /// <summary>
        /// Метод расчета контрольной суммы файла по алгоритму MD5
        /// </summary>
        protected String FileHashMD5(string Path)
        {
            using (FileStream fs = System.IO.File.OpenRead(Path))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] fileData = new byte[fs.Length];
                fs.Read(fileData, 0, (int)fs.Length);
                byte[] checkSum = md5.ComputeHash(fileData);
                string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                return result;
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
