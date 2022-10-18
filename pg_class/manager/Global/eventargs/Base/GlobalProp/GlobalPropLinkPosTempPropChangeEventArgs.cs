using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_classes;

namespace pg_class
{
    /// <summary>
    /// Аргумент событий изменения сущности 
    /// </summary>
    public class GlobalPropLinkPosTempPropChangeEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА
        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public GlobalPropLinkPosTempPropChangeEventArgs(global_prop_link_pos_temp_prop GlobalPropLinkPosTempProp, eAction Action) : base()
        {
            action = Action;
            if (GlobalPropLinkPosTempProp != null)
            {
                global_prop_link_pos_temp_prop = GlobalPropLinkPosTempProp;
            }
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        eAction action;
        global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action;}
        /// <summary>
        /// Сущность подвергшаяся модификации
        /// </summary>
        public global_prop_link_pos_temp_prop GlobalPropLinkPosTempProp { get => global_prop_link_pos_temp_prop; }
        #endregion
    }
}
