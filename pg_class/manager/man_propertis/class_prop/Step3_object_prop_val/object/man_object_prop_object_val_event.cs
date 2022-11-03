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
        /// Делегат события изменения значения объектного свойства объекта
        /// </summary>
        public delegate void ObjectPropObjectValChangeEventHandler(Object sender, ObjectPropObjectValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения объектного свойства объекта
        /// </summary>
        public event ObjectPropObjectValChangeEventHandler ObjectPropObjectValChange;
        

        /// <summary>
        ///  Метод вызова события изменения значения свойства объекта
        /// </summary>
        protected virtual void ObjectPropObjectValOnChange(ObjectPropObjectValChangeEventArgs e)
        {
            ObjectPropObjectValChangeEventHandler temp = ObjectPropObjectValChange;
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
