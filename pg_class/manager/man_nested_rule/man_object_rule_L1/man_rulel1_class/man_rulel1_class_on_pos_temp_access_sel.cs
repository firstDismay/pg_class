using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Npgsql;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using pg_class.pg_classes;

namespace pg_class
{
    public partial class manager
    {
        #region ВЫБРАТЬ РАЗРЕШЕНИЯ ВЛОЖЕННОСТИ УРОВНЯ 1 ГРУППА НА ШАБЛОН

        /// <summary>
        /// Лист разрешений уровня 1 класс на шаблон по идентификатору класса
        /// </summary>
        public List<rulel1_class_on_pos_temp_access> rulel1_class_on_pos_temp_access_by_id_class(Int64 iid_class)
        {
            List<rulel1_class_on_pos_temp_access> rulel1_list = new List<rulel1_class_on_pos_temp_access>();
            DataTable tbl_rulel1  = TableByName("vrulel1_class_on_pos_temp_tbl_access");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("rulel1_class_on_pos_temp_access_by_id_class");
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

            cmdk.Parameters["iid_class"].Value = iid_class;
            cmdk.Fill(tbl_rulel1);

            rulel1_class_on_pos_temp_access rl1;
            if (tbl_rulel1.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rulel1.Rows)
                {
                    rl1 = new rulel1_class_on_pos_temp_access(dr);
                    rulel1_list.Add(rl1);
                }
            }
            return rulel1_list;
        }

        /// <summary>
        /// Лист разрешений уровня 1 класс на шаблон по идентификатору класса
        /// </summary>
        public List<rulel1_class_on_pos_temp_access> rulel1_class_on_pos_temp_access_by_id_class(vclass Class)
        {
            return rulel1_class_on_pos_temp_access_by_id_class(Class.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean rulel1_class_on_pos_temp_access_by_id_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            cmdk = CommandByKey("rulel1_class_on_pos_temp_access_by_id_class");
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
        /// Лист разрешений уровня 1 класс на шаблон по идентификатору шаблона позиции
        /// </summary>
        public List<rulel1_class_on_pos_temp_access> rulel1_class_on_pos_temp_access_by_id_pos_temp(Int64 iid_pos_temp)
        {
            List<rulel1_class_on_pos_temp_access> rulel1_list = new List<rulel1_class_on_pos_temp_access>();
            DataTable tbl_rulel1  = TableByName("vrulel1_class_on_pos_temp_tbl_access");

            NpgsqlCommandKey cmdk;
            cmdk = CommandByKey("rulel1_class_on_pos_temp_access_by_id_pos_temp");

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

            cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;
            cmdk.Fill(tbl_rulel1);
            
            rulel1_class_on_pos_temp_access rl1;
            if (tbl_rulel1.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rulel1.Rows)
                {
                    rl1 = new rulel1_class_on_pos_temp_access(dr);
                    rulel1_list.Add(rl1);
                }
            }
            return rulel1_list;
        }

        /// <summary>
        /// Лист разрешений уровня 1 класс на шаблон по идентификатору шаблона позиции
        /// </summary>
        public List<rulel1_class_on_pos_temp_access> rulel1_class_on_pos_temp_access_by_id_pos_temp(pos_temp Pos_temp)
        {
            return rulel1_class_on_pos_temp_access_by_id_pos_temp(Pos_temp.Id);
        }

        /// <summary>
        /// Лист разрешений уровня 1 класс на шаблон по идентификатору позиции
        /// </summary>
        public List<rulel1_class_on_pos_temp_access> rulel1_class_on_pos_temp_access_by_id_position(position Position)
        {
            return rulel1_class_on_pos_temp_access_by_id_pos_temp(Position.Id_pos_temp);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean rulel1_class_on_pos_temp_access_by_id_pos_temp(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            cmdk = CommandByKey("rulel1_class_on_pos_temp_access_by_id_pos_temp");
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
    }
}
