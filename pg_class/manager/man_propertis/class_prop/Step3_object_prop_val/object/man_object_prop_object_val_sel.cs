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
        /// Данные значения объектного свойства объекта
        /// </summary>
        public object_prop_object_val object_prop_object_val_by_id_prop(Int64 iid_object_carrier, Int64 iid_class_prop)
        {
            object_prop_object_val object_prop_object_val  = null;

            DataTable tbl_object  = TableByName("vobject_prop_object_val");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("object_prop_object_val_by_id_prop");

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
            
            if (tbl_object.Rows.Count > 0)
            {
                object_prop_object_val = new object_prop_object_val(tbl_object.Rows[0]);
            }
            return object_prop_object_val;
        }

        /// <summary>
        /// Данные значения объектного свойства объекта
        /// </summary>
        public object_prop_object_val object_prop_object_val_by_id_prop(object_general Object_carrier, class_prop Class_prop_object_carrier)
        {
            return object_prop_object_val_by_id_prop(Object_carrier.Id, Class_prop_object_carrier.Id);
        }

        /// <summary>
        /// Данные значения объектного свойства объекта
        /// </summary>
        public object_prop_object_val object_prop_object_val_by_id_prop(object_general Object_carrier, object_prop Object_carrier_prop)
        {
            return object_prop_object_val_by_id_prop(Object_carrier.Id, Object_carrier_prop.Id_class_prop);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_object_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("object_prop_object_val_by_id_prop");
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
