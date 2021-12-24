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
    /// Класс элементов перечислений для свойств типа перечисление
    /// </summary>
    public partial class prop_enum_val
    {
        /// <summary>
        /// Лист представлений активных классов по идентификатору перечисления
        /// class_act_by_id_prop_enum
        /// </summary>
        public List<vclass> Class_act_get()
        {
            return Manager.class_act_by_id_prop_enum_val(this);
        }

        /// <summary>
        /// Лист снимков классов по идентификатору перечисления
        /// class_snapshot_by_id_prop_enum
        /// </summary>
        public List<vclass> Class_snapshot_get()
        {
            return Manager.class_snapshot_by_id_prop_enum_val(this);
        }
    }
}
