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
        /// Правило уровня 1 класс на шаблон по идентификатору правила
        /// </summary>
        public rulel1_class_on_pos_temp rulel1_class_on_pos_temp_by_id(Int64 iid_class, Int64 iid_pos_temp)
        {
            rulel1_class_on_pos_temp rulel1 = null;
            DataTable tbl_rl1 = TableByName("vrulel1_class_on_pos_temp");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("rulel1_class_on_pos_temp_by_id");
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
            cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;
            cmdk.Fill(tbl_rl1);

            if (tbl_rl1.Rows.Count > 0)
            {
                rulel1 = new rulel1_class_on_pos_temp(tbl_rl1.Rows[0]);
            }
            return rulel1;
        }

        /// <summary>
        /// Правило уровня 1 класс на шаблон по идентификатору правила
        /// </summary>
        public rulel1_class_on_pos_temp rulel1_class_on_pos_temp_by_id(vclass Class, pos_temp Pos_temp)
        {
            return rulel1_class_on_pos_temp_by_id(Class.Id, Pos_temp.Id);
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean rulel1_class_on_pos_temp_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("rulel1_class_on_pos_temp_by_id");
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
        /// Лист правил уровня 1 класс на шаблон по идентификатору класса
        /// </summary>
        public List<rulel1_class_on_pos_temp> rulel1_class_on_pos_temp_by_id_class(Int64 iid_class)
        {
            List<rulel1_class_on_pos_temp> rulel1_list = new List<rulel1_class_on_pos_temp>();
            DataTable tbl_rulel1 = TableByName("vrulel1_class_on_pos_temp");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("rulel1_class_on_pos_temp_by_id_class");
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

            rulel1_class_on_pos_temp rl1;
            if (tbl_rulel1.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rulel1.Rows)
                {
                    rl1 = new rulel1_class_on_pos_temp(dr);
                    rulel1_list.Add(rl1);
                }
            }
            return rulel1_list;
        }

        /// <summary>
        /// Лист правил уровня 1 класс на шаблон по идентификатору класса
        /// </summary>
        public List<rulel1_class_on_pos_temp> rulel1_class_on_pos_temp_by_id_class(vclass Class)
        {
            return rulel1_class_on_pos_temp_by_id_class(Class.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean rulel1_class_on_pos_temp_by_id_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("rulel1_class_on_pos_temp_by_id_class");
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
        /// Лист правил уровня 1 класс на шаблон по идентификатору шаблона позиции
        /// </summary>
        public List<rulel1_class_on_pos_temp> rulel1_class_on_pos_temp_by_id_pos_temp(Int64 iid_pos_temp)
        {
            List<rulel1_class_on_pos_temp> rulel1_list = new List<rulel1_class_on_pos_temp>();
            DataTable tbl_rulel1 = TableByName("vrulel1_class_on_pos_temp");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("rulel1_class_on_pos_temp_by_id_pos_temp");
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

            rulel1_class_on_pos_temp rl1;
            if (tbl_rulel1.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rulel1.Rows)
                {
                    rl1 = new rulel1_class_on_pos_temp(dr);
                    rulel1_list.Add(rl1);
                }
            }
            return rulel1_list;
        }

        /// <summary>
        /// Лист правил уровня 1 класс на шаблон по идентификатору шаблона позиции
        /// </summary>
        public List<rulel1_class_on_pos_temp> rulel1_class_on_pos_temp_by_id_pos_temp(pos_temp Pos_temp)
        {
            return rulel1_class_on_pos_temp_by_id_pos_temp(Pos_temp.Id);
        }

        /// <summary>
        /// Лист правил уровня 1 группа на шаблон по идентификатору шаблона позиции
        /// </summary>
        public List<rulel1_class_on_pos_temp> rulel1_class_on_pos_temp_by_id_pos_temp(position Position)
        {
            return rulel1_class_on_pos_temp_by_id_pos_temp(Position.Id_pos_temp);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean rulel1_class_on_pos_temp_by_id_pos_temp(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("rulel1_class_on_pos_temp_by_id_pos_temp");
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
