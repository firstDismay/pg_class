using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Npgsql;
using System.Data;
using System.Windows.Forms;
using pg_class.pg_exceptions;
using pg_class.poolcn;
using System.Globalization;


namespace pg_class
{
    /// <summary>
    /// Класс одиночка предоставляющий общий доступ к БД Ассистента"
    /// </summary>
    public partial class manager
    {
        #region МЕТОДЫ УПРАВЛЕНИЯ СЕССИЕЙ
        /// <summary>
        /// Метод входа пользователя при инициализированном менеджере
        /// </summary>
        public void LogOn(pg_settings Session_Settings)
        {
            JournalEventArgs me;
            if (Session_Settings != null)
            {
                manager.Pg_ManagerSettings = Session_Settings;
                if (pool_ != null)
                {                   
                    pool_.LogOn(Session_Settings);

                    //Повторная инициализация команд с новыми учетными данными
                    InitCommands();

                    //Генерируем событие изменения состояния менеджера данных
                    ManagerStateChangeEventArgs e = new ManagerStateChangeEventArgs(eEntity.pool, eManagerState.Connected);
                    manager.OnManagerStateChange(e);

                    me = new JournalEventArgs(0, eEntity.manager, 0, "Открытие сессии пользователя", eAction.Init, eJournalMessageType.information);
                    Me.JournalMessageOnReceived(me);
                }
                else
                {
                    me = new JournalEventArgs(0, eEntity.manager, 0, "Пул соединений не создан, открытие сессии невозможно", eAction.Init, eJournalMessageType.error);
                    Me.JournalMessageOnReceived(me);
                    throw (new PgManagerException(404, "Пул соединений не создан",
                   "HINT: Для создания пула соединений предварительно используйте метод Pool_create"));
                }
            }
            else
            {
                me = new JournalEventArgs(0, eEntity.manager, 0, "Не выполнена инициализация класса параметров подключения pg_settings", eAction.Init, eJournalMessageType.error);
                Me.JournalMessageOnReceived(me);
                throw (new PgManagerException(404, "Не выполнена инициализация класса параметров подключения pg_settings",
                   "Не выполнена инициализация класса параметров подключения pg_settings"));
            }
        }

        /// <summary>
        /// Метод выходв пользователя при инициализированном менеджере
        /// </summary>
        public void LogOf()
        {
            JournalEventArgs me;
            if (pool_ != null)
            {
                pool_.LogOff();
            }

            if (manager.Pg_ManagerSettings != null)
            {
                manager.Pg_ManagerSettings.Password = "";
                manager.Pg_ManagerSettings = null;
            }

            if (manager.StateInstance != eManagerState.LogOff)
            {
                ManagerStateInstanceSet(eManagerState.LogOff);
                //Генерируем событие изменения состояния менеджера данных
                ManagerStateChangeEventArgs e = new ManagerStateChangeEventArgs(eEntity.pool, eManagerState.LogOff);
                manager.OnManagerStateChange(e);

                me = new JournalEventArgs(0, eEntity.manager, 0, "Закрытие сессии пользователя", eAction.DisConnect, eJournalMessageType.information);
                if (Me != null)
                {
                    Me.JournalMessageOnReceived(me);
                }
            }
        }
        #endregion
    }
}
