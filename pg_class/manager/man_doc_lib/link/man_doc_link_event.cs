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
using System.Security.Cryptography;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения ссылки документа
        /// </summary>
        public delegate void DocLinkChangeEventHandler(Object sender, DocLinkChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении ссылки документа методом доступа к БД
        /// </summary>
        public event DocLinkChangeEventHandler DocLinkChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения атрибутов файла документа
        /// </summary>
        protected virtual void DocLinkOnChange(DocLinkChangeEventArgs e)
        {
            DocLinkChangeEventHandler temp = DocLinkChange;
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
