using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial class position
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ПОЗИЦИЯМИ

        /// <summary>
        /// Лист разрешенных групп на основе разрешения уровня 1 группа на шаблон по идентификатору позиции
        /// </summary>
        public List<group> Group_allowed_list
        {
            get
            {
                return Manager.group_allowed_rl1_by_id_position(this);
            }
        }
        #endregion
    }
}
