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
        #region ФУНКЦИИ ДЛЯ РАБОТЫ С КЛАССАМИ ПО ДАННЫМ ГЛОБАЛЬНЫХ СВОЙСТВ

        /// <summary>
        ///  Лист активных представлений классов по маске значения глобального свойства
        /// class_act_by_msk_global_prop
        /// </summary>
        public List<vclass> Class_act_by_msk_global_prop(String find_mask, Boolean class_real_only, Boolean Extended = false)
        {
            List<vclass> Result;
            if (Extended)
            {
                Result = Manager.class_act_ext_by_msk_global_prop(this, find_mask, class_real_only);
                
            }
            else
            {
                Result = Manager.class_act_by_msk_global_prop(this, find_mask, class_real_only);
            }
            return Result;

        }

        /// <summary>
        ///  Лист активных представлений классов по маске значения глобального свойства и идентификатора класса рекурсивно
        /// class_act_by_msk_global_prop_from_class
        /// </summary>
        public List<vclass> Class_act_by_msk_global_prop_from_class(String find_mask, Int64 iid_class, Boolean class_real_only, Boolean Extended = false)
        {
            List<vclass> Result;
            if (Extended)
            {
                Result = Manager.class_act_ext_by_msk_global_prop_id_class(id, iid_class, find_mask, class_real_only);
                
            }
            else
            {
                Result = Manager.class_act_by_msk_global_prop_id_class(id, iid_class, find_mask, class_real_only);
            }
            return Result;
        }

        /// <summary>
        ///  Лист активных представлений классов по маске значения глобального свойства и идентификатора класса рекурсивно
        /// class_act_by_msk_global_prop_from_group
        /// </summary>
        public List<vclass> Class_act_by_msk_global_prop_from_group(String find_mask, Int64 iid_group, Boolean class_real_only, Boolean Extended = false)
        {
            List<vclass> Result;
            if (Extended)
            {
                Result = Manager.class_act_ext_by_msk_global_prop_id_group(id, iid_group, find_mask, class_real_only);
                
            }
            else
            {
                Result = Manager.class_act_by_msk_global_prop_id_group(id, iid_group, find_mask, class_real_only);
            }
            return Result;
        }
        #endregion
    }
}
