using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс классов
    /// </summary>
    public partial class class_prop : ICloneable
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
                    result = Manager.class_prop_snapshot_by_id(id, timestamp_class);
                    break;
            }
            return result;
        }

        /// <summary>
        /// Клонированная сущность БД
        /// </summary>
        public class_prop CloneExt()
        {
            class_prop result = null;

            switch (StorageType)
            {
                case eStorageType.Active:
                    result = Manager.class_prop_by_id(id);
                    break;
                case eStorageType.History:
                    result = Manager.class_prop_snapshot_by_id(id, timestamp_class);
                    break;
            }
            return result;
        }
    }
}
