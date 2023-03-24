using System;


namespace pg_class
{
    /// <summary>
    /// Аргумент сообщения события изменения количества подключений пула соединений
    /// </summary>
    public class PoolConnectEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        protected PoolConnectEventArgs()
        {
        }


        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PoolConnectEventArgs(Int32 ConnectCurrent, Int32 ConnectMax) : this()
        {
            connectcurent = ConnectCurrent;
            connectmax = ConnectMax;
        }


        #endregion

        #region СВОЙСТВА КЛАССА
        private Int32 connectcurent = 0;
        private Int32 connectmax = 0;



        /// <summary>
        /// Количество подключений текущее
        /// </summary>
        public Int32 ConnectCurent { get => connectcurent; }

        /// <summary>
        /// Количество подключений текущее
        /// </summary>
        public Int32 ConnectMax { get => connectmax; }
        #endregion
    }
}
