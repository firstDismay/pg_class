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
        /// Лист доступных строковых паттернов для имен объектов
        /// </summary>
        public List<pattern_string> class_name_format_pattern_string_by_all()
        {
            List<pattern_string> pattern_string_list = new List<pattern_string>();
            DataTable tbl_pattern_string  = TableByName("vpattern_string");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_name_format_pattern_string_by_all");
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

            cmdk.Fill(tbl_pattern_string);
            
            pattern_string pattern_string;
            if (tbl_pattern_string.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pattern_string.Rows)
                {
                    pattern_string = new pattern_string(dr);
                    pattern_string_list.Add(pattern_string);
                }
            }
            return pattern_string_list;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_name_format_pattern_string_by_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_name_format_pattern_string_by_all");
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