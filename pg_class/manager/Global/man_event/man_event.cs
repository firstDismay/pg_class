using System;

namespace pg_class
{
    public partial class manager
    {
        #region СОБЫТИЕ ИЗМЕНЕНИЯ СОСТОЯНИЯ МЕНЕДЖЕРА ДАННЫХ

        /// <summary>
        /// Делегат события изменения состояния менеджера
        /// </summary>

        public delegate void ManagerStateChangeEventHandler(Object sender, ManagerStateChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении состояния менеджера
        /// </summary>
        public static event ManagerStateChangeEventHandler ManagerStateChange;


        /// <summary>
        ///  Метод вызова события изменения состояния менеджера
        /// </summary>
        internal static void OnManagerStateChange(ManagerStateChangeEventArgs e)
        {
            ManagerStateChangeEventHandler temp = ManagerStateChange;

            if (temp != null)
            {
                temp(Me, e);
            }
        }
        #endregion

        #region СОБЫТИЕ ОПОВЕЩЕНИЯ ЖУРНАЛА МЕНЕДЖЕРА 

        /// <summary>
        /// Делегат события возникновения сообщения журнала
        /// </summary>
        public delegate void JournalMessageEventHandler(Object sender, JournalEventArgs e);

        /// <summary>
        /// Событие возникает при появлении события журнала менеджера
        /// </summary>
        public static event JournalMessageEventHandler JournalMessageReceived;


        /// <summary>
        ///  Метод вызова события журнала менеджера
        /// </summary>
        protected virtual void JournalMessageOnReceived(JournalEventArgs e)
        {
            //Генерируем событие
            JournalMessageEventHandler temp = JournalMessageReceived;
            if (temp != null)
            {
                temp(this, e);
            }
        }

        /// <summary>
        ///  Метод вызова события журнала менеджера
        /// </summary>
        internal static void JournalMessageOnReceivedStatic(Object sender, JournalEventArgs e)
        {
            //Генерируем событие
            JournalMessageEventHandler temp = JournalMessageReceived;
            if (temp != null)
            {
                temp(sender, e);
            }
        }
        #endregion

        #region СОБЫТИЕ ИЗМЕНЕНИЯ КОЛИЧЕСТВА ПОДКЛЮЧЕНИЙ В ПУЛЕ СОЕДИНЕИЙ

        /// <summary>
        /// Делегат события количества подключений пула
        /// </summary>
        public delegate void PoolConnectCountChangeEventHandler(Object sender, PoolConnectEventArgs e);

        /// <summary>
        /// Событие изменения количества подключений пула
        /// </summary>
        public static event PoolConnectCountChangeEventHandler PoolConnectCountChange;


        /// <summary>
        ///  Метод вызова события изменения количества подключений пула
        /// </summary>
        protected virtual void PoolConnectCountOnChange(PoolConnectEventArgs e)
        {
            //Генерируем событие
            PoolConnectCountChangeEventHandler temp = PoolConnectCountChange;
            if (temp != null)
            {
                temp(this, e);
            }

        }

        /// <summary>
        ///  Статический метод вызова события изменения количества подключений пула
        /// </summary>
        internal static void PoolConnectCountOnChangeStatic(Object sender, PoolConnectEventArgs e)
        {
            //Генерируем событие
            PoolConnectCountChangeEventHandler temp = PoolConnectCountChange;
            if (temp != null)
            {
                temp(sender, e);
            }
        }
        #endregion

    }
}
