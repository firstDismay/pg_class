using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class conception
    {
        /// <summary>
        /// Метод возвращает список активных базовых классов концепции
        /// class_act_base_by_id_conception
        /// </summary>
        public List<vclass> class_act_base_list_get()
        {
            return Manager.class_act_base_by_id_conception(this);
        }
    }
}
