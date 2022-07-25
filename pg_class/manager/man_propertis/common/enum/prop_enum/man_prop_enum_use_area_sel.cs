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
        /// Лист доступных областей назначения для перечислений
        /// </summary>
        public List<prop_enum_use_area> prop_enum_use_area_by_all()
        {
            List<prop_enum_use_area> prop_enum_use_area_list = new List<prop_enum_use_area>();


            DataTable tbl_data_type  = TableByName("vprop_enum_use_area");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("prop_enum_use_area_by_all");

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

            cmdk.Fill(tbl_data_type);
            
            prop_enum_use_area prop_enum_use_area;
            if (tbl_data_type.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_data_type.Rows)
                {
                    prop_enum_use_area = new prop_enum_use_area(dr);
                    prop_enum_use_area_list.Add(prop_enum_use_area);
                }
            }
            return prop_enum_use_area_list;
        }


        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_use_area_by_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_use_area_by_all");
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
        public prop_enum_use_area prop_enum_use_area_by_id(Int32 id)
        {
            prop_enum_use_area prop_enum_use_area = null;

            DataTable tbl_type  = TableByName("vprop_enum_use_area");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("prop_enum_use_area_by_id");

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

            cmdk.Fill(tbl_type);
            
            if (tbl_type.Rows.Count > 0)
            {
                prop_enum_use_area = new prop_enum_use_area(tbl_type.Rows[0]);
            }

            return prop_enum_use_area;
        }


        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_use_area_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_use_area_by_id");
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
