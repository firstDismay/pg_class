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
        /// Делегат события изменения категории документа
        /// </summary>
        public delegate void DocCategoryChangeEventHandler(Object sender, DocCategoryChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении категории документа методом доступа к БД
        /// </summary>
        public event DocCategoryChangeEventHandler DocCategoryChange;

        /// <summary>
        ///  Метод вызова события изменения категории документа
        /// </summary>
        protected virtual void DocCategoryOnChange(DocCategoryChangeEventArgs e)
        {
            DocCategoryChangeEventHandler temp = DocCategoryChange;
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