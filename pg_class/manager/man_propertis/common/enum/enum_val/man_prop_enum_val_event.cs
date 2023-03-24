using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения элемента перечисления для свойства
        /// </summary>
        public delegate void PropEnumValChangeEventHandler(Object sender, PropEnumValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении перечисления для свойств
        /// </summary>
        public event PropEnumValChangeEventHandler PropEnumValChange;


        /// <summary>
        ///  Метод вызова события изменения перечисления для свойств
        /// </summary>
        protected virtual void PropEnumValOnChange(PropEnumValChangeEventArgs e)
        {
            PropEnumValChangeEventHandler temp = PropEnumValChange;
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
