using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_classes;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения сущности
    /// </summary>
    public class ObjectPropChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public ObjectPropChangeEventArgs(object_prop ObjectProp, eAction Action) : base()
        {
            action = Action;
            if (ObjectProp != null)
            {
                object_prop = ObjectProp;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        object_prop object_prop;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action;}
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public object_prop ObjectProp { get => object_prop; }
        #endregion
    }
}
