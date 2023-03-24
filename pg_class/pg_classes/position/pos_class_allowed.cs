using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class position
    {
        #region МЕТОДЫ ДЛЯ РАБОТЫ С РАЗРЕШЕННЫМИ КЛАССАМИ
        /// <summary>
        /// Лист разрешенных представлений вещественных классов по идентификатору группы
        /// </summary>
        public List<vclass> Class_real_allowed_by_id_group(group Group, Boolean Extended)
        {
            List<vclass> Result = null;

            if (Extended)
            {
                Result = Manager.class_act_real_ext_allowed_by_id_group(Group, this);
            }
            else
            {
                Result = Manager.class_act_real_allowed_by_id_group(Group, this);
            }
            return Result;
        }

        /// <summary>
        /// Лист разрешенных представлений вещественных классов по идентификатору группы
        /// </summary>
        public List<vclass> Class_real_allowed_by_id_group(Int64 Group, Boolean Extended)
        {
            List<vclass> Result = null;

            if (Extended)
            {
                Result = Manager.class_act_real_ext_allowed_by_id_group(Group, this.Id);
            }
            else
            {
                Result = Manager.class_act_real_allowed_by_id_group(Group, this.Id);
            }
            return Result;
        }

        /// <summary>
        /// Лист разрешенных представлений базовых абстрактных классов по идентификатору группы
        /// </summary>
        public List<vclass> Class_base_allowed_by_id_group(group Group, Boolean Extended)
        {
            List<vclass> Result = null;
            if (Extended)
            {
                Result = Manager.class_act_ext_base_allowed_by_id_group(Group, this);
            }
            else
            {
                Result = Manager.class_act_base_allowed_by_id_group(Group, this);
            }
            return Result;
        }
        #endregion
    }
}
