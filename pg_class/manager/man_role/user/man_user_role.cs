using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод назначает роль пользователю
        /// </summary>
        public Boolean user_role_user_grant(user user, role_user role)
        {
            Boolean Result = false;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("user_role_user_grant");

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

            cmdk.Parameters["ilogin"].Value = user.Login;
            cmdk.Parameters["irole_user"].Value = role.NameSystem;
            cmdk.ExecuteNonQuery();

            Result = true;
            //Генерируем событие изменения концепции
            UserChangeEventArgs e = new UserChangeEventArgs(user, eAction.Update);
            UserOnChange(e);
            //Возвращаем сущность
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_role_user_grant(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_role_user_grant");
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
        /// Метод исключает пользователя из роли
        /// </summary>
        public Boolean user_role_user_revoke(user user, role_user role)
        {
            Boolean Result = false;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("user_role_user_revoke");
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

            cmdk.Parameters["ilogin"].Value = user.Login;
            cmdk.Parameters["irole_user"].Value = role.NameSystem;
            cmdk.ExecuteNonQuery();

            Result = true;
            //Генерируем событие изменения концепции
            UserChangeEventArgs e = new UserChangeEventArgs(user, eAction.Update);
            UserOnChange(e);
            //Возвращаем сущность
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_role_user_revoke(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_role_user_revoke");
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