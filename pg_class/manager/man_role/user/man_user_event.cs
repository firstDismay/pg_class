using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения пользователя
        /// </summary>
        public delegate void UserChangeEventHandler(Object sender, UserChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении пользователя методом доступа к БД
        /// </summary>
        public event UserChangeEventHandler UserChange;


        /// <summary>
        ///  Метод вызова события изменения пользователя
        /// </summary>
        protected virtual void UserOnChange(UserChangeEventArgs e)
        {
            UserChangeEventHandler temp = UserChange;

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
