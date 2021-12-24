using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using pg_class.pg_exceptions;
using System.Data;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс шаблонов позиций
    /// </summary>
    public partial class pos_temp
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С РАЗРЕШЕННЫМИ ГРУППАМИ

        /// <summary>
        /// Лист разрешенных групп шаблона позиции
        /// </summary>
        public List<group> Group_allowed_list
        {
            get
            {
                return Manager.group_allowed_rl1_by_id_pos_temp(this);
            }
        }
        #endregion
    }
}
