using Newtonsoft.Json;
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
        ///  Метод добавляет список объектов по массиву параметров объектов
        /// </summary>
        public List<error_message> object_add_for_array_object_parameters(json_object_parameters[] object_parameters)
        {
            List<error_message> object_list = new List<error_message>();
            DataTable tbl_result = TableByName("errarg_object_add");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_add_for_array_object_parameters");
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

            String[] sobject_parameters = new String[object_parameters.Length];
            for (Int32 i = 0; i < object_parameters.Length; i++)
            {
                sobject_parameters[i] = JsonConvert.SerializeObject(object_parameters[i], Formatting.Indented);
            }

            cmdk.Parameters["object_parameters"].Value = sobject_parameters;
            cmdk.Fill(tbl_result);

            error_message og;
            if (tbl_result.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_result.Rows)
                {
                    og = new error_message(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_add_for_array_object_parameters(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_add_for_array_object_parameters");
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
