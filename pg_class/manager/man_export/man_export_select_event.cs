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
        #region ПРОЦЕДУРЫ ПРЯМОГО ОБОБЩЕННОГО ЭКСПОРТА В EXCEL
        /// <summary>
        /// Метод экспорта данных в Excel для произвольного запроса
        /// </summary>
        internal Byte[] export_to_excel(String command_export)
        {
            Byte[] Result = null;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("exp_base_entity_to_excel");

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

            cmdk.Parameters["command_export"].Value = command_export;
            object tmp = cmdk.ExecuteScalar();

            if (tmp != DBNull.Value)
            {
                Result = (Byte[])tmp;
            }

            //Генерируем событие завершения процедуры экспорта
            ExportCompletedEventArgs e = new ExportCompletedEventArgs(command_export, Result);
            ExportOnCompleted(e);
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        internal Boolean export_to_excel(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("exp_base_entity_to_excel");
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
        #endregion
        #region ПРОЦЕДУРА СОЗДАНИЯ ОБОБЩЕННОЙ КОМАНДЫ ОТЛОЖЕННОГО ЭКСПОРТА В EXCEL
        /// <summary>
        /// Метод создания команды экспорта данных в Excel для произвольного запроса
        /// </summary>
        internal command_export export_to_excel_get_command(String command_export, String Desc)
        {
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("exp_base_entity_to_excel", true);

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

            cmdk.Parameters["command_export"].Value = command_export;
            command_export cm = new command_export(cmdk, command_export, Desc);
            return cm;
        }
        #endregion
        //*****************************************************************************************

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ ПРОЦЕДУР ЭКСПОРТА

        /// <summary>
        /// Делегат события завершения процедуры экспорта
        /// </summary>
        public delegate void ExportCompletedEventHandler(Object sender, ExportCompletedEventArgs e);

        /// <summary>
        /// Событие возникает при на выходе из процедуры экспорта, ДО ВЫХОДА ИЗ ПРОЦЕДУРЫ
        /// Для получения доступа к результирующему массиву необходимо использовать аргумент события поле ByteArray
        /// </summary>
        public event ExportCompletedEventHandler ExportCompleted;
        //===========================================================

        /// <summary>
        ///  Метод вызова события завершения процедуры экспорта
        /// </summary>
        internal virtual void ExportOnCompleted(ExportCompletedEventArgs e)
        {
            ExportCompletedEventHandler temp = ExportCompleted;
            if (temp != null)
            {
                temp(this, e);
            }
            //Вызов события журнала
            JournalEventArgs me = new JournalEventArgs(e);
            JournalMessageOnReceived(me);
        }
        #endregion
    }
}
