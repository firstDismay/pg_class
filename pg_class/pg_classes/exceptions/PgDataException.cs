using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Исключение состояний сущностей БД
    /// </summary>
public class EntityStateException : ArgumentException
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
        /// Основной конструктор исключений сущностей БД
        /// </summary>
        public EntityStateException(Int32 ErrorID, String ErrorDesc) : base(ErrorDesc)
        {
            errorid = ErrorID;
            errordesc = ErrorDesc;
        }
    }
    
}
