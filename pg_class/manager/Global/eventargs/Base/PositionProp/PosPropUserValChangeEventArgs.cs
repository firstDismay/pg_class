using pg_class.pg_classes;
using System;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения значения пользовательского свойства позиции
    /// </summary>
    public class PositionPropUserValChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PositionPropUserValChangeEventArgs(position_prop_user_val PositionPropUserVal, eAction Action) : base()
        {
            action = Action;
            if (PositionPropUserVal != null)
            {
                position_prop_user_val = PositionPropUserVal;
                id_pos_temp_prop = PositionPropUserVal.Id_pos_temp_prop;
                id_position_carrier = PositionPropUserVal.Id_position_carrier;
            }
        }

        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PositionPropUserValChangeEventArgs(Int64 Id_ObjectCarrier, Int64 Id_CLassProp, eAction Action) : base()
        {
            action = Action;
            id_pos_temp_prop = Id_CLassProp;
            id_position_carrier = Id_ObjectCarrier;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        position_prop_user_val position_prop_user_val;
        Int64 id_pos_temp_prop;
        Int64 id_position_carrier;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }
        /// <summary>
        /// Данные значения свойства подвергшийся модификации
        /// </summary>
        public position_prop_user_val PositionPropUserVal { get => position_prop_user_val; }

        /// <summary>
        /// Идентификатор свойства шаблона позиции
        /// </summary>
        public Int64 Id_pos_temp_prop { get => id_pos_temp_prop; }

        /// <summary>
        /// Идентификатор свойства позиции 
        /// </summary>
        public Int64 Id_position_prop { get => id_pos_temp_prop; }

        /// <summary>
        /// Идентификатор позиции носителя свойства
        /// </summary>
        public Int64 Id_position_carrier { get => id_position_carrier; }
        #endregion
    }
}
