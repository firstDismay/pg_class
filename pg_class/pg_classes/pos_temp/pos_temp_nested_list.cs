using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс шаблонов позиций
    /// </summary>
    public partial class pos_temp
    {
        #region ЛИСТ ШАБЛОНОВ ПОЗИЦИЙ

        /// <summary>
        /// Метод возвращает Лист шаблонов позиций доступных к вложению в текущий шаблон
        /// </summary>
        public List<pos_temp> Pos_Temp_Nested_List_get(Boolean ignore_nested_limit)
        {
            return manager.Instance().pos_temp_nestedlist_by_id(this, ignore_nested_limit);
        }
       

       
        /// <summary>
        /// Метод определяет максимальное количество позиций указанного шаблона доступных к вложению в указанную позицию, 0 без ограничений
        /// </summary>
        public Int32 Pos_Temp_Nested_Limit_max(pos_temp pos_temp_nested)
        {
            return Manager.pos_temp_nested_limit_max(this, pos_temp_nested);
        }

        /// <summary>
        /// Метод возвращает минимальное значение параметра nested_limit_max определяемого по фактическому количеству вложенных позиций 
        /// </summary>
        public Int32 Pos_Temp_Nested_Limit_min(pos_temp pos_temp_nested)
        {
            return Manager.pos_temp_nested_limit_min(this, pos_temp_nested);
        }
        #endregion

        #region БЕЛЫЙ СПИСОК ШАБЛОНОВ ПОЗИЦИИ
        /// <summary>
        /// Метод возвращает Белый список шаблонов позиций
        /// </summary>
        public List<pos_temp> Pos_Temp_White_Nested_List_get()
        {
            return manager.Instance().pos_temp_white_nestedlist_by_id(this);
        }
        #endregion
    }
}
