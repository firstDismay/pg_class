using pg_class.pg_classes;
using System.Collections.Generic;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Лист базовых ролей сервера
        /// </summary>
        public List<role_base> User_role_base_all_get()
        {
            return user_role_base_by_all();
        }
    }
}
