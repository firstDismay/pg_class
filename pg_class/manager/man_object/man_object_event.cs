using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения объектов
        /// </summary>
        public delegate void ObjectChangeEventHandler(Object sender, ObjectChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении объекта методом доступа к БД
        /// </summary>
        public event ObjectChangeEventHandler ObjectChange;


        /// <summary>
        ///  Метод вызова события изменения объекта
        /// </summary>
        protected virtual void ObjectOnChange(ObjectChangeEventArgs e)
        {
            ObjectChangeEventHandler temp = ObjectChange;
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
