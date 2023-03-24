﻿using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения данных значения свойства класса типа ссылка
        /// </summary>
        public delegate void ClassPropLinkValChangeEventHandler(Object sender, ClassPropLinkValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении данных значения свойства класса типа ссылка
        /// </summary>
        public event ClassPropLinkValChangeEventHandler ClassPropLinkValChange;


        /// <summary>
        ///  Метод вызова события изменения ссылки для свойств
        /// </summary>
        protected virtual void ClassPropLinkValOnChange(ClassPropLinkValChangeEventArgs e)
        {
            ClassPropLinkValChangeEventHandler temp = ClassPropLinkValChange;
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
