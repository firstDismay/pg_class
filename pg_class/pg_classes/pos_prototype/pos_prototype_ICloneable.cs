using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс классов
    /// </summary>
    public partial class pos_prototype : ICloneable
    {

        /// <summary>
        /// Реализация интерфейса ICloneable
        /// </summary>
        public object Clone()
        {
            object result = null;
            result = Manager.pos_prototype_by_id(id);
            return result;
        }

        /// <summary>
        /// Клонированная сущность БД
        /// </summary>
        public pos_prototype CloneExt()
        {
            pos_prototype result = null;
            result = Manager.pos_prototype_by_id(id); ;
            return result;
        }
    }
}
