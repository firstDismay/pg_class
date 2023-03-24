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
        /// <summary>
        /// Роль пользователя по системному имени
        /// </summary>
        public role_user user_role_user_by_namesys(String inamesys)
        {
            role_user role_user = null;

            DataTable tbl_usr = TableByName("vrole_user"); //TableByName("vusers");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_role_user_by_namesys");

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


            cmdk.Parameters["inamesys"].Value = inamesys;

            cmdk.Fill(tbl_usr);

            if (tbl_usr.Rows.Count > 0)
            {
                role_user = new role_user(tbl_usr.Rows[0]);
            }

            return role_user;
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_role_user_by_namesys(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_role_user_by_namesys");
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
        /// Роль пользователя по глобальному идентификатору
        /// </summary>
        public role_user user_role_user_by_id(Int64 iid)
        {
            role_user role_user = null;

            DataTable tbl_usr = TableByName("vrole_user"); //TableByName("vusers");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_role_user_by_id");

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
                role_user = new role_user(tbl_usr.Rows[0]);
            }

            return role_user;
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_role_user_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_role_user_by_id");
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
        /// Лист всех ролей пользователей
        /// </summary>
        public List<role_user> user_role_user_by_all()
        {
            List<role_user> usr_list = new List<role_user>();

            DataTable tbl_usr = TableByName("vrole_user"); //TableByName("vusers");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_role_user_by_all");

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

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_role_user_by_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_role_user_by_all");
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
        /// Лист ролей пользователя
        /// </summary>
        public List<role_user> user_role_user_by_login(String ilogin, Boolean irecursive)
        {
            List<role_user> rol_list = new List<role_user>();

            DataTable tbl_rol = TableByName("vrole_user"); //TableByName("roles");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_role_user_by_login");
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
            cmdk.Parameters["irecursive"].Value = irecursive;

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

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_role_user_by_login(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_role_user_by_login");
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
        /// Лист ролей пользователя включенных в базовую роль
        /// </summary>
        public List<role_user> user_role_user_by_role_base(String irole_base)
        {
            List<role_user> rol_list = new List<role_user>();

            DataTable tbl_rol = TableByName("vrole_user"); //TableByName("roles");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_role_user_by_role_base");
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

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_role_user_by_role_base(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_role_user_by_role_base");
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
        /// Лист ролей пользователей сервера
        /// </summary>
        public List<role_user> User_role_user_all_get()
        {
            return user_role_user_by_all();
        }
    }
}