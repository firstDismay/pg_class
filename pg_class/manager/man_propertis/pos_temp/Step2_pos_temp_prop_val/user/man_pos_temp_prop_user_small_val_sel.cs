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
        /// Выбрать значение пользовательского свойства шаблона по идентификатору значения свойства
        /// </summary>
        public pos_temp_prop_user_val pos_temp_prop_user_small_val_by_id_prop(Int64 iid_pos_temp_prop)
        {
            pos_temp_prop_user_val pos_temp_prop_user_val = null;

            DataTable tbl_vpos_temp_prop_obj_val_class  = TableByName("vpos_temp_prop_user_small_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_prop_user_small_val_by_id_prop");

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

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            cmdk.Fill(tbl_vpos_temp_prop_obj_val_class);
            
            if (tbl_vpos_temp_prop_obj_val_class.Rows.Count > 0)
            {
                pos_temp_prop_user_val = new pos_temp_prop_user_val(tbl_vpos_temp_prop_obj_val_class.Rows[0]);
            }
            return pos_temp_prop_user_val;
        }

        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение пользовательского свойства активного представления класса по идентификатору значения свойства
        /// </summary>
        public pos_temp_prop_user_val pos_temp_prop_user_small_val_by_id_prop(pos_temp_prop PosTempProp)
        {
            return pos_temp_prop_user_small_val_by_id_prop(PosTempProp.Id);
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_user_small_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_user_small_val_by_id_prop");
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
