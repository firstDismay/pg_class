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
        /// Делегат события изменения привязки глобального свойства
        /// </summary>
        public delegate void GlobalPropLinkClassPropChangeEventHandler(Object sender, GlobalPropLinkClassPropChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении привязки глобального свойства
        /// </summary>
        public event GlobalPropLinkClassPropChangeEventHandler GlobalPropLinkClassPropChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения привязки глобального свойства
        /// </summary>
        protected virtual void GlobalPropLinkClassPropOnChange(GlobalPropLinkClassPropChangeEventArgs e)
        {
            GlobalPropLinkClassPropChangeEventHandler temp = GlobalPropLinkClassPropChange;
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
