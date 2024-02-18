﻿using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод удаляет свойство класса из глобального свойства
        /// </summary>
        public global_prop_link_class_prop global_prop_link_class_prop_exclude(Int64 iid_class_prop_definition)
        {
            global_prop_link_class_prop global_prop_link_class_prop;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("global_prop_link_class_prop_exclude");
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

            //Запрос удаляемой сущности
            global_prop_link_class_prop = global_prop_link_class_prop_by_id(iid_class_prop_definition);

            cmdk.Parameters["iid_class_prop_definition"].Value = iid_class_prop_definition;
            cmdk.ExecuteNonQuery();

            var prop_link = class_prop_by_id(iid_class_prop_definition);

            //Генерируем событие изменения
            if (global_prop_link_class_prop != null)
            {
                GlobalPropLinkClassPropChangeEventArgs e = new GlobalPropLinkClassPropChangeEventArgs(global_prop_link_class_prop, eAction.Exclude);
                GlobalPropLinkClassPropOnChange(e);
            }

            if (prop_link != null)
            {
                //Генерируем событие изменения свойства класса
                ClassPropChangeEventArgs e2 = new ClassPropChangeEventArgs(prop_link, eAction.Update);
                ClassPropOnChange(e2);
            }
            //Возвращаем сущность
            return global_prop_link_class_prop;
        }

        /// <summary>
        /// Метод удаляет свойство класса из глобального свойства
        /// </summary>
        public global_prop_link_class_prop global_prop_link_class_prop_exclude(class_prop ClassProp)
        {
            global_prop_link_class_prop Result = null;
            if (ClassProp != null)
            {
                Result = global_prop_link_class_prop_exclude( ClassProp.Id);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_link_class_prop_exclude(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("global_prop_link_class_prop_exclude");
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