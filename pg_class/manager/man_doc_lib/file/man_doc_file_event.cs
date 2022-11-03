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
        /// Делегат события изменения атрибутов файла документа
        /// </summary>
        public delegate void DocFileChangeEventHandler(Object sender, DocFileChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении атрибутов файла документа методом доступа к БД
        /// </summary>
        public event DocFileChangeEventHandler DocFileChange;
        

        /// <summary>
        ///  Метод вызова события изменения атрибутов файла документа
        /// </summary>
        protected virtual void DocFileOnChange(DocFileChangeEventArgs e)
        {
            DocFileChangeEventHandler temp = DocFileChange;
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
