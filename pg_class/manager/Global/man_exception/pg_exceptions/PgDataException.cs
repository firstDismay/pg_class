using pg_class.pg_classes;
using System;

namespace pg_class.pg_exceptions
{
    /// <summary>
    /// Исключение методов работы с БД
    /// </summary>
    public class PgDataException : ArgumentException
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Конструтор исключения журнала ДЗ для функций версии 2
        /// </summary>
        public PgDataException(eEntity Entity, eAction Action, eSubClass_ErrID SubClass_ErrID, String ErrorDesc) : base(ErrorDesc)
        {
            entity = Entity;
            action = Action;
            subclass_errid = SubClass_ErrID;
            errordesc = ErrorDesc;
            sourceerror = eSourceError.ClassFuncVer2;
        }

        /// <summary>
        /// Конструтор исключения журнала ДЗ для функций версии 1
        /// </summary>
        public PgDataException(Int32 ErrID, String ErrorDesc) : base(ErrorDesc)
        {
            entity = eEntity.entity;
            action = eAction.AnyAction;
            subclass_errid = eSubClass_ErrID.SCE0_Unknown_Error;
            errorid = ErrID;
            errordesc = ErrorDesc;
            sourceerror = eSourceError.ClassFuncVer1;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        private eEntity entity;
        /// <summary>
        /// Сущность операции над которой привели к возникновению исключения
        /// </summary>
        private eEntity Entity
        {
            get { return entity; }
        }


        private eAction action;
        /// <summary>
        /// Действие выполнение которого привело к возникновению исключения
        /// </summary>
        public eAction Action
        {
            get { return action; }
        }

        /// <summary>
        /// Описание действия выполнение которого привело к возникновению исключения
        /// </summary>
        public String ActionDesc
        {
            get
            {
                return manager.ActionDesc(action);
            }
        }

        private eSubClass_ErrID subclass_errid;
        /// <summary>
        /// Код подкласса ошибки
        /// </summary>
        public eSubClass_ErrID SubClass_ErrID
        {
            get { return subclass_errid; }
        }



        /// <summary>
        /// Описание подкласса ошибки
        /// </summary>
        public String SubClass_ErrDesc
        {
            get
            {
                return manager.SubClass_ErrDesc(SubClass_ErrID);
            }
        }



        private Int32 errorid;
        /// <summary>
        /// Полный код ошибки
        /// </summary>
        public Int32 ErrID
        {
            get
            {
                if (SourceError == eSourceError.ClassFuncVer2 || SourceError == eSourceError.ServerFuncVer2)
                {
                    errorid = ((Int32)SubClass_ErrID + (Int32)Action + (Int32)Entity_ErrID);
                }
                return errorid;
            }
        }

        /// <summary>
        /// Базовый код ошибки для сущностей БД
        /// </summary>
        public eEntity_ErrID Entity_ErrID
        {
            get { return manager.Entity_To_ErrID(Entity); }
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
        /// Ссылка на менеджера данных
        /// </summary>
        private manager Manager
        {
            get
            {
                return manager.Instance();
            }
        }

        private eSourceError sourceerror;

        /// <summary>
        /// Источник ошибки с учетом версий функций определяемых типом аргумента результата
        /// </summary>
        public eSourceError SourceError
        {
            get
            {
                return sourceerror;
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
