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
        /// Метод добавляет роль пользователя
        /// </summary>
        public role_user user_role_user_add( String role_name, String role_description, String role_namesys)
        {
            role_user role_user = null;
            String  namesys;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("usr_role_user_add");

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
            
            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    namesys = (String)(cmdk.Parameters["outid"].Value);
                    if (namesys.Length > 0)
                    {
                        role_user = user_role_user_by_namesys(namesys);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(-1, eEntity.role_user, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Генерируем событие изменения пользователя
            RoleUserChangeEventArgs e = new RoleUserChangeEventArgs(role_user, eAction.Insert);
            RoleUserOnChange(e);
            //Возвращаем Объект
            return role_user;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_role_user_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_role_user_add");
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
        //*********************************************************************************************
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет указанную роль пользователя
        /// </summary>
        public void user_role_user_del(String inamesys)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("usr_role_user_del");

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

            role_user usr = user_role_user_by_namesys(inamesys);
            cmdk.Parameters["inamesys"].Value = inamesys;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(-1, eEntity.role_user, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }
            
            //Генерируем событие изменения концепции
            if (usr != null)
            {
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

            //-=ACCESS=-***********************************************************************************
            /// <summary>
            /// Проверка прав доступа к методу
            /// </summary>
            public Boolean user_role_user_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_role_user_del");

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
        /// Роль пользователя по системному имени
        /// </summary>
        public role_user user_role_user_by_namesys(String inamesys)
        {
            role_user role_user = null;

            DataTable tbl_usr =  TableByName("vrole_user"); //TableByName("vusers");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("usr_role_user_by_namesys");

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

            cmdk.Parameters["inamesys"].Value = inamesys;

            cmdk.Fill(tbl_usr);
            
            if (tbl_usr .Rows.Count > 0)
            {
                role_user = new role_user(tbl_usr.Rows[0]);
            }

            return role_user;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_role_user_by_namesys(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_role_user_by_namesys");
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
        /// Роль пользователя по глобальному идентификатору
        /// </summary>
        public role_user user_role_user_by_id(Int64 iid)
        {
            role_user role_user = null;

            DataTable tbl_usr =  TableByName("vrole_user"); //TableByName("vusers");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("usr_role_user_by_id");

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

            cmdk.Fill(tbl_usr);
            
            if (tbl_usr.Rows.Count > 0)
            {
                role_user = new role_user(tbl_usr.Rows[0]);
            }

            return role_user;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_role_user_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_role_user_by_id");
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
        /// Лист всех ролей пользователей
        /// </summary>
        public List<role_user> user_role_user_by_all()
        {
            List<role_user> usr_list = new List<role_user>();

              DataTable tbl_usr =  TableByName("vrole_user"); //TableByName("vusers");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("usr_role_user_by_all");

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

            cmdk.Fill(tbl_usr);
            
            role_user usr;
            if (tbl_usr.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_usr.Rows)
                {
                    usr = new role_user(dr);
                    usr_list.Add(usr);
                }
            }
            return usr_list;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_role_user_by_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_role_user_by_all");
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
        /// Лист ролей пользователя
        /// </summary>
        public List<role_user> user_role_user_by_login(String ilogin)
        {
            List<role_user> rol_list = new List<role_user>();

            DataTable tbl_rol =  TableByName("vrole_user"); //TableByName("roles");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("usr_role_user_by_login");
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

            cmdk.Fill(tbl_rol);
            
            role_user rol;
            if (tbl_rol.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rol.Rows)
                {
                    rol = new role_user(dr);
                    rol_list.Add(rol);
                }
            }
            return rol_list;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_role_user_by_login(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_role_user_by_login");
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
        /// Лист ролей пользователя включенных в базовую роль
        /// </summary>
        public List<role_user> user_role_user_by_role_base(String irole_base)
        {
            List<role_user> rol_list = new List<role_user>();

            DataTable tbl_rol = TableByName("vrole_user"); //TableByName("roles");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("usr_role_user_by_role_base");
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

            cmdk.Parameters["irole_base"].Value = irole_base;
            
            cmdk.Fill(tbl_rol);
            
            role_user rol;
            if (tbl_rol.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rol.Rows)
                {
                    rol = new role_user(dr);
                    rol_list.Add(rol);
                }
            }
            return rol_list;
        }

        /// <summary>
        /// Лист ролей пользователя включенных в базовую роль
        /// </summary>
        public List<role_user> user_role_user_by_role_base(role_base RoleBase)
        {
            return user_role_user_by_role_base(RoleBase.NameSystem);
        }

            //-=ACCESS=-***********************************************************************************
            /// <summary>
            /// Проверка прав доступа к методу
            /// </summary>
            public Boolean user_role_user_by_role_base(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("usr_role_user_by_role_base");
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
        public eEntityState user_role_user_is_actual(String irole_user, DateTime mytimestamp)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("usr_role_user_is_actual");

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

            cmdk.Parameters["irole_user"].Value = irole_user;
            cmdk.Parameters["mytimestamp"].Value = mytimestamp;
           
            //Начало транзакции
            is_actual = (Int32)cmdk.ExecuteScalar();
            
            return (eEntityState)is_actual;
        }

        /// <summary>
        /// Метод определяет актуальность состояния данных роли пользователя
        /// </summary>
        public eEntityState user_role_user_is_actual(role_user RoleUser)
        {
            return user_is_actual(RoleUser.NameSystem, RoleUser.Timestamp);
        }

        #endregion

        #endregion

        #region ПОЛЯ И ПЕРЕМЕННЫЕ КЛАССА: ПОЛЬЗОВАТЕЛИ
        /// <summary>
        /// Лист ролей пользователей сервера
        /// </summary>
        public List<role_user> User_role_user_all_get()
        {
            return user_role_user_by_all();
        }
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ КОНЦЕПЦИЯМИ

        /// <summary>
        /// Делегат события изменения роли пользователя
        /// </summary>
        public delegate void RoleUserChangeEventHandler(Object sender, RoleUserChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении роли пользователя методом доступа к БД
        /// </summary>
        public event RoleUserChangeEventHandler RoleUserChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения роли пользователя
        /// </summary>
        protected virtual void RoleUserOnChange(RoleUserChangeEventArgs e)
        {
            RoleUserChangeEventHandler temp = RoleUserChange;
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