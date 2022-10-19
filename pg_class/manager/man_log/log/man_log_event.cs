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
using System.IO;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения атрибутов записи журнала
        /// </summary>
        public delegate void LogChangeEventHandler(Object sender, LogChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении атрибутов записи журнала методом доступа к БД
        /// </summary>
        public event LogChangeEventHandler LogChange;
        
        /// <summary>
        ///  Метод вызова события изменения атрибутов записи журнала
        /// </summary>
        protected virtual void LogOnChange(LogChangeEventArgs e)
        {
            LogChangeEventHandler temp = LogChange;
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