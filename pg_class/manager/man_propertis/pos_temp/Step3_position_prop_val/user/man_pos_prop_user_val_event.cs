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
        /// Делегат события изменения значения пользовательского свойства Позиции
        /// </summary>
        public delegate void PositionPropUserValChangeEventHandler(Object sender, PositionPropUserValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения пользовательского свойства позиции
        /// </summary>
        public event PositionPropUserValChangeEventHandler PositionPropUserValChange;
        

        /// <summary>
        ///  Метод вызова события изменения значения свойства объекта
        /// </summary>
        protected virtual void PositionPropUserValOnChange(PositionPropUserValChangeEventArgs e)
        {
            PositionPropUserValChangeEventHandler temp = PositionPropUserValChange;
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
