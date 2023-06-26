using pg_class.pg_classes;
using System;
using pg_class.pg_exceptions;

namespace pg_class.pg_exceptions
{
    /// <summary>
    /// Исключение методов работы с БД
    /// </summary>
    public class PgDataException : ArgumentException
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Конструктор исключения журнала ДЗ для функций версии 3
        /// </summary>
        public PgDataException(PgFunctionMessage Message)
        {
            message = Message;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        private PgFunctionMessage message;

        /// <summary>
        /// Класс сообщение функции об ошибке
        /// </summary>
        public PgFunctionMessage MessageFunction
        { 
            get { return message; }
        }

        /// <summary>
        /// Сущность операции над которой привели к возникновению исключения
        /// </summary>
        private eEntity Entity
        {
            get 
            { if (message != null)
                {
                    eEntity result;
                    if (Enum.TryParse(message.entity, out result))
                    { 
                        return result;
                    }
                }
                return eEntity.entity;
            }
        }

        /// <summary>
        /// Действие выполнение которого привело к возникновению исключения
        /// </summary>
        public eAction Action
        {
            get
            {
                if (message != null)
                {
                    eAction result;
                    if (Enum.TryParse(message.actionerr, out result))
                    {
                        return result;
                    }
                }
                return eAction.AnyAction;
            }
        }

        /// <summary>
        /// Описание действия выполнение которого привело к возникновению исключения
        /// </summary>
        public String ActionDesc
        {
            get
            {
                return manager.ActionDesc(Action);
            }
        }

        /// <summary>
        /// Ссылка на менеджера данных
        /// </summary>
        private manager Manager
        {
            get
            {
                return manager.Instance();
            }
        }
        #endregion

        #region МЕТОДЫ КЛАССА
        /// <summary>
        /// Метод возвращает класс сущности связанной с действием вызвавшим исключение
        /// </summary>
        public entity GetEntity()
        {
            return Manager.entity_by_id(Entity);
        }
        #endregion
    }
}
