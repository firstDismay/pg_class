﻿using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;
using System.Data;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Выбор класса значения объектного свойства исторического класса шаг №2
        /// </summary>
        public vclass class_class_prop_object_snapshot_by_id_class_prop(Int64 iid_class_prop, DateTime itimestamp_classop)
        {
            vclass vclass = null;

            DataTable tbl_vclass = TableByName("vclass");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_class_prop_object_snapshot_by_id_class_prop");

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


            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_classop;

            cmdk.Fill(tbl_vclass);

            if (tbl_vclass.Rows.Count > 0)
            {
                vclass = new vclass(tbl_vclass.Rows[0]);
            }
            return vclass;
        }


        /// <summary>
        /// Выбор класса значения объектного свойства исторического класса шаг №2
        /// </summary>
        public vclass class_class_prop_object_snapshot_by_id_class_prop(class_prop Class_prop)
        {
            vclass Result = null;
            switch (Class_prop.StorageType)
            {
                case eStorageType.History:
                    Result = class_class_prop_object_snapshot_by_id_class_prop(Class_prop.Id, Class_prop.Timestamp_class);
                    break;
                case eStorageType.Active:
                    throw new ArgumentOutOfRangeException("Актисвное свойство не допустимо методе class_class_prop_object_snapshot_by_id_class_prop!");
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_obj_class_val_step2_snapshot_by_id_class_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_prop_obj_class_val_step2_snapshot_by_id_class_prop");
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
