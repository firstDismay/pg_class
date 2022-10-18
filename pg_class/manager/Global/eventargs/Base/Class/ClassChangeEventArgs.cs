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
    public class ClassChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public ClassChangeEventArgs(vclass Vclass, eAction Action) : base()
        {
            action = Action;
            if (Vclass != null)
            {
                vclass = Vclass;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        vclass vclass;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action;}
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public vclass Vclass { get => vclass; }
        #endregion
    }
}
