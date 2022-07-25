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
        /// Делегат события изменения ссылки плана
        /// </summary>
        public delegate void PlanGivenRangePlanLinkChangeEventHandler(Object sender, PlanGivenRangePlanLinkChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении ссылки плана методом доступа к БД
        /// </summary>
        public event PlanGivenRangePlanLinkChangeEventHandler PlanGivenRangePlanLinkChange;

        /// <summary>
        ///  Метод вызова события изменения ссылки плана
        /// </summary>
        protected virtual void PlanGivenRangePlanLinkOnChange(PlanGivenRangePlanLinkChangeEventArgs e)
        {
            PlanGivenRangePlanLinkChangeEventHandler temp = PlanGivenRangePlanLinkChange;
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