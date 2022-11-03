using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using pg_class.pg_classes;

namespace pg_class
{
    public partial class manager
    {
        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ СОРТИРОВКИ ПОЗИЦИЙ

        /// <summary>
        /// Делегат событие применения методов сортировки позиций
        /// </summary>
        public delegate void PositionSortEventHandler(Object sender, PositionChangeEventArgs e);

        /// <summary>
        /// Делегат событие применения методов сортировки позиций
        /// </summary>
        public delegate void PositionRootSortEventHandler(Object sender, ConceptionChangeEventArgs e);

        /// <summary>
        /// Событие применения методов сортировки позиций
        /// </summary>
        public event PositionSortEventHandler PositionSort;

        /// <summary>
        /// Событие применения методов сортировки позиций
        /// </summary>
        public event PositionRootSortEventHandler PositionRootSort;
        

        /// <summary>
        ///  Метод вызова события применения методов сортировки позиций
        /// </summary>
        protected virtual void PositionSortOnChange(PositionChangeEventArgs e)
        {
            PositionSortEventHandler temp = PositionSort;

            if (temp != null)
            {
                temp(this, e);
            }
            //Вызов события журнала
            JournalEventArgs me = new JournalEventArgs(e);
            JournalMessageOnReceived(me);
        }

        /// <summary>
        ///  Метод вызова события применения методов сортировки позиций
        /// </summary>
        protected virtual void PositionSortOnChange(ConceptionChangeEventArgs e)
        {
            PositionRootSortEventHandler temp = PositionRootSort;

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
