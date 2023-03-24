using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс классов
    /// </summary>
    public partial class group : ICloneable
    {

        /// <summary>
        /// Реализация интерфейса ICloneable
        /// </summary>
        public object Clone()
        {
            object result = null;
            result = Manager.group_by_id(id);
            return result;
        }

        /// <summary>
        /// Клонированная сущность БД
        /// </summary>
        public group CloneExt()
        {
            group result = null;
            result = Manager.group_by_id(id); ;
            return result;
        }
    }
}
