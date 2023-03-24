﻿using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс классов
    /// </summary>
    public partial class pos_temp : ICloneable
    {

        /// <summary>
        /// Реализация интерфейса ICloneable
        /// </summary>
        public object Clone()
        {
            object result = null;
            result = Manager.pos_temp_by_id(id);
            return result;
        }

        /// <summary>
        /// Клонированная сущность БД
        /// </summary>
        public pos_temp CloneExt()
        {
            pos_temp result = null;
            result = Manager.pos_temp_by_id(id); ;
            return result;
        }
    }
}
