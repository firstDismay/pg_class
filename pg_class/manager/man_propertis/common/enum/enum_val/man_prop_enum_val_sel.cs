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
        /// Выбрать элемент перечисления для свойства по идентификатору перечисления
        /// </summary>
        public prop_enum_val prop_enum_val_by_id(Int64 iid_prop_enum_val)
        {
            prop_enum_val prop_enum_val = null;

            DataTable tbl_entity  = TableByName("vprop_enum_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("prop_enum_val_by_id");

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

            cmdk.Parameters["iid_prop_enum_val"].Value = iid_prop_enum_val;

            cmdk.Fill(tbl_entity);
            
            if (tbl_entity.Rows.Count > 0)
            {
                prop_enum_val = new prop_enum_val(tbl_entity.Rows[0]);
            }
            return prop_enum_val;
        }
        
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_val_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_val_by_id");
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
        ///  Выбрать все элементы перечисления для свойства по идентификатору перечисления
        /// </summary>
        public List<prop_enum_val> prop_enum_val_by_id_prop_enum( Int64 iid_prop_enum)
        {
            List<prop_enum_val> entity_list = new List<prop_enum_val>();

            DataTable tbl_entity  = TableByName("vprop_enum_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("prop_enum_val_by_id_prop_enum");

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

            cmdk.Parameters["iid_prop_enum"].Value = iid_prop_enum;

            cmdk.Fill(tbl_entity);
            
            prop_enum_val prop_enum_val;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    prop_enum_val = new prop_enum_val(dr);
                    entity_list.Add(prop_enum_val);
                }
            }
            return entity_list;
        }

        /// <summary>
        ///  Выбрать все элементы перечисления для свойства по идентификатору перечисления
        /// </summary>
        public List<prop_enum_val> prop_enum_val_by_id_prop_enum(prop_enum Prop_enum)
        {
            return prop_enum_val_by_id_prop_enum(Prop_enum.Id_prop_enum);
        }
        
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_val_by_id_prop_enum(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_val_by_id_prop_enum");
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
