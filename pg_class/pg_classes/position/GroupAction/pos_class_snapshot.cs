using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial class position
    {
        /// <summary>
        /// Лист исторических представлений базовых классов позиции носителя объектов
        /// </summary>
        public List<vclass> Class_snapshot_base_list_get(Boolean Extended = false, Boolean On_internal = false)
        {
            List<vclass> Result = null;
            if (Extended)
            {
                Result = Manager.class_snapshot_base_ext_by_id_position(this, On_internal);
            }
            else
            {
                Result = Manager.class_snapshot_base_by_id_position(this, On_internal);
            }
            return Result;
        }
    }
}
