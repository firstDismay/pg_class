﻿using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод добавляет шаблон позиции в лист ограничений вложенности
        /// </summary>
        public pos_temp pos_temp_nested_include(Int64 iid_pos_temp, Int64 id_pos_temp_nested, Int32 ipos_temp_nested_limit = 0)
        {
            pos_temp pos_temp = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_nested_include");
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

            cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;
            cmdk.Parameters["iid_pos_temp_nested"].Value = id_pos_temp_nested;
            cmdk.Parameters["ipos_temp_nested_limit"].Value = ipos_temp_nested_limit;
            cmdk.ExecuteNonQuery();

            pos_temp = pos_temp_by_id(iid_pos_temp);
            if (pos_temp != null)
            {
                //Вызов события изменения списка вложенности
                PosTempNestedListChangeEventArgs e;
                e = new PosTempNestedListChangeEventArgs(pos_temp, eActionPosTempNestedList.addrule);
                OnPosTempNestedListChange(e);
            }

            //Возвращаем сущность
            return pos_temp;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_nested_include(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_nested_include");
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