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
        #region ПРОЦЕДУРЫ ПРЯМОГО ЭКСПОРТА КЛАССОВ СО СВОЙСТВАМИ ПО ИД АБСТРАКТНОГО КЛАССА НОСИТЕЛЯ В EXCEL
        /// <summary>
        /// Метод экспорта классов со свойствами в Excel для указанного класса носителя
        /// </summary>
        internal Byte[] export_class_act_with_prop_by_id_parent_to_excel(Int64 iid_class_parent)
        {
            Byte[] Result = null;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("exp_class_act_with_prop_by_id_parent_to_excel");

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


            cmdk.Parameters["iid_class_parent"].Value = iid_class_parent;
            object tmp = cmdk.ExecuteScalar();

            if (tmp != DBNull.Value)
            {
                Result = (Byte[])tmp;
            }

            String command_export = String.Format(@"SELECT bpd.exp_class_act_with_prop_by_id_parent_to_excel({0})", iid_class_parent);
            //Генерируем событие завершения процедуры экспорта
            ExportCompletedEventArgs e = new ExportCompletedEventArgs(command_export, Result);
            ExportOnCompleted(e);
            return Result;
        }

        /// <summary>
        /// Метод экспорта классов со свойствами в Excel для указанного класса носителя
        /// </summary>
        internal Byte[] export_class_act_with_prop_by_id_parent_to_excel(vclass Class_parent)
        {
            return export_class_act_with_prop_by_id_parent_to_excel(Class_parent.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        internal Boolean export_class_act_with_prop_by_id_parent_to_excel(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("exp_class_act_with_prop_by_id_parent_to_excel");
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
        #region ПРОЦЕДУРА СОЗДАНИЯ КОМАНДЫ ОТЛОЖЕННОГО ЭКСПОРТА КЛАССОВ СО СВОЙСТВАМИ ПО ИД АБСТРАКТНОГО КЛАССА НОСИТЕЛЯ В EXCEL
        /// <summary>
        /// Метод создания команды экспорта классов со свойствами в Excel для указанного класса носителя
        /// </summary>
        internal command_export export_class_act_with_prop_by_id_parent_to_excel_get_command(vclass Class_Parent)
        {
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("exp_class_act_with_prop_by_id_parent_to_excel", true);

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

            cmdk.Parameters["iid_class_parent"].Value = Class_Parent.Id;

            String command_export = String.Format(@"SELECT bpd.exp_class_act_with_prop_by_id_parent_to_excel({0})", Class_Parent.Id);
            String Desc = String.Format(@"Отчет: Активные классы класса носителя: {0} | Режим: {1}", Class_Parent.Name, "Отчет");
            command_export cm = new command_export(cmdk, command_export, Desc);
            return cm;
        }
        #endregion
        //*****************************************************************************************

        #region ПРОЦЕДУРЫ ПРЯМОГО ЭКСПОРТА КЛАССОВ СО СВОЙСТВАМИ ПО ИД ГРУППЫ В EXCEL
        /// <summary>
        /// Метод экспорта классов со свойствами в Excel для указанной группы носителя
        /// </summary>
        internal Byte[] export_class_act_with_prop_by_id_group_to_excel(Int64 iid_group)
        {
            Byte[] Result = null;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("exp_class_act_with_prop_by_id_group_to_excel");

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

            cmdk.Parameters["iid_group"].Value = iid_group;
            object tmp = cmdk.ExecuteScalar();

            if (tmp != DBNull.Value)
            {
                Result = (Byte[])tmp;
            }

            String command_export = String.Format(@"SELECT bpd.exp_class_act_with_prop_by_id_group_to_excel({0})", iid_group);
            //Генерируем событие завершения процедуры экспорта
            ExportCompletedEventArgs e = new ExportCompletedEventArgs(command_export, Result);
            ExportOnCompleted(e);
            return Result;
        }

        /// <summary>
        /// Метод экспорта классов со свойствами в Excel для указанной группы носителя
        /// </summary>
        internal Byte[] export_class_act_with_prop_by_id_group_to_excel(group Group_parent)
        {
            return export_class_act_with_prop_by_id_group_to_excel(Group_parent.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        internal Boolean export_class_act_with_prop_by_id_group_to_excel(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("exp_class_act_with_prop_by_id_group_to_excel");
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
        #region ПРОЦЕДУРА СОЗДАНИЯ КОМАНДЫ ОТЛОЖЕННОГО ЭКСПОРТА КЛАССОВ СО СВОЙСТВАМИ ПО ИД ГРУППЫ В EXCEL
        /// <summary>
        /// Метод создания команды экспорта классов со свойствами в Excel для указанной группы носителя
        /// </summary>
        internal command_export export_class_act_with_prop_by_id_group_to_excel_get_command(group Group_Parent)
        {
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("exp_class_act_with_prop_by_id_group_to_excel", true);

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

            cmdk.Parameters["iid_group"].Value = Group_Parent.Id;
            String command_export = String.Format(@"SELECT bpd.exp_class_act_with_prop_by_id_group_to_excel({0})", Group_Parent.Id);
            String Desc = String.Format(@"Отчет: Активные классы класса носителя: {0} | Режим: {1}", Group_Parent.Name, "Отчет");
            command_export cm = new command_export(cmdk, command_export, Desc);
            return cm;
        }
        #endregion
        //*****************************************************************************************

        #region ПРОЦЕДУРЫ ПРЯМОГО ЭКСПОРТА ВЕЩЕСТВЕННЫХ КЛАССОВ СО СВОЙСТВАМИ ПО ИД АБСТРАКТНОГО КЛАССА РЕКУРСИВНО В EXCEL
        /// <summary>
        /// Метод экспорта вещественных классов со свойствами в Excel для указанного класса носителя
        /// </summary>
        internal Byte[] export_class_act_real_with_prop_by_id_parent_to_excel(Int64 iid_class_parent)
        {
            Byte[] Result = null;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("exp_class_act_real_with_prop_by_id_parent_to_excel");

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

            cmdk.Parameters["iid_class_parent"].Value = iid_class_parent;
            object tmp = cmdk.ExecuteScalar();

            if (tmp != DBNull.Value)
            {
                Result = (Byte[])tmp;
            }

            String command_export = String.Format(@"SELECT bpd.exp_class_act_real_with_prop_by_id_parent_to_excel({0})", iid_class_parent);
            //Генерируем событие завершения процедуры экспорта
            ExportCompletedEventArgs e = new ExportCompletedEventArgs(command_export, Result);
            ExportOnCompleted(e);
            return Result;
        }

        /// <summary>
        /// Метод экспорта вещественных классов со свойствами в Excel для указанного класса носителя
        /// </summary>
        internal Byte[] export_class_act_real_with_prop_by_id_parent_to_excel(vclass Class_parent)
        {
            return export_class_act_real_with_prop_by_id_parent_to_excel(Class_parent.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        internal Boolean export_class_act_real_with_prop_by_id_parent_to_excel(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("exp_class_act_real_with_prop_by_id_parent_to_excel");
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
        #region ПРОЦЕДУРА СОЗДАНИЯ КОМАНДЫ ОТЛОЖЕННОГО ЭКСПОРТА ВЕЩЕСТВЕННЫХ КЛАССОВ СО СВОЙСТВАМИ ПО ИД АБСТРАКТНОГО КЛАССА РЕКУРСИВНО В EXCEL
        /// <summary>
        /// Метод создания команды экспорта вещественных классов со свойствами в Excel для указанного класса носителя
        /// </summary>
        internal command_export export_class_act_real_with_prop_by_id_parent_to_excel_get_command(vclass Class_Parent)
        {
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("exp_class_act_real_with_prop_by_id_parent_to_excel", true);

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

            cmdk.Parameters["iid_class_parent"].Value = Class_Parent.Id;
            String command_export = String.Format(@"SELECT bpd.exp_class_act_real_with_prop_by_id_parent_to_excel({0})", Class_Parent.Id);
            String Desc = String.Format(@"Отчет: Активные вещественные классы класса носителя: {0} | Режим: {1}", Class_Parent.Name, "Отчет");
            command_export cm = new command_export(cmdk, command_export, Desc);
            return cm;
        }
        #endregion
        //*****************************************************************************************
            
        #region ПРОЦЕДУРЫ ПРЯМОГО ЭКСПОРТА ВЕЩЕСТВЕННЫХ КЛАССОВ СО СВОЙСТВАМИ ПО ИД ГРУППЫ РЕКУРСИВНО В EXCEL
        /// <summary>
        /// Метод экспорта вещественных классов со свойствами в Excel для указанного класса носителя
        /// </summary>
        internal Byte[] export_class_act_real_with_prop_by_id_group_to_excel(Int64 iid_group)
        {
            Byte[] Result = null;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("exp_class_act_real_with_prop_by_id_group_to_excel");

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

            cmdk.Parameters["iid_group"].Value = iid_group;
            object tmp = cmdk.ExecuteScalar();

            if (tmp != DBNull.Value)
            {
                Result = (Byte[])tmp;
            }

            String command_export = String.Format(@"SELECT bpd.exp_class_act_real_with_prop_by_id_group_to_excel({0})", iid_group);
            //Генерируем событие завершения процедуры экспорта
            ExportCompletedEventArgs e = new ExportCompletedEventArgs(command_export, Result);
            ExportOnCompleted(e);
            return Result;
        }

        /// <summary>
        /// Метод экспорта вещественных классов со свойствами в Excel для указанного класса носителя
        /// </summary>
        internal Byte[] export_class_act_real_with_prop_by_id_group_to_excel(group Group_parent)
        {
            return export_class_act_real_with_prop_by_id_group_to_excel(Group_parent.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        internal Boolean export_class_act_real_with_prop_by_id_group_to_excel(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("exp_class_act_real_with_prop_by_id_group_to_excel");
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
        #region ПРОЦЕДУРА СОЗДАНИЯ КОМАНДЫ ОТЛОЖЕННОГО ЭКСПОРТА ВЕЩЕСТВЕННЫХ КЛАССОВ СО СВОЙСТВАМИ ПО ИД ГРУППЫ РЕКУРСИВНО В EXCEL
        /// <summary>
        /// Метод создания команды экспорта вещественных классов со свойствами в Excel для указанного класса носителя
        /// </summary>
        internal command_export export_class_act_real_with_prop_by_id_group_to_excel_get_command(group Group_Parent)
        {
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("exp_class_act_real_with_prop_by_id_group_to_excel", true);

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

            cmdk.Parameters["iid_group"].Value = Group_Parent.Id;
            String command_export = String.Format(@"SELECT bpd.exp_class_act_real_with_prop_by_id_group_to_excel({0})", Group_Parent.Id);
            String Desc = String.Format(@"Отчет: Активные вещественные классы класса носителя: {0} | Режим: {1}", Group_Parent.Name, "Отчет");
            command_export cm = new command_export(cmdk, command_export,Desc);
            return cm;
        }
        #endregion
        //*****************************************************************************************
    }
}
