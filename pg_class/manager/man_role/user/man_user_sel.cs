using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;
using System.Collections.Generic;
using System.Data;

namespace pg_class
{
    public partial class manager
    {
        #region ВЫБРАТЬ


        /// <summary>
        /// Пользователь по логину
        /// </summary>
        public user user_by_login(String ilogin)
        {
            user user = null;

            DataTable tbl_usr = TableByName("vusers"); //TableByName("vusers");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_by_login");

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

            cmdk.Fill(tbl_usr);

            if (tbl_usr.Rows.Count > 0)
            {
                user = new user(tbl_usr.Rows[0]);
            }

            return user;
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_by_login(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_by_login");
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


        /// <summary>
        /// Пользователь по глобальному идентификатору
        /// </summary>
        public user user_by_id(Int64 iid)
        {
            user user = null;

            DataTable tbl_usr = TableByName("vusers"); //TableByName("vusers");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_by_id");

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


            cmdk.Parameters["iid"].Value = iid;

            cmdk.Fill(tbl_usr);

            if (tbl_usr.Rows.Count > 0)
            {
                user = new user(tbl_usr.Rows[0]);
            }

            return user;
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_by_id");
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



        /// <summary>
        /// Лист всех пользователей
        /// </summary>
        public List<user> user_by_all()
        {
            List<user> usr_list = new List<user>();
            DataTable tbl_usr = TableByName("vusers"); //TableByName("vusers");

            NpgsqlCommandKey cmdk;
            cmdk = CommandByKey("user_by_all");

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

            cmdk.Fill(tbl_usr);
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

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_by_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("user_by_all");
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

        /// <summary>
        /// Лист пользователей входящих в указанную роль
        /// </summary>
        public List<user> user_by_roles(String irole)
        {
            List<user> usr_list = new List<user>();
            DataTable tbl_usr = TableByName("vusers"); //TableByName("vusers");

            NpgsqlCommandKey cmdk;
            cmdk = CommandByKey("user_by_roles");
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

            cmdk.Parameters["irole"].Value = irole;
            cmdk.Fill(tbl_usr);
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

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_by_roles(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_by_roles");
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

        /// <summary>
        /// Текущий Пользователь
        /// </summary>
        public user user_by_current()
        {
            user user = null;
            DataTable tbl_usr = TableByName("vusers"); //TableByName("vusers");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("user_by_current");
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

            cmdk.Fill(tbl_usr);
            if (tbl_usr.Rows.Count > 0)
            {
                user = new user(tbl_usr.Rows[0]);
            }
            return user;
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_by_current(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_by_current");
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

        #endregion

        #region ПАРАМЕТРЫ ДОСТУПА К БД 

        /// <summary>
        /// Список функций доступных текущему пользователю, с параметрам доступности выполнения 
        /// </summary>
        public List<function> user_base_function_by_current()
        {
            List<function> func_list = new List<function>();

            DataTable tbl_func = TableByName("cfg_v_initproc_base_desc"); //TableByName("cfg_v_initproc_base_desc");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_base_function_by_current");

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

            cmdk.Fill(tbl_func);

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
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_base_function_by_current(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_base_function_by_current");
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



        /// <summary>
        /// Список функций доступных указанному пользователю, с параметрам доступности выполнения 
        /// </summary>
        public List<function> user_base_function_by_login(String usr_rolname)
        {
            List<function> func_list = new List<function>();

            DataTable tbl_func = TableByName("cfg_v_initproc_base_desc"); //TableByName("cfg_v_initproc_base_desc");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_base_function_by_login");

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

            cmdk.Fill(tbl_func);

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
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_base_function_by_login(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_base_function_by_login");
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
    }
}