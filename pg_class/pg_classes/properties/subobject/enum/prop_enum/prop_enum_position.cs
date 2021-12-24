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
        /// Лист позиций по идентификатору перечисления
        /// position_by_id_prop_enum
        /// </summary>
        public List<position> Position_using_list_get()
        {
            return Manager.position_by_id_prop_enum(this);
        }
    }
}
