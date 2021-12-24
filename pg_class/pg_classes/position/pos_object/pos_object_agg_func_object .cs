using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial class position
    {
        #region МЕТОДЫ ДЛЯ РАБОТЫ С ОБЪЕКТАМИ
        /// <summary>
        ///  Лист объектов указанной позиции по маске значения глобального свойства
        /// object_by_msk_global_prop_from_pos
        /// </summary>
        public List<object_general> Object_by_msk_global_prop_from_pos(global_prop Global_prop, String find_mask, Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_msk_global_prop_from_pos(Global_prop, this, find_mask);
            }
            else
            {
                Result = Manager.object_by_msk_global_prop_from_pos(Global_prop, this, find_mask);
            }
            return Result;
        }
        #endregion

    }
}
