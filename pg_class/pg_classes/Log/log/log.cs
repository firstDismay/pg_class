﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Data;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Xml.Linq;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс записей журнала
    /// </summary>
    public partial class log
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected log()
        {
            on_change = false;
            imagekey = "log_us";
            selectedimagekey = "log_s";
        }

        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public log(System.Data.DataRow row) : this()
        {

            switch (row.Table.TableName)
            {
                case "vlog":
                    tablename = row.Table.TableName;
                    id = (Int64)row["id"];
                    id_conception = (Int64)row["id_conception"];
                    id_category = (Int64)row["id_category"];
					name_category = (String)row["name_category"];
					name_category_len = row.Table.Columns["name_category"].MaxLength;
					level_category = (Int32)row["level"];

					title = (String)row["title"];
					title_len = row.Table.Columns["title"].MaxLength;
					message = (String)row["message"];
					message_len = row.Table.Columns["message"].MaxLength;
					class_body = (String)row["class_body"];
					if (!DBNull.Value.Equals(row["body"]))
                    {
						body = (String)row["body"];
					}

					user_author = (String)row["user_author"];
					datetime = Convert.ToDateTime(row["datetime"]);

					user_current = (String)row["user_current"];
					timestamp = Convert.ToDateTime(row["timestamp"]);
					break;
                default:
                    throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
		#endregion

		#region СВОЙСТВА КЛАССА

		private Int64 id = 0;
        private Int64 id_conception = 0;
        private Int64 id_category;
		private String name_category;
		private Int32 name_category_len;
		private Int32 level_category;

        private String title;
        private Int32 title_len;
        private String message;
		private Int32 message_len;
		private String class_body;
        private String body;

        private String user_author;
		private DateTime datetime;

        private String user_current;
		private DateTime timestamp;
        private String tablename;
        /// <summary>
        /// Имя таблицы базы ассистента, содержащей запись
        /// </summary>
        public String Tablename { get => tablename; }

        /// <summary>
        /// Идентификатор окумента
        /// </summary>
        public Int64 Id { get => id;}

        /// <summary>
        /// Идентификатор концепции
        /// </summary>
        public Int64 Id_conception { get => id_conception; }

        /// <summary>
        /// Идентификатор категории записи журнала
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
        /// Наименование категории записи журнала
        /// </summary>
		public String Name_category { get => name_category; }

		/// <summary>
		/// Максимально допустимая длинна строкового поля
		/// </summary>
		public Int32 Name_category_len { get => name_category_len; }

		/// <summary>
		/// Уровень категории записи журнала
		/// </summary>
		public Int32 Level_category { get => level_category; }

		/// <summary>
		/// Заголовок записи журнала
		/// </summary>
		public String Title
        {
            get
            {
                return title;
            } 
            set
            {
                if (title != value)
                {
                    if (value.Length > title_len)
                    {
                        value = value.Substring(0, title_len);
                    }
					title = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Максимально допустимая длинна строкового поля
        /// </summary>
        public Int32 Title_len { get => title_len; }
        
        /// <summary>
        /// Сообщение записи журнала
        /// </summary>
        public String Message
        {
            get
            {
                return message;
            }
            set
            {
                if (message != value)
                {
                    if (value.Length > message_len)
                    {
                        value = value.Substring(0, message_len);
                    }
					message = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Максимально допустимая длинна строкового поля
        /// </summary>
        public Int32 Message_len { get => message_len; }

		/// <summary>
		/// Класс сообщения
		/// </summary>
		public String Class_body
		{
			get
			{
				return class_body;
			}
			set
			{
				if (class_body != value)
				{
					class_body = value;
					on_change = true;
				}
			}
		}

		/// <summary>
		/// Тело сообщения в формате JSON
		/// </summary>
		public String Body
		{
			get
			{
				return body;
			}
			set
			{
                if (body != value)
                {
                    body = value;
                    on_change = true;
                }
			}
		}

		/// <summary>
		/// Автор сообщения или отвественный
		/// </summary>
		public String User_author
		{
			get
			{
				return user_author;
			}
			set
			{
				if (user_author != value)
				{
					user_author = value;
					on_change = true;
				}
			}
		}

		/// <summary>
		/// Дата сообщения устанавливаемая автором вручную
		/// </summary>
		public DateTime Datetime
		{
			get
			{
				return datetime;
			}
			set
			{
				if (datetime != value)
				{
					datetime = value;
					on_change = true;
				}
			}
		}

		/// <summary>
		/// Автор сообщения регисрируемый автоматически по учетным данным
		/// </summary>
		public String User_current { get => user_current; }

		/// <summary>
		/// Дата сообщения регистрируемая автоматически по данным сервера
		/// </summary>
		public DateTime Timestamp { get => timestamp; }
		
		private Boolean on_change;
        /// <summary>
        /// Свойство определяющее потребность в обновлении данных БД
        /// </summary>
        public Boolean On_change { get => on_change; }
                
        /// <summary>
        /// Ссылка на менеджера данных
        /// </summary>
        private manager Manager { get => manager.Instance(); }

        private String imagekey;
        /// <summary>
        /// Ключ объекта
        /// </summary>
        public string ImageKey { get => imagekey;}
        
        private String selectedimagekey;
        /// <summary>
        /// Ключ выделенного объекта
        /// </summary>
        public string SelectedImageKey { get => selectedimagekey;}
        #endregion

        #region МЕТОДЫ КЛАССА

        /// <summary>
        /// Свойство определяет актуальность текущего состояния документа
        /// </summary>
        public eEntityState Is_actual()
        {
           // return Manager.log_is_actual(this);
           throw new NotImplementedException();
        }

        /// <summary>
        /// Обновление группы в БД
        /// </summary>
        public void Update()
        {
            if (on_change)
            {             
                //Manager.log_upd(this);
                Refresh();
                on_change = false;
                throw new NotImplementedException();
            }
        }


        /// <summary>
        /// Обновление группы из БД
        /// </summary>
        public Boolean Refresh()
        {
            log temp;
            Boolean Result = false;
/*            switch (tablename)
            {
                case "vlog":
                    temp = Manager.log_by_id(id);
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
                case "vlog_ext":
                    temp = Manager.log_ext_by_id(id);
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
            return Result;*/
            throw new NotImplementedException();
        }

        /// <summary>
        /// удаление документа и вложенных файлов
        /// group_del
        /// </summary>
        public void Del()
        {
            //Manager.log_del(id);
            throw new NotImplementedException();
        }
        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА
        /// <summary>
        ///Переопределенный метод класса для работы с листами и списками
        /// </summary>
        public override string ToString()
        {
            return title;
        }
        #endregion
    }
}