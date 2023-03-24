using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения роли пользователя
        /// </summary>
        public delegate void RoleUserChangeEventHandler(Object sender, RoleUserChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении роли пользователя методом доступа к БД
        /// </summary>
        public event RoleUserChangeEventHandler RoleUserChange;


        /// <summary>
        ///  Метод вызова события изменения роли пользователя
        /// </summary>
        protected virtual void RoleUserOnChange(RoleUserChangeEventArgs e)
        {
            RoleUserChangeEventHandler temp = RoleUserChange;
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