using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс классов
    /// </summary>
    public partial class object_general : ICloneable
    {

        /// <summary>
        /// Реализация интерфейса ICloneable
        /// </summary>
        public object Clone()
        {
            object result = null;
            result = Manager.object_by_id(id);
            return result;
        }

        /// <summary>
        /// Клонированная сущность БД
        /// </summary>
        public object_general CloneExt()
        {
            object_general result = null;
            result = Manager.object_by_id(id); ;
            return result;
        }
    }
}
