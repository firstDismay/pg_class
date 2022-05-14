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
        /// Выбор свойства шаблона по идентификатору свойства
        /// </summary>
        public pos_temp_prop pos_temp_prop_by_id(Int64 iid)
        {
            pos_temp_prop pos_temp_prop = null;

            DataTable tbl_vpos_temp_prop  = TableByName("vpos_temp_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_prop_by_id");

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

            cmdk.Parameters["iid"].Value = iid;

            cmdk.Fill(tbl_vpos_temp_prop);
            
            if (tbl_vpos_temp_prop.Rows.Count > 0)
            {
                pos_temp_prop = new pos_temp_prop(tbl_vpos_temp_prop.Rows[0]);
            }
            return pos_temp_prop;
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_by_id");
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
        /// Выбор свойства шаблона по идентификатору глобального свойства
        /// </summary>
        public pos_temp_prop pos_temp_prop_by_id_global_prop(Int64 iid_pos_temp, Int64 iid_global_prop)
        {
            pos_temp_prop pos_temp_prop = null;

            DataTable tbl_vpos_temp_prop  = TableByName("vpos_temp_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_prop_by_id_global_prop");

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

            cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;
            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;

            cmdk.Fill(tbl_vpos_temp_prop);
            
            if (tbl_vpos_temp_prop.Rows.Count > 0)
            {
                pos_temp_prop = new pos_temp_prop(tbl_vpos_temp_prop.Rows[0]);
            }
            return pos_temp_prop;
        }

        /// <summary>
        /// Выбор свойства шаблона по идентификатору глобального свойства
        /// </summary>
        public pos_temp_prop pos_temp_prop_by_id_global_prop(pos_temp Pos_temp, global_prop Global_prop)
        {
            return pos_temp_prop_by_id_global_prop(Pos_temp.Id, Global_prop.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_by_id_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_by_id_global_prop");
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
        /// Лист свойств шаблона по идентификатору шаблона
        /// </summary>
        public List<pos_temp_prop> pos_temp_prop_by_id_pos_temp(Int64 iid_pos_temp)
        {
            List<pos_temp_prop> pos_temp_prop_list = new List<pos_temp_prop>();


            DataTable tbl_pos_temp_prop  = TableByName("vpos_temp_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_prop_by_id_pos_temp");

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

            cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;

            cmdk.Fill(tbl_pos_temp_prop);
            
            pos_temp_prop cp;
            if (tbl_pos_temp_prop.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_pos_temp_prop.Rows)
                {
                    cp = new pos_temp_prop(dr);
                    pos_temp_prop_list.Add(cp);
                }
            }
            return pos_temp_prop_list;
        }

        /// <summary>
        /// Лист свойств представления активного класса по идентификатору класса
        /// </summary>
        public List<pos_temp_prop> pos_temp_prop_by_id_pos_temp(pos_temp PosTemp)
        {
            return pos_temp_prop_by_id_pos_temp(PosTemp.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_by_id_pos_temp(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_by_id_pos_temp");
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
