using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Делегат события изменения
        /// </summary>
        public delegate void PosTempNestedListChangeEventHandler(Object sender, PosTempNestedListChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении списка ограничения вложенности
        /// </summary>
        public event PosTempNestedListChangeEventHandler PosTempNestedListChange;


        /// <summary>
        ///  Метод вызова события изменения концепции
        /// </summary>
        protected virtual void OnPosTempNestedListChange(PosTempNestedListChangeEventArgs e)
        {
            PosTempNestedListChangeEventHandler temp = this.PosTempNestedListChange;

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
