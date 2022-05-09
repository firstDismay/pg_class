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
        /// Делегат события изменения ссылки планового диапазона
        /// </summary>
        public delegate void PlanRangeLinkChangeEventHandler(Object sender, PlanRangeLinkChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении ссылки плана методом доступа к БД
        /// </summary>
        public event PlanRangeLinkChangeEventHandler PlanRangeLinkChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения ссылки плана
        /// </summary>
        protected virtual void PlanRangeLinkOnChange(PlanRangeLinkChangeEventArgs e)
        {
            PlanRangeLinkChangeEventHandler temp = PlanRangeLinkChange;
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
