using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс прототипов позиций
    /// </summary>
    public partial class pos_prototype
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ШАБЛОНАМИ ПОЗИЦИЙ

        /// <summary>
        /// Лист всех шаблонов позиции по идентификатору прототипа, без учета концепции
        /// </summary>
        public List<pos_temp> Pos_temp_all
        {
            get
            {
                return Manager.pos_temp_by_id_prototype_all(this);
            }
        }
        #endregion
    }
}
