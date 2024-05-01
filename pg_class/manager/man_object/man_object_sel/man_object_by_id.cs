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
        /// Представление объекта по идентификатору
        /// </summary>
        public object_general object_by_id(Int64 id)
        {
            object_general object_general = null;

            DataTable tbl_object = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id");
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

            cmdk.Parameters["iid"].Value = id;
            cmdk.Fill(tbl_object);
            if (tbl_object.Rows.Count > 0)
            {
                object_general = new object_general(tbl_object.Rows[0]);
            }
            return object_general;
        }

        /// <summary>
        /// Представление объекта по идентификатору пути объекта
        /// </summary>
        public object_general object_by_id(object_path Object_path, Boolean Extended = false)
        {
            object_general Result;
            if (Extended)
            {
                Result = object_ext_by_id(Object_path.Id_object);
            }
            else
            {
                Result = object_by_id(Object_path.Id_object);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id");
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
