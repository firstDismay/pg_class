using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_exceptions;

namespace pg_class.pg_classes
{
    public partial class global_prop
    {
        #region ОБЪЕКТЫ ПО МАСКЕ ЗНАЧЕНИЯ ГЛОБАЛЬНОГО СВОЙСТВА
        /// <summary>
        ///  Лист объектов по маске значения глобального свойства
        /// object_by_msk_global_prop
        /// </summary>
        public List<object_general> Object_by_msk_global_prop(String find_mask, Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_msk_global_prop(this, find_mask);
            }
            else
            {
                Result = Manager.object_by_msk_global_prop(this, find_mask);
            }
            return Result;

        }

        /// <summary>
        ///  Лист объектов указанной позиции по маске значения глобального свойства
        /// object_by_msk_global_prop_from_pos
        /// </summary>
        public List<object_general> Object_by_msk_global_prop_from_pos(String find_mask, position Position, Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_msk_global_prop_from_pos(this, Position, find_mask);
            }
            else
            {
                Result = Manager.object_by_msk_global_prop_from_pos(this, Position, find_mask);
            }
            return Result;
        }
        #endregion

        #region ОБЪЕКТЫ НОСИТЕЛЯ ПО МАСКЕ ЗНАЧЕНИЯ ГЛОБАЛЬНОГО СВОЙСТВА ОБЪЕКТА ЗНАЧЕНИЯ ОБЪЕКТНОГО СВОЙСТВА
        /// <summary>
        ///  Лист объектов носителей по маске значения глобального свойства объекта значения глобального свойства
        /// object_prop_user_small_agg_func_carrier_find
        /// </summary>
        public List<object_general> Object_carrier_by_msk_global_prop(String find_mask, Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_ext_carrier_by_msk_global_prop(this, find_mask);
            }
            else
            {
                Result = Manager.object_carrier_by_msk_global_prop(this, find_mask);
            }
            return Result;

        }
        #endregion
    }
}
