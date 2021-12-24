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
        /// Лист позиций по идентификатору элемента перечисления
        /// position_by_id_prop_enum_val
        /// </summary>
        public List<position> Position_using_list_get()
        {
            return Manager.position_by_id_prop_enum_val(this);
        }
    }
}
