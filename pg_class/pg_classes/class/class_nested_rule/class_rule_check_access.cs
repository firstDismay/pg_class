using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial class vclass
    {
        #region МЕТОДЫ ПРОВЕРКИ РАЗРЕШЕНИЙ

        /// <summary>
        /// Метод определяет наличие разрешения RL1 класс на шаблон для переданной пары
        /// </summary>
        public Boolean rulel1_class_on_pos_temp_check_access(pos_temp Pos_temp)
        {
            return Manager.rulel1_class_on_pos_temp_check_access(Pos_temp.Id, this.Id);
        }

        /// <summary>
        /// Метод определяет наличие разрешения RL1 группа на шаблон для переданной пары
        /// </summary>
        public Boolean rulel1_group_on_pos_temp_check_access(pos_temp Pos_temp)
        {
            return Manager.rulel1_group_on_pos_temp_check_access(Pos_temp.Id, this.Id_group);
        }

        /// <summary>
        /// Метод определяет наличие разрешения RL2 класс на позицию для переданной пары
        /// </summary>
        public Boolean rulel2_class_on_position_check_access(position Position)
        {
            return Manager.rulel2_class_on_position_check_access(Position, this);
        }
        #endregion
    }
}
