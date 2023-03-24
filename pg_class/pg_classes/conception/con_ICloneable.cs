using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс классов
    /// </summary>
    public partial class conception : ICloneable
    {

        /// <summary>
        /// Реализация интерфейса ICloneable
        /// </summary>
        public object Clone()
        {
            object result = null;
            result = Manager.conception_by_id(id);
            return result;
        }

        /// <summary>
        /// Клонированная сущность БД
        /// </summary>
        public conception CloneExt()
        {
            conception result = null;
            result = Manager.conception_by_id(id); ;
            return result;
        }
    }
}
