﻿using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод добавляет выбранный тип данных в указанную концепцию
        /// </summary>
        public void con_prop_data_type_set(Int64 iid_conception, Int32 iid_prop_data_type, String ialias, Int32 isort)
        {
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("con_prop_data_type_set");
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

            cmdk.Parameters["iid_conception"].Value = iid_conception;
            cmdk.Parameters["iid_prop_data_type"].Value = iid_prop_data_type;
            cmdk.Parameters["ialias"].Value = ialias;
            cmdk.Parameters["isort"].Value = isort;
            cmdk.ExecuteNonQuery();

            //Вызов события изменения списка вложенности
            Con_Prop_Data_TypeListChangeEventArgs e;
            e = new Con_Prop_Data_TypeListChangeEventArgs(iid_conception, iid_prop_data_type, eActionRuleList.addrule);
            OnCon_Prop_Data_TypeListChange(e);
        }

        /// <summary>
        /// Метод добавляет выбранный тип данных в указанную концепцию
        /// </summary>
        public void con_prop_data_type_set(con_prop_data_type Con_prop_data_type)
        {
            con_prop_data_type_set(Con_prop_data_type.Id_conception, Con_prop_data_type.Id, Con_prop_data_type.Alias, Con_prop_data_type.Sort);
        }

        /// <summary>
        /// Метод добавляет выбранный тип данных в указанную концепцию
        /// </summary>
        public void con_prop_data_type_set(conception Conception, prop_data_type Con_prop_data_type, String Alias, Int32 Sort)
        {
            con_prop_data_type_set(Conception.Id, Con_prop_data_type.Id, Alias, Sort);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean con_prop_data_type_set(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("con_prop_data_type_set");
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