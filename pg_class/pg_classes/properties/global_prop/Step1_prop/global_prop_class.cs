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
        /// Лист представлений классов использующих глобальное свойство
        /// </summary>
        public List<vclass> Class_using_list_get(Boolean Extended = false)
        {
            List<vclass> Result = null;
            if (Extended)
            {
                Result = Manager.class_act_ext_by_id_global_prop(this);
            }
            else
            {
                Result = Manager.class_act_by_id_global_prop(this);
            }
            return Result;
        }
        #endregion
    }
}
