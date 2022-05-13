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
        /// Делегат события изменения данных области значений глобального свойства
        /// </summary>
        public delegate void GlobalPropAreaValChangeEventHandler(Object sender, GlobalPropAreaValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении данных области значений глобального свойства
        /// </summary>
        public event GlobalPropAreaValChangeEventHandler GlobalPropAreaValChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения данных области значений глобального свойства
        /// </summary>
        protected virtual void GlobalPropAreaValOnChange(GlobalPropAreaValChangeEventArgs e)
        {
            GlobalPropAreaValChangeEventHandler temp = GlobalPropAreaValChange;
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
