using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial class object_general
    {
        /// <summary>
        /// Лист объектов класса с учетом штампа времени
        /// </summary>
        public List<object_general> Object_same_list_get(Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_id_class_snapshot(this);
            }
            else
            {
                Result = Manager.object_by_id_class_snapshot(this);
            }
            return Result;
        }

        /// <summary>
        /// Лист всех объектов класса без учета штампа времени
        /// </summary>
        public List<object_general> Object_same_list_full_get(Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_id_class_full(this);
            }
            else
            {
                Result = Manager.object_by_id_class_full(this);
            }
            return Result;
        }
    }
}
