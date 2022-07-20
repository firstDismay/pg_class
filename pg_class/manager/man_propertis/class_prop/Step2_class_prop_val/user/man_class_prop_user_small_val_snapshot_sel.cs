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
        /// Выбрать значение пользовательского свойства исторического представления класса по идентификатору значения свойства
        /// </summary>
        public class_prop_user_val class_prop_user_small_val_snapshot_by_id_prop(Int64 iid_class_prop, DateTime itimestamp_class)
        {
            class_prop_user_val class_prop_user_val = null;

            DataTable tbl_vclass_prop_obj_val_class  = TableByName("vclass_prop_user_small_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_user_small_val_snapshot_by_id_prop");

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
            //=======================

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;

            cmdk.Fill(tbl_vclass_prop_obj_val_class);
            
            if (tbl_vclass_prop_obj_val_class.Rows.Count > 0)
            {
                class_prop_user_val = new class_prop_user_val(tbl_vclass_prop_obj_val_class.Rows[0]);
            }
            return class_prop_user_val;
        }


        /// <summary>
        /// Выбрать значение пользовательского свойства исторического представления класса по идентификатору значения свойства
        /// </summary>
        public class_prop_user_val class_prop_user_small_val_snapshot_by_id_prop(class_prop Class_prop)
        {
            return class_prop_user_small_val_snapshot_by_id_prop(Class_prop.Id, Class_prop.Timestamp_class);
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_user_small_val_snapshot_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_user_small_val_snapshot_by_id_prop");
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
