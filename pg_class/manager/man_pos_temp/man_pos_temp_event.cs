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
using System.Windows.Forms;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения шаблона позиции
        /// </summary>
        public delegate void PosTempChangeEventHandler(Object sender, PosTempChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении шаблона позиции методом доступа к БД
        /// </summary>
        public event PosTempChangeEventHandler PosTempChange;
        

        /// <summary>
        ///  Метод вызова события изменения шаблона позиции
        /// </summary>
        protected virtual void PosTempOnChange(PosTempChangeEventArgs e)
        {
            PosTempChangeEventHandler temp = PosTempChange;

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
