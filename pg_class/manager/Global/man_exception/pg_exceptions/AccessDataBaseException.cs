using System;

namespace pg_class.pg_exceptions
{
    /// <summary>
    /// Исключение доступа к методам БД
    /// </summary>
    public class AccessDataBaseException : ArgumentException
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

        /// <summary>
        /// Конструтор исключения журнала ДЗ
        /// </summary>
        public AccessDataBaseException(Int32 ErrorID, String ErrorDesc) : base(ErrorDesc)
        {
            errorid = ErrorID;
            errordesc = ErrorDesc;
        }

    }
}

