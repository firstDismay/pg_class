using pg_class.pg_classes;
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
        public void user_del(String login)
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

            user usr = user_by_login(login);

            cmdk.Parameters["ilogin"].Value = login;
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            switch (error)
            {
                case 0:
                    //Генерируем событие удаления пользователя
                    if (usr != null)
                    {
                        UserChangeEventArgs e = new UserChangeEventArgs(usr, eAction.Delete);
                        UserOnChange(e);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(-1, eEntity.user, error, desc_error, eAction.Delete, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
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