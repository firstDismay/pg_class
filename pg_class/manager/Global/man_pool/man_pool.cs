using pg_class.pg_exceptions;
using pg_class.poolcn;
using System;
using System.Globalization;


namespace pg_class
{
    /// <summary>
    /// Класс одиночка предоставляющий общий доступ к БД Ассистента"
    /// </summary>
    public partial class manager
    {
        #region ОСНОВНЫЕ СВОЙСТВА И МЕТОДЫ ПУЛА СОЕДИНЕНИЙ
        static private pool pool_;

        /// <summary>
        /// Метод первичного создания пула соединений
        /// </summary>
        public void Pool_Create(pg_settings newSession_Settings)
        {
            JournalEventArgs me;
            if (newSession_Settings != null)
            {
                if (pool_ == null)
                {
                    Pg_ManagerSettings = newSession_Settings;
                    me = new JournalEventArgs(0, eEntity.manager, "action_allowed", "Создание пула соединений", eAction.Init, eJournalMessageType.information);
                    Me.JournalMessageOnReceived(me);
                    pool_ = new pool();
                    //
                    ManagerStateInstanceSet(eManagerState.Connected);
                    //
                    InitAPI();
                    //Генерируем событие изменения состояния менеджера данных
                    ManagerStateChangeEventArgs e = new ManagerStateChangeEventArgs(eEntity.manager, eManagerState.Connected);
                    manager.OnManagerStateChange(e);
                    stoptime = DateTime.Now;
                    inittime = stoptime - starttime;
                    me = new JournalEventArgs(0, eEntity.manager, "action_allowed", String.Format("Менеджер данных готов, время первичной инициализации: {0}сек.", inittime.TotalSeconds.ToString(@"0.000", CultureInfo.InvariantCulture)), eAction.Init, eJournalMessageType.information);
                    Me.JournalMessageOnReceived(me);
                }
                else
                {
                    throw (new PgManagerException(404, "Пул соединений уже создан",
                   "HINT: Для повторного создания пула соединений предварительно используйте метод Pool_drop!"));
                }
            }
            else
            {
                throw (new PgManagerException(404, "Не выполнена инициализация класса параметров подключения pg_settings",
                   "Не выполнена инициализация класса параметров подключения pg_settings"));
            }
        }

        /// <summary>
        /// Метод уничтожения пула соединений
        /// </summary>
        public void Pool_drop()
        {
            JournalEventArgs me;

            if (pool_ != null)
            {
                me = new JournalEventArgs(0, eEntity.manager, "action_allowed", "Удаление пула соединений", eAction.Delete, eJournalMessageType.information);
                Me.JournalMessageOnReceived(me);
                pool_.Connect_Close();
                pool_ = null;
                me = new JournalEventArgs(0, eEntity.manager, "action_allowed", "Пул соединений удален", eAction.Delete, eJournalMessageType.information);
                Me.JournalMessageOnReceived(me);
            }
            ManagerStateInstanceSet(eManagerState.NoReady);
            //Генерируем событие изменения состояния менеджера данных
            ManagerStateChangeEventArgs e = new ManagerStateChangeEventArgs(eEntity.manager, eManagerState.NoReady);
            manager.OnManagerStateChange(e);
        }

        /// <summary>
        /// Максимальное количество подключений в сесии менеджера
        /// </summary>
        internal int PoolConnectMax
        {
            get
            {
                Int32 Result = -1;
                if (Pg_ManagerSettings != null)
                {
                    Result = Pg_ManagerSettings.PoolConnectMax;
                }
                return Result;
            }
        }

        /// <summary>
        /// Текущее количество подключений в сесии менеджера
        /// </summary>
        internal int PoolConnectCurrent
        {
            get
            {
                Int32 Result = 0;
                if (pool_ != null)
                {
                    Result = pool_.PoolConnectCurrent;
                }
                return Result;
            }
        }
        #endregion
    }
}
