using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
    { /// <summary>
    /// Класс пользователей БД учеет
    /// </summary>
    public partial class user
    {
        #region МЕТОДЫ КЛАССА
		/// <summary>
		/// Метод определяет членство пользователя в указанной роли
		/// </summary>
		public Boolean Is_member_role(role_base vrole, Boolean irecursive)
        {
            return Manager.user_is_member_role(this, vrole, irecursive);
        }

        /// <summary>
        /// Метод определяет членство пользователя в указанной роли
        /// </summary>
        public Boolean Is_member_role(role_user vrole, Boolean irecursive)
        {
            return Manager.user_is_member_role(this, vrole, irecursive);
        }

        /// <summary>
        /// Лист ролей пользователя
        /// </summary>
        public List<role_user> Role_user_list_get(Boolean recursive)
        {
            return Manager.user_role_user_by_login(rolname, recursive);
        }

        /// <summary>
        /// Лист ролей базовых пользователя
        /// </summary>
        public List<role_base> Role_base_list_get(Boolean recursive)
        {
            return Manager.user_role_base_by_login(rolname, recursive);
        }

        /// <summary>
        /// Лист функция пользователя
        /// </summary>
        public List<function> Functions_base_list_get()
        {
            return Manager.user_base_function_by_login(rolname);
        }
        #endregion
    }
}
