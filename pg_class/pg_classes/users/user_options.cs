using System;

namespace pg_class.pg_classes
{ /// <summary>
  /// Класс пользовательских предпочтений хранимых в БД
  /// </summary>
    public partial class user_options
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        protected user_options()
        {
            on_change = false;
            imagekey = "user_options_us";
            selectedimagekey = "user_options_s";
        }
        /// <summary>
        /// Полный конструктор класса для возврата данных существующих записей через строку таблицы 
        /// </summary>
        public user_options(System.Data.DataRow row) : this()
        {

            //if (Модуль.Table is ТаблицаМодулей)
            if (row.Table.TableName == "user_options")
            {
                login = (String)row["login"];
                pref_conception = (Int64)row["pref_conception"];
                timestamp = (DateTime)row["timestamp"];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Наименование входной таблицы '{0}' не соответствует ограничениям конструктора!", row.Table.TableName));
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА


        private String login;
        private Int64 pref_conception;
        private DateTime timestamp;

        /// <summary>
        /// Штамп времени пользователя
        /// </summary>
        public DateTime Timestamp { get => timestamp; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public String Login
        {
            get
            {
                return login;
            }
        }

        /// <summary>
        /// Предпочитаемая концепция пользователя
        /// </summary>
        public Int64 PrefConception
        {
            get
            {
                return pref_conception;
            }
            set
            {
                if (pref_conception != value)
                {
                    pref_conception = value;
                    on_change = true;
                }
            }
        }

        /// <summary>
        /// Предпочитаемая концепция пользователя
        /// </summary>
        public conception Pref_Conception
        {
            get
            {
                return Manager.conception_by_id(pref_conception);
            }
        }



        //**********************************
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

        /// <summary>
        /// Уникальный строковый идентификатор пользователя
        /// </summary>
        public String Key
        {
            get
            {
                return "user_options_" + login.ToString();
            }
        }
        #endregion

        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Свойство определяет актуальность текущего состояния пользователя
        /// </summary>
        public eEntityState Is_actual()
        {
            return manager.Instance().user_options_is_actual(this);
        }

        /// <summary>
        /// Обновление пользователя в БД
        /// </summary>
        public void Update()
        {
            if (on_change)
            {
                Manager.user_options_upd(this);
                Refresh();
                on_change = false;

            }
        }


        /// <summary>
        /// Обновление пользователя из БД
        /// </summary>
        public Boolean Refresh()
        {
            user_options temp;
            Boolean Result = false;
            temp = Manager.user_options_by_current();
            if (temp != null)
            {
                login = temp.Login;
                timestamp = temp.Timestamp;
                pref_conception = temp.PrefConception;
                Result = true;
            }
            else
            {
                Result = false;
            }
            return Result;
        }
        #endregion

        #region ПЕРЕОПРЕДЕЛЕННЫЕ МЕТОДЫ КЛАССА

        #endregion
    }
}
