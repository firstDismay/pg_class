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
        #region МЕТОДЫ КЛАССА: РАСШИРЕНИЕ ДВОИЧНЫХ ДАННЫХ
            #region ВЫБРАТЬ
      
        /// <summary>
        /// Лист доступных расширений бинарного свойства 
        /// </summary>
        public List<prop_data_bin_ext> prop_data_bin_ext_by_all()
        {
            List<prop_data_bin_ext> prop_list = new List<prop_data_bin_ext>();

            
            DataTable tbl_prop  = TableByName("prop_data_bin_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("prop_data_bin_ext_by_all");

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

            try
            {
                cmdk.Fill(tbl_prop);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            prop_data_bin_ext prop_ext;
            if (tbl_prop.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_prop.Rows)
                {
                    prop_ext = new prop_data_bin_ext(dr);
                    prop_list.Add(prop_ext);
                }
            }

            return prop_list;
        }

        /// <summary>
        /// Лист доступных расширений бинарного свойства 
        /// </summary>
        public List<String> prop_data_bin_ext_by_all2()
        {
            List<String> Result = new List<string>();

            List<prop_data_bin_ext> tmp = prop_data_bin_ext_by_all();
            if (tmp != null)
            {
                foreach (prop_data_bin_ext i in tmp)
                {
                    if (i.Name != "none")
                    {
                        Result.Add(i.Name);
                    }
                }
            }
            return Result;
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_data_bin_ext_by_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_data_bin_ext_by_all");
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
        //*********************************************************************************************

        /// <summary>
        /// Лист доступных расширений бинарного свойства для указанного типа свойства 
        /// </summary>
        public List<prop_data_bin_ext> prop_data_bin_ext_by_id_data_type(Int32 id_data_type)
        {
            List<prop_data_bin_ext> prop_list = new List<prop_data_bin_ext>();


            DataTable tbl_prop  = TableByName("prop_data_bin_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("prop_data_bin_ext_by_id_data_type");

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

            cmdk.Parameters["iid_data_type"].Value = id_data_type;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_prop);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            prop_data_bin_ext prop_ext;
            if (tbl_prop.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_prop.Rows)
                {
                    prop_ext = new prop_data_bin_ext(dr);
                    prop_list.Add(prop_ext);
                }
            }

            return prop_list;
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_data_bin_ext_by_id_data_type(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            cmdk = CommandByKey("prop_data_bin_ext_by_id_data_type");
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
        //*********************************************************************************************

        /////////////////////////////////////////////

        //*********************************************************************************************
        /// <summary>
        /// Расширение бинарного свойства по идентификатору
        /// </summary>
        public prop_data_bin_ext prop_data_bin_ext_by_id(Int64 id)
        {
            prop_data_bin_ext prop_data_bin_ext = null;

            DataTable tbl_prop  = TableByName("prop_data_bin_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("prop_data_bin_ext_by_id");

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

            cmdk.Parameters["iid"].Value = id;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_prop);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

            if (tbl_prop.Rows.Count > 0)
            {
                prop_data_bin_ext = new prop_data_bin_ext(tbl_prop.Rows[0]);
            }

            return prop_data_bin_ext;
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_data_bin_ext_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_data_bin_ext_by_id");
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
        //*********************************************************************************************

        #endregion
        #endregion

        #region МЕТОДЫ КЛАССА: ТИПЫ СВОЙСТВ
        #region ВЫБРАТЬ


        /// <summary>
        /// Лист доступных типов свойств
        /// </summary>
        public List<prop_type> prop_type_by_all()
        {
            List<prop_type> type_list = new List<prop_type>();


            DataTable tbl_data_type  = TableByName("vprop_type");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("prop_type_by_all");

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

            try
            {
                cmdk.Fill(tbl_data_type);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            prop_type data_type;
            if (tbl_data_type.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_data_type.Rows)
                {
                    data_type = new prop_type(dr);
                    type_list.Add(data_type);
                }
            }
            return type_list;
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_type_by_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_type_by_all");
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

        //*********************************************************************************************
        /// <summary>
        /// Тип  свойства по ИД
        /// </summary>
        public prop_type prop_type_by_id(Int32 id)
        {
            prop_type prop_type = null;

            DataTable tbl_type  = TableByName("vprop_type");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("prop_type_by_id");

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

            cmdk.Parameters["iid"].Value = id;

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_type);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

            if (tbl_type.Rows.Count > 0)
            {
                prop_type = new prop_type(tbl_type.Rows[0]);
            }

            return prop_type;
        }

      
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_type_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_type_by_id");
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
        //*********************************************************************************************

        #endregion
        #endregion

        #region МЕТОДЫ СВОЙСТВ КЛАССА: РЕЖИМЫ ВСТРАИВАНИЯ ОБЪЕКТОВ ДЛЯ ОБЪЕКТНЫХ СВОЙСТВ ПРИ СОЗДАНИИ ОБЪЕКТА НОСИТЕЛЯ
        #region ВЫБРАТЬ


        /// <summary>
        /// Лист режимов создания встроенных объектов при создании объектного свойства объекта
        /// </summary>
        public List<object_prop_create_emded_mode> object_prop_create_emded_mode_by_all()
        {
            List<object_prop_create_emded_mode> entity_list = new List<object_prop_create_emded_mode>();


            DataTable tbl_data_type  = TableByName("vobject_prop_create_emded_mode");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_prop_create_emded_mode_by_all");

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

            try
            {
                cmdk.Fill(tbl_data_type);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            object_prop_create_emded_mode item;
            if (tbl_data_type.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_data_type.Rows)
                {
                    item = new object_prop_create_emded_mode(dr);
                    entity_list.Add(item);
                }
            }
            return entity_list;
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_create_emded_mode_by_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_prop_create_emded_mode_by_all");
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

        #region МЕТОДЫ СВОЙСТВ КЛАССА: СТРОКОВЫЕ ПАТТЕРНЫ ДЛЯ ИМЕН ОБЪЕКТОВ
        #region ВЫБРАТЬ


        /// <summary>
        /// Лист доступных строковых паттернов для имен объектов
        /// </summary>
        public List<pattern_string> class_name_format_pattern_string_by_all()
        {
            List<pattern_string> pattern_string_list = new List<pattern_string>();


            DataTable tbl_pattern_string  = TableByName("vpattern_string");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_name_format_pattern_string_by_all");

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

            try
            {
                cmdk.Fill(tbl_pattern_string);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();
            pattern_string pattern_string;
            if (tbl_pattern_string.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pattern_string.Rows)
                {
                    pattern_string = new pattern_string(dr);
                    pattern_string_list.Add(pattern_string);
                }
            }
            return pattern_string_list;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_name_format_pattern_string_by_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_name_format_pattern_string_by_all");
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
