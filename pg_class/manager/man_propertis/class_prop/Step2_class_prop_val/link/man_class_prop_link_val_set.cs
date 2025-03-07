﻿using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Установить данные значения свойства типа ссылка
        /// </summary>
        public class_prop_link_val class_prop_link_val_set(Int64 iid_class_prop, Int32 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            class_prop_link_val Class_prop_link_val = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;

            cmdk = CommandByKey("class_prop_link_val_set");
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
            cmdk.Parameters["iid_entity"].Value = iid_entity;

            if (iid_entity_instance <= 0)
            {
                cmdk.Parameters["iid_entity_instance"].Value = DBNull.Value;
            }
            else
            {
                cmdk.Parameters["iid_entity_instance"].Value = iid_entity_instance;
            }

            if (iid_sub_entity_instance <= 0)
            {
                cmdk.Parameters["iid_sub_entity_instance"].Value = DBNull.Value;
            }
            else
            {
                cmdk.Parameters["iid_sub_entity_instance"].Value = iid_sub_entity_instance;
            }
            cmdk.ExecuteNonQuery();

            Class_prop_link_val = class_prop_link_val_by_id_prop(iid_class_prop);
            if (Class_prop_link_val != null)
            {
                //Генерируем событие изменения данных значения свойства типа перечисление
                ClassPropLinkValChangeEventArgs e = new ClassPropLinkValChangeEventArgs(Class_prop_link_val, eAction.Insert);
                ClassPropLinkValOnChange(e);
            }
            //Возвращаем Сущность
            return Class_prop_link_val;
        }

        /// <summary>
        /// Добавить данные значения свойства-ссылки
        /// </summary>
        public class_prop_link_val class_prop_link_val_set(class_prop_link_val Class_prop_link_val)
        {
            class_prop_link_val Result = null;
            if (Class_prop_link_val != null)
            {
                Result = class_prop_link_val_set(Class_prop_link_val.Id_class_prop, Class_prop_link_val.Link_id_entity, Class_prop_link_val.Link_id_entity_instance, Class_prop_link_val.Link_id_sub_entity_instance);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_link_val_set(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_link_val_set");
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