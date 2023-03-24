using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения значения объектного свойства позиции
        /// </summary>
        public delegate void PositionPropObjectValChangeEventHandler(Object sender, PositionPropObjectValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения объектного свойства позиции
        /// </summary>
        public event PositionPropObjectValChangeEventHandler PositionPropObjectValChange;


        /// <summary>
        ///  Метод вызова события изменения значения свойства позиции
        /// </summary>
        protected virtual void PositionPropObjectValOnChange(PositionPropObjectValChangeEventArgs e)
        {
            PositionPropObjectValChangeEventHandler temp = PositionPropObjectValChange;
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
