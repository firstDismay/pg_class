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
        /// Делегат события изменения концепции
        /// </summary>
        public delegate void ConceptionChangeEventHandler(Object sender, ConceptionChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении концепции методом доступа к БД
        /// </summary>
        public event ConceptionChangeEventHandler ConceptionChange;

        /// <summary>
        ///  Метод вызова события изменения концепции
        /// </summary>
        protected virtual void ConceptionOnChange(ConceptionChangeEventArgs e)
        {
            ConceptionChangeEventHandler temp = ConceptionChange;
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
