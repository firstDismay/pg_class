using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения данных значения свойства шаблона типа ссылка
        /// </summary>
        public delegate void PosTempPropLinkValChangeEventHandler(Object sender, PosTempPropLinkValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении данных значения свойства шаблона типа ссылка
        /// </summary>
        public event PosTempPropLinkValChangeEventHandler PosTempPropLinkValChange;


        /// <summary>
        ///  Метод вызова события изменения ссылки для свойств
        /// </summary>
        protected virtual void PosTempPropLinkValOnChange(PosTempPropLinkValChangeEventArgs e)
        {
            PosTempPropLinkValChangeEventHandler temp = PosTempPropLinkValChange;
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
