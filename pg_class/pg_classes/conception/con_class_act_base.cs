using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class conception
    {
        /// <summary>
        /// Метод возвращает список активных базовых классов концепции
        /// class_act_base_by_id_conception
        /// </summary>
        public List<vclass> class_act_base_list_get(Boolean Extended = false)
        {
            List<vclass> Result = null;
            if (Extended)
            {
                Result = Manager.class_act_ext_base_by_id_conception(this);
            }
            else
            {
                Result = Manager.class_act_base_by_id_conception(this);
            }
            return Result;
        }
    }
}
