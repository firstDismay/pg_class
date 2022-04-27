using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using pg_class.pg_classes;
using pg_class.poolcn;

namespace pg_class
{
    public partial class manager
    {
        #region EXPORT object_by_id_position

        /// <summary>
        /// Метод экспорта объектов в Excel для указанной позиции носителя
        /// </summary>
        internal Byte[] exp_object_by_id_position_to_excel(Int64 iid_position, eExportMode imode, Boolean iquantity_show)
        {
            Byte[] Result = null;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("exp_object_by_id_position_to_excel");

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

            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["iid_position"].Value = (Int32)imode;
            cmdk.Parameters["iid_position"].Value = iquantity_show;
            object tmp = cmdk.ExecuteScalar();

            if (tmp != DBNull.Value)
            {
                Result = (Byte[])tmp;
            }

            String command_export = String.Format(@"SELECT bpd.exp_object_by_id_position_to_excel({0},{1},{2})", iid_position, imode.ToString(), iquantity_show.ToString());
            //Генерируем событие завершения процедуры экспорта
            ExportCompletedEventArgs e = new ExportCompletedEventArgs(command_export, Result);
            ExportOnCompleted(e);
            return Result;
        }
        
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        internal Boolean exp_object_by_id_position_to_excel(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            cmdk = CommandByKey("exp_object_by_id_position_to_excel");
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

        #region ПРОЦЕДУРА СОЗДАНИЯ КОМАНДЫ ОТЛОЖЕННОГО ЭКСПОРТА В EXCEL
        /// <summary>
        /// Метод создания команды экспорта объектов в Excel для указанной позиции носителя
        /// </summary>
        internal command_export exp_object_by_id_position_to_excel_get_command(Int64 iid_position, eExportMode imode, Boolean iquantity_show)
        {
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("exp_object_by_id_position_to_excel", true);

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

            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["iid_position"].Value = (Int32)imode;
            cmdk.Parameters["iid_position"].Value = iquantity_show;

            String command_export = String.Format(@"SELECT bpd.exp_object_by_id_position_to_excel({0},{1},{2})", iid_position, imode.ToString(), iquantity_show.ToString());
            String Desc = String.Format(@"Отчет: Объекты позиции носителя: {0} | Режим: {1}", iid_position, manager.ExportMode(imode));
            command_export cm = new command_export(cmdk, command_export, Desc);
            return cm;
        }
        #endregion
        #endregion
    }
}
