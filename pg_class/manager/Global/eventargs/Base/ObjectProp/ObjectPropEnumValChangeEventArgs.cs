using pg_class.pg_classes;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения данных свойства объекта типа перечисление
    /// </summary>
    public class ObjectPropEnumValChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public ObjectPropEnumValChangeEventArgs(object_prop_enum_val Object_prop_enum_val, eAction Action) : base()
        {
            action = Action;
            if (Object_prop_enum_val != null)
            {
                object_prop_enum_val = Object_prop_enum_val;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        object_prop_enum_val object_prop_enum_val;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public object_prop_enum_val ObjectPropEnumVal { get => object_prop_enum_val; }

        /// <summary>
        /// Идентификатор объекта носителя свойства
        /// </summary>
        public Int64 Id_object_carrier { get => ObjectPropEnumVal.Id_object; }

        /// <summary>
        /// Идентификатор класса носителя свойства
        /// </summary>
        public Int64 Id_class { get => ObjectPropEnumVal.Id_class; }


        /// <summary>
        /// Штамп времени класса носителя свойства
        /// </summary>
        public DateTime Timestamp_class { get => ObjectPropEnumVal.Timestamp_class; }

        /// <summary>
        /// Идентификатор свойства класса носителя свойства
        /// </summary>
        public Int64 Id_class_prop { get => ObjectPropEnumVal.Id_class_prop; }
        #endregion
    }
}
