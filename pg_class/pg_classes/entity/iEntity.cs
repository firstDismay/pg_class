using System;

namespace pg_class.pg_classes
{
    interface iEntity
    {
        /// <summary>
        /// Идентификатор сущности в БД
        /// </summary>
        int EntityID
        {
            get;
        }

        /// <summary>
        /// Идентификатор сущности в БД
        /// </summary>
        String EntityKey
        {
            get;
        }

        /// <summary>
        /// Сущность БД
        /// </summary>
        entity Entity();

        /// <summary>
        /// Класс сущности как класс доступа к данным
        /// </summary>
        Type EntityType
        {
            get;
        }

        /// <summary>
        /// Перечисление класса сущности
        /// </summary>
        eEntity EntityEnum
        {
            get;
        }

        /// <summary>
        /// Класс сущности к классе доступа к данным
        /// </summary>
        String EntityTypeName
        {
            get;
        }

        /// <summary>
        /// Признак линкуемой сущности
        /// </summary>
        Boolean Can_link();
    }
}
