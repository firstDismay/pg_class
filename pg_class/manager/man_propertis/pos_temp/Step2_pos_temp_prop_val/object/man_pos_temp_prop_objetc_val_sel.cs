using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;
using System.Data;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Выбрать данные значения объектного свойства шаблона по идентификатору значения свойства
        /// </summary>
        public pos_temp_prop_object_val pos_temp_prop_object_val_by_id(Int64 iid)
        {
            pos_temp_prop_object_val pos_temp_prop_object_val = null;

            DataTable tbl_Entity = TableByName("vpos_temp_prop_object_val");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("pos_temp_prop_object_val_by_id");

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


            cmdk.Parameters["iid"].Value = iid;

            cmdk.Fill(tbl_Entity);

            if (tbl_Entity.Rows.Count > 0)
            {
                pos_temp_prop_object_val = new pos_temp_prop_object_val(tbl_Entity.Rows[0]);
            }
            return pos_temp_prop_object_val;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_object_val_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("pos_temp_prop_object_val_by_id");
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


        /// <summary>
        /// Выбрать данные значения объектного свойства шаблона по идентификатору свойства
        /// </summary>
        public pos_temp_prop_object_val pos_temp_prop_object_val_by_id_prop(Int64 iid_pos_temp_prop)
        {
            pos_temp_prop_object_val pos_temp_prop_object_val = null;

            DataTable tbl_Entity = TableByName("vpos_temp_prop_object_val");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("pos_temp_prop_object_val_by_id_prop");

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

            cmdk.Fill(tbl_Entity);

            if (tbl_Entity.Rows.Count > 0)
            {
                pos_temp_prop_object_val = new pos_temp_prop_object_val(tbl_Entity.Rows[0]);
            }
            return pos_temp_prop_object_val;
        }

        /// <summary>
        /// Выбрать значение свойства активного представления класса по идентификатору свойства
        /// </summary>
        public pos_temp_prop_object_val pos_temp_prop_object_val_by_id_prop(pos_temp_prop PosTemp_prop)
        {
            return pos_temp_prop_object_val_by_id_prop(PosTemp_prop.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_object_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("pos_temp_prop_object_val_by_id_prop");
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
