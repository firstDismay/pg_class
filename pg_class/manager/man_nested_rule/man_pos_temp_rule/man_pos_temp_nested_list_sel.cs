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
        /// <summary>
        /// Правило вложенности шаблонов позиций по полному идентификатору
        /// </summary>
        public pos_temp_nested_rule pos_temp_nested_whitelist_by_id( Int64 iid_pos_temp, Int64 iid_pos_temp_nested)
        {
            pos_temp_nested_rule pos_temp_rule = null;

            DataTable tbl_con  = TableByName("vpos_temp_nested_rule");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("pos_temp_nested_whitelist_by_id");

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
            cmdk.Parameters["iid_pos_temp_nested"].Value = iid_pos_temp_nested;

            cmdk.Fill(tbl_con);
            
            if (tbl_con.Rows.Count > 0)
            {
                pos_temp_rule = new pos_temp_nested_rule(tbl_con.Rows[0]);
            }

            return pos_temp_rule;
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_nested_whitelist_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("pos_temp_nested_whitelist_by_id");
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
        /// Полный перечень потенциально доступных Правил вложенности шаблонов позиций для указанного шаблона позиции
        /// </summary>
        public List<pos_temp_nested_rule> pos_temp_nested_whitelist_full( Int64 iid_pos_temp , Int64 iid_con )
        {
            List<pos_temp_nested_rule> rule_list = new List<pos_temp_nested_rule>();


            DataTable tbl_rule_list  = TableByName("vpos_temp_nested_rule");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("pos_temp_nested_whitelist_full");

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
            cmdk.Parameters["iid_con"].Value = iid_con;

            cmdk.Fill(tbl_rule_list);
            
            pos_temp_nested_rule rule;
            if (tbl_rule_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rule_list.Rows)
                {
                    rule = new pos_temp_nested_rule(dr);
                    rule_list.Add(rule);
                }
            }

            return rule_list;
        }


        /// <summary>
        /// Полный перечень потенциально доступных Правил вложенности шаблонов позиций для указанного шаблона позиции
        /// </summary>
        public List<pos_temp_nested_rule> pos_temp_nested_whitelist_full(pos_temp Pos_temp)
        {
            return pos_temp_nested_whitelist_full(Pos_temp.Id, Pos_temp.Id_conception);
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_nested_whitelist_full(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("pos_temp_nested_whitelist_full");
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
        /// Перечень существующих Правил вложенности шаблонов позиции по идентификатору шаблона
        /// </summary>
        public List<pos_temp_nested_rule>pos_temp_nested_whitelist(Int64 iid_pos_temp)
        {
            List<pos_temp_nested_rule> rule_list = new List<pos_temp_nested_rule>();


            DataTable tbl_rule_list  = TableByName("vpos_temp_nested_rule");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("pos_temp_nested_whitelist");

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

            cmdk.Fill(tbl_rule_list);
            
            pos_temp_nested_rule rule;
            if (tbl_rule_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_rule_list.Rows)
                {
                    rule = new pos_temp_nested_rule(dr);
                    rule_list.Add(rule);
                }
            }

            return rule_list;
        }

        /// <summary>
        /// Перечень Правил вложенности шаблонов позиции по идентификатору шаблона
        /// </summary>
        public List<pos_temp_nested_rule> pos_temp_nested_whitelist(pos_temp Pos_temp)
        {
            return pos_temp_nested_whitelist(Pos_temp.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_nested_whitelist(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("pos_temp_nested_whitelist");
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
