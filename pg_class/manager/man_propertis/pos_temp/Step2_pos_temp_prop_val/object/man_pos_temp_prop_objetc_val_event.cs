using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения значения свойства класса
        /// </summary>
        public delegate void PosTempPropObjectValChangeEventHandler(Object sender, PosTempPropObjectValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения свойства шаблона
        /// </summary>
        public event PosTempPropObjectValChangeEventHandler PosTempPropObjectValChange;


        /// <summary>
        ///  Метод вызова события изменения свойства шаблона
        /// </summary>
        protected virtual void PosTempPropObjectValOnChange(PosTempPropObjectValChangeEventArgs e)
        {
            PosTempPropObjectValChangeEventHandler temp = PosTempPropObjectValChange;
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
