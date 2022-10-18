using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_classes;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения значения объектного свойства класса
    /// </summary>
    public class PosTempPropObjectValChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PosTempPropObjectValChangeEventArgs(pos_temp_prop_object_val newPosTempPropObjectVal, eAction Action) : base()
        {
            action = Action;
            if (newPosTempPropObjectVal != null)
            {
                pos_temp_prop_object_val = newPosTempPropObjectVal;
                id_pos_temp_prop = newPosTempPropObjectVal.Id_pos_temp_prop;
            }
        }

        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PosTempPropObjectValChangeEventArgs(Int64 Id_pos_temp_prop, eAction Action) : base()
        {
            action = Action;
            id_pos_temp_prop = Id_pos_temp_prop;
        }

        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        pos_temp_prop_object_val pos_temp_prop_object_val;
        Int64 id_pos_temp_prop;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action;}
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public pos_temp_prop_object_val PosTempPropObjectVal { get => pos_temp_prop_object_val; }

        /// <summary>
        /// Идентификатор свойства шаблона
        /// </summary>
        public Int64 Id_PosTempProp { get => id_pos_temp_prop; }
        #endregion
    }
}
