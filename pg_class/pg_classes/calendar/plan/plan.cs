using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Data;
using System.Security.Cryptography;

namespace pg_class.pg_classes.calendar
{
    /// <summary>
    /// Класс планов 
    /// </summary>
    public partial class plan
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected plan()
        {
            on_change = false;
            imagekey = "plan_us";
            selectedimagekey = "plan_s";
        }

        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public plan(System.Data.DataRow row) : this()
        {

            switch (row.Table.TableName)
            {
                case "vpaln":
                    tablename = row.Table.TableName;
                    id = (Int64)row["id"];
                    id_conception = (Int64)row["id_conception"];
                    id_root = (Int64)row["id_root"];
                    id_parent = (Int64)row["id_parent"];
                    level = (Int32)row["level"];
                    name = (String)row["name"];
                    name_len = row.Table.Columns["name"].MaxLength;
                    desc = (String)row["desc"];
                    desc_len = row.Table.Columns["desc"].MaxLength;
                    on= (Boolean)row["on"];
                    on_crossing = (Boolean)row["on_crossing"];
                    on_freeze = (Boolean)row["on_freeze"];
                    plan_max = (Int32)row["plan_max"];
                    range_max = (Int32)row["range_max"];
                    has_child_plan = (Boolean)row["has_child_plan"];
                    timestamp = Convert.ToDateTime(row["timestamp"]);
                    timestamp_child_change = Convert.ToDateTime(row["timestamp_child_change"]);
                    path = (String)(row["path"]);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int64 id = 0;
        private Int64 id_conception = 0;
        private Int64 id_parent = 0;
        private Int64 id_root = 0;
        private Int32 level = 0;
        private String name;
        private Int32 name_len;
        private String desc;
        private Int32 desc_len;

        private Boolean on = true;
        private Boolean on_freeze = false;
        private Boolean on_crossing = true;
        private Boolean has_child_plan = true;

        private Int32 plan_max = -1;
        private Int32 range_max = -1;

        private DateTime timestamp;
        private DateTime timestamp_child_change;

        private String path;

        private Boolean on_change;

        private String tablename;
        /// <summary>
        /// Имя таблицы базы ассистента, содержащей запись
        /// </summary>
        public String Tablename { get => tablename; }

        /// <summary>
        /// Идентификатор плана
        /// </summary>
        public Int64 Id { get => id;}

        /// <summary>
        /// Идентификатор концепции плана
        /// </summary>
        public Int64 Id_conception { get => id_conception; }

        /// <summary>
        /// Идентификатор плана носителя
        /// </summary>
        public Int64 Id_parent { get => id_parent; }

        /// <summary>
        /// Идентификатор корневого плана носителя
        /// </summary>
        public Int64 Id_root { get => id_root; }

        /// <summary>
        /// Текущий уровень вложенности плана
        /// </summary>
        public Int32 Level { get => level; }

        /// <summary>
        /// Наименование плана
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
                DataTable tbl_pos  = manager.Instance().TableByName("vdocument");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["name"].MaxLength;
                }
                return result;
            }
        }
        
        /// <summary>
        /// Описание плана
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
        public static  Int32 Desc_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_pos  = manager.Instance().TableByName("vdocument");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["desc"].MaxLength;
                }
                return result;
            }
        }


        /// <summary>
        /// Признак активности плана
        /// </summary>
        public Boolean On 
        {
            get
            {
                return on;
            }
            set
            {
                on = value;
                on_change = true;
            }
        }
        
        /// <summary>
        /// Признак защиты плана от изменений
        /// </summary>
        public Boolean On_freeze 
        {
            get
            {
                return on_freeze;
            }
            set
            {
                on_freeze = value;
                on_change = true;
            }
        }
        
        /// <summary>
        /// Признак доступности пересечения плановых диапазонов в дочерних планах
        /// </summary>
        public Boolean On_crossing 
        {
            get
            {
                return on_crossing;
            }
            set
            {
                on_crossing = value;
                on_change = true;
            }
        }

        /// <summary>
        /// Ограничение количества вложенных планов -1 не ограничено
        /// </summary>
        public Int32 Plan_max 
        {
            get
            {
                return plan_max;
            }
            set
            {
                plan_max = value;
                on_change = true;
            }
        }

        /// <summary>
        /// Ограничение количества плановых диапазонов -1 не ограничено
        /// </summary>
        public Int32 Range_max 
        {
            get
            {
                return range_max;
            }
            set
            {
                range_max = value;
                on_change = true;
            }
        }

        /// <summary>
        /// Путь к плану
        /// </summary>
        public String Path { get => path; }


        /// <summary>
        /// Признак наличия вложенных планов
        /// </summary>
        public Boolean Has_child_plan
        {
            get
            {
                return has_child_plan;
            }
        }
        

        /// <summary>
        /// Штамп времени плана
        /// </summary>
        public DateTime Timestamp { get => timestamp; }

        /// <summary>
        /// Штамп времени состояния потомков плана
        /// </summary>
        public DateTime Timestamp_child_change { get => timestamp_child_change; }

        
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
        #endregion

        #region МЕТОДЫ КЛАССА

        /// <summary>
        /// Свойство определяет актуальность текущего состояния плана
        /// </summary>
        public eEntityState Is_actual()
        {
            throw (new Exception("Метод не реализован!"));
            //return Manager.document_is_actual(this);
        }

        /// <summary>
        /// Обновление группы в БД
        /// </summary>
        public void Update()
        {
            if (on_change)
            {             
                //Manager.document_upd(this);
                Refresh();
                on_change = false;
            }
        }

        /// <summary>
        /// Обновление группы из БД
        /// </summary>
        public Boolean Refresh()
        {
            throw (new Exception("Метод не реализован!"));
            /*
            document temp;
            Boolean Result = false;
            switch (tablename)
            {
                case "vdocument":
                    temp = Manager.document_by_id(id);
                    if (temp != null)
                    {
                        tablename = temp.Tablename;
                        id = temp.Id;
                        id_conception = temp.Id_conception;
                        id_parent = temp.Id_parent;
                        id_category = temp.Id_category;
                        on_grouping = temp.On_grouping;
                        package_item = temp.Package_item;
                        name = temp.Name;
                        desc = temp.Desc;
                        regnum = temp.Regnum;
                        regdate = temp.Regdate;
                        has_link = temp.Has_link;
                        has_doc = temp.Has_doc;
                        has_file = temp.Has_file;
                        timestamp = temp.Timestamp;
                        is_inside = temp.Is_inside;
                        Result = true;
                        on_change = false;
                    }
                    else
                    {
                        Result = false;
                    }
                    break;
                case "vdocument_ext":
                    temp = Manager.document_ext_by_id(id);
                    if (temp != null)
                    {
                        tablename = temp.Tablename;
                        id = temp.Id;
                        id_conception = temp.Id_conception;
                        id_parent = temp.Id_parent;
                        id_category = temp.Id_category;
                        on_grouping = temp.On_grouping;
                        package_item = temp.Package_item;
                        name = temp.Name;
                        desc = temp.Desc;
                        regnum = temp.Regnum;
                        regdate = temp.Regdate;
                        has_link = temp.Has_link;
                        has_doc = temp.Has_doc;
                        has_file = temp.Has_file;
                        timestamp = temp.Timestamp;
                        is_inside = temp.Is_inside;

                        doc_file_list = temp.Doc_file_list_get(false);
                        doc_link_list = temp.Doc_link_list_get(false);
                        doc_category = temp.Doc_category_get(false);

                        Result = true;
                        on_change = false;
                    }
                    else
                    {
                        Result = false;
                    }
                    break;
            }
            return Result;*/
        }

        /// <summary>
        /// удаление документа и вложенных файлов
        /// group_del
        /// </summary>
        public void Del()
        {
            Manager.document_del(id);
        }
        #endregion

        #region МЕТОДЫ КЛАССА ДЛЯ РАБОТЫ СО СПИСКАМИ ДОКУМЕНТА
        List<doc_file> doc_file_list;
        /// <summary>
        /// Лист файлов документа
        /// </summary>
        public List<doc_file> Doc_file_list_get(Boolean DirectRequest = true)
        {
            if (DirectRequest || doc_file_list == null)
            {
                doc_file_list = Manager.doc_file_by_id_document(Id);
            }
            return doc_file_list;
        }

        List<doc_link> doc_link_list;
        /// <summary>
        /// Лист ссылок документа
        /// </summary>
        public List<doc_link> Doc_link_list_get(Boolean DirectRequest = true)
        {
            if (DirectRequest || doc_link_list == null)
            {
                doc_link_list = Manager.doc_link_by_id_document(Id);
            }
            return doc_link_list;
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
