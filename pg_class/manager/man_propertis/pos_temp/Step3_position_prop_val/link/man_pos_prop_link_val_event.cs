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
        /// Делегат события изменения значения свойства позиции типа ссылка
        /// </summary>
        public delegate void PositionPropLinkValChangeEventHandler(Object sender, PositionPropLinkValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения свойства позиции типа ссылка
        /// </summary>
        public event PositionPropLinkValChangeEventHandler PositionPropLinkValChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения значения свойства позиции
        /// </summary>
        protected virtual void PositionPropLinkValOnChange(PositionPropLinkValChangeEventArgs e)
        {
            PositionPropLinkValChangeEventHandler temp = PositionPropLinkValChange;
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
