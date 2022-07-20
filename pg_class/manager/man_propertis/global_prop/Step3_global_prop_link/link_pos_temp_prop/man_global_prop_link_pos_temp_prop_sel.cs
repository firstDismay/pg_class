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
        /// Выбор ссылки глобального свойства на свойство класса по идентификатору ссылки
        /// </summary>
        public global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop_by_id(Int64 iid_global_prop, Int64 iid_pos_temp_prop)
        {
            global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop = null;

            DataTable tbl_vglobal_prop_link  = TableByName("vglobal_prop_link_pos_temp_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("global_prop_link_pos_temp_prop_by_id");

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
            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            cmdk.Fill(tbl_vglobal_prop_link);
            
            if (tbl_vglobal_prop_link.Rows.Count > 0)
            {
                global_prop_link_pos_temp_prop = new global_prop_link_pos_temp_prop(tbl_vglobal_prop_link.Rows[0]);
            }
            return global_prop_link_pos_temp_prop;
        }

        /// <summary>
        /// Выбор ссылки глобального свойства на свойство класса по идентификатору ссылки
        /// </summary>
        public global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop_by_id(global_prop GlobalProp, pos_temp_prop PosTempProp)
        {
            return global_prop_link_pos_temp_prop_by_id(GlobalProp.Id, PosTempProp.Id);
        }

        /// <summary>
        /// Выбор ссылки глобального свойства на свойство класса по идентификатору ссылки
        /// </summary>
        public global_prop_link_pos_temp_prop global_prop_link_pos_temp_prop_by_id(global_prop_link_pos_temp_prop GlobalPropLink)
        {
            return global_prop_link_pos_temp_prop_by_id(GlobalPropLink.Id_global_prop, GlobalPropLink.Id_pos_temp_prop);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_link_pos_temp_prop_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("global_prop_link_pos_temp_prop_by_id");
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
        /// Лист ссылок глобального свойства на свойства классов по идентификатору глобального свойства
        /// </summary>
        public List<global_prop_link_pos_temp_prop> global_prop_link_pos_temp_prop_by_id_global_prop(Int64 iid_global_prop)
        {
            List<global_prop_link_pos_temp_prop> global_prop_link_list = new List<global_prop_link_pos_temp_prop>();

            
            DataTable tbl_global_prop_link  = TableByName("vglobal_prop_link_pos_temp_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("global_prop_link_pos_temp_prop_by_id_global_prop");

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

            cmdk.Fill(tbl_global_prop_link);
            
            global_prop_link_pos_temp_prop gpl;
            if (tbl_global_prop_link.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_global_prop_link.Rows)
                {
                    gpl = new global_prop_link_pos_temp_prop(dr);
                    global_prop_link_list.Add(gpl);
                }
            }
            return global_prop_link_list;
        }

        /// <summary>
        /// Лист ссылок глобального свойства на свойства классов по идентификатору глобального свойства
        /// </summary>
        public List<global_prop_link_pos_temp_prop> global_prop_link_pos_temp_prop_by_id_global_prop(global_prop GlobalProp)
        {
            return global_prop_link_pos_temp_prop_by_id_global_prop(GlobalProp.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_link_pos_temp_prop_by_id_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("global_prop_link_pos_temp_prop_by_id_global_prop");
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
