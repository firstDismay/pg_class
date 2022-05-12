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
        /// Делегат события изменения значения перечисления для свойства
        /// </summary>
        public delegate void PropEnumChangeEventHandler(Object sender, PropEnumChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении перечисления для свойств
        /// </summary>
        public event PropEnumChangeEventHandler PropEnumChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения перечисления для свойств
        /// </summary>
        protected virtual void PropEnumOnChange(PropEnumChangeEventArgs e)
        {
            PropEnumChangeEventHandler temp = PropEnumChange;
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
