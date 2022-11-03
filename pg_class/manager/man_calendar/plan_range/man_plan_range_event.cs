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
        /// Делегат события изменения планового диапазона
        /// </summary>
        public delegate void PlanRangeChangeEventHandler(Object sender, PlanRangeChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении планового диапазона методом доступа к БД
        /// </summary>
        public event PlanRangeChangeEventHandler PlanRangeChange;
        

        /// <summary>
        ///  Метод вызова события изменения плана
        /// </summary>
        protected virtual void PlanRangeOnChange(PlanRangeChangeEventArgs e)
        {
            PlanRangeChangeEventHandler temp = PlanRangeChange;
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
