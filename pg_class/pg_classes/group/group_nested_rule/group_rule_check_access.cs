using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial class group
    {
        #region МЕТОДЫ ПРОВЕРКИ РАЗРЕШЕНИЙ

        /// <summary>
        /// Метод определяет наличие разрешения RL1 группа на шаблон для переданной пары
        /// </summary>
        public Boolean rulel1_group_on_pos_temp_check_access(pos_temp Pos_temp)
        {
            return Manager.rulel1_group_on_pos_temp_check_access(Pos_temp.Id, this.Id);
        }
        
        #endregion
    }
}
