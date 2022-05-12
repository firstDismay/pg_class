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
        /// Выбрать значение свойства активного представления класса по идентификатору значения свойства
        /// </summary>
        public class_prop_object_val class_prop_object_val_by_id(Int64 iid)
        {
            class_prop_object_val class_prop_obj_val_class = null;

            DataTable tbl_vclass_prop_obj_val_class  = TableByName("vclass_prop_object_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_object_val_by_id");

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

            cmdk.Parameters["iid"].Value = iid;

            cmdk.Fill(tbl_vclass_prop_obj_val_class);
            
            if (tbl_vclass_prop_obj_val_class.Rows.Count > 0)
            {
                class_prop_obj_val_class = new class_prop_object_val(tbl_vclass_prop_obj_val_class.Rows[0]);
            }
            return class_prop_obj_val_class;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_object_val_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_object_val_by_id");
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
        //*********************************************************************************************
        
        /// <summary>
        /// Выбрать значение свойства активного представления класса по идентификатору свойства
        /// </summary>
        public class_prop_object_val class_prop_object_val_by_id_prop(Int64 iid_class_prop)
        {
            class_prop_object_val class_prop_obj_val_class = null;

            DataTable tbl_vclass_prop_obj_val_class  = TableByName("vclass_prop_object_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_object_val_by_id_prop");

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

            cmdk.Fill(tbl_vclass_prop_obj_val_class);
            
            if (tbl_vclass_prop_obj_val_class.Rows.Count > 0)
            {
                class_prop_obj_val_class = new class_prop_object_val(tbl_vclass_prop_obj_val_class.Rows[0]);
            }
            return class_prop_obj_val_class;
        }

        /// <summary>
        /// Выбрать значение свойства активного представления класса по идентификатору свойства
        /// </summary>
        public class_prop_object_val class_prop_object_val_by_id_prop(class_prop Class_prop)
        {
            class_prop_object_val Result = null;
            switch (Class_prop.StorageType)
            {
                case eStorageType.Active:
                    Result = class_prop_object_val_by_id_prop(Class_prop.Id);
                    break;
                case eStorageType.History:
                    throw new PgDataException(505, "Исторический класс class_prop не допустим методе class_prop_object_val_by_id_prop!");
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_object_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_object_val_by_id_prop");
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
