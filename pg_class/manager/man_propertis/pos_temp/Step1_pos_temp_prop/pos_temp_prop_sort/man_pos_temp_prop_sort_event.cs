using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат событие применения методов сортировки свойств шаблона позиции
        /// </summary>
        public delegate void PosTempPropSortEventHandler(Object sender, PosTempChangeEventArgs e);

        /// <summary>
        /// Событие применения методов сортировки свойств шаблона позиции
        /// </summary>
        public event PosTempPropSortEventHandler PosTempPropSort;


        /// <summary>
        ///  Метод вызова события применения методов сортировки свойств шаблона позиции
        /// </summary>
        protected virtual void PosTempPropSortOnChange(PosTempChangeEventArgs e)
        {
            PosTempPropSortEventHandler temp = PosTempPropSort;

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
