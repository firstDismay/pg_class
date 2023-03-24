using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения значения объектного свойства объекта
        /// </summary>
        public delegate void ObjectPropObjectValChangeEventHandler(Object sender, ObjectPropObjectValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения объектного свойства объекта
        /// </summary>
        public event ObjectPropObjectValChangeEventHandler ObjectPropObjectValChange;


        /// <summary>
        ///  Метод вызова события изменения значения свойства объекта
        /// </summary>
        protected virtual void ObjectPropObjectValOnChange(ObjectPropObjectValChangeEventArgs e)
        {
            ObjectPropObjectValChangeEventHandler temp = ObjectPropObjectValChange;
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
