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
        /// Лист шаблонов позиций использующих глобальное свойство
        /// </summary>
        public List<pos_temp> Pos_temp_using_list_get(Boolean Extended = false)
        {
            return Manager.pos_temp_by_id_global_prop(this); ;
        }
        #endregion
    }
}
