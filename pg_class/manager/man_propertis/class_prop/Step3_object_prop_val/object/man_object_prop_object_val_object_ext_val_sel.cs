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

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Лист представлений объектов значений объектного свойства
        /// </summary>
        public List<object_general> object_object_prop_by_id_object_carrier_ext(Int64 iid_object_carrier, Int64 iid_class_prop)
        {
            List<object_general> object_list = new List<object_general>();

            DataTable tbl_object = TableByName("vobject_general_ext");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("object_object_prop_by_id_object_carrier_ext");

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
            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;

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
        public List<object_general> object_object_prop_by_id_object_carrier_ext(object_general Object_carrier, class_prop Class_prop)
        {
            return object_object_prop_by_id_object_carrier_ext(Object_carrier.Id, Class_prop.Id);
        }

        /// <summary>
        /// Лист представлений объектов значений объектного свойства
        /// </summary>
        public List<object_general> object_object_prop_by_id_object_carrier_ext(object_general Object_carrier, object_prop Object_prop)
        {
            return object_object_prop_by_id_object_carrier_ext(Object_carrier.Id, Object_prop.Id_class_prop);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_object_prop_by_id_object_carrier_ext(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("object_object_prop_by_id_object_carrier_ext");
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
