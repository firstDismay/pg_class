using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс классов
    /// </summary>
    public partial class vclass : ICloneable
    {

        /// <summary>
        /// Клонированная сущность БД
        /// </summary>
        public object Clone()
        {
            object result = null;

            switch (StorageType)
            {
                case eStorageType.Active:
                    result = Manager.class_act_by_id(id);
                    break;
                case eStorageType.History:
                    result = Manager.class_snapshot_by_id(id, timestamp);
                    break;
            }
            return result;
        }

        /// <summary>
        /// Клонированная сущность БД
        /// </summary>
        public vclass CloneExt()
        {
            vclass result = null;

            switch (StorageType)
            {
                case eStorageType.Active:
                    result = Manager.class_act_by_id(id);
                    break;
                case eStorageType.History:
                    result = Manager.class_snapshot_by_id(id, timestamp);
                    break;
            }
            return result;
        }
    }
}
