namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс классов
    /// </summary>
    public partial class class_prop // : IComparable
    {
        /*
        /// <summary>
        /// 
        /// </summary>
        public Int32 CompareTo(object iEntity)
        {
            Int32 Result = 0;
            if (iEntity == null) return 1;

            class_prop otherVclass_prop = iEntity as class_prop;
            if (otherVclass_prop != null)
            {
                switch (StorageType)
                {
                    case eStorageType.Active:
                        if (id == otherVclass_prop.Id)
                        {
                            Result = 0;
                        }
                        else
                        {
                            Result = -1;
                        }
                        break;
                    case eStorageType.History:

                        if (id == otherVclass_prop.Id && timestamp_class == otherVclass_prop.Timestamp_class)
                        {
                            Result = 0;
                        }
                        else
                        {
                            Result = -1;
                        }
                        break;
                }
            }
            else
            {
                throw new ArgumentException("Сущность не является классом!");
            }
            return Result;
        }

        /// <summary>
        /// Переопределение метода сравнения сущностей
        /// </summary>
        public override bool Equals(object iEntity)
        {
            Boolean Result = false;
            if (iEntity == null) return false;

            class_prop otherVclass_prop = iEntity as class_prop;
            if (otherVclass_prop != null)
            {
                switch (StorageType)
                {
                    case eStorageType.Active:
                        if (id == otherVclass_prop.Id)
                        {
                            Result = true;
                        }
                        else
                        {
                            Result = false;
                        }
                        break;
                    case eStorageType.History:

                        if (id == otherVclass_prop.Id && timestamp_class == otherVclass_prop.Timestamp_class)
                        {
                            Result = true;
                        }
                        else
                        {
                            Result = false;
                        }
                        break;
                }
            }
            else
            {
                throw new ArgumentException("Переданная сущность не соотвествует сравиниваемой сущности!");
            }
            return Result;
        }

        /// <summary>
        /// Переопределение метода GetHashCode
        /// </summary>
        public override int GetHashCode()
        {
            return Convert.ToInt32(id);
        }

        /// <summary>
        /// Оператор равенства сущностей
        /// </summary>
        public static bool operator ==(class_prop Entity1, class_prop Entity2)
        {
            Boolean Result = false;
            if ((object)Entity1 == null || (object)Entity2 == null)
            {
                Result = false;
            }
            else
            {
                Result = Entity1.Equals(Entity2);
            }
            return Result;
        }

        /// <summary>
        /// Оператор неравенства сущностей
        /// </summary>
        public static bool operator !=(class_prop Entity1, class_prop Entity2)
        {
            Boolean Result = false;
            if ((object)Entity1 == null || (object)Entity2 == null)
            {
                Result = true;
            }
            else
            {
                Result = Entity1.Equals(Entity2);
            }
            return Result;
        } */


        /// <summary>
        /// Уникальный строковый идентификатор позиции
        /// </summary>

    }
}
