using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс обобщенного представления объектов
    /// </summary>
    public partial class object_general
    {

        #region МЕТОДЫ РАБОТЫ C ПРАВИЛАМИ ВЛОЖЕННОСТИ УРОВНЯ 2 КЛАСС НА ПОЗИЦИЮ

        #region ВЫБРАТЬ
        /// <summary>
        /// Правило уровня 2 класс на позицию по идентификатору правила
        /// </summary>
        public rulel2_class_on_position RuleL2_class_on_position
        {
            get
            {
                return Manager.Rulel2_class_on_position_by_id(this);
            }
        }

        /// <summary>
        /// Историческое правило уровня 2 класс на позицию по идентификатору правила
        /// </summary>
        public rulel2_class_snapshot_on_position RuleL2_class_snapshot_on_position
        {
            get
            {
                return Manager.Rulel2_class_snapshot_on_position_by_id(this);
            }
        }
        #endregion
        #endregion
    }
}
