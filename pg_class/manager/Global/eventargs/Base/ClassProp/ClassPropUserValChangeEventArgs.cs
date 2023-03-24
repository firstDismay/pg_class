using pg_class.pg_classes;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения значения пользовательского свойства класса
    /// </summary>
    public class ClassPropUserValChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public ClassPropUserValChangeEventArgs(class_prop_user_val ClassPropUserVal, eAction Action) : base()
        {
            action = Action;
            if (ClassPropUserVal != null)
            {
                class_prop_user_val = ClassPropUserVal;
                id_class_prop = ClassPropUserVal.Id_class_prop;
            }
        }

        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public ClassPropUserValChangeEventArgs(Int64 Id_CLassProp, eAction Action) : base()
        {
            action = Action;
            id_class_prop = Id_CLassProp;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        class_prop_user_val class_prop_user_val;
        Int64 id_class_prop;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public class_prop_user_val ClassPropUserVal { get => class_prop_user_val; }

        /// <summary>
        /// Идентификатор свойства класса
        /// </summary>
        public Int64 Id_Class_Prop { get => id_class_prop; }
        #endregion
    }
}
