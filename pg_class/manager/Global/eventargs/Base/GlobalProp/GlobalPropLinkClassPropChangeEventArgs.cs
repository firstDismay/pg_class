using pg_class.pg_classes;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения сущности 
    /// </summary>
    public class GlobalPropLinkClassPropChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public GlobalPropLinkClassPropChangeEventArgs(global_prop_link_class_prop newGlobalPropLinkClassProp, eAction Action) : base()
        {
            action = Action;
            if (newGlobalPropLinkClassProp != null)
            {
                global_prop_link_class_prop = newGlobalPropLinkClassProp;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        global_prop_link_class_prop global_prop_link_class_prop;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Сущность подвергшаяся модификации
        /// </summary>
        public global_prop_link_class_prop GlobalPropLinkClassProp { get => global_prop_link_class_prop; }
        #endregion
    }
}
