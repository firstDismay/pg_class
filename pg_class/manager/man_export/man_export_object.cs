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
        //-=EXPORT TO EXCEL=-**************************************************************************
        /// <summary>
        /// Лист представлений объектов по идентификатору позиции
        /// </summary>
        public Byte[] object_by_id_position(Int64 iid_position, eBaseExportFormat ExportFormat)
        {
            Byte[] Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.object_by_id_position({0})", iid_position);
                    Result = export_to_excel(command_export);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT o.* FROM bpd.object o  JOIN bpd.object_by_id_position({0}) f ON f.id = o.id", iid_position);
                    Result = export_to_excel(command_export);
                    break;
                case eBaseExportFormat.ReportEntity:
                    Result = export_object_general_by_id_pos_to_excel(iid_position);
                    break;
                case eBaseExportFormat.ReportEntityWithProp:
                    Result = export_object_with_prop_by_id_pos_to_excel(iid_position);
                    break;
            }
            return Result;
        }

        /// <summary>
        /// Rоманда экспорта Лист представлений объектов по идентификатору позиции
        /// </summary>
        public command_export object_by_id_position_command_export(Int64 iid_position, eBaseExportFormat ExportFormat)
        {
            command_export Result = null;
            String desc;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.object_by_id_position({0})", iid_position);
                    desc = String.Format(@"Экпорт: Объекты позиции: {0} | Режим: {1}", pos_by_id(iid_position).NamePosition, manager.ExportMode(ExportFormat));
                    Result = export_to_excel_get_command(command_export, desc);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT o.* FROM bpd.object o  JOIN bpd.object_by_id_position({0}) f ON f.id = o.id", iid_position);
                    desc = String.Format(@"Экпорт: Объекты позиции: {0} | Режим: {1}", pos_by_id(iid_position).NamePosition, manager.ExportMode(ExportFormat));
                    Result = export_to_excel_get_command(command_export, desc);
                    break;
                case eBaseExportFormat.ReportEntity:
                    Result = export_object_general_by_id_pos_to_excel_get_command(iid_position);
                    break;
                case eBaseExportFormat.ReportEntityWithProp:
                    Result = export_object_with_prop_by_id_pos_to_excel_get_command(iid_position);
                    break;
            }
            return Result;
        }
        //-=EXPORT TO EXCEL=-**************************************************************************

        #region ПРОЦЕДУРА ЭКСПОРТА В EXCEL ПРЕДСТАВЛЕНИЕ ОБОБЩЕННОЕ
        /// <summary>
        /// Метод экспорта обобщенного представления объектов в Excel для указанной позиции носителя
        /// </summary>
        internal Byte[] export_object_general_by_id_pos_to_excel(Int64 iid_position)
        {
            Byte[] Result = null;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("exp_object_general_by_id_pos_to_excel");

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
            object tmp = cmdk.ExecuteScalar();

            if (tmp != DBNull.Value)
            {
                Result = (Byte[])tmp;
            }

            String command_export = String.Format(@"SELECT bpd.exp_object_general_by_id_pos_to_excel({0})", iid_position);
            //Генерируем событие завершения процедуры экспорта
            ExportCompletedEventArgs e = new ExportCompletedEventArgs(command_export, Result);
            ExportOnCompleted(e);
            return Result;
        }

        /// <summary>
        /// Метод экспорта обобщенного представления объектов в Excel для указанной позиции носителя
        /// </summary>
        internal Byte[] export_object_general_by_id_pos_to_excel(position Position_parent)
        {
            return export_object_general_by_id_pos_to_excel(Position_parent.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        internal Boolean export_object_general_by_id_pos_to_excel(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("exp_object_general_by_id_pos_to_excel");
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
        #region ПРОЦЕДУРА СОЗДАНИЯ КОМАНДЫ ОТЛОЖЕННОГО ЭКСПОРТА В EXCEL ПРЕДСТАВЛЕНИЕ ОБОБЩЕННОЕ
        /// <summary>
        /// Метод создания команды экспорта обобщенного представления объектов в Excel для указанной позиции носителя
        /// </summary>
        internal command_export export_object_general_by_id_pos_to_excel_get_command(Int64 iid_position)
        {
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("exp_object_general_by_id_pos_to_excel", true);

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
            String command_export = String.Format(@"SELECT bpd.exp_object_general_by_id_pos_to_excel({0})", iid_position);
            String Desc = String.Format(@"Отчет: Объекты позиции носителя: {0} | Режим: {1}", iid_position, manager.ExportMode(eBaseExportFormat.ReportEntity));
            command_export cm = new command_export(cmdk, command_export, Desc);
            return cm;
        }
        #endregion
        //*****************************************************************************************

        #region ПРОЦЕДУРА ЭКСПОРТА В EXCEL ПРЕДСТАВЛЕНИЕ СО СВОЙСТВАМИ
        /// <summary>
        /// Метод экспорта объектов со свойствами в Excel для указанной позиции носителя
        /// </summary>
        internal Byte[] export_object_with_prop_by_id_pos_to_excel(Int64 iid_position)
        {
            Byte[] Result = null;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("exp_object_with_prop_by_id_pos_to_excel");

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
            object tmp = cmdk.ExecuteScalar();

            if (tmp != DBNull.Value)
            {
                Result = (Byte[])tmp;
            }

            String command_export = String.Format(@"SELECT bpd.exp_object_with_prop_by_id_pos_to_excel({0})", iid_position);
            //Генерируем событие завершения процедуры экспорта
            ExportCompletedEventArgs e = new ExportCompletedEventArgs(command_export, Result);
            ExportOnCompleted(e);
            return Result;
        }

        /// <summary>
        /// Метод экспорта объектов со свойствами в Excel для указанной позиции носителя
        /// </summary>
        internal Byte[] export_object_with_prop_by_id_pos_to_excel(position Position_parent)
        {
            return export_object_with_prop_by_id_pos_to_excel(Position_parent.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        internal Boolean export_object_with_prop_by_id_pos_to_excel(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("export_object_with_prop_by_id_pos_to_excel");
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
        #region ПРОЦЕДУРА СОЗДАНИЯ КОМАНДЫ ОТЛОЖЕННОГО ЭКСПОРТА В EXCEL ПРЕДСТАВЛЕНИЕ СО СВОЙСТВАМИ
        /// <summary>
        /// Метод создания команды экспорта объектов со свойствами в Excel для указанной позиции носителя
        /// </summary>
        internal command_export export_object_with_prop_by_id_pos_to_excel_get_command(Int64 iid_position)
        {
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("exp_object_with_prop_by_id_pos_to_excel", true);

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
            String command_export = String.Format(@"SELECT bpd.exp_object_with_prop_by_id_pos_to_excel({0})", iid_position);
            String Desc = String.Format(@"Отчет: Объекты со свойствами позиции носителя: {0} | Режим: {1}", iid_position, manager.ExportMode(eBaseExportFormat.ReportEntityWithProp));
            command_export cm = new command_export(cmdk, command_export,  Desc);
            return cm;
        }
        #endregion
        //*****************************************************************************************
        #endregion

        #region ПРОЦЕДУРА ЭКСПОРТА В EXCEL
        /// <summary>
        /// Метод экспорта объектов (со свойствами) концепции по маске значения глобального свойства
        /// exp_object_with_prop_by_global_prop_from_con_to_excel
        /// </summary>
        internal Byte[] export_object_with_prop_by_global_prop_from_con_to_excel(Int64 iid_global_prop, String find_mask)
        {
            Byte[] Result = null;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("exp_object_with_prop_by_global_prop_from_con_to_excel");

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

            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;
            cmdk.Parameters["find_mask"].Value = find_mask;

            object tmp = cmdk.ExecuteScalar();

            if (tmp != DBNull.Value)
            {
                Result = (Byte[])tmp;
            }

            String command_export = String.Format(@"SELECT bpd.exp_object_with_prop_by_global_prop_from_con_to_excel({0},'{1}')", iid_global_prop, find_mask);
            //Генерируем событие завершения процедуры экспорта
            ExportCompletedEventArgs e = new ExportCompletedEventArgs(command_export, Result);
            ExportOnCompleted(e);
            return Result;
        }

        /// <summary>
        /// Метод экспорта объектов (со свойствами) концепции по маске значения глобального свойства
        /// exp_object_with_prop_by_global_prop_from_con_to_excel
        /// </summary>
        internal Byte[] export_object_with_prop_by_global_prop_from_con_to_excel(global_prop GlobalProp, String find_mask)
        {
            return export_object_with_prop_by_global_prop_from_con_to_excel(GlobalProp.Id, find_mask);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        internal Boolean export_object_with_prop_by_global_prop_from_con_to_excel(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("exp_object_with_prop_by_global_prop_from_con_to_excel");
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
        #region ПРОЦЕДУРА СОЗДАНИЯ КОМАНДЫ ОТЛОЖЕННОГО ЭКСПОРТА В EXCEL
        /// <summary>
        /// Метод создания команды экспорта объектов (со свойствами) концепции по маске значения глобального свойства
        /// exp_object_with_prop_by_find_from_con_to_excel
        /// </summary>
        internal command_export export_object_with_prop_by_global_prop_from_con_to_excel_get_command(global_prop GlobalProp, String find_mask)
        {
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("exp_object_with_prop_by_global_prop_from_con_to_excel", true);

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

            cmdk.Parameters["iid_global_prop"].Value = GlobalProp.Id;
            cmdk.Parameters["find_mask"].Value = find_mask;

            String command_export = String.Format(@"SELECT bpd.exp_object_with_prop_by_global_prop_from_con_to_excel({0},'{1}')", GlobalProp.Id, find_mask);
            String Desc = String.Format(@"Отчет: Объекты концепции по маске значения глобального свойтсва: {0} = {1} | Режим: {2}", GlobalProp.Name, find_mask, manager.ExportMode(eBaseExportFormat.ReportEntityWithProp));
            command_export cm = new command_export(cmdk, command_export, Desc);
            return cm;
        }
        #endregion
        //*****************************************************************************************

        #region ПРОЦЕДУРА ЭКСПОРТА В EXCEL
        /// <summary>
        /// Метод экспорта объектов (со свойствами) позиции по маске значения глобального свойства
        /// exp_object_with_prop_by_global_prop_from_con_to_excel
        /// </summary>
        internal Byte[] export_object_with_prop_by_global_prop_from_pos_to_excel(Int64 iid_global_prop, Int64 iid_position, String find_mask)
        {
            Byte[] Result = null;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("exp_object_with_prop_by_msk_global_prop_from_pos_to_excel", true);

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

            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;
            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["find_mask"].Value = find_mask;

            object tmp = cmdk.ExecuteScalar();

            if (tmp != DBNull.Value)
            {
                Result = (Byte[])tmp;
            }

            String command_export = String.Format(@"SELECT bpd.exp_object_with_prop_by_msk_global_prop_from_pos_to_excel({0}, {1}, '{2}')", iid_global_prop, iid_position, find_mask);
            //Генерируем событие завершения процедуры экспорта
            ExportCompletedEventArgs e = new ExportCompletedEventArgs(command_export, Result);
            ExportOnCompleted(e);
            return Result;
        }

        /// <summary>
        /// Метод экспорта объектов (со свойствами) позиции по маске значения глобального свойства
        /// exp_object_with_prop_by_global_prop_from_con_to_excel
        /// </summary>
        internal Byte[] export_object_with_prop_by_global_prop_from_pos_to_excel(global_prop GlobalProp, position Position, String find_mask)
        {
            return export_object_with_prop_by_global_prop_from_pos_to_excel(GlobalProp.Id, Position.Id, find_mask);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        internal Boolean export_object_with_prop_by_global_prop_from_pos_to_excel(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("exp_object_with_prop_by_msk_global_prop_from_pos_to_excel");
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
        #region ПРОЦЕДУРА СОЗДАНИЯ КОМАНДЫ ОТЛОЖЕННОГО ЭКСПОРТА В EXCEL
        /// <summary>
        /// Метод создания команды экспорта объектов (со свойствами) позиции по маске значения глобального свойства
        /// exp_object_with_prop_by_find_from_pos_to_excel
        /// </summary>
        internal command_export export_object_with_prop_by_global_prop_from_pos_to_excel_get_command(global_prop GlobalProp, position Position, String find_mask)
        {
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("exp_object_with_prop_by_msk_global_prop_from_pos_to_excel", true);

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

            cmdk.Parameters["iid_global_prop"].Value = GlobalProp.Id;
            cmdk.Parameters["iid_position"].Value = Position.Id;
            cmdk.Parameters["find_mask"].Value = find_mask;

            String command_export = String.Format(@"SELECT bpd.exp_object_with_prop_by_msk_global_prop_from_pos_to_excel({0}, {1},'{2}')", GlobalProp.Id, Position.Id, find_mask);
            String Desc = String.Format(@"Отчет: Объекты концепции по маске значения глобального свойтсва: {0} = {1} в позиции: {2}| Режим: {3}", GlobalProp.Name, Position.NamePosition, find_mask, manager.ExportMode(eBaseExportFormat.ReportEntityWithProp));
            command_export cm = new command_export(cmdk, command_export, Desc);
            return cm;
        }
        #endregion
        //*****************************************************************************************
    }
}
