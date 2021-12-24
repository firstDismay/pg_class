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

namespace pg_class
{
    public partial class manager
    {
        #region ПОИСК КЛАССОВ ПО МАСКЕ ИМЕНИ ГЛОБАЛЬНОГО СВОЙСТВА
        #region FAST
        /// <summary>
        /// Лист представлений активных классов по маске значения глобального свойства
        /// </summary>
        public List<vclass> class_act_by_msk_global_prop(Int64 iid_global_prop, String find_mask, Boolean class_real_only)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_by_msk_global_prop");

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
            cmdk.Parameters["class_real_only"].Value = class_real_only;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных классов по маске значения глобального свойства
        /// </summary>
        public List<vclass> class_act_by_msk_global_prop(global_prop Global_prp, String find_mask, Boolean class_real_only)
        { 
            return class_act_by_msk_global_prop(Global_prp.Id, find_mask, class_real_only);
        }

        //-=EXPORT TO EXCEL=-**************************************************************************
        /// <summary>
        /// Экспорт представлений активных классов по маске значения глобального свойства
        /// </summary>
        public Byte[] class_act_by_msk_global_prop(Int64 iid_global_prop, String find_mask, Boolean class_real_only, eBaseExportFormat ExportFormat)
        {
            Byte[] Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.class_act_by_msk_global_prop({0}, '{1}', {2})", iid_global_prop, find_mask, class_real_only);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT c.* FROM ONLY bpd.class c JOIN bpd.class_act_by_msk_global_prop({0}, '{1}', {2}) f ON f.id = c.id", iid_global_prop, find_mask, class_real_only);
                    break;
            }
            Result = export_to_excel(command_export);
            return Result;
        }

        /// <summary>
        /// Команда экспорта представлений активных классов по маске значения глобального свойства
        /// </summary>
        public command_export class_act_by_msk_global_prop_command_export(Int64 iid_global_prop, String find_mask, Boolean class_real_only, eBaseExportFormat ExportFormat)
        {
            command_export Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.class_act_by_msk_global_prop({0}, '{1}', {2})", iid_global_prop, find_mask, class_real_only);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT c.* FROM ONLY bpd.class c JOIN bpd.class_act_by_msk_global_prop({0}, '{1}', {2}) f ON f.id = c.id", iid_global_prop, find_mask, class_real_only);
                    break;
            }
            
            String desc = String.Format(@"Экпорт: Активные классы по маске значения глобального свойства: {0} | Маска значения: {1} | Режим: {2}", global_prop_by_id(iid_global_prop).Name, find_mask, manager.ExportMode(ExportFormat));
            Result = export_to_excel_get_command(command_export, desc);
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_by_msk_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_by_msk_global_prop");
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

        #region EXT
        /// <summary>
        /// Лист представлений активных классов по маске значения глобального свойства
        /// </summary>
        public List<vclass> class_act_ext_by_msk_global_prop(Int64 iid_global_prop, String find_mask, Boolean class_real_only)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_ext_by_msk_global_prop");

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
            cmdk.Parameters["class_real_only"].Value = class_real_only;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных классов по маске значения глобального свойства
        /// </summary>
        public List<vclass> class_act_ext_by_msk_global_prop(global_prop Global_prp, String find_mask, Boolean class_real_only)
        {
            return class_act_ext_by_msk_global_prop(Global_prp.Id, find_mask, class_real_only);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_ext_by_msk_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_ext_by_msk_global_prop");
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
        #endregion

        #region ПОИСК КЛАССОВ ПО МАСКЕ ИМЕНИ ГЛОБАЛЬНОГО СВОЙСТВА И ИДЕНТИФИКАТОРУ КЛАССА РЕКУРСИВНО
        #region FAST
        /// <summary>
        /// Лист представлений активных классов по маске значения глобального свойства
        /// </summary>
        public List<vclass> class_act_by_msk_global_prop_from_class(Int64 iid_global_prop, Int64 iid_class, String find_mask, Boolean class_real_only)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_by_msk_global_prop_from_class");

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
            cmdk.Parameters["iid_class"].Value = iid_class;
            cmdk.Parameters["find_mask"].Value = find_mask;
            cmdk.Parameters["class_real_only"].Value = class_real_only;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных классов по маске значения глобального свойства
        /// </summary>
        public List<vclass> class_act_by_msk_global_prop_from_class(global_prop Global_prp, vclass Class, String find_mask, Boolean class_real_only)
        {
            return class_act_by_msk_global_prop_from_class(Global_prp.Id, Class.Id, find_mask, class_real_only);
        }

        //-=EXPORT TO EXCEL=-**************************************************************************
        /// <summary>
        /// Экспорт представлений активных классов по маске значения глобального свойства
        /// </summary>
        public Byte[] class_act_by_msk_global_prop_from_class(Int64 iid_global_prop, Int64 iid_class, String find_mask, Boolean class_real_only, eBaseExportFormat ExportFormat)
        {
            Byte[] Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.class_act_by_msk_global_prop_from_class({0}, {1}, '{2}', {3})", iid_global_prop, iid_class, find_mask, class_real_only);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT c.* FROM ONLY bpd.class c JOIN bpd.class_act_by_msk_global_prop_from_class({0}, {1}, '{2}', {3}) f ON f.id = c.id", iid_global_prop, iid_class, find_mask, class_real_only);
                    break;
            }
            Result = export_to_excel(command_export);
            return Result;
        }

        /// <summary>
        /// Команда экспорта представлений активных классов по маске значения глобального свойства
        /// </summary>
        public command_export class_act_by_msk_global_prop_from_class_command_export(Int64 iid_global_prop, Int64 iid_class, String find_mask, Boolean class_real_only, eBaseExportFormat ExportFormat)
        {
            command_export Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.class_act_by_msk_global_prop_from_class({0}, {1}, '{2}', {3})", iid_global_prop, iid_class, find_mask, class_real_only);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT c.* FROM ONLY bpd.class c JOIN bpd.class_act_by_msk_global_prop_from_class({0}, {1}, '{2}', {3}) f ON f.id = c.id", iid_global_prop, iid_class, find_mask, class_real_only);
                    break;
            }

            String desc = String.Format(@"Экпорт: Активные классы по маске значения глобального свойства: {0} | Маска значения: {1} | Режим: {2}", global_prop_by_id(iid_global_prop).Name, find_mask, manager.ExportMode(ExportFormat));
            Result = export_to_excel_get_command(command_export, desc);
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_msk_global_prop_from_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_by_msk_global_prop_from_class");
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

        #region EXT
        /// <summary>
        /// Лист представлений активных классов по маске значения глобального свойства
        /// </summary>
        public List<vclass> class_act_ext_by_msk_global_prop_from_class(Int64 iid_global_prop, Int64 iid_class, String find_mask, Boolean class_real_only)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_ext_by_msk_global_prop_from_class");

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
            cmdk.Parameters["iid_class"].Value = iid_class;
            cmdk.Parameters["find_mask"].Value = find_mask;
            cmdk.Parameters["class_real_only"].Value = class_real_only;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных классов по маске значения глобального свойства
        /// </summary>
        public List<vclass> class_act_ext_by_msk_global_prop_from_class(global_prop Global_prp, vclass Class, String find_mask, Boolean class_real_only)
        {
            return class_act_ext_by_msk_global_prop_from_class(Global_prp.Id, Class.Id, find_mask, class_real_only);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_ext_by_msk_global_prop_from_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_ext_by_msk_global_prop_from_class");
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
        #endregion

        #region ПОИСК КЛАССОВ ПО МАСКЕ ИМЕНИ ГЛОБАЛЬНОГО СВОЙСТВА И ИДЕНТИФИКАТОРУ ГРУППЫ РЕКУРСИВНО
        #region FAST
        /// <summary>
        /// Лист представлений активных классов по маске значения глобального свойства
        /// </summary>
        public List<vclass> class_act_by_msk_global_prop_from_group(Int64 iid_global_prop, Int64 iid_group, String find_mask, Boolean class_real_only)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_by_msk_global_prop_from_group");

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
            cmdk.Parameters["iid_group"].Value = iid_group;
            cmdk.Parameters["find_mask"].Value = find_mask;
            cmdk.Parameters["class_real_only"].Value = class_real_only;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных классов по маске значения глобального свойства
        /// </summary>
        public List<vclass> class_act_by_msk_global_prop_from_group(global_prop Global_prp, group Group, String find_mask, Boolean class_real_only)
        {
            return class_act_by_msk_global_prop_from_group(Global_prp.Id, Group.Id, find_mask, class_real_only);
        }

        //-=EXPORT TO EXCEL=-**************************************************************************
        /// <summary>
        /// Экспорт представлений активных классов по маске значения глобального свойства
        /// </summary>
        public Byte[] class_act_by_msk_global_prop_from_group(Int64 iid_global_prop, Int64 iid_group, String find_mask, Boolean class_real_only, eBaseExportFormat ExportFormat)
        {
            Byte[] Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.class_act_by_msk_global_prop_from_group({0}, {1}, '{2}', {3})", iid_global_prop, iid_group, find_mask, class_real_only);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT c.* FROM ONLY bpd.class c JOIN bpd.class_act_by_msk_global_prop_from_group({0}, {1}, '{2}', {3}) f ON f.id = c.id", iid_global_prop, iid_group, find_mask, class_real_only);
                    break;
            }
            Result = export_to_excel(command_export);
            return Result;
        }

        /// <summary>
        /// Команда экспорта представлений активных классов по маске значения глобального свойства
        /// </summary>
        public command_export class_act_by_msk_global_prop_from_group_command_export(Int64 iid_global_prop, Int64 iid_group, String find_mask, Boolean class_real_only, eBaseExportFormat ExportFormat)
        {
            command_export Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.class_act_by_msk_global_prop_from_group({0}, {1}, '{2}', {3})", iid_global_prop, iid_group, find_mask, class_real_only);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT c.* FROM ONLY bpd.class c JOIN bpd.class_act_by_msk_global_prop_from_group({0}, {1}, '{2}', {3}) f ON f.id = c.id", iid_global_prop, iid_group, find_mask, class_real_only);
                    break;
            }

            String desc = String.Format(@"Экпорт: Активные классы по маске значения глобального свойства: {0} | Маска значения: {1} | Режим: {2}", global_prop_by_id(iid_global_prop).Name, find_mask, manager.ExportMode(ExportFormat));
            Result = export_to_excel_get_command(command_export, desc);
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_msk_global_prop_from_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_by_msk_global_prop_from_group");
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

        #region EXT
        /// <summary>
        /// Лист представлений активных классов по маске значения глобального свойства
        /// </summary>
        public List<vclass> class_act_ext_by_msk_global_prop_from_group(Int64 iid_global_prop, Int64 iid_group, String find_mask, Boolean class_real_only)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_act_ext_by_msk_global_prop_from_group");

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
            cmdk.Parameters["iid_group"].Value = iid_group;
            cmdk.Parameters["find_mask"].Value = find_mask;
            cmdk.Parameters["class_real_only"].Value = class_real_only;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_vclass);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            vclass vc;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    vc = new vclass(dr);
                    vclass_list.Add(vc);
                }
            }
            return vclass_list;
        }

        /// <summary>
        /// Лист представлений активных классов по маске значения глобального свойства
        /// </summary>
        public List<vclass> class_act_ext_by_msk_global_prop_from_group(global_prop Global_prp, group Group, String find_mask, Boolean class_real_only)
        {
            return class_act_ext_by_msk_global_prop_from_group(Global_prp.Id, Group.Id, find_mask, class_real_only);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_ext_by_msk_global_prop_from_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_ext_by_msk_global_prop_from_group");
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
        #endregion

    }
}
