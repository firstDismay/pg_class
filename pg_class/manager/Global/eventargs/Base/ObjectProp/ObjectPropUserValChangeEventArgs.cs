using pg_class.pg_classes;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения значения пользовательского свойства объекта
    /// </summary>
    public class ObjectPropUserValChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public ObjectPropUserValChangeEventArgs(object_prop_user_val ObjectPropUserVal, eAction Action) : base()
        {
            action = Action;
            if (ObjectPropUserVal != null)
            {
                object_prop_user_val = ObjectPropUserVal;
                id_class_prop = ObjectPropUserVal.Id_class_prop;
                id_object_carrier = ObjectPropUserVal.Id_object_carrier;
            }
        }

        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public ObjectPropUserValChangeEventArgs(Int64 Id_ObjectCarrier, Int64 Id_CLassProp, eAction Action) : base()
        {
            action = Action;
            id_class_prop = Id_CLassProp;
            id_object_carrier = Id_ObjectCarrier;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        object_prop_user_val object_prop_user_val;
        Int64 id_class_prop;
        Int64 id_object_carrier;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public object_prop_user_val ObjectPropUserVal { get => object_prop_user_val; }

        /// <summary>
        /// Идентификатор свойства класса
        /// </summary>
        public Int64 Id_class_prop { get => id_class_prop; }

        /// <summary>
        /// Идентификатор свойства объекта
        /// </summary>
        public Int64 Id_object_prop { get => id_class_prop; }

        /// <summary>
        /// Идентификатор объекта носителя свойства
        /// </summary>
        public Int64 Id_object_carrier { get => id_object_carrier; }
        #endregion
    }
}
