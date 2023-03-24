using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения группы
        /// </summary>
        public delegate void GroupChangeEventHandler(Object sender, GroupChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении группы методом доступа к БД
        /// </summary>
        public event GroupChangeEventHandler GroupChange;


        /// <summary>
        ///  Метод вызова события изменения группы
        /// </summary>
        protected virtual void GroupOnChange(GroupChangeEventArgs e)
        {
            GroupChangeEventHandler temp = GroupChange;
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
