using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Npgsql;
using System.Data;
using System.Windows.Forms;
using pg_class.pg_exceptions;
using System.Net.Sockets;
using System.Linq;

namespace pg_class
{
    /// <summary>
    /// Класс одиночка предоставляющий общий доступ к БД Ассистента"
    /// </summary>
    public partial class manager : IDisposable
    {
        #region РЕАЛИЗАЦИЯ ОДИНОЧКИ

        /// <summary>
        /// Защищенная переменная хранящая текущий экземпляр одиночки
        /// </summary>
        private static manager Me;
        private DateTime starttime;
        private DateTime stoptime;
        private TimeSpan inittime;

        /// <summary>
        /// Защищенный конструктор класса
        /// </summary>
        protected manager()
        {
            starttime = DateTime.Now;
            JournalEventArgs me;
            //Инициализация класса менеджера
            managerstate = eManagerState.NoReady;
            //Вызов события журнала
            me = new JournalEventArgs(0, eEntity.manager, 0, "Сессия журнала открыта", eAction.Init, eJournalMessageType.information);
            JournalMessageOnReceived(me);
            //Вызов события журнала
            me = new JournalEventArgs(0, eEntity.manager, 0, "Менеджер данных создан", eAction.Init, eJournalMessageType.information);
            JournalMessageOnReceived(me);
        }

        /// <summary>
        /// Метод инициализации одиночки возвращет ссылку на менеджер БД
        /// </summary>
        static public manager Instance()
        {
            if (Me == null)
            {
                Me = new manager();
            }
            return Me;
        }
        #endregion

        #region ОСНОВНЫЕ СВОЙСТВА И МЕТОДЫ ОДИНОЧКИ
        static private eManagerState managerstate = eManagerState.NoReady;

        /// <summary>
        /// Состояние экземпляра менеджера данных
        /// </summary>
        static public eManagerState StateInstance
        {
            get
            {
                if (Me == null)
                {
                    managerstate = eManagerState.NoReady;
                }
                return managerstate;
            }
        }

        /// <summary>
        /// Состояние экземпляра менеджера данных установить
        /// </summary>
        internal void ManagerStateInstanceSet(eManagerState ManagerState)
        {
            managerstate = ManagerState;
        }

        /// <summary>
        /// Состояние экземпляра менеджера данных установить
        /// </summary>
        static internal void ManagerStateInstanceStsticSet(eManagerState ManagerState)
        {
            managerstate = ManagerState;
        }
        #endregion

        #region РЕАЛИЗАЦИЯ ИНТЕРФЕЙСА IDispose

        private bool disposed = false;

        /// <summary>
        /// Реализация интерфейса IDispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
        
        /// <summary>
        /// Метод очистки ресурсов
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    Close();
                }

                // Note disposing has been done.
                disposed = true;
            }
        }
        #endregion

    }
}
