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
        /// Делегат события изменения представления класса
        /// </summary>
        public delegate void ClassChangeEventHandler(Object sender, ClassChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении представления класса методом доступа к БД
        /// </summary>
        public event ClassChangeEventHandler ClassChange;
        

        /// <summary>
        ///  Метод вызова события изменения представления класса
        /// </summary>
        protected virtual void ClassOnChange(ClassChangeEventArgs e)
        {
            ClassChangeEventHandler temp = ClassChange;

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
