using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class global_prop
    {
        #region ОБЪЕКТЫ ПО МАСКЕ ЗНАЧЕНИЯ ГЛОБАЛЬНОГО СВОЙСТВА
        /// <summary>
        ///  Лист объектов по маске значения глобального свойства
        /// object_by_array_prop
        /// </summary>
        public List<object_general> Object_by_prop(PropSearchСondition prop_search_condition, Int64 iid_position = -1, Boolean Extended = false)
        {
            List<object_general> Result;
            prop_search_condition.IdDefinitionProp = -1;
            prop_search_condition.IdGlobalProp = Id;
            if (Extended)
            {
                Result = Manager.object_ext_by_prop(prop_search_condition, iid_position);
            }
            else
            {
                Result = Manager.object_by_prop(prop_search_condition, iid_position);
            }
            return Result;
        }
        #endregion
    }
}
