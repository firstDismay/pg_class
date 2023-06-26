namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс классов
    /// </summary>
    public partial class object_general //: IComparable
    {
        /*
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Int32 CompareTo(object iEntity)
        {
            Int32 Result = 0;
            if (iEntity == null)
            {
                Result = 1;
            }
            else
            {
                object_general otherObject = iEntity as object_general;
                if (otherObject != null)
                {
                    if (Id == otherObject.Id)
                    {
                        Result = 0;
                    }
                    else
                    {
                        Result = -1;
                    }
                }
                else
                {
                    throw new ArgumentException("Переданная сущность не соответствует сравиниваемой сущности!");
                }
            }
            return Result;
        }

        /// <summary>
        /// Переопределение метода сравнения сущностей
        /// </summary>
        public override bool Equals(object iEntity)
        {
            Boolean Result = true;
            if (iEntity == null)
            {
                Result = false;
            }
            else
            {
                object_general otherObject = iEntity as object_general;
                if (otherObject != null)
                {
                    if (Id == otherObject.Id)
                    {
                        Result = true;
                    }
                    else
                    {
                        Result = false;
                    }
                }
                else
                {
                    throw new ArgumentException("Переданная сущность не соответствует сравиниваемой сущности!");
                }
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
        public static bool operator ==(object_general Entity1, object_general Entity2)
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
        public static bool operator !=(object_general Entity1, object_general Entity2)
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
