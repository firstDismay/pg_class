using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_classes;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения данных свойства типа ссылка
    /// </summary>
    public class PosTempPropLinkValChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PosTempPropLinkValChangeEventArgs(pos_temp_prop_link_val newPosTempPropLinkVal, eAction Action) : base()
        {
            action = Action;
            if (newPosTempPropLinkVal != null)
            {
                pos_temp_prop_link_val = newPosTempPropLinkVal;
                id_pos_temp_prop = newPosTempPropLinkVal.Id_pos_temp_prop;
            }
        }

        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public PosTempPropLinkValChangeEventArgs(Int64 Id_pos_temp_prop, eAction Action) : base()
        {
            action = Action;
            id_pos_temp_prop = Id_pos_temp_prop;
        }

        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        pos_temp_prop_link_val pos_temp_prop_link_val;
        Int64 id_pos_temp_prop;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action;}
        /// <summary>
        /// Объект подвергшийся модификации
        /// </summary>
        public pos_temp_prop_link_val PosTempPropLinkVal { get => pos_temp_prop_link_val; }
        #endregion
    }
}
