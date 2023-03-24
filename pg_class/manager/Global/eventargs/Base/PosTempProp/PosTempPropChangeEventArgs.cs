using pg_class.pg_classes;
using System;
namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения свойств шаблонов позиций
    /// </summary>
    public class PosTempPropChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PosTempPropChangeEventArgs(pos_temp_prop newPosTempProp, eAction Action) : base()
        {
            action = Action;
            if (newPosTempProp != null)
            {
                pos_temp_prop = newPosTempProp;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        pos_temp_prop pos_temp_prop;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public pos_temp_prop PosTempProp { get => pos_temp_prop; }
        #endregion
    }
}
