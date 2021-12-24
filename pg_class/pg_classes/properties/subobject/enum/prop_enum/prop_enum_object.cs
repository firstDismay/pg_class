using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Data;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс перечислений для свойств типа перечисление
    /// </summary>
    public partial class prop_enum
    {
        /// <summary>
        /// Лист объектов по идентификатору перечисления
        /// object_by_id_prop_enum
        /// </summary>
        public List<object_general> Object_using_get(Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_id_prop_enum(this);
            }
            else
            {
                Result = Manager.object_by_id_prop_enum(this);
            }
            return Result;
        }
    }
}
