using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_exceptions;

namespace pg_class.pg_classes
{
    public partial class global_prop
    {
        #region ГРУППОВЫЕ ФУНКЦИИ ДЛЯ РАБОТЫ СО СВЯЗАННЫМИ СВОЙСТВАМИ КЛАССОВ

        /// <summary>
        /// Метод переопределяет тэг для всех связанных свойств класса
        /// global_prop_set_tag_class_prop
        /// </summary>
        public global_prop Class_prop_set_tag(String itag)
        {
            return Manager.global_prop_set_tag_class_prop(this, itag);
        }
            #endregion
        }
}
