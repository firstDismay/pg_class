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
        /// Лист объектов снимка класса по идентификатору класса
        /// </summary>
        public List<object_general> object_by_id_class_snapshot(Int64 iid_class, DateTime itimestamp_class)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_object = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_class_snapshot");
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
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;
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
        /// Лист объектов снимка класса по идентификатору класса
        /// </summary>
        public List<object_general> object_by_id_class_snapshot(vclass Class)
        {
            return object_by_id_class_snapshot(Class.Id, Class.Timestamp);
        }

        /// <summary>
        /// Лист объектов снимка класса по идентификатору класса
        /// </summary>
        public List<object_general> object_by_id_class_snapshot(object_general Object_general)
        {
            return object_by_id_class_snapshot(Object_general.Id_class, Object_general.Timestamp_class);
        }

        /// <summary>
        /// Лист объектов снимка класса по идентификатору класса
        /// </summary>
        public List<object_general> object_by_id_class_snapshot(vclass Class, Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = object_ext_by_id_class_snapshot(Class);
            }
            else
            {
                Result = object_by_id_class_snapshot(Class);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_class_snapshot(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_class_snapshot");
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