using pg_class.pg_exceptions;
using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс файла документов 
    /// </summary>
    public partial class doc_file
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected doc_file()
        {
            on_change = false;
            imagekey = "doc_file_us";
            selectedimagekey = "doc_file_s";
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public doc_file(System.Data.DataRow row) : this()
        {

            if (row.Table.TableName == "vdoc_file")
            {
                id = (Int64)row["id"];
                uuid = (String)row["uuid"];
                md5 = (String)row["md5"];
                id_conception = (Int64)row["id_conception"];
                catalog = (Int32)row["catalog"];
                id_document = (Int64)row["id_document"];
                name = (String)row["name"];
                name_len = row.Table.Columns["name"].MaxLength;
                extension = (String)row["extension"];
                version = (String)row["version"];
                version_len = row.Table.Columns["version"].MaxLength;
                versiondate = Convert.ToDateTime(row["versiondate"]);
                fulltxtsrch_on = (Boolean)row["fulltxtsrch_on"];
                timestamp = Convert.ToDateTime(row["timestamp"]);
                data_length = (Int32)row["data_length"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }

        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через класс композитного типа
        /// </summary>
        public doc_file(pg_vdoc_file df) : this()
        {

            if (df != null)
            {
                id = df.id;
                uuid = df.uuid.ToString();
                md5 = df.md5;
                id_conception = df.id_conception;
                catalog = df.catalog;
                id_document = df.id_document;
                name = df.name;
                name_len = df.name.Length;
                extension = df.extension;
                version = df.version;
                version_len = df.version.Length;
                versiondate = df.versiondate;
                fulltxtsrch_on = df.fulltxtsrch_on;
                timestamp = df.timestamp;
                data_length = df.data_length;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Переданное значение композитного типа равно нулю");
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Int64 id;
        private String uuid;
        private String md5;
        private Int64 id_conception;
        private Int32 catalog;
        private Int64 id_document;
        private String name;
        private Int32 name_len;
        private String extension;
        private String version;
        private Int32 version_len;
        private DateTime versiondate;
        private Boolean fulltxtsrch_on;
        private DateTime timestamp;

        private Int64 data_length;

        /// <summary>
        /// Внутрисистемный идентификатор файла
        /// </summary>
        public Int64 Id { get => id; }

        /// <summary>
        /// Идентификатор файла документа в каталоге файловой системы
        /// </summary>
        public String Uuid { get => uuid; }

        /// <summary>
        /// Хэш MD5 файла документа
        /// </summary>
        public String Md5 { get => md5; }

        /// <summary>
        /// Идентификатор концепции
        /// </summary>
        public Int64 Id_conception { get => id_conception; }

        /// <summary>
        /// Каталог документа в каталоге концепции
        /// </summary>
        public Int32 Catalog { get => catalog; }

        /// <summary>
        /// Идентификатор документа
        /// </summary>
        public Int64 Id_document { get => id_document; }


        /// <summary>
        /// Наименование файла документа
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
                    String Result = value;
                    char[] charInvalidFileChars = Path.GetInvalidFileNameChars();

                    foreach (char charInvalid in charInvalidFileChars)
                    {
                        Result = Result.Replace(charInvalid, ' ');
                    }
                    Result = Result.Replace(';', ' ');
                    Result = Result.Replace("  ", " ");
                    name = Result;
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
                DataTable tbl_pos = manager.Instance().TableByName("vdocument");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["name"].MaxLength;
                }
                return result;
            }
        }

        /// <summary>
        /// Расширение файла документа
        /// </summary>
        public String Extension
        {
            get
            {
                return extension;
            }
            set
            {
                if (extension != value)
                {
                    extension = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Версия файла документа
        /// </summary>
        public String Version
        {
            get
            {
                return version;
            }
            set
            {
                if (version != value)
                {
                    if (value.Length > version_len)
                    {
                        value = value.Substring(0, version_len);
                    }
                    version = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Максимально допустимая длинна строкового поля
        /// </summary>
        public static Int32 Version_len
        {
            get
            {
                Int32 result = -1;
                DataTable tbl_pos = manager.Instance().TableByName("vdoc_file");
                if (tbl_pos != null)
                {
                    result = tbl_pos.Columns["version"].MaxLength;
                }
                return result;
            }
        }

        /// <summary>
        /// Дата версии файла документа
        /// </summary>
        public DateTime Versiondate { get => versiondate; set => versiondate = value; }


        /// <summary>
        /// Признак доступности полнотекстового поиска для файла документа
        /// </summary>
        public Boolean Fulltxtsrch_on
        {
            get
            {
                return fulltxtsrch_on;
            }

            set
            {
                if (fulltxtsrch_on != value)
                {
                    fulltxtsrch_on = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Штамп времени документа
        /// </summary>
        public DateTime Timestamp { get => timestamp; }

        /// <summary>
        /// Длинна байтового масива файла в байтах, доступна после загрузки данных в библиотеку
        /// </summary>
        public Int64 Data_length { get => data_length; }

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
        /// Свойство определяет актуальность текущего состояния файла документа
        /// </summary>
        public eEntityState Is_actual()
        {
            return Manager.doc_file_is_actual(this);
        }

        /// <summary>
        /// Метод выполняет проверку хеша файла, выполняя сравнение данных в базе с фактическим значением
        /// </summary>
        public Boolean hash_md5_check(eSizeTransferPage isizepage = eSizeTransferPage.Size4Mb)
        {
            return Manager.doc_file_hash_md5_check(this, isizepage);
        }

        /// <summary>
        /// Обновление группы в БД
        /// </summary>
        public void Update()
        {
            if (on_change)
            {
                Manager.doc_file_upd(this);
                Refresh();
                on_change = false;
            }
        }

        /// <summary>
        /// Обновление группы из БД
        /// </summary>
        public Boolean Refresh()
        {

            doc_file temp;
            Boolean Result = false;
            temp = Manager.doc_file_by_id(id);

            if (temp != null)
            {
                id = temp.Id;
                uuid = temp.Uuid;
                md5 = temp.Md5;
                id_conception = temp.Id_conception;
                catalog = temp.Catalog;
                id_document = temp.Id_document;
                name = temp.Name;
                extension = temp.Extension;
                version = temp.Version;
                versiondate = temp.Versiondate;
                fulltxtsrch_on = temp.Fulltxtsrch_on;
                timestamp = temp.Timestamp;
                data_length = temp.data_length;
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
        /// Метод извлекает из каталога двоичные данные файла документа
        /// </summary>
        public Byte[] doc_file_data_get(eSizeTransferPage isizepage)
        {
            return Manager.doc_file_data_by_id(this, isizepage);
        }

        /// <summary>
        /// Метод извлекает из каталога двоичные данные файла документа и сохраняет их в указанный каталог
        /// </summary>
        public String doc_file_save(String Path, eSizeTransferPage isizepage)
        {

            Byte[] file_data = null;

            System.IO.Directory.CreateDirectory(Path);

            Int32 n = 0;
            String tmpPath = String.Format(@"{0}\{1}{2}", Path, Name, Extension);
            while (System.IO.File.Exists(tmpPath))
            {
                n++;
                tmpPath = String.Format(@"{0}\{1}({3}){2}", Path, Name, Extension, n);
            }

            Path = tmpPath;
            using (FileStream fs = System.IO.File.OpenWrite(Path))
            {
                file_data = Manager.doc_file_data_by_id(this, isizepage);
                fs.Write(file_data, 0, file_data.Length);
            }
            return Path;
        }

        /// <summary>
        /// Метод извлекает из каталога двоичные данные файла документа, сохраняет их в указанный каталог и открывает связанным приложением
        /// </summary>
        public void doc_file_open(String Path, eSizeTransferPage isizepage)
        {
            String tmpPath = doc_file_save(Path, isizepage);
            //Если файл выгружен, запускаем связанное приложение
            if (System.IO.File.Exists(tmpPath))
            {
                try
                {
                    System.Diagnostics.Process.Start(tmpPath);
                }
                catch (System.ComponentModel.Win32Exception e)
                {
                    throw new PgManagerException(400, "На пользовательском ПК отсутсвуют программы связанные с расширением: " + Extension, e.Message);
                }
            }
            else
            {
                throw new PgManagerException(403, "Выгрузка файла во временный каталог пользователя не удалась.", "Ошибка сохранения данных файла.");
            }
        }

        /// <summary>
        /// Метод извлекает из каталога двоичные данные файла документа и сохраняет их в указанный предполижительно временный каталог по UUID
        /// </summary>
        public String doc_file_save_uuid(String Path, eSizeTransferPage isizepage)
        {
            Byte[] file_data = null;

            System.IO.Directory.CreateDirectory(Path);

            Path = String.Format(@"{0}\{1}", Path, uuid);
            using (FileStream fs = System.IO.File.OpenWrite(Path))
            {
                file_data = Manager.doc_file_data_by_id(this, isizepage);
                fs.Write(file_data, 0, file_data.Length);
            }
            return Path;
        }

        /// <summary>
        /// Метод заменяет двоичный файл документа
        /// </summary>
        public doc_file doc_file_change(String ifilename, String iversion, DateTime iversiondate, String iextension, Byte[] file_data, eSizeTransferPage isizepage)
        {
            doc_file Result;
            Result = Manager.doc_file_change(Id, ifilename, iversion, iversiondate, iextension, file_data, isizepage);
            Refresh();
            return Result;
        }

        /// <summary>
        /// Метод заменяет двоичный файл документа
        /// </summary>
        public doc_file doc_file_change(String iversion, DateTime iversiondate, String Path, eSizeTransferPage isizepage)
        {
            doc_file Result;
            Result = Manager.doc_file_change(Id, iversion, iversiondate, Path, isizepage);
            Refresh();
            return Result;
        }

        /// <summary>
        /// удаление ссылки на документ
        /// </summary>
        public void Del()
        {
            Manager.doc_file_del(id);
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

        /// <summary>
        /// Метод расчета контрольной суммы файла по алгоритму MD5
        /// </summary>
        protected String FileHashMD5(byte[] fileData)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] checkSum = md5.ComputeHash(fileData);
            string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
            return result;
        }

        /// <summary>
        /// MIME тип файла
        /// </summary>
        public String FileMimeType()
        {
            return manager.GetMimeType(extension);
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
