using pg_class.pg_exceptions;
using System;
using System.Collections.Generic;

namespace pg_class.poolcn
{
    /// <summary>
    /// Пул соединений мнеджера
    /// </summary>
    internal partial class pool
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Полный конструктор класса для инициализации пула с первичными папаремтрами сессии
        /// </summary>
        internal pool()
        {
            cn_list = new List<connect>();

            //Вызов события журнала
            JournalEventArgs me = new JournalEventArgs(0, eEntity.pool, "action_allowed", "Пул соединений создан", eAction.Connect, eJournalMessageType.information);
            manager.JournalMessageOnReceivedStatic(this, me);

            connect CN = new connect();
            CN.Open();
            CN.UnLock();
            cn_list.Add(CN);

            //Вызов события изменения количества подключений
            PoolConnectEventArgs pc = new PoolConnectEventArgs(cn_list.Count, manager.PoolConnectMaxStatic);
            manager.PoolConnectCountOnChangeStatic(this, pc);

            //Вызов события журнала
            me = new JournalEventArgs(0, eEntity.manager, "action_allowed", "Менеджер данных подключен в БД", eAction.Connect, eJournalMessageType.information);
            manager.JournalMessageOnReceivedStatic(this, me);

            StartControlTimer();
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        List<connect> cn_list;
        //Boolean is_init;

        //private pg_settings Pg_PoolSessionSettings;
        /// <summary>
        /// Параметры текущей сесии пользователя, хранимые независимо от состояния экземпляра менеджера
        /// </summary>
        internal pg_settings Session_Settings
        {
            get
            {
                return manager.Pg_ManagerSettings;
            }
        }

        /// <summary>
        /// Максимальное количество подключений в сесии менеджера
        /// </summary>
        internal int PoolConnectMax
        {
            get
            {
                Int32 Result = -1;
                if (Session_Settings != null)
                {
                    Result = Session_Settings.PoolConnectMax;
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
                if (cn_list != null)
                {
                    Result = cn_list.Count;
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
        /// <summary>
        /// Метод возвращает подключенное выделенное соединение
        /// </summary>
        internal connect Connect_Get(Boolean quiet = false)
        {
            connect CN = null;
            JournalEventArgs me;

            switch (manager.StateInstance)
            {
                case eManagerState.Connected:
                case eManagerState.Disconnected:
                    lock (cn_list)
                    {
                        if (cn_list.Count > 0)
                        {
                            CN = cn_list.Find(x => !x.IsUse && !x.IsCorupted);
                            if (CN == null)
                            {
                                if (cn_list.Count < PoolConnectMax)
                                {
                                    CN = new connect();
                                    CN.Open();
                                    CN.Lock();
                                    cn_list.Add(CN);
                                    //Вызов события изменения количества подключений
                                    PoolConnectEventArgs pc = new PoolConnectEventArgs(cn_list.Count, manager.PoolConnectMaxStatic);
                                    manager.PoolConnectCountOnChangeStatic(this, pc);
                                }
                                else
                                {
                                    //Ожидание свободного подключения
                                    while (CN == null)
                                    {
                                        CN = cn_list.Find(x => !x.IsUse && !x.IsCorupted);
                                    }
                                    CN.Open();
                                    CN.Lock();
                                }
                            }
                            else
                            {
                                CN.Open();
                                CN.Lock();
                            }
                        }
                        else
                        {
                            CN = new connect();
                            CN.Open();
                            CN.Lock();
                            cn_list.Add(CN);
                            StartControlTimer();
                            //Вызов события изменения количества подключений
                            PoolConnectEventArgs pc = new PoolConnectEventArgs(cn_list.Count, manager.PoolConnectMaxStatic);
                            manager.PoolConnectCountOnChangeStatic(this, pc);
                        }

                        if (manager.StateInstance == eManagerState.Disconnected)
                        {
                            Manager.ManagerStateInstanceSet(eManagerState.Connected);
                            //Генерируем событие изменения состояния менеджера данных
                            if (!quiet)
                            {
                                ManagerStateChangeEventArgs e2 = new ManagerStateChangeEventArgs(eEntity.pool, eManagerState.Connected);
                                manager.OnManagerStateChange(e2);
                            }
                            //Вызов события журнала
                            me = new JournalEventArgs(0, eEntity.manager, "action_allowed", "Менеджер данных подключен в БД", eAction.Connect, eJournalMessageType.information);
                            manager.JournalMessageOnReceivedStatic(this, me);
                        }
                    }
                    break;
                case eManagerState.LogOff:
                    //Вызов события журнала
                    me = new JournalEventArgs(0, eEntity.manager, "action_allowed", "Авторизующая сессия сервера завершена", eAction.Connect, eJournalMessageType.error);
                    manager.JournalMessageOnReceivedStatic(this, me);
                    throw new PgManagerException(404, "Авторизующая сессия сервера завершена", "Сессия сервера завершена, выполнение команд не доступно");
                case eManagerState.NoReady:
                    //Вызов события журнала
                    me = new JournalEventArgs(0, eEntity.manager, "action_allowed", "Пул менеджера данных не создан", eAction.Connect, eJournalMessageType.error);
                    manager.JournalMessageOnReceivedStatic(this, me);
                    throw new PgManagerException(404, "Пул менеджера данных не создан", "Пул менеджера данных не создан, выполнение команд не доступно");
            }
            return CN;
        }

        /// <summary>
        /// Закрытие всех соединений по коменде менеджера
        /// </summary>
        internal void Connect_Close()
        {
            lock (cn_list)
            {
                if (cn_list.Count > 0)
                {
                    foreach (connect c in cn_list)
                    {
                        c.Drop();
                    }
                    cn_list.Clear();
                }
                StopControlTimer();
                if (manager.StateInstance == eManagerState.Connected)
                {
                    Manager.ManagerStateInstanceSet(eManagerState.Disconnected);
                    //Генерируем событие изменения состояния менеджера данных
                    ManagerStateChangeEventArgs e2 = new ManagerStateChangeEventArgs(eEntity.pool, eManagerState.Disconnected);
                    manager.OnManagerStateChange(e2);
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(0, eEntity.pool, "action_allowed", "Все соединения менеджера закрыты по команде менеджера данных", eAction.DisConnect, eJournalMessageType.information);
                    manager.JournalMessageOnReceivedStatic(this, me);
                }
                //Вызов события изменения количества подключений
                PoolConnectEventArgs pc = new PoolConnectEventArgs(cn_list.Count, manager.PoolConnectMaxStatic);
                manager.PoolConnectCountOnChangeStatic(this, pc);
            }
        }

        /// <summary>
        /// Закрытие указанного соединения сервера
        /// </summary>
        protected void Connect_Remove(connect CN)
        {
            lock (cn_list)
            {
                if (cn_list != null)
                {
                    if (cn_list.Count > 0)
                    {
                        cn_list.Remove(CN);
                    }
                }

                if (manager.StateInstance == eManagerState.Connected && cn_list.Count == 0)
                {
                    StopControlTimer();
                    Manager.ManagerStateInstanceSet(eManagerState.Disconnected);
                    //Генерируем событие изменения состояния менеджера данных
                    ManagerStateChangeEventArgs e2 = new ManagerStateChangeEventArgs(eEntity.pool, eManagerState.Disconnected);
                    manager.OnManagerStateChange(e2);
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(0, eEntity.pool, "action_allowed", "Все соединения менеджера закрыты по команде менеджера данных", eAction.DisConnect, eJournalMessageType.information);
                    manager.JournalMessageOnReceivedStatic(this, me);
                }
                //Вызов события изменения количества подключений
                PoolConnectEventArgs pc = new PoolConnectEventArgs(cn_list.Count, manager.PoolConnectMaxStatic);
                manager.PoolConnectCountOnChangeStatic(this, pc);
            }
        }
        #endregion
    }
}