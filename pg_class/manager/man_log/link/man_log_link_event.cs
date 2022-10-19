using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using pg_class.pg_classes;
using System.Security.Cryptography;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения ссылки записи журнала
        /// </summary>
        public delegate void LogLinkChangeEventHandler(Object sender, LogLinkChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении ссылки записи журнала методом доступа к БД
        /// </summary>
        public event LogLinkChangeEventHandler LogLinkChange;

        /// <summary>
        ///  Метод вызова события изменения атрибутов файла записи журнала
        /// </summary>
        protected virtual void LogLinkOnChange(LogLinkChangeEventArgs e)
        {
            LogLinkChangeEventHandler temp = LogLinkChange;
            if (temp != null)
            {
                temp(this, e);
            }
            //Вызов события журнала
            JournalEventArgs me = new JournalEventArgs(e);
            JournalMessageOnReceived(me);
        }
    }
}