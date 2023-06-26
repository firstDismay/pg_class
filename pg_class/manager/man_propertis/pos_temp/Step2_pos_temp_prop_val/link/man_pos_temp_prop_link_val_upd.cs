﻿using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Изменить данные значения свойства-ссылки
        /// </summary>
        public pos_temp_prop_link_val pos_temp_prop_link_val_upd(Int64 iid_pos_temp_prop, Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            pos_temp_prop_link_val pos_temp_prop_link_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;

            cmdk = CommandByKey("pos_temp_prop_link_val_upd");
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

            pos_temp_prop_link_val = pos_temp_prop_link_val_by_id_prop(iid_pos_temp_prop);
            if (pos_temp_prop_link_val != null)
            {
                //Генерируем событие изменения свойства шаблона
                PosTempPropLinkValChangeEventArgs e = new PosTempPropLinkValChangeEventArgs(pos_temp_prop_link_val, eAction.Update);
                PosTempPropLinkValOnChange(e);
            }

            //Возвращаем Сущность
            return pos_temp_prop_link_val;
        }

        /// <summary>
        /// Изменить данные значения свойства-ссылки
        /// </summary>
        public pos_temp_prop_link_val pos_temp_prop_link_val_upd(pos_temp_prop_link_val PosTemp_prop_link_val)
        {
            return pos_temp_prop_link_val_upd(PosTemp_prop_link_val.Id_pos_temp_prop, PosTemp_prop_link_val.Link_id_entity, PosTemp_prop_link_val.Link_id_entity_instance, PosTemp_prop_link_val.Link_id_sub_entity_instance);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_link_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_prop_link_val_upd");
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