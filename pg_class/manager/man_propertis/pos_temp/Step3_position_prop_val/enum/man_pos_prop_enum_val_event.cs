using System;

namespace pg_class
{

    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения значения свойства позиции типа перечисление
        /// </summary>
        public delegate void PositionPropEnumValChangeEventHandler(Object sender, PositionPropEnumValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения свойства позиции типа перечисление
        /// </summary>
        public event PositionPropEnumValChangeEventHandler PositionPropEnumValChange;


        /// <summary>
        ///  Метод вызова события изменения значения свойства позиции
        /// </summary>
        protected virtual void PositionPropEnumValOnChange(PositionPropEnumValChangeEventArgs e)
        {
            PositionPropEnumValChangeEventHandler temp = PositionPropEnumValChange;
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
