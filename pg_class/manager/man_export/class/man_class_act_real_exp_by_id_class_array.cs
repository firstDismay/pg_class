﻿using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод экспорта активных представлений вещественных классов в Excel по массиву идентификаторов
        /// </summary>
        public Byte[] exp_class_act_real_by_id_class_array_to_excel(Int64[] iclass_array, eExportMode imode, Boolean iquantity_show)
        {
            Byte[] Result = null;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("exp_class_act_real_by_id_class_array_to_excel");
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

            cmdk.Parameters["iclass_array"].Value = iclass_array;
            cmdk.Parameters["imode"].Value = (Int32)imode;
            cmdk.Parameters["iquantity_show"].Value = iquantity_show;
            object tmp = cmdk.ExecuteScalar();

            if (tmp != DBNull.Value)
            {
                Result = (Byte[])tmp;
            }

            String command_export = String.Format(@"SELECT bpd.exp_class_act_real_by_id_class_array_to_excel({0},{1},{2})", "Array", imode.ToString(), iquantity_show.ToString());
            //Генерируем событие завершения процедуры экспорта
            ExportCompletedEventArgs e = new ExportCompletedEventArgs(command_export, Result);
            ExportOnCompleted(e);
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean exp_class_act_real_by_id_class_array_to_excel(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("exp_class_act_real_by_id_class_array_to_excel");
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
