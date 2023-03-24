using System;

namespace pg_class
{

    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения значения свойства позиции типа ссылка
        /// </summary>
        public delegate void PositionPropLinkValChangeEventHandler(Object sender, PositionPropLinkValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения свойства позиции типа ссылка
        /// </summary>
        public event PositionPropLinkValChangeEventHandler PositionPropLinkValChange;


        /// <summary>
        ///  Метод вызова события изменения значения свойства позиции
        /// </summary>
        protected virtual void PositionPropLinkValOnChange(PositionPropLinkValChangeEventArgs e)
        {
            PositionPropLinkValChangeEventHandler temp = PositionPropLinkValChange;
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
