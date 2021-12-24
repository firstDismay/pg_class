using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_classes;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения концепций
    /// </summary>
    public class ConceptionChangeEventArgs:EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public ConceptionChangeEventArgs(conception Conception, eAction Action) : base()
        {
            action = Action;
            conception = Conception;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        conception conception;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action;}
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public conception Conception { get => conception;}
        #endregion
    }
}
