﻿using pg_class.pg_classes;
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
        /// Лист представлений объектов по id объекта носителя
        /// </summary>
        public List<object_general> object_by_id_object_carrier(Int64 iid_object_carrier)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_object = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_object_carrier");
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

            cmdk.Parameters["iid_object_carrier"].Value = iid_object_carrier;
            cmdk.Fill(tbl_object);
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист представлений объектов по id родительского объекта
        /// </summary>
        public List<object_general> object_by_id_object_carrier(object_general Object_parent)
        {
            return object_by_id_object_carrier(Object_parent.Id);
        }

        /// <summary>
        /// Лист представлений объектов по id родительского объекта
        /// </summary>
        public List<object_general> object_by_id_object_carrier(object_general Object_parent, Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = object_ext_by_id_object_carrier(Object_parent);
            }
            else
            {
                Result = object_by_id_object_carrier(Object_parent);
            }
            return Result;
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_object_carrier(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_object_carrier");
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
