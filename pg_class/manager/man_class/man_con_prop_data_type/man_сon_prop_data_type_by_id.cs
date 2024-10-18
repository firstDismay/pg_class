using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;
using System.Collections.Generic;
using System.Data;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод возвращает назначение типа данных на указанную концепцию по идентификатору концепции и типа данных
        /// </summary>
        public con_prop_data_type сon_prop_data_type_by_id(Int64 iid_conception, Int32 iid_prop_data_type)
        {
            con_prop_data_type prop_data_type = null;
            DataTable tbl_rulel2 = TableByName("vcon_prop_data_type");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("con_prop_data_type_by_id");
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
            cmdk.Fill(tbl_rulel2);

            if (tbl_rulel2.Rows.Count > 0)
            {
                prop_data_type = new con_prop_data_type(tbl_rulel2.Rows[0]);
            }

            return prop_data_type;
        }

        /// <summary>
        /// Метод возвращает назначение типа данных на указанную концепцию по идентификатору свойства
        /// </summary>
        public con_prop_data_type сon_prop_data_type_by_id(class_prop Class_prop)
        {
            return сon_prop_data_type_by_id(Class_prop.Id_conception, Class_prop.Id_data_type);
        }

        /// <summary>
        /// Метод возвращает назначение типа данных на указанную концепцию по идентификатору свойства
        /// </summary>
        public con_prop_data_type сon_prop_data_type_by_id(object_prop Object_prop)
        {
            return сon_prop_data_type_by_id(Object_prop.Id_conception, Object_prop.Id_data_type);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean сon_prop_data_type_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("сon_prop_data_type_by_id");
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