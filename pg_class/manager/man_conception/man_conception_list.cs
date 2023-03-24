using pg_class.pg_classes;
using System.Collections.Generic;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Инициализация листа концепций
        /// </summary>
        public List<conception> conception_list_get()
        {
            return conception_by_all(conception_list_state);
        }
    }
}
