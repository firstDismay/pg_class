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
        /// Метод изменяет указанного пользователя
        /// </summary>
        public user user_upd(String usr_name, String usr_otchestvo, String usr_familiya, String usr_login, String usr_newlogin,
            Boolean usr_rolsuper, Boolean usr_rolinherit, Boolean usr_rolcreaterole, Boolean usr_rolcreatedb,
            Boolean usr_rolcanlogin, Boolean usr_rolcanweblogin, Boolean usr_bypassrls)
        {
            user user = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            
            cmdk = CommandByKey("user_upd");

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

            cmdk.Parameters["usr_name"].Value = usr_name;
            cmdk.Parameters["usr_otchestvo"].Value = usr_otchestvo;
            cmdk.Parameters["usr_familiya"].Value = usr_familiya;
            cmdk.Parameters["usr_login"].Value = usr_login;
            cmdk.Parameters["usr_newlogin"].Value = usr_newlogin;
            cmdk.Parameters["usr_rolsuper"].Value = usr_rolsuper;
            cmdk.Parameters["usr_rolsuper"].Value = usr_rolsuper;
            cmdk.Parameters["usr_rolinherit"].Value = usr_rolinherit;
            cmdk.Parameters["usr_rolcreaterole"].Value = usr_rolcreaterole;
            cmdk.Parameters["usr_rolcreatedb"].Value = usr_rolcreatedb;
            cmdk.Parameters["usr_rolcanlogin"].Value = usr_rolcanlogin;
            cmdk.Parameters["usr_rolcanweblogin"].Value = usr_rolcanweblogin;
            cmdk.Parameters["usr_bypassrls"].Value = usr_bypassrls;
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            switch (error)
            {
                case 0:
                        user = user_by_login(usr_newlogin);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(-1, eEntity.user, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения концепции
            UserChangeEventArgs e = new UserChangeEventArgs(user, eAction.Update);
            UserOnChange(e);
            //Возвращаем сущность
            return user;
        }

        /// <summary>
        /// Метод изменяет указанного пользователя
        /// </summary>
        public user user_upd(String usr_name, String usr_otchestvo, String usr_familiya, String usr_login,
            Boolean usr_rolsuper, Boolean usr_rolinherit, Boolean usr_rolcreaterole, Boolean usr_rolcreatedb,
            Boolean usr_rolcanlogin, Boolean usr_rolcanweblogin, Boolean usr_bypassrls)
        {
            return user_upd(usr_name, usr_otchestvo, usr_familiya, usr_login, usr_login,
            usr_rolsuper, usr_rolinherit, usr_rolcreaterole, usr_rolcreatedb,
            usr_rolcanlogin, usr_rolcanweblogin, usr_bypassrls);
        }

        /// <summary>
        /// Метод изменяет указанного пользователя
        /// </summary>
        public user user_upd(user user)
        {
            //Int64 iid, String iname, String idesc, Boolean ion
            return user_upd(user.UserName, user.UserOtchestvo, user.UserFamiliya, user.Login,
            user.RolSuper, user.RolInherit, user.RolCreaterole, user.RolCreatedb,
            user.RolCanLogin, user.RolCanWebLogin, user.RolBypassRLS);
        }

        /// <summary>
        /// Метод изменяет указанного пользователя
        /// </summary>
        public user user_upd(user user, String usr_newlogin)
        {
            //Int64 iid, String iname, String idesc, Boolean ion
            return user_upd(user.UserName, user.UserOtchestvo, user.UserFamiliya, user.Login, usr_newlogin,
            user.RolSuper, user.RolInherit, user.RolCreaterole, user.RolCreatedb,
            user.RolCanLogin, user.RolCanWebLogin, user.RolBypassRLS);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("user_upd");
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
