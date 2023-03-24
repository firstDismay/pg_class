using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения ссылки планового диапазона
        /// </summary>
        public delegate void PlanRangeLinkChangeEventHandler(Object sender, PlanRangeLinkChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении ссылки плана методом доступа к БД
        /// </summary>
        public event PlanRangeLinkChangeEventHandler PlanRangeLinkChange;


        /// <summary>
        ///  Метод вызова события изменения ссылки плана
        /// </summary>
        protected virtual void PlanRangeLinkOnChange(PlanRangeLinkChangeEventArgs e)
        {
            PlanRangeLinkChangeEventHandler temp = PlanRangeLinkChange;
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
