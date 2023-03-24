using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс ссылка документа
    /// </summary>
    public partial class doc_link
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected doc_link()
        {
            imagekey = "doc_link_us";
            selectedimagekey = "doc_link_s";
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public doc_link(System.Data.DataRow row) : this()
        {

            if (row.Table.TableName == "vdoc_link")
            {
                id = (Int64)row["id"];
                id_conception = (Int64)row["id_conception"];
                id_document = (Int64)row["id_document"];
                id_category = (Int64)row["id_category"];
                name = (String)row["name"];
                regnum = (String)row["regnum"];
                regnum_len = row.Table.Columns["regnum"].MaxLength;
                regdate = Convert.ToDateTime(row["regdate"]);

                id_entity = (Int32)row["id_entity"];
                id_entity_instance = (Int64)row["id_entity_instance"];
                id_sub_entity_instance = (Int64)row["id_sub_entity_instance"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }

        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через класс композитного типа
        /// </summary>
        public doc_link(pg_vdoc_link dl) : this()
        {

            if (dl != null)
            {
                id = dl.id;
                id_conception = dl.id_conception;
                id_document = dl.id_document;
                id_category = dl.id_category;
                name = dl.name;
                regnum = dl.regnum;
                regnum_len = dl.regnum.Length;
                regdate = dl.regdate;

                id_entity = dl.id_entity;
                id_entity_instance = dl.id_entity_instance;
                id_sub_entity_instance = dl.id_sub_entity_instance;
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
        private Int64 id_document;
        private Int64 id_category;
        private String name;
        private String regnum;
        private Int32 regnum_len;
        private DateTime regdate;
        private Int32 id_entity;
        private Int64 id_entity_instance;
        private Int64 id_sub_entity_instance;

        /// <summary>
        /// Идентификатор ссылки на документ документа
        /// </summary>
        public Int64 Id { get => id; }

        /// <summary>
        /// Идентификатор концепции
        /// </summary>
        public Int64 Id_conception { get => id_conception; }

        /// <summary>
        /// Идентификатор документа
        /// </summary>
        public Int64 Id_document { get => id_document; }

        /// <summary>
        /// Идентификатор категории документа
        /// </summary>
        public Int64 Id_category { get => id_category; }

        /// <summary>
        /// Наименование документа
        /// </summary>
        public String Name
        {
            get
            {
                return name;
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
                DataTable tbl_pos = manager.Instance().TableByName("vdocument");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["name"].MaxLength;
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
        public DateTime Regdate { get => regdate; }


        /// <summary>
        /// Перечисление ссылающейся сущности определяющей тип ссылочного объекта
        /// </summary>
        public eEntity Link_e_entity
        {
            get
            {
                return (eEntity)id_entity;
            }
        }

        /// <summary>
        /// Идентификатор ссылающейся сущности
        /// </summary>
        public Int32 Link_id_entity { get => id_entity; }

        /// <summary>
        /// Идентификатор экземпляра ссылающейся сущности
        /// </summary>
        public Int64 Link_id_entity_instance { get => id_entity_instance; }

        /// <summary>
        /// Дополнительный идентификатор ссылающейся сущности
        /// </summary>
        public Int64 Link_id_sub_entity_instance { get => id_sub_entity_instance; }

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
        /// Свойство определяет актуальность текущего состояния ссылки
        /// </summary>
        public eEntityState Is_actual()
        {
            return Manager.doc_link_is_actual(id);
        }

        /// <summary>
        /// Обновление ссылки из БД
        /// </summary>
        public Boolean Refresh()
        {
            doc_link temp;
            Boolean Result = false;
            temp = Manager.doc_link_by_id(id);

            if (temp != null)
            {
                id = temp.Id;
                id_conception = temp.Id_conception;
                id_document = temp.Id_document;
                id_category = temp.Id_category;
                name = temp.Name;
                regnum = temp.Regnum;
                regdate = temp.Regdate;

                id_entity = temp.Link_id_entity;
                id_entity_instance = temp.Link_id_entity_instance;
                id_sub_entity_instance = temp.Link_id_sub_entity_instance;
                Result = true;
            }
            else
            {
                Result = false;
            }
            return Result;
        }

        /// <summary>
        /// удаление ссылки
        /// </summary>
        public void Del()
        {
            Manager.doc_link_del(id);
        }

        /// <summary>
        /// Метод возвращает экземпляр сущности в которую входит экземпляр значения
        /// </summary>
        public object Link_entity_instance_get()
        {
            object Result = null;
            switch (Link_e_entity)
            {
                case eEntity.user:
                    Result = Manager.user_by_id(id_entity_instance);
                    break;
                case eEntity.pos_temp:
                    Result = Manager.pos_temp_by_id(id_entity_instance);
                    break;
                case eEntity.position:
                    Result = Manager.position_by_id(id_entity_instance);
                    break;
                case eEntity.position_prop:
                    Result = Manager.position_prop_by_id(id_entity_instance, id_sub_entity_instance);
                    break;
                case eEntity.pos_temp_prop:
                    Result = Manager.pos_temp_prop_by_id(id_entity_instance);
                    break;
                case eEntity.group:
                    Result = Manager.group_by_id(id_entity_instance);
                    break;
                case eEntity.vclass:
                    Result = Manager.class_act_by_id(id_entity_instance);
                    break;
                case eEntity.class_prop:
                    Result = Manager.class_prop_by_id(id_entity_instance);
                    break;
                case eEntity.vobject:
                    Result = Manager.object_by_id(id_entity_instance);
                    break;
                case eEntity.object_prop:
                    Result = Manager.object_prop_by_id(id_entity_instance, id_sub_entity_instance);
                    break;
                default:
                    Result = Manager.entity_by_id(Convert.ToInt32(id_entity));
                    break;
            }
            return Result;
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
