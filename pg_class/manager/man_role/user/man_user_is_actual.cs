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
        /// Метод определяет актуальность состояния данных пользователя
        /// </summary>
        public eEntityState user_is_actual(String ilogin, DateTime itimestamp)
        {
            Int32 is_actual = 3;
            
            NpgsqlCommandKey cmdk;
            
            cmdk = CommandByKey("user_is_actual");
            if (cmdk != null)
            {
                if (!cmdk.Access)
                {
                    throw new AccessDataBaseException(404, String.Format(@"Отказано в доступе к методу: {0}!", cmdk.CommandText));
                }
            }
            else
            {
                throw new AccessDataBaseException(405, String.Format(@"Не найден метод: {0}!", cmdk.CommandText));
            }

            cmdk.Parameters["ilogin"].Value = ilogin;
            cmdk.Parameters["itimestamp"].Value = itimestamp;
            is_actual = (Int32)cmdk.ExecuteScalar();
            
            return (eEntityState)is_actual;
        }

        /// <summary>
        /// Метод определяет актуальность состояния данных пользователя
        /// </summary>
        public eEntityState user_is_actual(user User)
        {
            return user_is_actual(User.Login, User.Timestamp);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_is_actual(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("user_is_actual");
            if (cmdk != null)
            {
                Result = cmdk.Access;
                if (Result)
                {
                    Access = eAccess.Success;
                }
                else
                {
                    Access = eAccess.NotAvailable;
                }
            }
            return Result;
        }

        /// <summary>
        /// Метод определяет доступность изменения пароля указанной учетной записи для указанной изменяемой учетной записи
        /// </summary>
        public Boolean user_pwd_can_change(String ilogin, String icorrectable_login)
        {
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("user_pwd_can_change");
            if (cmdk != null)
            {
                if (!cmdk.Access)
                {
                    throw new AccessDataBaseException(404, String.Format(@"Отказано в доступе к методу: {0}!", cmdk.CommandText));
                }
            }
            else
            {
                throw new AccessDataBaseException(405, String.Format(@"Не найден метод: {0}!", cmdk.CommandText));
            }

            cmdk.Parameters["ilogin"].Value = ilogin;
            cmdk.Parameters["icorrectable_login"].Value = icorrectable_login;

            return (Boolean)cmdk.ExecuteScalar();
        }

        /// <summary>
        /// Метод определяет доступность изменения пароля указанной учетной записи для указанной изменяемой учетной записи
        /// </summary>
        public Boolean user_pwd_can_change(user ilogin, user icorrectable_login)
        {
            return user_pwd_can_change(ilogin.Login, icorrectable_login.Login);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_pwd_can_change(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("user_pwd_can_change");

            if (cmdk != null)
            {
                Result = cmdk.Access;
                if (Result)
                {
                    Access = eAccess.Success;
                }
                else
                {
                    Access = eAccess.NotAvailable;
                }
            }
            return Result;
        }

        
        /// <summary>
        /// Метод определяет членство учетной записи в указанной роли
        /// </summary>
        public Boolean user_is_member_role(String ilogin, String irole, Boolean irecursive)
        {
            Boolean Result = false;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("user_is_member_role");
            if (cmdk != null)
            {
                if (!cmdk.Access)
                {
                    throw new AccessDataBaseException(404, String.Format(@"Отказано в доступе к методу: {0}!", cmdk.CommandText));
                }
            }
            else
            {
                throw new AccessDataBaseException(405, String.Format(@"Не найден метод: {0}!", cmdk.CommandText));
            }

            cmdk.Parameters["ilogin"].Value = ilogin;
            cmdk.Parameters["irole"].Value = irole;
            cmdk.Parameters["irecursive"].Value = irecursive;
            
            return (Boolean)cmdk.ExecuteScalar();
        }

        /// <summary>
        /// Метод определяет членство пользователя в указанной роли
        /// </summary>
        public Boolean user_is_member_role(user login, role_user role, Boolean irecursive)
        {
            return user_is_member_role(login.Login, role.NameSystem, irecursive);
        }

        /// <summary>
        /// Метод определяет членство пользователя в указанной роли
        /// </summary>
        public Boolean user_is_member_role(user login, role_base role, Boolean irecursive)
        {
            return user_is_member_role(login.Login, role.NameSystem, irecursive);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean usr_is_member_role(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("user_is_member_role");

            if (cmdk != null)
            {
                Result = cmdk.Access;
                if (Result)
                {
                    Access = eAccess.Success;
                }
                else
                {
                    Access = eAccess.NotAvailable;
                }
            }
            return Result;
        }
    }
}
