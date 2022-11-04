using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс записи журнала
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

            include_class_body_to_JSON = false;
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
					level_category = (Int32)row["level_category"];

					title = (String)row["title"];
					message = (String)row["message"];
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
		private Int32 level_category;

        private String title;
        private String message;
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
					title = value;
                    on_change = true;
                }
            }
        }

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
					message = value;
                    on_change = true;
                }
            }
        }

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
        /// Свойство определяет актуальность текущего состояния записи журнала
        /// </summary>
        public eEntityState Is_actual()
        {
           return Manager.log_is_actual(this);
           throw new NotImplementedException();
        }

        /// <summary>
        /// Обновление записи журнала в БД
        /// </summary>
        public void Update()
        {
            if (on_change)
            {
                include_class_body_to_json_boby();
                Manager.log_upd(this);
                Refresh();
                on_change = false;
            }
        }


        /// <summary>
        /// Обновление записи журнала из БД
        /// </summary>
        public Boolean Refresh()
        {
            log temp;
            Boolean Result = false;
            switch (tablename)
            {
				case "vlog":
					temp = Manager.log_by_id(id);
					if (temp != null)
					{
						tablename = temp.Tablename;
						id = temp.Id;
						id_conception = temp.Id_conception;
						id_category = temp.Id_category;
						name_category = temp.Name_category;
						level_category = temp.Level_category;
						title = temp.Title;
						message = temp.Message;
						class_body = temp.Class_body;
						body = temp.Body;
						user_author = temp.User_author;
						datetime = temp.Datetime;
						user_current = temp.User_current;
						timestamp = temp.Timestamp;
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
        /// удаление записи журнала
        /// group_del
        /// </summary>
        public void Del()
        {
            Manager.log_del(id);
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