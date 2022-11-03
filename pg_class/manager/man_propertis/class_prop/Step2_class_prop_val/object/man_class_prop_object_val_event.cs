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
        /// Делегат события изменения значения объектного свойства класса
        /// </summary>
        public delegate void ClassPropObjectValChangeEventHandler(Object sender, ClassPropObjectValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения объектного свойства класса методом доступа к БД
        /// </summary>
        public event ClassPropObjectValChangeEventHandler ClassPropObjectValChange;
        

        /// <summary>
        ///  Метод вызова события изменения свойства класса
        /// </summary>
        protected virtual void ClassPropObjectValOnChange(ClassPropObjectValChangeEventArgs e)
        {
            ClassPropObjectValChangeEventHandler temp = ClassPropObjectValChange;
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
