﻿using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод удаляет указанного пользователя
        /// </summary>
        public void user_del(String irole_name)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("user_del");
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

            user usr = user_by_login(irole_name);

            cmdk.Parameters["irole_name"].Value = irole_name;
            cmdk.ExecuteNonQuery();

            //Генерируем событие удаления пользователя
            if (usr != null)
            {
                UserChangeEventArgs e = new UserChangeEventArgs(usr, eAction.Delete);
                UserOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет указанного пользователя
        /// </summary>
        public void user_del(user User)
        {
            user_del(User.Login);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("user_del");
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