using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод обновляет опции текущего пользователя
        /// </summary>
        public user_options user_options_upd(Int64 ipref_conception)
        {
            user_options user_options = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("user_options_upd");
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

            cmdk.Parameters["ipref_conception"].Value = ipref_conception;
            cmdk.ExecuteNonQuery();

            user_options = user_options_by_current();
            //Генерируем событие изменения пользователя
            UserChangeEventArgs e = new UserChangeEventArgs(User_current, eAction.Update);
            UserOnChange(e);
            //Возвращаем сущность
            return user_options;
        }

        /// <summary>
        /// Метод обновляет опции текущего пользователя
        /// </summary>
        public user_options user_options_upd(user_options UserOptions)
        {
            return user_options_upd(UserOptions.PrefConception);
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_options_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("user_options_upd");
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