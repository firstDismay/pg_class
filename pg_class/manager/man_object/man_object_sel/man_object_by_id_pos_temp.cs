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
        /// Лист объектов шаблона позиции по идентификатору шаблона позиции
        /// </summary>
        public List<object_general> object_by_id_pos_temp(Int64 iid_pos_temp)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_object = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_pos_temp");
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
        ///Лист объектов шаблона позиции по идентификатору шаблона позиции
        /// </summary>
        public List<object_general> object_by_id_pos_temp(pos_temp Pos_temp)
        {
            return object_by_id_pos_temp(Pos_temp.Id);
        }

        /// <summary>
        /// Лист объектов шаблона позиции по идентификатору шаблона позиции
        /// </summary>
        public List<object_general> object_by_id_pos_temp(pos_temp Pos_temp, Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = object_ext_by_id_pos_temp(Pos_temp);
            }
            else
            {
                Result = object_by_id_pos_temp(Pos_temp);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_pos_temp(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_pos_temp");
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
