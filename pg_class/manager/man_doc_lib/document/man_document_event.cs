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
using System.IO;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения атрибутов документа
        /// </summary>
        public delegate void DocumentChangeEventHandler(Object sender, DocumentChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении атрибутов документа методом доступа к БД
        /// </summary>
        public event DocumentChangeEventHandler DocumentChange;
        
        /// <summary>
        ///  Метод вызова события изменения атрибутов документа
        /// </summary>
        protected virtual void DocumentOnChange(DocumentChangeEventArgs e)
        {
            DocumentChangeEventHandler temp = DocumentChange;
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