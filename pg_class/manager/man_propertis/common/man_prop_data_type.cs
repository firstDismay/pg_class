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
        #region МЕТОДЫ КЛАССА: ТИПЫ ДАННЫХ СВОЙСТВ БД
        #region ВЫБРАТЬ


        /// <summary>
        /// Лист доступных типов данных свойств
        /// </summary>
        public List<prop_data_type> prop_data_type_by_all()
        {
            List<prop_data_type> data_type_list = new List<prop_data_type>();


            DataTable tbl_data_type  = TableByName("vprop_data_type");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("prop_data_type_by_all");

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
            
            prop_data_type data_type;
            if (tbl_data_type.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_data_type.Rows)
                {
                    data_type = new prop_data_type(dr);
                    data_type_list.Add(data_type);
                }
            }
            return data_type_list;
        }


        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_data_type_by_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_data_type_by_all");
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

        #region МЕТОДЫ КЛАССА: СПЕЦИФИКАТОРЫ ЗНАЧЕНИЙ СВОЙСТВ
        #region ВЫБРАТЬ


        /// <summary>
        /// Лист действующих спецификаторов значения свойства
        /// </summary>
        public prop_val_spec prop_val_spec_by_id_data_type(Int32 iid_data_type)
        {
            prop_val_spec prop_val_spec = null;


            DataTable tbl_prop_val_spec  = TableByName("vcfg_prop_spec_limit2");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("prop_val_spec_by_id_data_type");

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

            cmdk.Parameters["iid_data_type"].Value = iid_data_type;

            cmdk.Fill(tbl_prop_val_spec);
            
            if (tbl_prop_val_spec.Rows.Count > 0)
            {
                 prop_val_spec = new prop_val_spec(tbl_prop_val_spec.Rows[0]);
    
            }
            return prop_val_spec;
        }


        /// <summary>
        /// Лист действующих спецификаторов значения свойства
        /// </summary>
        public prop_val_spec prop_val_spec_by_id_data_type(eDataType Data_type)
        {
            return prop_val_spec_by_id_data_type((Int32)Data_type);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_val_spec_by_id_data_type(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_val_spec_by_id_data_type");
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
