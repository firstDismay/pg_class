using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial class pos_temp
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ПОЗИЦИЯМИ ШАБЛОНА ПОЗИЦИИ
 
            /// <summary>
            /// Лист позиций шаблона позиции
            /// </summary>
            public List<position> Pos_inheritance_list
            {
                get
                {
                    return Manager.pos_by_id_pos_temp(this.Id);
                }
            }
        #endregion

        #region МЕТОДЫ РАБОТЫ С ЛИСТАМИ ПРОТОТИПОВ ПОЗИЦИЙ
        /// <summary>
        /// Лист позиций шаблона позиции
        /// </summary>
        public List<position> Pos_inheritance_list_get()
        {
            return Manager.pos_by_id_pos_temp(this);
        }


        /// <summary>
        /// Лист макетов наименований позиций шаблона
        /// </summary>
        public List<String> Position_name_layout_list_get()
        {
            return Manager.position_name_layout_by_id_pos_temp(this);
        }
        #endregion
    }
}
