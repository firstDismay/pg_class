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
        /// Делегат события изменения позиции
        /// </summary>
        public delegate void PositionChangeEventHandler(Object sender, PositionChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении позиции методом доступа к БД
        /// </summary>
        public event PositionChangeEventHandler PositionChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения позиции
        /// </summary>
        protected virtual void PositionOnChange(PositionChangeEventArgs e)
        {
            PositionChangeEventHandler temp = PositionChange;

            if (temp != null)
            {
                temp(this, e);
            }
            //Вызов события журнала
            JournalEventArgs me = new JournalEventArgs(e);
            JournalMessageOnReceived(me);
        }

        /// <summary>
        /// Событие возникает при изменении блокировки позиции методом доступа к БД
        /// </summary>
        public event PositionChangeEventHandler PositionChangeLock;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения блокировки позиции
        /// </summary>
        protected virtual void PositionOnChangeLock(PositionChangeEventArgs e)
        {
            PositionChangeEventHandler temp = PositionChangeLock;

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
