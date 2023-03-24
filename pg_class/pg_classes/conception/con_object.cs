using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class conception
    {

        #region Поисковые методы объекта позиции

        /// <summary>
        /// Лист представлений объектов по шаблону имени объекта в указанной концепции
        /// object_ext_in_conception_find_by_name
        /// </summary>
        public List<object_general> Object_by_name(String name_mask, Boolean on_internal = false, Boolean Extended = false)
        {
            List<object_general> Result = null;
            if (Extended)
            {
                Result = Manager.object_ext_by_name(name_mask, id, on_internal);
            }
            else
            {
                Result = Manager.object_by_name(name_mask, id, on_internal);
            }
            return Result;
        }

        /// <summary>
        /// Лист представлений объектов соотвествующих набору значений глобальных/определяющих свойств (подбор по критериям)
        /// object_by_array_prop
        /// object_ext_by_array_prop
        /// </summary>
        public List<object_general> Object_by_array_prop(PropSearchСondition[] array_prop, Int64 iid_position, Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_array_prop(array_prop, iid_position);
            }
            else
            {
                Result = Manager.object_by_array_prop(array_prop, iid_position);
            }
            return Result;
        }
        #endregion

    }
}
