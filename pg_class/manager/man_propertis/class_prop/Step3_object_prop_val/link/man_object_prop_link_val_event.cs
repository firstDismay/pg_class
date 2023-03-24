using System;

namespace pg_class
{

    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения значения свойства объекта типа ссылка
        /// </summary>
        public delegate void ObjectPropLinkValChangeEventHandler(Object sender, ObjectPropLinkValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения свойства объекта типа ссылка
        /// </summary>
        public event ObjectPropLinkValChangeEventHandler ObjectPropLinkValChange;


        /// <summary>
        ///  Метод вызова события изменения значения свойства объекта 
        /// </summary>
        protected virtual void ObjectPropLinkValOnChange(ObjectPropLinkValChangeEventArgs e)
        {
            ObjectPropLinkValChangeEventHandler temp = ObjectPropLinkValChange;
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
