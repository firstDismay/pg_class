using pg_class.pg_classes;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения значения объектного свойства объекта
    /// </summary>
    public class ObjectPropObjectValChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public ObjectPropObjectValChangeEventArgs(object_prop_object_val ObjectPropObjectVal, eAction Action) : base()
        {
            action = Action;
            if (ObjectPropObjectVal != null)
            {
                object_prop_object_val = ObjectPropObjectVal;
                id_class_prop = ObjectPropObjectVal.Id_object_prop;
                id_object_carrier = ObjectPropObjectVal.Id_object_carrier;
            }
        }

        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public ObjectPropObjectValChangeEventArgs(Int64 Id_ObjectCarrier, Int64 Id_CLassProp, eAction Action) : base()
        {
            action = Action;
            id_class_prop = Id_CLassProp;
            id_object_carrier = Id_ObjectCarrier;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        object_prop_object_val object_prop_object_val;
        Int64 id_class_prop;
        Int64 id_object_carrier;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public object_prop_object_val ObjectPropObjectVal { get => object_prop_object_val; }

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
