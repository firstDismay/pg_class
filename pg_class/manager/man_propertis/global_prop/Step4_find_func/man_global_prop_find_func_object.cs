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
        #region ПОИСК ОБЪЕКТОВ ПО МАСКЕ ИМЕНИ ГЛОБАЛЬНОГО СВОЙСТВА
        #region FAST
        /// <summary>
        /// Лист объектов по маске значения глобального свойства
        /// </summary>
        public List<object_general> object_by_msk_global_prop(Int64 iid_global_prop, String find_mask)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_by_msk_global_prop");

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

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов по маске значения глобального свойства
        /// </summary>
        public List<object_general> object_by_msk_global_prop(global_prop Global_prp, String find_mask)
        {
            return object_by_msk_global_prop(Global_prp.Id, find_mask);
        }

        //-=EXPORT TO EXCEL=-**************************************************************************
        /// <summary>
        /// Экспорт Лист объектов по маске значения глобального свойства
        /// </summary>
        public Byte[] object_by_msk_global_prop(Int64 iid_global_prop, String find_mask, eBaseExportFormat ExportFormat)
        {
            Byte[] Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.object_by_msk_global_prop({0}, '{1}')", iid_global_prop, find_mask);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT o.* FROM bpd.object o  JOIN bpd.object_by_msk_global_prop({0}, '{1}') f ON f.id = o.id", iid_global_prop, find_mask);
                    break;
                default:
                    command_export = String.Format(@"SELECT * FROM bpd.object_by_msk_global_prop({0}, '{1}')", iid_global_prop, find_mask);
                    break;
            }
            Result = export_to_excel(command_export);
            return Result;
        }

        /// <summary>
        /// Команда экспорта листа объектов по маске значения глобального свойства
        /// </summary>
        public command_export object_by_msk_global_prop_command_export(Int64 iid_global_prop, String find_mask, eBaseExportFormat ExportFormat)
        {
            command_export Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.object_by_msk_global_prop({0}, '{1}')", iid_global_prop, find_mask);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT o.* FROM bpd.object o  JOIN bpd.object_by_msk_global_prop({0}, '{1}') f ON f.id = o.id", iid_global_prop, find_mask);
                    break;
                default:
                    command_export = String.Format(@"SELECT * FROM bpd.object_by_msk_global_prop({0}, '{1}')", iid_global_prop, find_mask);
                    break;
            }
            
            String desc = String.Format(@"Экпорт: Объекты по маске значения глобального свойства: {0} | Маска значения: {1} | Режим: {2}", global_prop_by_id(iid_global_prop).Name, find_mask, manager.ExportMode(ExportFormat));
            Result = export_to_excel_get_command(command_export, desc);
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_msk_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_by_msk_global_prop");
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
        /// Лист объектов по маске значения глобального свойства
        /// </summary>
        public List<object_general> object_ext_by_msk_global_prop(Int64 iid_global_prop, String find_mask)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_by_msk_global_prop");

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

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов по маске значения глобального свойства
        /// </summary>
        public List<object_general> object_ext_by_msk_global_prop(global_prop Global_prp, String find_mask)
        {
            return object_ext_by_msk_global_prop(Global_prp.Id, find_mask);
        }

        

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_msk_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_by_msk_global_prop");
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

        #region ПОИСК ОБЪЕКТОВ НОСИТЕЛЕЙ ПО МАСКЕ ИМЕНИ ГЛОБАЛЬНОГО СВОЙСТВА ОБЪЕКТА ЗНАЧЕНИЯ ОБЪЕКТНОГО СВОЙСТВА
        #region FAST
        /// <summary>
        /// Лист объектов носителей по маске значения глобального свойства объекта значения объектного свойства
        /// </summary>
        public List<object_general> object_carrier_by_msk_global_prop(Int64 iid_global_prop, String find_mask)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_carrier_by_msk_global_prop");

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

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов носителей по маске значения глобального свойства объекта значения объектного свойства
        /// </summary>
        public List<object_general> object_carrier_by_msk_global_prop(global_prop Global_prp, String find_mask)
        {
            return object_carrier_by_msk_global_prop(Global_prp.Id, find_mask);
        }

        //-=EXPORT TO EXCEL=-**************************************************************************
        /// <summary>
        /// Экспорт Лист объектов носителей по маске значения глобального свойства объекта значения объектного свойства
        /// </summary>
        public Byte[] object_carrier_by_msk_global_prop(Int64 iid_global_prop, String find_mask, eBaseExportFormat ExportFormat)
        {
            Byte[] Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.object_carrier_by_msk_global_prop({0}, '{1}')", iid_global_prop, find_mask);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT o.* FROM bpd.object o  JOIN bpd.object_carrier_by_msk_global_prop({0}, '{1}') f ON f.id = o.id", iid_global_prop, find_mask);
                    break;
                default:
                    command_export = String.Format(@"SELECT * FROM bpd.object_carrier_by_msk_global_prop({0}, '{1}')", iid_global_prop, find_mask);
                    break;
            }
            Result = export_to_excel(command_export);
            return Result;
        }

        /// <summary>
        /// Команда экспорта Лист объектов носителей по маске значения глобального свойства объекта значения объектного свойства
        /// </summary>
        public command_export object_carrier_by_msk_global_prop_command_export(Int64 iid_global_prop, String find_mask, eBaseExportFormat ExportFormat)
        {
            command_export Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.object_carrier_by_msk_global_prop({0}, '{1}')", iid_global_prop, find_mask);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT o.* FROM bpd.object o  JOIN bpd.object_carrier_by_msk_global_prop({0}, '{1}') f ON f.id = o.id", iid_global_prop, find_mask);
                    break;
                default:
                    command_export = String.Format(@"SELECT * FROM bpd.object_carrier_by_msk_global_prop({0}, '{1}')", iid_global_prop, find_mask);
                    break;
            }

            String desc = String.Format(@"Экпорт: Объекты по маске значения глобального свойства: {0} | Маска значения: {1} | Режим: {2}", global_prop_by_id(iid_global_prop).Name, find_mask, manager.ExportMode(ExportFormat));
            Result = export_to_excel_get_command(command_export, desc);
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_carrier_by_msk_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_carrier_by_msk_global_prop");
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
        /// Лист расширенных объектов носителей по маске значения глобального свойства объекта значения объектного свойства
        /// </summary>
        public List<object_general> object_ext_carrier_by_msk_global_prop(Int64 iid_global_prop, String find_mask)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_carrier_by_msk_global_prop");

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

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист расширенных объектов носителей по маске значения глобального свойства объекта значения объектного свойства
        /// </summary>
        public List<object_general> object_ext_carrier_by_msk_global_prop(global_prop Global_prp, String find_mask)
        {
            return object_ext_carrier_by_msk_global_prop(Global_prp.Id, find_mask);
        }



        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_carrier_by_msk_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_carrier_by_msk_global_prop");
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
        
        #region ПОИСК ОБЪЕКТОВ ПО МАСКЕ ИМЕНИ ГЛОБАЛЬНОГО СВОЙСТВА В УКАЗАННОЙ ПОЗИЦИИ
        #region FAST
        /// <summary>
        /// Лист объектов указанной позиции по маске значения глобального свойства 
        /// </summary>
        public List<object_general> object_by_msk_global_prop_from_pos(Int64 iid_global_prop, Int64 iid_position, String find_mask)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_by_msk_global_prop_from_pos");

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

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов указанной позиции по маске значения глобального свойства 
        /// </summary>
        public List<object_general> object_by_msk_global_prop_from_pos(global_prop Global_prp,  position Position, String find_mask)
        {
            return object_by_msk_global_prop_from_pos(Global_prp.Id, Position.Id, find_mask);
        }

        //-=EXPORT TO EXCEL=-**************************************************************************
        /// <summary>
        /// Экспорт Лист объектов указанной позиции по маске значения глобального свойства 
        /// </summary>
        public Byte[] object_by_msk_global_prop_from_pos(Int64 iid_global_prop, Int64 iid_position, String find_mask, eBaseExportFormat ExportFormat)
        {
            Byte[] Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.object_by_msk_global_prop_from_pos({0}, {1}, '{2}')", iid_global_prop, iid_position, find_mask);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT o.* FROM bpd.object o  JOIN bpd.object_by_msk_global_prop_from_pos({0}, {1}, '{2}') f ON f.id = o.id", iid_global_prop, iid_position, find_mask);
                    break;
                case eBaseExportFormat.ReportEntity:
                case eBaseExportFormat.ReportEntityWithProp:
                    command_export = String.Format(@"bpd.exp_object_with_prop_by_msk_global_prop_from_pos_to_excel(iid_global_prop bigint, iid_position bigint, find_mask character varying)", iid_global_prop, iid_position, find_mask);
                    break;
                default:
                    command_export = String.Format(@"SELECT * FROM bpd.object_by_msk_global_prop_from_pos({0}, {1}, '{2}')", iid_global_prop, iid_position, find_mask);
                    break;
            }
            Result = export_to_excel(command_export);
            return Result;
        }

        /// <summary>
        /// Команда экспорта листа объектов указанной позиции по маске значения глобального свойства 
        /// </summary>
        public command_export object_by_msk_global_prop_from_pos_command_export(Int64 iid_global_prop, Int64 iid_position, String find_mask, eBaseExportFormat ExportFormat)
        {
            command_export Result = null;
            String command_export = "";

            switch (ExportFormat)
            {
                case eBaseExportFormat.ViewEntity:
                    command_export = String.Format(@"SELECT * FROM bpd.object_by_msk_global_prop_from_pos({0}, {1}, '{2}')", iid_global_prop, iid_position, find_mask);
                    break;
                case eBaseExportFormat.TableEntity:
                    command_export = String.Format(@"SELECT o.* FROM bpd.object o  JOIN bpd.object_by_msk_global_prop_from_pos({0}, {1}, '{2}') f ON f.id = o.id", iid_global_prop, iid_position, find_mask);
                    break;
                default:
                    command_export = String.Format(@"SELECT * FROM bpd.object_by_msk_global_prop_from_pos({0}, {1}, '{2}')", iid_global_prop, iid_position, find_mask);
                    break;
            }
            
            String desc = String.Format(@"Экпорт: Объекты позиции: {0}, по маске значения глобального свойства: {1} | Маска значения: {2} | Режим: {3}",  pos_by_id(iid_position).NamePosition, global_prop_by_id(iid_global_prop).Name, find_mask, manager.ExportMode(ExportFormat));
            Result = export_to_excel_get_command(command_export, desc);
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_msk_global_prop_from_pos(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_by_msk_global_prop_from_pos");
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
        /// Лист объектов указанной позиции по маске значения глобального свойства 
        /// </summary>
        public List<object_general> object_ext_by_msk_global_prop_from_pos(Int64 iid_global_prop, Int64 iid_position, String find_mask)
        {
            List<object_general> object_list = new List<object_general>();


            DataTable tbl_object = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_ext_by_msk_global_prop_from_pos");

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

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов указанной позиции по маске значения глобального свойства 
        /// </summary>
        public List<object_general> object_ext_by_msk_global_prop_from_pos(global_prop Global_prp, position Position, String find_mask)
        {
            return object_ext_by_msk_global_prop_from_pos(Global_prp.Id, Position.Id, find_mask);
        }



        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_msk_global_prop_from_pos(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_ext_by_msk_global_prop_from_pos");
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
