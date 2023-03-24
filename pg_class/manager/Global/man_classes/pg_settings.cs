using System;
using System.Text;

namespace pg_class
{
    /// <summary>
    /// Класс инициализации настроек библиотеки доступа к БД Учет
    /// </summary>
    public class pg_settings
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Закрытый конструктор класса
        /// </summary>
        protected pg_settings()
        {
            pg_sb = new Npgsql.NpgsqlConnectionStringBuilder();
        }
        /// <summary>
        /// Основной конструктор инициализации класса настроек
        /// </summary>
        public pg_settings(String UserName, String Password, String Host, String DataBase, Int32 Port = 5999,
                String ApplicationName = "-",
                String SearchPath = "bpd, public", Int32 SessionTimeOut = 30, Int32 Timeout = 240, Int32 CommandTimeout = 2400, Int32 PoolConnectMax = 10, Boolean LoadTableComposites = true) : this()
        {
            StringBuilder sb = new StringBuilder();
            //Если имя вызывающего приложения не передано, передаем имя класса доступа к данным
            if (ApplicationName == "-")
            {
                sb.Append(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
                sb.Append(", Ver=");
                sb.Append(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
                ApplicationName_ = sb.ToString();
            }
            else
            {
                sb.Append(ApplicationName);
                sb.Append(", ");
                sb.Append(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
                sb.Append(", Ver=");
                sb.Append(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
                ApplicationName_ = sb.ToString();
            }
            //sur-asdb88.ogk.energo.local      uchet.asuscomm.com
            SessionTimeOut_ = SessionTimeOut;
            PoolConnectMax_ = PoolConnectMax;

            //Настройки параметров SSL начало
            pg_sb.SslMode = Npgsql.SslMode.Require;
            pg_sb.TrustServerCertificate = true;
            //Настройки параметров SSL конец

            pg_sb.ApplicationName = ApplicationName_;
            pg_sb.Host = Host;
            pg_sb.Port = Port;
            pg_sb.Database = DataBase;
            pg_sb.SearchPath = SearchPath;
            pg_sb.Username = UserName;
            pg_sb.Password = Password;
            pg_sb.CommandTimeout = CommandTimeout; //Время выполнения единичной команды 2400 сек
            pg_sb.InternalCommandTimeout = -1;
            pg_sb.Timeout = Timeout; //Время для установления соединения в секундах 240 сек
            //pg_sb.TcpKeepAlive = true;
            //pg_sb.KeepAlive = 60;
            pg_sb.Pooling = false;
            //pg_sb.ConnectionIdleLifetime = SessionTimeOut * 60 + 10;
            pg_sb.ClientEncoding = "UTF8";
            pg_sb.Encoding = "UTF8";

            pg_sb.LoadTableComposites = LoadTableComposites;
        }
        #endregion

        #region СВОЙСТВА КЛАССА

        private Npgsql.NpgsqlConnectionStringBuilder pg_sb;
        private String ApplicationName_;

        /// <summary>
        /// Наименование приложение в формате предоставляемом в строке подключения
        /// </summary>
        public String ApplicationName
        {
            get
            {
                return ApplicationName_;
            }
        }
        /// <summary>
        /// Строка подключенияя
        /// </summary>
        public string NpgsqlConnectionString
        {
            get
            {
                if (pg_sb != null)
                {
                    return pg_sb.ToString();
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Путь поиска по умолчанию
        /// </summary>
        public string SearchPath
        {
            get
            {
                return pg_sb.SearchPath;
            }
            set
            {
                pg_sb.SearchPath = value;
            }
        }

        /// <summary>
        /// Сетевое имя или IP адрес сервера БД
        /// </summary>
        public string Host
        {
            get
            {
                return pg_sb.Host;
            }
            set
            {
                pg_sb.Host = value;
            }
        }

        /// <summary>
        /// Порт ожидания запросов
        /// </summary>
        public int Port
        {
            get
            {
                return pg_sb.Port;
            }
            set
            {
                pg_sb.Port = value;
            }
        }

        Int32 PoolConnectMax_;
        /// <summary>
        /// Максимальное количество подключений в сесии менеджера
        /// </summary>
        public int PoolConnectMax
        {
            get
            {
                return PoolConnectMax_;
            }
            set
            {
                PoolConnectMax_ = value;
            }
        }

        /// <summary>
        /// Название БД
        /// </summary>
        public string DataBase
        {
            get
            {
                return pg_sb.Database;
            }
            set
            {
                pg_sb.Database = value;
            }
        }

        /// <summary>
        /// Роль пользователя БД
        /// </summary>
        public String UserName
        {
            get
            {
                return pg_sb.Username;
            }
            set
            {
                pg_sb.Username = value;
            }
        }

        /// <summary>
        /// Пароль роли БД если применим по условиям авторизации
        /// </summary>
        public String Password
        {
            set
            {
                pg_sb.Password = value;
            }
        }
        /// <summary>
        /// Возвращает или задает логическое значение, которое определяет, возвращаются ли сведения, связанные с 
        /// безопасностью (такие как пароль), как часть подключения, если оно открыто или когда-либо находилось в открытом состоянии.
        /// </summary>
        public Boolean PersistSecurityInfo
        {
            get
            {
                return pg_sb.PersistSecurityInfo;
            }
            set
            {
                pg_sb.PersistSecurityInfo = value;
            }
        }

        /// <summary>
        /// Время ожидания (в секундах) при попытке выполнить команду, прежде чем завершить попытку и выдать ошибку. Установить на ноль для бесконечности.
        /// </summary>
        public Int32 CommandTimeout
        {
            get
            {
                return pg_sb.CommandTimeout;
            }
            set
            {
                pg_sb.CommandTimeout = value;
            }
        }


        private Int32 SessionTimeOut_;
        /// <summary>
        /// Время бездействия клиентского приложения в минутах, до вызова метода закрытия соединения с сервером
        /// </summary>
        public Int32 SessionTimeOut
        {
            get
            {
                return SessionTimeOut_;
            }
            set
            {
                SessionTimeOut_ = value;
            }
        }

        /// <summary>
        /// Время ожидания при попытке установить соединение в секундах
        /// </summary>
        public Int32 Timeout
        {
            get
            {
                return pg_sb.Timeout;
            }
            set
            {
                pg_sb.Timeout = value;
            }
        }

        private String UploadTemp_;
        /// <summary>
        /// Наименование временной директории для загрузки файлов библиотеки документов
        /// </summary>
        public String UploadTemp
        {
            get
            {
                if (UploadTemp_ == null)
                {
                    UploadTemp_ = "$uchet$";
                }
                return UploadTemp_;
            }
            set { UploadTemp_ = value; }
        }
        #endregion
    }
}
