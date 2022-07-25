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
using NpgsqlTypes;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения выделенного диапазона плана
        /// </summary>
        public delegate void PlanGivenRangePlanChangeEventHandler(Object sender, PlanGivenRangePlanChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении выделенного диапазона плана методом доступа к БД
        /// </summary>
        public event PlanGivenRangePlanChangeEventHandler PlanGivenRangePlanChange;

        /// <summary>
        ///  Метод вызова события изменения плана
        /// </summary>
        protected virtual void PlanGivenRangePlanOnChange(PlanGivenRangePlanChangeEventArgs e)
        {
            PlanGivenRangePlanChangeEventHandler temp = PlanGivenRangePlanChange;
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