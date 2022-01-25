using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace pg_class.poolcn
{
    /// <summary>
    /// Класс подключение для пула подключений
    /// </summary>
    internal partial class connect
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Закрытый конструктор класса
        /// </summary>
        internal connect()
        {
            isuse = false;
        }
        #endregion

        #region ОСНОВНЫЕ СВОЙСТВА СОЕДИНЕНИЯ

        private Boolean isuse;
        /// <summary>
        /// Признак доступности соединения для выполнения команд
        /// </summary>
        internal Boolean IsUse
            {
            get
            {
                return isuse;
            }
        }
        
        /// <summary>
        /// Переменная подключения к БД Учет
        /// </summary>
        private NpgsqlConnection cn;
        /// <summary>
        /// Текущее подключение к БД Учет
        /// </summary>
        public NpgsqlConnection CN
        {
            get
            {
                return cn;
            }
        }

        /// <summary>
        /// Параметры текущей сесии пользователя, хранимые независимо от состояния экземпляра менеджера
        /// </summary>
        public pg_settings Session_Settings
        {
            get
            {
                return manager.Pg_ManagerSettings;
            }
        }

        /// <summary>
        /// Текущее состояние подключения экземпляра одиночки
        /// </summary>
        public ConnectionState CnState
        {
            get
            {
                ConnectionState Result = ConnectionState.Closed;
                if (cn != null)
                {
                    Result = cn.State;
                }
                return Result;
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

        #endregion

        #region МЕТОДЫ КЛАССА
        #region ОТКРЫТИЕ СОЕДИНЕНИЯ
        /// <summary>
        ///Метод открытия подключения с предопределенными в первичном конструкторе параметрами подключения
        /// </summary>
        internal void Open()
        {
            Boolean firstopen = false;
            try
            {
                if (cn == null)
                {
                    cn = new NpgsqlConnection(Session_Settings.NpgsqlConnectionString);
                    firstopen = true;
                }
                else
                {
                    cn.ConnectionString = Session_Settings.NpgsqlConnectionString;
                }

                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }

                if (firstopen)
                {
                    //Сопоставление композитных типов
                    npgsql_type_map(cn);
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(0, eEntity.connect, 0, "Свободное подключение установлено", eAction.Connect, eJournalMessageType.information);
                    manager.JournalMessageOnReceivedStatic(this, me);
                }
            }
            catch (Exception ex)
            {
                if (cn != null)
                {
                    Manager.Connect_Remove(this);
                }

                if (manager.StateInstance == eManagerState.LogOff)
                {
                    manager.ManagerStateInstanceStsticSet(eManagerState.LogOff);
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(0, eEntity.connect, 0, "Ошибка подключения к серверу", eAction.Connect, eJournalMessageType.error);
                    manager.JournalMessageOnReceivedStatic(this, me);
                    //Генерируем событие изменения состояния менеджера данных
                    ManagerStateChangeEventArgs e = new ManagerStateChangeEventArgs(eEntity.pool, eManagerState.NoReady);
                    manager.OnManagerStateChange(e);
                    Manager.man_exception_hadler(ex);
                }
                else
                {
                    manager.ManagerStateInstanceStsticSet(eManagerState.NoReady);
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(0, eEntity.connect, 0, "Ошибка подключения к серверу", eAction.Connect, eJournalMessageType.error);
                    manager.JournalMessageOnReceivedStatic(this, me);
                    //Генерируем событие изменения состояния менеджера данных
                    ManagerStateChangeEventArgs e = new ManagerStateChangeEventArgs(eEntity.pool, eManagerState.NoReady);
                    manager.OnManagerStateChange(e);
                    Manager.man_exception_hadler(ex);
                }
            }
        }
        #endregion

        #region ЗАКРЫТИЕ СОЕДИНЕНИЯ

        /// <summary>
        /// Метод закрывает и уничтожает соединение
        /// </summary>
        internal void Drop()
        {
            if (cn != null)
            {
                cn.CloseAsync();
                cn.Dispose();
                cn = null;
                ///Сообщить в пул соединений о необхимости исключить подключение из списка соединений
                Manager.Connect_Remove(this);
                
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(0, eEntity.manager, 0, "Неиспользуемое подключение закрыто", eAction.Delete, eJournalMessageType.information);
                manager.JournalMessageOnReceivedStatic(this, me);
            }
        }

        /// <summary>
        /// Метод закрывает соединение
        /// </summary>
        public void Close()
        {
            if (cn != null)
            {
                cn.CloseAsync();
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(0, eEntity.manager, 0, "Подключение закрыто", eAction.DisConnect, eJournalMessageType.information);
                manager.JournalMessageOnReceivedStatic(this, me);
            }
        }
        #endregion

        #region БЛОКИРОВКА РАЗБЛОКИРОВКА ПОДКЛЮЧЕНИЯ
        /// <summary>
        ///Метод блокировки подключения соединения
        /// </summary>
        internal void Lock()
        {
            isuse = true;
        }

        /// <summary>
        ///Метод блокировки подключения соединения
        /// </summary>
        internal void UnLock()
        {
            isuse = false;
            SetLastTimeUsing();
        }
        #endregion

        #region КОНТРОЛЬ ВРЕМЕНИ УДЕРЖАНИЯ СОЕДИНЕНИЯ
        /// <summary>
        /// Время последнего обращения к соединению
        /// </summary>
        private DateTime lasttimeusing;
        /// <summary>
        /// Метод возвращает время последнего обращения к одиночке
        /// </summary>
        internal DateTime LastTimeUsing
        {
            get
            {
                return lasttimeusing;
            }
        }
        /// <summary>
        /// Метод устанавливает время последнего обращения к одиночке
        /// </summary>
        internal void SetLastTimeUsing()
        {
            lasttimeusing = DateTime.Now;
        }

        /// <summary>
        /// Метод возвращает время простоя класса доступа к данным в минутах
        /// </summary>
        /// <returns>Время простоя в минутах</returns>
        internal Double GetTimeOutUsing()
        {
            Double Result_ = 0;
            TimeSpan time = DateTime.Now - LastTimeUsing;

            Result_ = time.TotalMinutes;
            return Result_;
        }
        
        #endregion     
        #endregion
    }
}
