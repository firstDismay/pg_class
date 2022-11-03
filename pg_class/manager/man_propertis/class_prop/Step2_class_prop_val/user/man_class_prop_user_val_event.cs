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
        /// Делегат события изменения данных значения пользовательского свойства класса
        /// </summary>
        public delegate void ClassPropUserValChangeEventHandler(Object sender, ClassPropUserValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения пользовательского свойства класса методом доступа к БД
        /// </summary>
        public event ClassPropUserValChangeEventHandler ClassPropUserValChange;
        

        /// <summary>
        ///  Метод вызова события изменения данных значения пользовательского свойства класса
        /// </summary>
        protected virtual void ClassPropUserValOnChange(ClassPropUserValChangeEventArgs e)
        {
            ClassPropUserValChangeEventHandler temp = ClassPropUserValChange;
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
