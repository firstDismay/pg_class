using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения данных области значений глобального свойства
        /// </summary>
        public delegate void GlobalPropAreaValChangeEventHandler(Object sender, GlobalPropAreaValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении данных области значений глобального свойства
        /// </summary>
        public event GlobalPropAreaValChangeEventHandler GlobalPropAreaValChange;


        /// <summary>
        ///  Метод вызова события изменения данных области значений глобального свойства
        /// </summary>
        protected virtual void GlobalPropAreaValOnChange(GlobalPropAreaValChangeEventArgs e)
        {
            GlobalPropAreaValChangeEventHandler temp = GlobalPropAreaValChange;
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
