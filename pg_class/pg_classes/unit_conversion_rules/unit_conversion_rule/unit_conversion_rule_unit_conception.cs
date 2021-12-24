using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial class unit_conversion_rule
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ИЗМЕРЯЕМОЙ ВЕЛИЧИНОЙ ПРАВИЛА ПЕРЕСЧЕТА
        
        /// <summary>
        /// Измеряемая величина правила пересчета
        /// </summary>
        public unit_conception Unit_conception
        {
            get
            {
                return Manager.unit_conception_by_id(Id_unit, id_conception);
            }
        }
        #endregion

    }
}
