using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс классов
    /// </summary>
    public partial class log_link : iEntity
    {
        /// <summary>
        /// Идентификатор сущности в БД
        /// </summary>
        public int EntityID
        {
            get
            {
                return 68;
            }
        }

        /// <summary>
        /// Идентификатор сущности в БД
        /// </summary>
        public eEntity EntityEnum
        {
            get
            {
                return eEntity.log_link;
            }
        }

        /// <summary>
        /// Идентификатор сущности в БД
        /// </summary>
        public String EntityKey
        {
            get
            {
                return String.Format("log_link_{0}", id);
            }
        }

        /// <summary>
        /// Класс сущности к классе доступа к данным
        /// </summary>
        public Type EntityType
        {
            get
            {
                return typeof(log_link);
            }
        }

        /// <summary>
        /// Класс сущности к классе доступа к данным
        /// </summary>
        public String EntityTypeName
        {
            get
            {
                return EntityType.FullName;
            }
        }

        entity entity;
        /// <summary>
        /// Сущность БД
        /// </summary>
        public entity Entity()
        {
            if (entity == null)
            {
                entity = Manager.entity_by_id(EntityID);
            }
            return entity;
        }

        /// <summary>
        /// Сущность БД
        /// </summary>
        public Boolean Can_link()
        {
            Boolean Result = false;
            entity ResultE = Entity();
            if (ResultE != null)
            {
                Result = ResultE.Can_link;
            }
            return Result;
        }
    }
}
