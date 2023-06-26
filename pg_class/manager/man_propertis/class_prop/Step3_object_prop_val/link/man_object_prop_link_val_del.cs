﻿using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Удалить значение свойства-ссылки объекта
        /// </summary>
        public void object_prop_link_val_del(Int64 iid_object, Int64 iid_class_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_prop_link_val_del");
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

            //Предварительный запрос сущностей
            object_prop object_prop = object_prop_by_id(iid_object, iid_class_prop);
            object_prop_link_val object_prop_link_val = object_prop_link_val_by_id_prop(object_prop);

            cmdk.Parameters["iid_object"].Value = iid_object;
            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.ExecuteNonQuery();

            if (object_prop_link_val != null)
            {
                //Генерируем событие изменения значения свойства объекта
                ObjectPropLinkValChangeEventArgs e = new ObjectPropLinkValChangeEventArgs(object_prop_link_val, eAction.Delete);
                ObjectPropLinkValOnChange(e);
            }
        }


        /// <summary>
        /// Удалить значение свойства-перечисления активного представления класса
        /// </summary>
        public void object_prop_link_val_del(object_prop ObjectProp)
        {
            object_prop_link_val_del(ObjectProp.Id_object_carrier, ObjectProp.Id_class_prop);
        }


        /// <summary>
        /// Удалить значение свойства-перечисления активного представления класса
        /// </summary>
        public void object_prop_link_val_del(object_prop_link_val ObjectPropLinkVal)
        {
            object_prop_link_val_del(ObjectPropLinkVal.Id_object, ObjectPropLinkVal.Id_class_prop);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_link_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_prop_link_val_del");
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