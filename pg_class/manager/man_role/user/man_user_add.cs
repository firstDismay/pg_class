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
        /// Метод добавляет пользователя
        /// </summary>
        public user user_add( String usr_name, String usr_otchestvo, String usr_familiya, String usr_rolname, String usr_pwd,
            Boolean usr_rolsuper,Boolean usr_rolinherit,  Boolean usr_rolcreaterole, Boolean usr_rolcreatedb,
            Boolean usr_rolcanlogin, Boolean usr_rolcanweblogin, Boolean usr_bypassrls)
        {
            user user = null;
            String  login;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("user_add");

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
            //=======================
            
            cmdk.Parameters["usr_name"].Value = usr_name;
            cmdk.Parameters["usr_otchestvo"].Value = usr_otchestvo;
            cmdk.Parameters["usr_familiya"].Value = usr_familiya;
            cmdk.Parameters["usr_rolname"].Value = usr_rolname;
            cmdk.Parameters["usr_pwd"].Value = usr_pwd;
            cmdk.Parameters["usr_rolsuper"].Value = usr_rolsuper;
            cmdk.Parameters["usr_rolsuper"].Value = usr_rolsuper;
            cmdk.Parameters["usr_rolinherit"].Value = usr_rolinherit;
            cmdk.Parameters["usr_rolcreaterole"].Value = usr_rolcreaterole;
            cmdk.Parameters["usr_rolcreatedb"].Value = usr_rolcreatedb;
            cmdk.Parameters["usr_rolcanlogin"].Value = usr_rolcanlogin;
            cmdk.Parameters["usr_rolcanweblogin"].Value = usr_rolcanweblogin;
            cmdk.Parameters["usr_bypassrls"].Value = usr_bypassrls;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    login = (String)(cmdk.Parameters["outid"].Value);
                    if (login.Length > 0)
                    {
                        user = user_by_login(login);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(-1, eEntity.user, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Генерируем событие изменения пользователя
            UserChangeEventArgs e = new UserChangeEventArgs(user, eAction.Insert);
            UserOnChange(e);
            //Возвращаем Объект
            return user;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("user_add");
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
