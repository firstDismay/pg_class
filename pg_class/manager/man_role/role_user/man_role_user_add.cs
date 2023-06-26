using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод добавляет роль пользователя
        /// </summary>
        public role_user user_role_user_add(String irole_name, String irole_description, String irole_namesys)
        {
            role_user role_user = null;
            String namesys;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("user_role_user_add");
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

            cmdk.Parameters["irole_name"].Value = irole_name;
            cmdk.Parameters["irole_description"].Value = irole_description;
            cmdk.Parameters["irole_namesys"].Value = irole_namesys;
            cmdk.ExecuteNonQuery();

            namesys = (String)(cmdk.Parameters["outid"].Value);
            role_user = user_role_user_by_namesys(namesys);
            if (role_user != null)
            {
                //Генерируем событие изменения пользователя
                RoleUserChangeEventArgs e = new RoleUserChangeEventArgs(role_user, eAction.Insert);
                RoleUserOnChange(e);
            }

            //Возвращаем сущность
            return role_user;
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_role_user_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("user_role_user_add");
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