using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_classes;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения значения пользовательского свойства класса
    /// </summary>
    public class PosTempPropUserValChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PosTempPropUserValChangeEventArgs(pos_temp_prop_user_val newPosTempPropUserVal, eAction Action) : base()
        {
            action = Action;
            if (newPosTempPropUserVal != null)
            {
                pos_temp_prop_user_val = newPosTempPropUserVal;
                id_pos_temp_prop = newPosTempPropUserVal.Id_pos_temp_prop;
            }
        }

        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PosTempPropUserValChangeEventArgs(Int64 Id_pos_temp_prop, eAction Action) : base()
        {
            action = Action;
            id_pos_temp_prop = Id_pos_temp_prop;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        pos_temp_prop_user_val pos_temp_prop_user_val;
        Int64 id_pos_temp_prop;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action;}
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public pos_temp_prop_user_val PosTempPropUserVal { get => pos_temp_prop_user_val; }

        /// <summary>
        /// Идентификатор свойства шаблона
        /// </summary>
        public Int64 Id_PosTempProp { get => id_pos_temp_prop; }
        #endregion
    }
}
