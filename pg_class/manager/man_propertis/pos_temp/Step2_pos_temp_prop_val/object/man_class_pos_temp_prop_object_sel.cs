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
        /// Выбор класса значения объектного свойства шаблона step№2 по идентификатору свойства шаблона
        /// </summary>
        public vclass class_pos_temp_prop_object_by_id_pos_temp_prop(Int64 iid_pos_temp_prop)
        {
            vclass vclass = null;

            DataTable tbl_vclass  = TableByName("vclass");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("class_pos_temp_prop_object_by_id_pos_temp_prop");

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
            

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            cmdk.Fill(tbl_vclass);
            
            if (tbl_vclass.Rows.Count > 0)
            {
                vclass = new vclass(tbl_vclass.Rows[0]);
            }
            return vclass;
        }


        /// <summary>
        /// Выбор класса значения объектного свойства активного класса шаг №2
        /// </summary>
        public vclass class_pos_temp_prop_object_by_id_pos_temp_prop(pos_temp_prop PosTemp_prop)
        {
            return class_pos_temp_prop_object_by_id_pos_temp_prop(PosTemp_prop.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_pos_temp_prop_object_by_id_pos_temp_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("class_pos_temp_prop_object_by_id_pos_temp_prop");
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
