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
        /// Лист внутренних объектов объекта используемых в качестве значений объектных свойств
        /// </summary>
        public List<object_general> Object_inside_list_get(Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_id_object_carrier(this);
            }
            else
            {
                Result = Manager.object_by_id_object_carrier(this);
            }
            return Result;
        }

        /// <summary>
        /// Объект носитель для объектов встроенных в объектные свойства объектов
        /// </summary>
        public object_general Object_parent_get(Boolean Extended = false)
        {
            object_general Result = null;
            if (Extended)
            {
                Result = Manager.object_ext_by_id(id_object_carrier);
            }
            else
            {
                Result = Manager.object_by_id(id_object_carrier);
            }
            return Result;
        }
        #endregion

    }
}
