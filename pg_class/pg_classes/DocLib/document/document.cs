using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс документов 
    /// </summary>
    public partial class document
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected document()
        {
            on_change = false;
            imagekey = "document_us";
            selectedimagekey = "document_s";
        }

        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public document(System.Data.DataRow row) : this()
        {

            switch (row.Table.TableName)
            {
                case "vdocument":
                    tablename = row.Table.TableName;
                    id = (Int64)row["id"];
                    id_conception = (Int64)row["id_conception"];
                    id_parent = (Int64)row["id_parent"];
                    id_category = (Int64)row["id_category"];
                    on_grouping = (Boolean)row["on_grouping"];
                    package_item = (Boolean)row["package_item"];
                    name = (String)row["name"];
                    name_len = row.Table.Columns["name"].MaxLength;
                    desc = (String)row["desc"];
                    desc_len = row.Table.Columns["desc"].MaxLength;
                    regnum = (String)row["regnum"];
                    regnum_len = row.Table.Columns["regnum"].MaxLength;
                    regdate = Convert.ToDateTime(row["regdate"]);
                    has_link = (Boolean)row["has_link"];
                    has_doc = (Boolean)row["has_doc"];
                    has_file = (Boolean)row["has_file"];
                    timestamp = Convert.ToDateTime(row["timestamp"]);
                    is_inside = (Boolean)row["is_inside"];
                    break;
                case "vdocument_ext":
                    tablename = row.Table.TableName;
                    id = (Int64)row["id"];
                    id_conception = (Int64)row["id_conception"];
                    id_parent = (Int64)row["id_parent"];
                    id_category = (Int64)row["id_category"];
                    on_grouping = (Boolean)row["on_grouping"];
                    package_item = (Boolean)row["package_item"];
                    name = (String)row["name"];
                    name_len = row.Table.Columns["name"].MaxLength;
                    desc = (String)row["desc"];
                    desc_len = row.Table.Columns["desc"].MaxLength;
                    regnum = (String)row["regnum"];
                    regnum_len = row.Table.Columns["regnum"].MaxLength;
                    regdate = Convert.ToDateTime(row["regdate"]);
                    has_link = (Boolean)row["has_link"];
                    has_doc = (Boolean)row["has_doc"];
                    has_file = (Boolean)row["has_file"];
                    timestamp = Convert.ToDateTime(row["timestamp"]);
                    is_inside = (Boolean)row["is_inside"];

                    doc_file_list = new List<doc_file>();
                    if (!DBNull.Value.Equals(row["doc_file_list"]))
                    {
                        pg_vdoc_file[] dfa = (pg_vdoc_file[])row["doc_file_list"];
                        doc_file df;
                        foreach (pg_vdoc_file i in dfa)
                        {
                            df = new doc_file(i);
                            doc_file_list.Add(df);
                        }
                    }
                    doc_link_list = new List<doc_link>();
                    if (!DBNull.Value.Equals(row["doc_link_list"]))
                    {
                        pg_vdoc_link[] dla = (pg_vdoc_link[])row["doc_link_list"];
                        doc_link dl;
                        foreach (pg_vdoc_link i in dla)
                        {
                            dl = new doc_link(i);
                            doc_link_list.Add(dl);
                        }
                    }

                    List<doc_category> doc_category_list = new List<doc_category>();
                    if (!DBNull.Value.Equals(row["doc_category_list"]))
                    {
                        pg_vdoc_category[] dca = (pg_vdoc_category[])row["doc_category_list"];
                        doc_category dc;
                        foreach (pg_vdoc_category i in dca)
                        {
                            dc = new doc_category(i);
                            doc_category_list.Add(dc);
                        }
                    }
                    if (doc_category_list.Count > 0)
                    {
                        doc_category = doc_category_list.Find(x => x.Id == id_category);
                    }
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
        private Int64 id_category;
        private Boolean on_grouping;
        private Boolean package_item;
        private String name;
        private Int32 name_len;
        private String desc;
        private Int32 desc_len;
        private String regnum;
        private Int32 regnum_len;
        private DateTime regdate;
        private Boolean has_link;
        private Boolean has_doc;
        private Boolean has_file;
        private DateTime timestamp;
        private Boolean is_inside;

        private String tablename;
        /// <summary>
        /// Имя таблицы базы ассистента, содержащей запись одокументе
        /// </summary>
        public String Tablename { get => tablename; }

        /// <summary>
        /// Идентификатор окумента
        /// </summary>
        public Int64 Id { get => id; }

        /// <summary>
        /// Идентификатор концепции документа
        /// </summary>
        public Int64 Id_conception { get => id_conception; }

        /// <summary>
        /// Идентификатор документа носителя
        /// </summary>
        public Int64 Id_parent { get => id_parent; }

        /// <summary>
        /// Идентификатор категории документа
        /// </summary>
        public Int64 Id_category
        {
            get
            {
                return id_category;
            }
            set
            {
                if (id_category != value)
                {
                    id_category = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Свойство определяет доступность вложения документов в указанный документ, зависит от категории
        /// </summary>
        public Boolean On_grouping
        {
            get
            {
                return on_grouping;
            }
        }


        /// <summary>
        /// Документ является элементом пакета
        /// </summary>
        public Boolean Package_item { get => package_item; }
        /// <summary>
        /// Наименование документа
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
        /// Метод формирует имя файла из имени документа
        /// </summary>
        private String NameFile()
        {
            String Result = name;
            char[] charInvalidFileChars = Path.GetInvalidFileNameChars();

            foreach (char charInvalid in charInvalidFileChars)
            {
                Result = Result.Replace(charInvalid, ' ');
            }
            Result = Result.Replace(';', ' ');
            Result = Result.Replace("  ", " ");
            return Result;
        }

        /// <summary>
        /// Максимально допустимая длинна строкового поля
        /// </summary>
        public static Int32 Name_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_pos = manager.Instance().TableByName("vdocument");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["name"].MaxLength;
                }
                return result;
            }
        }

        /// <summary>
        /// Описание документа
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
                DataTable tbl_pos = manager.Instance().TableByName("vdocument");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["desc"].MaxLength;
                }
                return result;
            }
        }

        /// <summary>
        /// Регистрационный номер документа
        /// </summary>
        public String Regnum
        {
            get
            {
                return regnum;
            }
            set
            {
                if (regnum != value)
                {
                    if (value.Length > regnum_len)
                    {
                        value = value.Substring(0, regnum_len);
                    }
                    regnum = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Максимально допустимая длинна строкового поля
        /// </summary>
        public static Int32 Regnum_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_pos = manager.Instance().TableByName("vdocument");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["regnum"].MaxLength;
                }
                return result;
            }
        }

        /// <summary>
        /// Дата регистрации документа
        /// </summary>
        public DateTime Regdate { get => regdate; set => regdate = value; }


        /// <summary>
        /// Признак наличия файлов в документе
        /// </summary>
        public Boolean Has_file
        {
            get
            {
                return has_file;
            }
        }

        /// <summary>
        /// Признак наличия ссылок на документ
        /// </summary>
        public Boolean Has_link
        {
            get
            {
                return has_link;
            }
        }

        /// <summary>
        /// Призка наличия вложенных документов
        /// </summary>
        public Boolean Has_doc
        {
            get
            {
                return has_doc;
            }
        }

        /// <summary>
        /// Штамп времени документа
        /// </summary>
        public DateTime Timestamp { get => timestamp; }

        /// <summary>
        /// Признак документа являющегося элементом пакета
        /// </summary>
        public Boolean Is_inside { get => is_inside; }


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
        /// Свойство определяет актуальность текущего состояния документа
        /// </summary>
        public eEntityState Is_actual()
        {
            return Manager.document_is_actual(this);
        }

        /// <summary>
        /// Обновление группы в БД
        /// </summary>
        public void Update()
        {
            if (on_change)
            {
                Manager.document_upd(this);
                Refresh();
                on_change = false;
            }
        }

        /// <summary>
        /// Исключить документ из пакета докумнтов
        /// document_exc_from_pack
        /// </summary>
        public void ExcludeFromPack()
        {
            Manager.document_exclude_from_pack(this);
            Refresh();
        }

        /// <summary>
        /// Включить документ в пакет докумнтов
        /// document_inc_in_pack
        /// </summary>
        public void IncludeInPack(Int64 iid_document_pack)
        {
            Manager.document_include_in_pack(iid_document_pack, id);
            Refresh();
        }

        /// <summary>
        /// Обновление группы из БД
        /// </summary>
        public Boolean Refresh()
        {
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

                        doc_file_list = temp.doc_file_list_get(false);
                        doc_link_list = temp.doc_link_list_get(false);
                        doc_category = temp.doc_category_get(false);

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
        /// удаление документа и вложенных файлов
        /// group_del
        /// </summary>
        public void Del()
        {
            Manager.document_del(id);
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
