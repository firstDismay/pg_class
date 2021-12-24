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
    public class GlobalPropChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public GlobalPropChangeEventArgs(global_prop GlobalProp, eAction Action) : base()
        {
            action = Action;
            if (GlobalProp != null)
            {
                global_prop = GlobalProp;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        global_prop global_prop;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action;}
        /// <summary>
        /// Сущность подвергшаяся модификации
        /// </summary>
        public global_prop GlobalProp { get => global_prop; }
        #endregion
    }
}
