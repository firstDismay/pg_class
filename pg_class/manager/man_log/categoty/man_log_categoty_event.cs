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

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения категории записи журнала
        /// </summary>
        public delegate void LogCategoryChangeEventHandler(Object sender, LogCategoryChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении категории записи журнала методом доступа к БД
        /// </summary>
        public event LogCategoryChangeEventHandler LogCategoryChange;

        /// <summary>
        ///  Метод вызова события изменения категории записи журнала
        /// </summary>
        protected virtual void LogCategoryOnChange(LogCategoryChangeEventArgs e)
        {
            LogCategoryChangeEventHandler temp = LogCategoryChange;
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