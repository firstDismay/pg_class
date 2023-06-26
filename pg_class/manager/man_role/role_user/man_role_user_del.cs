using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод удаляет указанную роль пользователя
        /// </summary>
        public void user_role_user_del(String inamesys)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("user_role_user_del");
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

            role_user usr = user_role_user_by_namesys(inamesys);

            cmdk.Parameters["inamesys"].Value = inamesys;
            cmdk.ExecuteNonQuery();

            if (usr != null)
            {
                //Генерируем событие изменения концепции
                RoleUserChangeEventArgs e = new RoleUserChangeEventArgs(usr, eAction.Delete);
                RoleUserOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет указанную роль пользователя
        /// </summary>
        public void user_role_user_del(role_user RoleUser)
        {
            user_role_user_del(RoleUser.NameSystem);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_role_user_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("user_role_user_del");

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