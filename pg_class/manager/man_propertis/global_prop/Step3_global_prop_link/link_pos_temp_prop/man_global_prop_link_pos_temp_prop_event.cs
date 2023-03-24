using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения привязки глобального свойства
        /// </summary>
        public delegate void GlobalPropLinkPosTempPropChangeEventHandler(Object sender, GlobalPropLinkPosTempPropChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении привязки глобального свойства
        /// </summary>
        public event GlobalPropLinkPosTempPropChangeEventHandler GlobalPropLinkPosTempPropChange;


        /// <summary>
        ///  Метод вызова события изменения привязки глобального свойства
        /// </summary>
        protected virtual void GlobalPropLinkPosTempPropOnChange(GlobalPropLinkPosTempPropChangeEventArgs e)
        {
            GlobalPropLinkPosTempPropChangeEventHandler temp = GlobalPropLinkPosTempPropChange;
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
