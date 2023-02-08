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
using Newtonsoft.Json;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        ///  Метод добавляет список объектов по массиву параметров объектов
        /// </summary>
        public List<errarg_object_add> object_add_for_array_object_parameter(json_object_parameters[] array_object_parameter)
        {
            List<errarg_object_add> object_list = new List<errarg_object_add>();
            DataTable tbl_result = TableByName("errarg_object_add");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_add_for_array_object_parameter");
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

            String[] sarray_object_parameter = new String[array_object_parameter.Length];
            for (Int32 i = 0; i < array_object_parameter.Length; i++)
            {
                sarray_object_parameter[i] = JsonConvert.SerializeObject(array_object_parameter[i], Formatting.Indented);
            }

            cmdk.Parameters["array_object_parameters"].Value = sarray_object_parameter;
            cmdk.Fill(tbl_result);

            errarg_object_add og;
            if (tbl_result.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_result.Rows)
                {
                    og = new errarg_object_add(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }
       
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_add_for_array_object_parameter(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_add_for_array_object_parameter");
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
