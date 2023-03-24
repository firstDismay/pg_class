using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения значения пользовательского свойства объекта
        /// </summary>
        public delegate void ObjectPropUserValChangeEventHandler(Object sender, ObjectPropUserValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения пользовательского свойства объекта
        /// </summary>
        public event ObjectPropUserValChangeEventHandler ObjectPropUserValChange;


        /// <summary>
        ///  Метод вызова события изменения значения свойства объекта
        /// </summary>
        protected virtual void ObjectPropUserValOnChange(ObjectPropUserValChangeEventArgs e)
        {
            ObjectPropUserValChangeEventHandler temp = ObjectPropUserValChange;
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
