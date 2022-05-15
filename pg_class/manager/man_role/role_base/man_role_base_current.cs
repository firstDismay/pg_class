using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using pg_class.pg_classes;

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
