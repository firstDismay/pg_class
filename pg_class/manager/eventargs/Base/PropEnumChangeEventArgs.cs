using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_classes;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения перечисления для свойств
    /// </summary>
    public class PropEnumChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PropEnumChangeEventArgs(prop_enum Prop_enum, eAction Action) : base()
        {
            action = Action;
            prop_enum = Prop_enum;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        prop_enum prop_enum;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action;}
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public prop_enum PropEnum { get => prop_enum; }
        #endregion
    }
}
