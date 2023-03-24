using System;

namespace pg_class
{
    public partial class manager
    {
        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ ПРОЦЕДУР ЭКСПОРТА

        /// <summary>
        /// Делегат события завершения процедуры экспорта
        /// </summary>
        public delegate void ExportCompletedEventHandler(Object sender, ExportCompletedEventArgs e);

        /// <summary>
        /// Событие возникает при на выходе из процедуры экспорта, ДО ВЫХОДА ИЗ ПРОЦЕДУРЫ
        /// Для получения доступа к результирующему массиву необходимо использовать аргумент события поле ByteArray
        /// </summary>
        public event ExportCompletedEventHandler ExportCompleted;


        /// <summary>
        ///  Метод вызова события завершения процедуры экспорта
        /// </summary>
        internal virtual void ExportOnCompleted(ExportCompletedEventArgs e)
        {
            ExportCompletedEventHandler temp = ExportCompleted;
            if (temp != null)
            {
                temp(this, e);
            }
            //Вызов события журнала
            JournalEventArgs me = new JournalEventArgs(e);
            JournalMessageOnReceived(me);
        }
        #endregion
    }
}
