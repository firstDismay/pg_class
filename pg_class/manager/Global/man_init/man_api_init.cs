using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System.Net.Sockets;
using pg_class.poolcn;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод инициализации класса
        /// </summary>
        protected void InitAPI()
        {
            //Вызов события журнала
            JournalEventArgs me = new JournalEventArgs(0, eEntity.manager, 0, "Инициализация менеджера данных", eAction.Init, eJournalMessageType.information);
            JournalMessageOnReceived(me);

            //Инициализация подключения к БД конфигурации
            connect cn = pool_.Connect_Get(true);

            //Вызов события журнала
            me = new JournalEventArgs(0, eEntity.manager, 0, "Инициализация команд менеджера данных", eAction.Init, eJournalMessageType.information);
            JournalMessageOnReceived(me);
            //Инициализация команд работы с БД
            InitCommand2(cn.CN);
            cn.UnLock();

            //Инициализация концепций
            conception_list_state = eStatus.on;

            //Вызов события журнала
            String msg = String.Format("Инициализация команд менеджера данных завершена, загружено команд: {0}, загружено таблиц: {1}", command_list.Count, datatable_list.Count);
            me = new JournalEventArgs(0, eEntity.manager, 0, msg, eAction.Init, eJournalMessageType.information);
            JournalMessageOnReceived(me);
        }
    }
}