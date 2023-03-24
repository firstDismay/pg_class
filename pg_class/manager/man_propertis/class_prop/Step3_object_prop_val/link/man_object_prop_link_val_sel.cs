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
        /// Выбрать данные значения свойства объекта типа ссылка по идентификатору значения свойства
        /// </summary>
        public object_prop_link_val object_prop_link_val_by_id_prop(Int64 iid_object, Int64 iid_class_prop)
        {
            object_prop_link_val object_prop_link_val = null;

            DataTable tbl_entity = TableByName("vobject_prop_link_val");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("object_prop_link_val_by_id_prop");

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


            cmdk.Parameters["iid_object"].Value = iid_object;
            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;

            cmdk.Fill(tbl_entity);

            if (tbl_entity.Rows.Count > 0)
            {
                object_prop_link_val = new object_prop_link_val(tbl_entity.Rows[0]);
            }
            return object_prop_link_val;
        }


        /// <summary>
        /// Выбрать данные значения свойства объекта типа ссылка по идентификатору значения свойства
        /// </summary>
        public object_prop_link_val object_prop_link_val_by_id_prop(object_prop ObjectProp)
        {
            return object_prop_link_val_by_id_prop(ObjectProp.Id_object_carrier, ObjectProp.Id_class_prop);
        }


        /// <summary>
        /// Выбрать данные значения свойства объекта типа ссылка по идентификатору значения свойства
        /// </summary>
        public object_prop_link_val object_prop_link_val_by_id_prop(object_prop_link_val ObjectPropLink_val)
        {
            return object_prop_link_val_by_id_prop(ObjectPropLink_val.Id_object, ObjectPropLink_val.Id_class_prop);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_link_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("object_prop_link_val_by_id_prop");
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
