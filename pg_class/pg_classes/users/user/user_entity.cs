﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Data;
using pg_class.pg_exceptions;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс классов
    /// </summary>
    public partial class user : iEntity
    {
        /// <summary>
        /// Идентификатор сущности в БД
        /// </summary>
        public int EntityID
        {
            get
            {
                return 8;
            }
        }

        /// <summary>
        /// Идентификатор сущности в БД
        /// </summary>
        public eEntity EntityEnum
        {
            get
            {
                return eEntity.user;
            }
        }

        /// <summary>
        /// Идентификатор сущности в БД
        /// </summary>
        public String EntityKey
        {
            get
            {
                return Key;
            }
        }

        /// <summary>
        /// Класс сущности к классе доступа к данным
        /// </summary>
        public Type EntityType
        {
            get
            {
                return typeof(user);
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
