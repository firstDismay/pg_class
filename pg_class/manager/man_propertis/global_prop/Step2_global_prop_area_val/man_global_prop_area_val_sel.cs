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
        /// Выбор данных области значений глобального свойства по идентификатру свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_by_id_prop(Int64 iid_global_prop)
        {
            global_prop_area_val global_prop_area_val = null;

            DataTable tbl_entity  = TableByName("vglobal_prop_area_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("global_prop_area_val_by_id_prop");

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

            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;

            cmdk.Fill(tbl_entity);
            
            if (tbl_entity.Rows.Count > 0)
            {
                global_prop_area_val = new global_prop_area_val(tbl_entity.Rows[0]);
            }
            return global_prop_area_val;
        }

        /// <summary>
        /// Выбор глобального свойства по идентификатру свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_by_id_prop(global_prop GlobalProp)
        {
            return global_prop_area_val_by_id_prop(GlobalProp.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_area_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("global_prop_area_val_by_id_prop");
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
