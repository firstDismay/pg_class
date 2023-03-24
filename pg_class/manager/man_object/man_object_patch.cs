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
        /// Лист объектов path определяющих путь до активного представления класса
        /// </summary>
        public List<object_path> object_path_by_id_object(Int64 iid_object)
        {
            List<object_path> object_path_list = new List<object_path>();
            DataTable tbl_object_path = TableByName("path3");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_path");
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

            cmdk.Parameters["iid_object"].Value = iid_object;
            cmdk.Fill(tbl_object_path);

            object_path obj;
            if (tbl_object_path.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object_path.Rows)
                {
                    obj = new object_path(dr);
                    object_path_list.Add(obj);
                }
            }
            return object_path_list;
        }

        /// <summary>
        /// Лист объектов path определяющих путь до активного представления класса
        /// </summary>
        public List<object_path> object_path_by_id_object(object_general Object)
        {
            return object_path_by_id_object(Object.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_path_by_id_object(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_path");
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
        /// Метод возвращает строковое представление пути объекта
        /// </summary>
        public String object_spathfull(Int64 iid_object)
        {
            String Result;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_spathfull");
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

            cmdk.Parameters["iid_object"].Value = iid_object;
            Result = (String)cmdk.ExecuteScalar();
            return Result;
        }
    }
}