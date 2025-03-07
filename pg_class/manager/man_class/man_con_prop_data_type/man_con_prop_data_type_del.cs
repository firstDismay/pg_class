﻿using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод удаляет назначение типа данных из указанной концепции
        /// </summary>
        public void Con_prop_data_type_del(Int64 iid_conception, Int32 iid_prop_data_type)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("con_prop_data_type_del");
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
            cmdk.ExecuteNonQuery();

            //Вызов события изменения списка вложенности
            Con_Prop_Data_TypeListChangeEventArgs e;
            e = new Con_Prop_Data_TypeListChangeEventArgs(iid_conception, iid_prop_data_type, eActionRuleList.delrule);
            OnCon_Prop_Data_TypeListChange(e);
        }

        /// <summary>
        /// Метод удаляет назначение типа данных из указанной концепции
        /// </summary>
        public void Con_prop_data_type_del(con_prop_data_type Con_prop_data_type)
        {
            Con_prop_data_type_del(Con_prop_data_type.Id_conception, Con_prop_data_type.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Con_prop_data_type_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("con_prop_data_type_del");
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