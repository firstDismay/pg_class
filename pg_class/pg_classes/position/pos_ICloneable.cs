using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс классов
    /// </summary>
    public partial class position : ICloneable
    {

        /// <summary>
        /// Реализация интерфейса ICloneable
        /// </summary>
        public object Clone()
        {
            object result = null;
            result = Manager.position_by_id(id);
            return result;
        }

        /// <summary>
        /// Клонированная сущность БД
        /// </summary>
        public position CloneExt()
        {
            position result = null;
            result = Manager.position_by_id(id);
            return result;
        }
    }
}
