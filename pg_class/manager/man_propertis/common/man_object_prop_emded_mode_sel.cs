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
        /// Лист режимов создания встроенных объектов при создании объектного свойства объекта
        /// </summary>
        public List<object_prop_create_emded_mode> object_prop_create_emded_mode_by_all()
        {
            List<object_prop_create_emded_mode> entity_list = new List<object_prop_create_emded_mode>();


            DataTable tbl_data_type  = TableByName("vobject_prop_create_emded_mode");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_prop_create_emded_mode_by_all");

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

            cmdk.Fill(tbl_data_type);
            
            object_prop_create_emded_mode item;
            if (tbl_data_type.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_data_type.Rows)
                {
                    item = new object_prop_create_emded_mode(dr);
                    entity_list.Add(item);
                }
            }
            return entity_list;
        }


        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_create_emded_mode_by_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_prop_create_emded_mode_by_all");
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
