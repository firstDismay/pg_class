using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_classes;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения значения свойства-перечисления позиции
    /// </summary>
    public class PositionPropEnumValChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PositionPropEnumValChangeEventArgs(position_prop_enum_val PositionPropEnumVal, eAction Action) : base()
        {
            action = Action;
            if (PositionPropEnumVal != null)
            {
                position_prop_enum_val = PositionPropEnumVal;
                id_pos_temp_prop = PositionPropEnumVal.Id_pos_temp_prop;
                id_position_carrier = PositionPropEnumVal.Id_position_carrier;
            }
        }

        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PositionPropEnumValChangeEventArgs(Int64 Id_ObjectCarrier, Int64  Id_CLassProp, eAction Action) : base()
        {
            action = Action;
            id_pos_temp_prop = Id_CLassProp;
            id_position_carrier = Id_ObjectCarrier;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        position_prop_enum_val position_prop_enum_val;
        Int64 id_pos_temp_prop;
        Int64 id_position_carrier;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action;}
        /// <summary>
        /// Данные значения свойства подвергшийся модификации
        /// </summary>
        public position_prop_enum_val PositionPropEnumVal { get => position_prop_enum_val; }

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
