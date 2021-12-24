using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Data;
using pg_class.pg_exceptions;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс глобальных свойств концепции
    /// </summary>
    public partial class global_prop
    {
        #region ВЫБРАТЬ
        /// <summary>
        /// Лист позиций использующих глобальное свойство
        /// position_by_id_global_prop
        /// </summary>
        public List<position> Position_using_list_get(Boolean Extended = false)
        {
            return Manager.position_by_id_global_prop(this); ;
        }
        #endregion
    }
}
