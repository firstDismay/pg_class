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
        /// Лист представлений объектов по маске имени объекта в указанной позиции рекурсивно
        /// </summary>
        public List<object_general> object_ext_by_name_id_pos(String iname, Int64 iid_position, Boolean on_inside)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general_ext");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("object_ext_by_name_id_pos");

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


            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["on_inside"].Value = on_inside;

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
        /// Лист представлений объектов по маске имени объекта в указанной позиции рекурсивно
        /// </summary>
        public List<object_general> object_ext_by_name_id_pos(String iname, position Position, Boolean on_inside)
        {
            return object_ext_by_name_id_pos(iname, Position, on_inside);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_name_id_pos(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("object_ext_by_name_id_pos");
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
