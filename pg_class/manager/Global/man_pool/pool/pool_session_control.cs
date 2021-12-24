using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using pg_class.pg_exceptions;

namespace pg_class.poolcn
{
    /// <summary>
    /// Пул соединений мнеджера
    /// </summary>
    internal partial class pool
    {
        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Полный конструктор класса для инициализации пула с первичными папаремтрами сессии
        /// </summary>
        internal void LogOn(pg_settings newSessionSettings)
        {
            JournalEventArgs me;
            manager.Pg_ManagerSettings = newSessionSettings;

            lock (cn_list)
            {
                if (cn_list.Count > 0)
                {
                    foreach (connect c in cn_list)
                    {
                        if (c.CnState == ConnectionState.Open)
                        {
                            c.Close();
                        }
                        c.Drop();
                    }
                    cn_list.Clear();
                }
                connect CN = new connect();
                CN.Open();
                cn_list.Add(CN);
            }
            StartControlTimer();

            Manager.ManagerStateInstanceSet(eManagerState.Connected);
            //Вызов события изменения количества подключений
            PoolConnectEventArgs pc = new PoolConnectEventArgs(cn_list.Count, manager.PoolConnectMaxStatic);
            manager.PoolConnectCountOnChangeStatic(this, pc);
            
            //Вызов события журнала
            me = new JournalEventArgs(0, eEntity.pool, 0, "Вход пользователя выполнен", eAction.Connect, eJournalMessageType.information);
            manager.JournalMessageOnReceivedStatic(this, me);
        }

        /// <summary>
        /// Метод завершает сеанс пользователя к БД
        /// </summary>
        internal void LogOff()
        {
            lock (cn_list)
            {
                if (cn_list.Count > 0)
                {
                    foreach (connect c in cn_list)
                    {
                        if (c.CnState == ConnectionState.Open)
                        {
                            c.Close();
                        }
                        c.Drop();
                    }
                    cn_list.Clear();
                }
            }
            StopControlTimer();
            
            //Вызов события изменения количества подключений
            PoolConnectEventArgs pc = new PoolConnectEventArgs(cn_list.Count, manager.PoolConnectMaxStatic);
            manager.PoolConnectCountOnChangeStatic(this, pc);
            
            //Вызов события журнала
            JournalEventArgs me = new JournalEventArgs(0, eEntity.pool, 0, "Выход пользователя выполнен", eAction.DisConnect, eJournalMessageType.information);
            manager.JournalMessageOnReceivedStatic(this, me);
        }
        #endregion
    }
}
