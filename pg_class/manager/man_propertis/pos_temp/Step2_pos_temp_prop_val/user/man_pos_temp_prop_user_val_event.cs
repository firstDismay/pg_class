using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения данных значения пользовательского свойства шаблона
        /// </summary>
        public delegate void PosTempPropUserValChangeEventHandler(Object sender, PosTempPropUserValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения пользовательского свойства шаблона методом доступа к БД
        /// </summary>
        public event PosTempPropUserValChangeEventHandler PosTempPropUserValChange;


        /// <summary>
        ///  Метод вызова события изменения данных значения пользовательского свойства шаблона
        /// </summary>
        protected virtual void PosTempPropUserValOnChange(PosTempPropUserValChangeEventArgs e)
        {
            PosTempPropUserValChangeEventHandler temp = PosTempPropUserValChange;
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
