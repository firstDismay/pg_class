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
        /// Делегат события изменения свойства класса
        /// </summary>
        public delegate void ClassPropChangeEventHandler(Object sender, ClassPropChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении свойства класса методом доступа к БД
        /// </summary>
        public event ClassPropChangeEventHandler ClassPropChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения свойства класса
        /// </summary>
        protected virtual void ClassPropOnChange(ClassPropChangeEventArgs e)
        {
            ClassPropChangeEventHandler temp = ClassPropChange;
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
