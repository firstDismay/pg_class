namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс классов
    /// </summary>
    public partial class object_prop //: IComparable
    {
        /*
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Int32 CompareTo(object iEntity)
        {
            Int32 Result = 0;
            if (iEntity == null) return 1;

            object_prop otherObject_prop = iEntity as object_prop;
            if (otherObject_prop != null)
            {
                if (Id_object_carrier == otherObject_prop.Id_object_carrier && Id_class_prop == otherObject_prop.Id_class_prop)
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
                throw new ArgumentException("Переданная сущность не соотвествует сравиниваемой сущности!");
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
                object_prop otherObject_prop = iEntity as object_prop;
                if (otherObject_prop != null)
                {
                    if (Id_object_carrier == otherObject_prop.Id_object_carrier && Id_class_prop == otherObject_prop.Id_class_prop)
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
                    throw new ArgumentException("Переданная сущность не соотвествует сравиниваемой сущности!");
                }
            }
            return Result;
        }

        /// <summary>
        /// Переопределение метода GetHashCode
        /// </summary>
        public override int GetHashCode()
        {
            return Convert.ToInt32(id_class_prop);
        }

        /// <summary>
        /// Оператор равенства сущностей
        /// </summary>
        public static bool operator ==(object_prop Entity1, object_prop Entity2)
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
        public static bool operator !=(object_prop Entity1, object_prop Entity2)
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
        }
        */
        /// <summary>
        /// Уникальный строковый идентификатор
        /// </summary>
    }
}
