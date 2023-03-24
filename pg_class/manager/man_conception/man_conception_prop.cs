using pg_class.pg_classes;
using System.Collections.Generic;

namespace pg_class
{
    public partial class manager
    {
        private eStatus conception_list_state;

        /// <summary>
        /// Свойство определяет стутус концепций запрашиваемых в лист
        /// </summary>
        public eStatus Conception_list_state { get => conception_list_state; set => conception_list_state = value; }

        /// <summary>
        /// Лист концепций
        /// </summary>
        public List<conception> Conception_list
        {
            get
            {
                return conception_by_all(conception_list_state);
            }
        }
    }
}
