using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_classes;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения объекта
    /// </summary>
    public class ObjectChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public ObjectChangeEventArgs(object_general Vobject, eAction Action) : base()
        {
            action = Action;
            if (Vobject != null)
            {
                vobject = Vobject;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        object_general vobject;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action;}
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public object_general Object_general { get => vobject; }
        #endregion
    }
}
