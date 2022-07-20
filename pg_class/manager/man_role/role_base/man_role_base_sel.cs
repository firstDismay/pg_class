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
        /// Лист базовых ролей пользователя
        /// </summary>
        public List<role_base> user_role_base_by_login(String ilogin, Boolean irecursive)
        {
            List<role_base> rol_list = new List<role_base>();

            DataTable tbl_rol =  TableByName("vrole_base");
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("user_role_base_by_login");
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
            
            role_base rol;
            if (tbl_rol.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rol.Rows)
                {
                    rol = new role_base(dr);
                    rol_list.Add(rol);
                }
            }
            return rol_list;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_role_base_by_login(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("user_role_base_by_login");
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
        /// Лист базовых ролей
        /// </summary>
        public List<role_base> user_role_base_by_all()
        {
            List<role_base> rol_list = new List<role_base>();

            DataTable tbl_rol =  TableByName("vrole_base");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("user_role_base_by_all");
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

            cmdk.Fill(tbl_rol);
            
            role_base rol;
            if (tbl_rol.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rol.Rows)
                {
                    rol = new role_base(dr);
                    rol_list.Add(rol);
                }
            }
            return rol_list;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean user_role_base_by_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("user_role_base_by_all");
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
