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
        /// Выбрать данные значения свойства-ссылки по идентификатору свойства
        /// </summary>
        public class_prop_link_val class_prop_link_val_by_id_prop(Int64 iid_class_prop)
        {
            class_prop_link_val Сlass_prop_link_val = null;

            DataTable tbl_entity = TableByName("vclass_prop_link_val");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_prop_link_val_by_id_prop");

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

            cmdk.Fill(tbl_entity);

            if (tbl_entity.Rows.Count > 0)
            {
                Сlass_prop_link_val = new class_prop_link_val(tbl_entity.Rows[0]);
            }
            return Сlass_prop_link_val;
        }


        /// <summary>
        /// Выбрать данные значения свойства-ссылки по идентификатору свойства
        /// </summary>
        public class_prop_link_val class_prop_link_val_by_id_prop(class_prop Class_prop)
        {
            return class_prop_link_val_by_id_prop(Class_prop.Id);
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_link_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_prop_link_val_by_id_prop");
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
