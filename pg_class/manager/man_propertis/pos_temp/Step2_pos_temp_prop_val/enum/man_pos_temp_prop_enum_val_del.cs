﻿using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Удалить данные значения свойства перечисления
        /// </summary>
        public void pos_temp_prop_enum_val_del(Int64 iid_pos_temp_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_prop_enum_val_del");
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
            pos_temp_prop_enum_val pos_temp_prop_enum_val = pos_temp_prop_enum_val_by_id_prop(iid_pos_temp_prop);

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;
            cmdk.ExecuteNonQuery();

            //Генерируем событие удаления свойства класса
            if (pos_temp_prop_enum_val != null)
            {
                PosTempPropEnumValChangeEventArgs e = new PosTempPropEnumValChangeEventArgs(pos_temp_prop_enum_val, eAction.Delete);
                PosTempPropEnumValOnChange(e);
            }
        }

        /// <summary>
        /// Удалить данные значения свойства перечисления
        /// </summary>
        public void pos_temp_prop_enum_val_del(pos_temp_prop_enum_val PosTemp_prop_enum_val)
        {
            pos_temp_prop_enum_val_del(PosTemp_prop_enum_val.Id_pos_temp_prop);
        }

        /// <summary>
        /// Удалить данные значения свойства перечисления
        /// </summary>
        public void pos_temp_prop_enum_val_del(pos_temp_prop PosTemp_prop)
        {
            pos_temp_prop_enum_val_del(PosTemp_prop.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_enum_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_prop_enum_val_del");
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