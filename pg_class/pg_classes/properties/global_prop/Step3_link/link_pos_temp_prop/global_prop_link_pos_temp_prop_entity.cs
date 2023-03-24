using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс глобальных свойств концепции
    /// </summary>
    public partial class global_prop_link_pos_temp_prop : iEntity
    {
        /// <summary>
        /// Идентификатор сущности в БД
        /// </summary>
        public int EntityID
        {
            get
            {
                return 56;
            }
        }

        /// <summary>
        /// Идентификатор сущности в БД
        /// </summary>
        public eEntity EntityEnum
        {
            get
            {
                return eEntity.global_prop_link_pos_temp_prop;
            }
        }

        /// <summary>
        /// Идентификатор сущности в БД
        /// </summary>
        public String EntityKey
        {
            get
            {
                return String.Format("Global_prop{0}_link_pos_temp_prop{1}", id_global_prop, id_pos_temp_prop);
            }
        }

        /// <summary>
        /// Класс сущности к классе доступа к данным
        /// </summary>
        public Type EntityType
        {
            get
            {
                return typeof(global_prop);
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
