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
        #region СВОЙСТВА ДЛЯ РАБОТЫ С НАСЛЕДУЮЩИМИ ПРЕДСТАВЛЕНИЯМИ КЛАССОВ

        /// <summary>
        /// Лист представлений объектов ссылающихся на указанный объект, разрешение обратных ссылок
        /// object_ext_by_link_object
        /// </summary>
        public List<object_general> Object_by_link_object_list_get(Boolean on_recursive, Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_link_object(this, on_recursive);
            }
            else
            {
                Result = Manager.object_by_link_object(this, on_recursive);
            }
            return Result;
        }
        #endregion

    }
}
