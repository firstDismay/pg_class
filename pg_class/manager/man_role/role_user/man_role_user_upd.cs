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
        /// Метод изменяет указанную роль пользователя
        /// </summary>
        public role_user user_role_user_upd(String role_name, String role_description, String role_namesys, String role_newnamesys)
        {
            role_user role_user = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("usr_role_user_upd");

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

            cmdk.Parameters["role_name"].Value = role_name;
            cmdk.Parameters["role_description"].Value = role_description;
            cmdk.Parameters["role_namesys"].Value = role_namesys;
            cmdk.Parameters["role_newnamesys"].Value = role_newnamesys;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                        role_user = user_role_user_by_namesys(role_newnamesys);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(-1, eEntity.role_user, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения концепции
            RoleUserChangeEventArgs e = new RoleUserChangeEventArgs(role_user, eAction.Update);
            RoleUserOnChange(e);
            //Возвращаем Объект
            return role_user;
        }

        /// <summary>
        /// Метод изменяет указанную роль пользователя
        /// </summary>
        public role_user user_role_user_upd(String role_name, String role_description, String role_namesys)
        {
            return user_role_user_upd(role_name, role_description, role_namesys, role_namesys);
        }

        /// <summary>
        /// Метод изменяет указанную роль пользователя
        /// </summary>
        public role_user user_role_user_upd(role_user RoleUser)
        {
            //Int64 iid, String iname, String idesc, Boolean ion
            return user_role_user_upd(RoleUser.Name, RoleUser.Desc, RoleUser.NameSystem, RoleUser.NameSystem);
        }

        /// <summary>
        /// Метод изменяет указанную роль пользователя
        /// </summary>
        public role_user user_role_user_upd(role_user RoleUser, String role_newnamesys)
        {
            return user_role_user_upd(RoleUser.Name, RoleUser.Desc, RoleUser.NameSystem, role_newnamesys);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_role_user_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_role_user_upd");
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
        /// Метод назначает роль пользователя в базовую роль
        /// </summary>
        public Boolean user_role_base_grant(role_user RoleUser, role_base RoleBase)
        {
            Boolean Result = false;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("usr_role_base_grant");

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

            cmdk.Parameters["irole_user"].Value = RoleUser.NameSystem;
            cmdk.Parameters["irole_base"].Value = RoleBase.NameSystem;
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
                    JournalEventArgs me = new JournalEventArgs(-1, eEntity.role_user, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения концепции
            RoleUserChangeEventArgs e = new RoleUserChangeEventArgs(RoleUser, eAction.Update);
            RoleUserOnChange(e);
            //Возвращаем Объект
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_role_base_grant(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_role_base_grant");
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
        /// Метод исключает роль пользователя из базовой роли
        /// </summary>
        public Boolean user_role_base_revoke(role_user RoleUser, role_base RoleBase)
        {
            Boolean Result = false;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("usr_role_base_revoke");
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

            cmdk.Parameters["irole_user"].Value = RoleUser.NameSystem;
            cmdk.Parameters["irole_base"].Value = RoleBase.NameSystem;

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
                    JournalEventArgs me = new JournalEventArgs(-1, eEntity.role_user, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения концепции
            RoleUserChangeEventArgs e = new RoleUserChangeEventArgs(RoleUser, eAction.Update);
            RoleUserOnChange(e);
            //Возвращаем Объект
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_role_base_revoke(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_role_base_revoke");
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