﻿using System;
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
        /// Изменить данные значения свойства-ссылки
        /// </summary>
        public class_prop_link_val class_prop_link_val_upd(Int64 iid_class_prop, Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            class_prop_link_val Class_prop_link_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_prop_link_val_upd");

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

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================     
            switch (error)
            {
                case 0:
                    Class_prop_link_val = class_prop_link_val_by_id_prop(iid_class_prop);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_class_prop, eEntity.class_prop_link_val, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (Class_prop_link_val != null)
            {
                //Генерируем событие изменения свойства класса
                ClassPropLinkValChangeEventArgs e = new ClassPropLinkValChangeEventArgs(Class_prop_link_val, eAction.Update);
                ClassPropLinkValOnChange(e);
            }
            //Возвращаем Сущность
            return Class_prop_link_val;
        }


        /// <summary>
        /// Изменить данные значения свойства-ссылки
        /// </summary>
        public class_prop_link_val class_prop_link_val_upd(class_prop_link_val Class_prop_link_val)
        {
            return class_prop_link_val_upd(Class_prop_link_val.Id_class_prop, Class_prop_link_val.Link_id_entity, Class_prop_link_val.Link_id_entity_instance, Class_prop_link_val.Link_id_sub_entity_instance);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_link_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_link_val_upd");
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
