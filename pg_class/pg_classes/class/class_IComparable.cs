namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс классов
    /// </summary>
    public partial class vclass //: IComparable
    {
        /*/// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Int32 CompareTo(object iEntity)
        {
            Int32 Result = 0;
            if (iEntity == null) return 1;

            vclass otherVclass = iEntity as vclass;
            if (otherVclass != null)
            {
                switch (StorageType)
                {
                    case eStorageType.Active:
                        if (id == otherVclass.Id)
                        {
                            Result = 0;
                        }
                        else
                        {
                            Result = -1;
                        }
                        break;
                    case eStorageType.History:

                        if (id == otherVclass.Id && timestamp == otherVclass.Timestamp)
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
                throw new ArgumentException("Переданная сущность не соответствует сравиниваемой сущности!");
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

            vclass otherVclass = iEntity as vclass;
            if (otherVclass != null)
            {
                switch (StorageType)
                {
                    case eStorageType.Active:
                        if (id == otherVclass.Id)
                        {
                            Result = true;
                        }
                        else
                        {
                            Result = false;
                        }
                        break;
                    case eStorageType.History:

                        if (id == otherVclass.Id && timestamp == otherVclass.Timestamp)
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
                throw new ArgumentException("Переданная сущность не соответствует сравиниваемой сущности!");
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
        public static bool operator == (vclass Entity1, vclass Entity2)
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
        public static bool operator !=(vclass Entity1, vclass Entity2)
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
        }*/


    }
}
