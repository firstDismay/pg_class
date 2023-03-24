using System;

namespace pg_class
{

    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения значения свойства объекта типа перечисление
        /// </summary>
        public delegate void ObjectPropEnumValChangeEventHandler(Object sender, ObjectPropEnumValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения свойства объекта типа перечисление
        /// </summary>
        public event ObjectPropEnumValChangeEventHandler ObjectPropEnumValChange;


        /// <summary>
        ///  Метод вызова события изменения значения свойства объекта 
        /// </summary>
        protected virtual void ObjectPropEnumValOnChange(ObjectPropEnumValChangeEventArgs e)
        {
            ObjectPropEnumValChangeEventHandler temp = ObjectPropEnumValChange;
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
