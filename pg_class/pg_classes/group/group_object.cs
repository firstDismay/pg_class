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
    /// Класс групп
    /// </summary>
    public partial class group
    {
        #region МЕТОДЫ РАБОТЫ С ОБЪЕКТАМИ ГРУПП
        /// <summary>
        /// Gриводит все объекты uheggs к активным состояниям классов группы
        /// object_cast_for_class_act_by_id_group
        /// </summary>
        public List<errarg_cast> Object_cast_to_active_state()
        {
            return Manager.object_cast_for_class_act_by_id_group(this);
        }
        #endregion
    }
}
