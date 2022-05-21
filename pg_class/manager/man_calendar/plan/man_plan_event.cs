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
using pg_class.pg_classes.calendar;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения плана
        /// </summary>
        public delegate void PlanChangeEventHandler(Object sender, PlanChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении плана методом доступа к БД
        /// </summary>
        public event PlanChangeEventHandler PlanChange;
        
        /// <summary>
        ///  Метод вызова события изменения плана
        /// </summary>
        protected virtual void PlanOnChange(PlanChangeEventArgs e)
        {
            PlanChangeEventHandler temp = PlanChange;
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
