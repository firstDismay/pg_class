﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using pg_class.pg_classes;
using System.Runtime.InteropServices.ComTypes;

namespace pg_class
{
    public partial class manager
    {
<<<<<<< HEAD
/// <summary>
/// Лист объектов указанной позиции по маске значения глобального свойства 
/// </summary>
        public List<object_general> object_by_id_position_msk_global_prop(Int64 iid_position, Int64 iid_global_prop, 
=======
        /// <summary>
        /// Лист объектов указанной позиции по маске значения глобального свойства
        /// </summary>
        /// <param name="iid_position">Идентификатор позиции</param>
        /// <param name="iid_global_prop">Идентификатор глобального свойства</param>
        /// <param name="search_method">Строкое представление метода поиска</param>
        /// <param name="valreq">Значение, маска поиска, для методов поиска по массивам идентификаторы критериев через запятую</param>
        /// <param name="valmin">Минимальное значение поиска при поиске в диапазоне</param>
        /// <param name="valmax">Максимальное значение поиска при поиске в диапазоне</param>
        /// <returns>Лист объектов</returns>
        /// <exception cref="AccessDataBaseException"></exception>
        public List<object_general> object_by_id_position_global_prop(Int64 iid_position, Int64 iid_global_prop, 
>>>>>>> e7d329e (Изменение наименований методов поиска объектов по глобальным свойствам с аргументом метода поиска)
                                                                        eSearchMethods search_method, String valreq, String valmin, String valmax)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_object = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_position_global_prop");
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

            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;
            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["search_method"].Value = search_method.ToString();
            cmdk.Parameters["valreq"].Value = valreq;
            cmdk.Parameters["valmin"].Value = valmin;
            cmdk.Parameters["valmax"].Value = valmax;
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
        /// Лист объектов указанной позиции по маске значения глобального свойства 
        /// </summary>
<<<<<<< HEAD
        public List<object_general> object_by_id_position_msk_global_prop(position Position, global_prop Global_prp,
=======
        /// <param name="Position">Идентификатор позиции</param>
        /// <param name="Global_prp">Идентификатор глобального свойства</param>
        /// <param name="search_method">Строкое представление метода поиска</param>
        /// <param name="valreq">Значение, маска поиска, для методов поиска по массивам идентификаторы критериев через запятую</param>
        /// <param name="valmin">Минимальное значение поиска при поиске в диапазоне</param>
        /// <param name="valmax">Максимальное значение поиска при поиске в диапазоне</param>
        /// <returns>Лист объектов</returns>
        /// <exception cref="AccessDataBaseException"></exception>
        public List<object_general> object_by_id_position_global_prop(position Position, global_prop Global_prp,
>>>>>>> e7d329e (Изменение наименований методов поиска объектов по глобальным свойствам с аргументом метода поиска)
                                                                        eSearchMethods search_method, String valreq, String valmin, String valmax)
        {
            return object_by_id_position_global_prop(Position.Id, Global_prp.Id, search_method, valreq, valmin, valmax);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_position_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            cmdk = CommandByKey("object_by_id_position_global_prop");
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
