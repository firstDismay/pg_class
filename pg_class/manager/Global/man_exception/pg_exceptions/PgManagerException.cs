using System;

namespace pg_class.pg_exceptions
{
    /// <summary>
    /// Класс определяющий общие исключения менеджера данных
    /// </summary>
    public class PgManagerException : ArgumentException
    {
        private Int32 errorid;
        /// <summary>
        /// Код ошибки
        /// </summary>
        public Int32 ErrorID
        {
            get { return errorid; }
        }
        private String errordesc;
        /// <summary>
        /// Описание ошибки
        /// </summary>
        public String ErrorDesc
        {
            get { return errordesc; }
        }

        private String originalmessage;
        /// <summary>
        /// Сообщение исходного иключения
        /// </summary>
        public String OriginalMessage
        {
            get { return originalmessage; }
        }

        /// <summary>
        /// Конструтор исключения журнала ДЗ
        /// </summary>
        public PgManagerException(Int32 ErrorID, String ErrorDesc, String OriginalMessage) : base(ErrorDesc)
        {
            //Генерируем событие изменения состояния менеджера данных
            ManagerStateChangeEventArgs e2 = new ManagerStateChangeEventArgs(eEntity.manager, eManagerState.Disconnected);
            manager.OnManagerStateChange(e2);
            errorid = ErrorID;
            errordesc = ErrorDesc;
            originalmessage = OriginalMessage;
        }
    }
}
