using pg_class.pg_classes;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения данных свойства типа перечисление
    /// </summary>
    public class PosTempPropEnumValChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PosTempPropEnumValChangeEventArgs(pos_temp_prop_enum_val newPosTempPropEnumVal, eAction Action) : base()
        {
            action = Action;
            if (newPosTempPropEnumVal != null)
            {
                pos_temp_prop_enum_val = newPosTempPropEnumVal;
                id_pos_temp_prop = newPosTempPropEnumVal.Id_pos_temp_prop;
            }
        }

        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PosTempPropEnumValChangeEventArgs(Int64 Id_pos_temp_prop, eAction Action) : base()
        {
            action = Action;
            id_pos_temp_prop = Id_pos_temp_prop;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        pos_temp_prop_enum_val pos_temp_prop_enum_val;
        Int64 id_pos_temp_prop;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }

        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public pos_temp_prop_enum_val PosTempPropEnumVal { get => pos_temp_prop_enum_val; }

        /// <summary>
        /// Идентификатор свойства шаблона
        /// </summary>
        public Int64 Id_PosTempProp { get => id_pos_temp_prop; }
        #endregion
    }
}
