using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения ссылки плана
        /// </summary>
        public delegate void PlanLinkChangeEventHandler(Object sender, PlanLinkChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении ссылки плана методом доступа к БД
        /// </summary>
        public event PlanLinkChangeEventHandler PlanLinkChange;

        /// <summary>
        ///  Метод вызова события изменения ссылки плана
        /// </summary>
        protected virtual void PlanLinkOnChange(PlanLinkChangeEventArgs e)
        {
            PlanLinkChangeEventHandler temp = PlanLinkChange;
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