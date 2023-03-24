using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения состояния менеджера данных
    /// </summary>
    public class ManagerStateChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public ManagerStateChangeEventArgs(eEntity Entity, eManagerState ManagerState) : base()
        {
            entity = Entity;
            managerstate = ManagerState;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eEntity entity;
        /// <summary>
        /// Перечисление определяющее сущность вызвавшую исключение
        /// </summary>
        public eEntity Entity { get => entity; }

        eManagerState managerstate;
        /// <summary>
        /// Перечисление определяющее состояние менеджера данных
        /// </summary>
        public eManagerState ManagerState { get => managerstate; }

        #endregion
    }
}
