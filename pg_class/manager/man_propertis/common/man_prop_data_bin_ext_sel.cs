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

            cmdk.Fill(tbl_prop);
            
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


        //ACCESS
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

            cmdk.Fill(tbl_prop);
            
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


        //ACCESS
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

            cmdk.Fill(tbl_prop);
            
            if (tbl_prop.Rows.Count > 0)
            {
                prop_data_bin_ext = new prop_data_bin_ext(tbl_prop.Rows[0]);
            }

            return prop_data_bin_ext;
        }


        //ACCESS
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
    }
}
