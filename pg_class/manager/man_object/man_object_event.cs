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
using Newtonsoft.Json;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения объектов
        /// </summary>
        public delegate void ObjectChangeEventHandler(Object sender, ObjectChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении объекта методом доступа к БД
        /// </summary>
        public event ObjectChangeEventHandler ObjectChange;
        

        /// <summary>
        ///  Метод вызова события изменения объекта
        /// </summary>
        protected virtual void ObjectOnChange(ObjectChangeEventArgs e)
        {
            ObjectChangeEventHandler temp = ObjectChange;
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
