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
        
        #region МЕТОДЫ КЛАССА: ПОЛЬЗОВАТЕЛИ

        #region ДОБАВИТЬ

        /// <summary>
        /// Метод добавляет пользователя
        /// </summary>
        public user user_add( String usr_name, String usr_otchestvo, String usr_familiya, String usr_rolname, String usr_pwd,
            Boolean usr_rolsuper,Boolean usr_rolinherit,  Boolean usr_rolcreaterole, Boolean usr_rolcreatedb,
            Boolean usr_rolcanlogin, Boolean usr_bypassrls)
        {
            user user = null;
            String  login;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("usr_add");

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
            cmdk = CommandByKey("usr_add");
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
        //*********************************************************************************************
        #endregion

        #region ИЗМЕНИТЬ
        /// <summary>
        /// Метод изменяет указанного пользователя
        /// </summary>
        public user user_upd(String usr_name, String usr_otchestvo, String usr_familiya, String usr_login, String usr_newlogin,
            Boolean usr_rolsuper, Boolean usr_rolinherit, Boolean usr_rolcreaterole, Boolean usr_rolcreatedb,
            Boolean usr_rolcanlogin, Boolean usr_bypassrls)
        {
            user user = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("usr_upd");

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
            cmdk.Parameters["usr_login"].Value = usr_login;
            cmdk.Parameters["usr_newlogin"].Value = usr_newlogin;
            cmdk.Parameters["usr_rolsuper"].Value = usr_rolsuper;
            cmdk.Parameters["usr_rolsuper"].Value = usr_rolsuper;
            cmdk.Parameters["usr_rolinherit"].Value = usr_rolinherit;
            cmdk.Parameters["usr_rolcreaterole"].Value = usr_rolcreaterole;
            cmdk.Parameters["usr_rolcreatedb"].Value = usr_rolcreatedb;
            cmdk.Parameters["usr_rolcanlogin"].Value = usr_rolcanlogin;
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
            //Возвращаем Объект
            return user;
        }

        /// <summary>
        /// Метод изменяет указанного пользователя
        /// </summary>
        public user user_upd(String usr_name, String usr_otchestvo, String usr_familiya, String usr_login,
            Boolean usr_rolsuper, Boolean usr_rolinherit, Boolean usr_rolcreaterole, Boolean usr_rolcreatedb,
            Boolean usr_rolcanlogin, Boolean usr_bypassrls)
        {
            return user_upd(usr_name, usr_otchestvo, usr_familiya, usr_login, usr_login,
            usr_rolsuper, usr_rolinherit, usr_rolcreaterole, usr_rolcreatedb,
            usr_rolcanlogin, usr_bypassrls);
        }

        /// <summary>
        /// Метод изменяет указанного пользователя
        /// </summary>
        public user user_upd(user user)
        {
            //Int64 iid, String iname, String idesc, Boolean ion
            return user_upd(user.UserName, user.UserOtchestvo, user.UserFamiliya, user.Login,
            user.RolSuper, user.RolInherit, user.RolCreaterole, user.RolCreatedb,
            user.RolCanLogin, user.RolBypassRLS);
        }

        /// <summary>
        /// Метод изменяет указанного пользователя
        /// </summary>
        public user user_upd(user user, String usr_newlogin)
        {
            //Int64 iid, String iname, String idesc, Boolean ion
            return user_upd(user.UserName, user.UserOtchestvo, user.UserFamiliya, user.Login, usr_newlogin,
            user.RolSuper, user.RolInherit, user.RolCreaterole, user.RolCreatedb,
            user.RolCanLogin, user.RolBypassRLS);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_upd");
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
        //*********************************************************************************************

        /// <summary>
        /// Метод изменяет пароль указанного пользователя метод для администратора
        /// </summary>
        private user user_set_pwd(String login, String newpwd)
        {
            user user = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("usr_set_pwd");

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

            cmdk.Parameters["usr_login"].Value = login;
            cmdk.Parameters["newpwd"].Value = newpwd;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    user = user_by_login(login);
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
            //Возвращаем Объект
            return user;
        }

        /// <summary>
        /// Метод изменяет пароль указанного пользователя метод для администратора
        /// </summary>
        public user user_set_pwd(user user, String newpwd1, String newpwd2)
        {
            if (newpwd1 != newpwd2)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Новый пароль и подтверждение пароля не совпадают!");
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(0, eEntity.user, 101, sb.ToString(), eAction.Execute, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw (new PgDataException(101, sb.ToString()));
            }
            else
            {
                if (newpwd1.Length < 6)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Пароль не отвечает требованиям политики безопасности! Минимальная длинна пароля 6 символов.");
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(0, eEntity.user, 101, sb.ToString(), eAction.Execute, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw (new PgDataException(101, sb.ToString()));
                }
                else
                {
                    user_set_pwd(user.Login, newpwd1);
                }
            }
            return User_current;
        }

        /// <summary>
        /// Метод изменяет пароль указанного пользователя метод для администратора
        /// </summary>
        public user user_set_me_pwd(String oldpwd, String newpwd1, String newpwd2)
        {
            if (newpwd1 != newpwd2)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Новый пароль и подтверждение пароля не совпадают!");
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(0, eEntity.user, 101, sb.ToString(), eAction.Execute, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw (new PgDataException(101, sb.ToString()));
            }
            else
            {
                if (newpwd1.Length < 6)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Пароль не отвечает требованиям политики безопасности! Минимальная длинна пароля 6 символов.");
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(0, eEntity.user, 101, sb.ToString(), eAction.Execute, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw (new PgDataException(101, sb.ToString()));
                }
                else
                {
                    //LogOff();
                    Pg_ManagerSettings.Password = oldpwd;
                    //Open();
                    user_set_pwd(User_current.Login, newpwd1);
                }
            }
            return User_current;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_set_pwd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_set_pwd");
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
        //*********************************************************************************************
        
        /// <summary>
        /// Метод назначает роль пользователю
        /// </summary>
        public Boolean user_role_user_grant(user user, role_user role)
        {
            Boolean Result = false;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("usr_role_user_grant");

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

            cmdk.Parameters["ilogin"].Value = user.Login;
            cmdk.Parameters["irole_user"].Value = role.NameSystem;
            try
            {
                //Выполнение основной команды в контексте транзакции
                cmdk.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                cmdk.Transaction.Rollback();
                PG_exception_hadler(ex, cmdk);
            }
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    Result = true;
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
            //Возвращаем Объект
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_role_user_grant(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_role_user_grant");
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
        //*********************************************************************************************
        
         /// <summary>
        /// Метод исключает пользователя из роли
        /// </summary>
        public Boolean user_role_user_revoke(user user, role_user role)
        {
            Boolean Result = false;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("usr_role_user_revoke");
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

            cmdk.Parameters["ilogin"].Value = user.Login;
            cmdk.Parameters["irole_user"].Value = role.NameSystem;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    Result = true;
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
            //Возвращаем Объект
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_role_user_revoke(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_role_user_revoke");
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
        //*********************************************************************************************
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет указанного пользователя
        /// </summary>
        public void user_del(String login)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("usr_del");

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

            user usr = user_by_login(login);
            cmdk.Parameters["ilogin"].Value = login;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(-1, eEntity.user, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }
            
            //Генерируем событие изменения концепции
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

            //-=ACCESS=-***********************************************************************************
            /// <summary>
            /// Проверка прав доступа к методу
            /// </summary>
            public Boolean user_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_del");

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
        //*********************************************************************************************
        #endregion

        #region ВЫБРАТЬ

        //*********************************************************************************************
        /// <summary>
        /// Пользователь по логину
        /// </summary>
        public user user_by_login(String login)
        {
            user user = null;

            DataTable tbl_usr =  TableByName("vusers"); //TableByName("vusers");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("usr_by_login");

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

            cmdk.Parameters["login"].Value = login;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_usr);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

            if (tbl_usr .Rows.Count > 0)
            {
                user = new user(tbl_usr.Rows[0]);
            }

            return user;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_by_login(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_by_login");
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
        //*********************************************************************************************

        /// <summary>
        /// Пользователь по глобальному идентификатору
        /// </summary>
        public user user_by_id(Int64 iid)
        {
            user user = null;

            DataTable tbl_usr =  TableByName("vusers"); //TableByName("vusers");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("usr_by_id");

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

            cmdk.Parameters["iid"].Value = iid;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_usr);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

            if (tbl_usr.Rows.Count > 0)
            {
                user = new user(tbl_usr.Rows[0]);
            }

            return user;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_by_id");
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
        //*********************************************************************************************
        

        /// <summary>
        /// Лист всех пользователей
        /// </summary>
        public List<user> user_by_all()
        {
            List<user> usr_list = new List<user>();

              DataTable tbl_usr =  TableByName("vusers"); //TableByName("vusers");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("usr_by_all");

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

            try
            {
                cmdk.Fill(tbl_usr);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            user usr;
            if (tbl_usr.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_usr.Rows)
                {
                    usr = new user(dr);
                    usr_list.Add(usr);
                }
            }
            return usr_list;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_by_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_by_all");
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
        //*********************************************************************************************
        
        /// <summary>
        /// Лист пользователей входящих в указанную роль
        /// </summary>
        public List<user> user_by_roles(String roles)
        {
            List<user> usr_list = new List<user>();

            DataTable tbl_usr =  TableByName("vusers"); //TableByName("vusers");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("usr_by_roles");
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

            cmdk.Parameters["roles"].Value = roles;

            try
            {
                cmdk.Fill(tbl_usr);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            user usr;
            if (tbl_usr.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_usr.Rows)
                {
                    usr = new user(dr);
                    usr_list.Add(usr);
                }
            }
            return usr_list;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_by_roles(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_by_roles");
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
        //*********************************************************************************************
        
        //*********************************************************************************************
        /// <summary>
        /// Текущий Пользователь
        /// </summary>
        public user user_by_current()
        {
            user user = null;

            DataTable tbl_usr =  TableByName("vusers"); //TableByName("vusers");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("usr_by_current");

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

            try
            {
                cmdk.Fill(tbl_usr);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

            if (tbl_usr.Rows.Count > 0)
            {
                user = new user(tbl_usr.Rows[0]);
            }

            return user;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_by_current(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_by_current");
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
        //*********************************************************************************************
       
        #endregion

        #region СВОЙСТВА ПОЛУЧАЕМЫЕ ИЗ БД
        //*********************************************************************************************
        /// <summary>
        /// Метод определяет актуальность состояния данных пользователя
        /// </summary>
        public eEntityState user_is_actual(String login, DateTime mytimestamp)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("usr_is_actual2");

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

            cmdk.Parameters["login"].Value = login;
            cmdk.Parameters["mytimestamp"].Value = mytimestamp;
           
            //Начало транзакции
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


        //*********************************************************************************************
        /// <summary>
        /// Метод определяет доступность изменения пароля указанной учетной записи для указанной изменяемой учетной записи
        /// </summary>
        public Boolean user_can_change_pwd(String usr_login, String usr_change_login)
        {
            Boolean Result = false;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("usr_can_change_pwd");

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

            cmdk.Parameters["usr_login"].Value = usr_login;
            cmdk.Parameters["usr_change_login"].Value = usr_change_login;

            //Начало транзакции
            Result = (Boolean)cmdk.ExecuteScalar();
            
            return Result;
        }

        /// <summary>
        /// Метод определяет доступность изменения пароля указанной учетной записи для указанной изменяемой учетной записи
        /// </summary>
        public Boolean user_can_change_pwd(user usr_login, user usr_change_login)
        {
            return user_can_change_pwd(usr_login.Login, usr_change_login.Login);
        }

        //*********************************************************************************************
        /// <summary>
        /// Метод определяет членство учетной записи в указанной роли
        /// </summary>
        public Boolean user_is_member_role(String ilogin, String irole)
        {
            Boolean Result = false;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("usr_is_member_role");

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

            //Начало транзакции
            Result = (Boolean)cmdk.ExecuteScalar();
            
            return Result;
        }

        /// <summary>
        /// Метод определяет членство пользователя в указанной роли
        /// </summary>
        public Boolean user_is_member_role(user login, role_user role)
        {
            return user_is_member_role(login.Login, role.NameSystem);
        }

        /// <summary>
        /// Метод определяет членство пользователя в указанной роли
        /// </summary>
        public Boolean user_is_member_role(user login, role_base role)
        {
            return user_is_member_role(login.Login, role.NameSystem);
        }

        #endregion


        #region ПАРАМЕТРЫ ДОСТУПА К БД 
        //*********************************************************************************************
        /// <summary>
        /// Список функций доступных текущему пользователю, с параметрам доступности выполнения 
        /// </summary>
        public List<function> user_base_function_by_current()
        {
            List<function> func_list = new List<function>();

            DataTable tbl_func = TableByName("cfg_v_initproc_base_desc"); //TableByName("cfg_v_initproc_base_desc");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("usr_base_function_by_current");

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
            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_func);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            function func;
            if (tbl_func.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_func.Rows)
                {
                    func = new function(dr);
                    func_list.Add(func);
                }
            }

            return func_list;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_base_function_by_current(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_base_function_by_current");
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
        //*********************************************************************************************
        
        //*********************************************************************************************
        /// <summary>
        /// Список функций доступных указанному пользователю, с параметрам доступности выполнения 
        /// </summary>
        public List<function> user_base_function_by_login(String usr_rolname)
        {
            List<function> func_list = new List<function>();

            DataTable tbl_func = TableByName("cfg_v_initproc_base_desc"); //TableByName("cfg_v_initproc_base_desc");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("usr_base_function_by_login");

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

            cmdk.Parameters["usr_rolname"].Value = usr_rolname;
            try
            {
                cmdk.Fill(tbl_func);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            function func;
            if (tbl_func.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_func.Rows)
                {
                    func = new function(dr);
                    func_list.Add(func);
                }
            }

            return func_list;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_base_function_by_login(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_base_function_by_login");
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
        //*********************************************************************************************
        #endregion

        #endregion

        #region ПОЛЯ И ПЕРЕМЕННЫЕ КЛАССА: ПОЛЬЗОВАТЕЛИ

        
        /// <summary>
        /// Лист пользователей
        /// </summary>
        public List<user> User_list_get()
        { 
            return user_by_all();
        }
                
        /// <summary>
        /// Текущий пользователь
        /// </summary>
        public user User_current
        {
            get
            {
                return user_by_current();
            }
        }
        #endregion

        #region ОПЦИИ И ПРЕДПОЧТЕНИЯ ПОЛЬЗОВАТЕЛЯ СОХРАНЯЕМЫЕ НА СТОРОНЕ СЕРВЕРА
        #region ОБНОВИТЬ
        /// <summary>
        /// Метод обновляет опции текущего пользователя
        /// </summary>
        public user_options user_options_upd(Int64 ipref_conception)
        {
            user_options user_options = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("usr_options_upd");

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

            cmdk.Parameters["ipref_conception"].Value = ipref_conception;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
           
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    user_options = user_options_by_current();
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(-1, eEntity.user, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения пользователя
            UserChangeEventArgs e = new UserChangeEventArgs(User_current, eAction.Update);
            UserOnChange(e);
            //Возвращаем Объект
            return user_options;
        }

        /// <summary>
        /// Метод обновляет опции текущего пользователя
        /// </summary>
        public user_options user_options_upd(user_options UserOptions)
        {
            return user_options_upd( UserOptions.PrefConception);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_options_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_options_upd");
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
        //*********************************************************************************************
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Опции текущего пользователя
        /// </summary>
        public user_options user_options_by_current()
        {
            user_options user_options = null;

            DataTable tbl_usr =  TableByName("user_options"); // TableByName("user_options")
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("usr_options_by_current");

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

            
            try
            {
                cmdk.Fill(tbl_usr);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

            if (tbl_usr.Rows.Count > 0)
            {
                user_options = new user_options(tbl_usr.Rows[0]);
            }
            return user_options;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_options_by_current(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_options_by_current");
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
        //*********************************************************************************************
        
         //*********************************************************************************************
        /// <summary>
        /// Метод определяет актуальность состояния опций пользователя
        /// </summary>
        public eEntityState user_options_is_actual(String login, DateTime mytimestamp)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("usr_options_is_actual");

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

            cmdk.Parameters["ilogin"].Value = login;
            cmdk.Parameters["imytimestamp"].Value = mytimestamp;

            //Начало транзакции
            is_actual = (Int32)cmdk.ExecuteScalar();
            
            return (eEntityState)is_actual;
            ;
        }

        /// <summary>
        /// Метод определяет актуальность состояния опций пользователя
        /// </summary>
        public eEntityState user_options_is_actual(user_options UserOptions)
        {
            return user_options_is_actual(UserOptions.Login, UserOptions.Timestamp);
        }
        
        #endregion
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ КОНЦЕПЦИЯМИ

        /// <summary>
        /// Делегат события изменения пользователя
        /// </summary>
        public delegate void UserChangeEventHandler(Object sender, UserChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении пользователя методом доступа к БД
        /// </summary>
        public event UserChangeEventHandler UserChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения пользователя
        /// </summary>
        protected virtual void UserOnChange(UserChangeEventArgs e)
        {
            UserChangeEventHandler temp = UserChange;

            if (temp != null)
            {
                temp(this, e);
            }
            //Вызов события журнала
            JournalEventArgs me = new JournalEventArgs(e);
            JournalMessageOnReceived(me);
        }

        #endregion
    }
}
