using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_classes;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения данных свойства объекта типа ссылка
    /// </summary>
    public class ObjectPropLinkValChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public ObjectPropLinkValChangeEventArgs(object_prop_link_val Object_prop_link_val, eAction Action) : base()
        {
            action = Action;
            if (Object_prop_link_val != null)
            {
                object_prop_link_val = Object_prop_link_val;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        object_prop_link_val object_prop_link_val;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action;}
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public object_prop_link_val ObjectPropLinkVal { get => object_prop_link_val; }

        /// <summary>
        /// Идентификатор объекта носителя свойства
        /// </summary>
        public Int64 Id_object_carrier { get => ObjectPropLinkVal.Id_object; }

        /// <summary>
        /// Идентификатор класса носителя свойства
        /// </summary>
        public Int64 Id_class { get => ObjectPropLinkVal.Id_class; }


        /// <summary>
        /// Штамп времени класса носителя свойства
        /// </summary>
        public DateTime Timestamp_class { get => ObjectPropLinkVal.Timestamp_class; }

        /// <summary>
        /// Идентификатор свойства класса носителя свойства
        /// </summary>
        public Int64 Id_class_prop { get => ObjectPropLinkVal.Id_class_prop; }
        #endregion
    }
}
