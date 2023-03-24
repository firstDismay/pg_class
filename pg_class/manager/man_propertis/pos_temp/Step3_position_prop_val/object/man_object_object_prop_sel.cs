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
        /// Лист представлений объектов значений объектного свойства позиции
        /// </summary>
        public List<object_general> object_object_prop_by_id_position_carrier(Int64 iid_position_carrier, Int64 iid_pos_temp_prop)
        {
            List<object_general> object_list = new List<object_general>();

            DataTable tbl_object = TableByName("vobject_general");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("object_object_prop_by_id_position_carrier");

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


            cmdk.Parameters["iid_position_carrier"].Value = iid_position_carrier;
            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

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
        /// Лист представлений объектов значений объектного свойства
        /// </summary>
        public List<object_general> object_object_prop_by_id_position_carrier(object_general Object_carrier, pos_temp_prop Pos_temp_prop)
        {
            return object_object_prop_by_id_position_carrier(Object_carrier.Id, Pos_temp_prop.Id);
        }

        /// <summary>
        /// Лист представлений объектов значений объектного свойства
        /// </summary>
        public List<object_general> object_object_prop_by_id_position_carrier(object_general Object_carrier, position_prop Position_prop)
        {
            return object_object_prop_by_id_position_carrier(Object_carrier.Id, Position_prop.Id_pos_temp_prop);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_object_prop_by_id_position_carrier(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("object_object_prop_by_id_position_carrier");
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
