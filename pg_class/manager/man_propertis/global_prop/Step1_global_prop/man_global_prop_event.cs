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
        /// Делегат события изменения глобального свойства
        /// </summary>
        public delegate void GlobalPropChangeEventHandler(Object sender, GlobalPropChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении глобального свойства
        /// </summary>
        public event GlobalPropChangeEventHandler GlobalPropChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения глобального свойства
        /// </summary>
        protected virtual void GlobalPropOnChange(GlobalPropChangeEventArgs e)
        {
            GlobalPropChangeEventHandler temp = GlobalPropChange;
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
