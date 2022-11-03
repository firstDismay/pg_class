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
        /// Лист представлений активных дочерних классов по строгому соотвествию имени
        /// </summary>
        public List<vclass> class_act_by_id_parent_strict_name(Int64 iid_parent, String iname)
        {
            List<vclass> vclass_list = new List<vclass>();
            DataTable tbl_vclass = TableByName("vclass");
            NpgsqlCommandKey cmdk;
            
            cmdk = CommandByKey("class_act_by_id_parent_strict_name");
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

            cmdk.Parameters["iid_parent"].Value = iid_parent;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Fill(tbl_vclass);
            
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
        /// Лист представлений активных дочерних классов по строгому соотвествию имени
        /// </summary>
        public List<vclass> class_act_by_id_parent_strict_name(vclass Vclass_parent, String iname)
        {
            List<vclass> Result = null;
            switch (Vclass_parent.StorageType)
            {
                case eStorageType.Active:
                    Result = class_act_by_id_parent_strict_name(Vclass_parent.Id, iname);
                    break;
                case eStorageType.History:
                    throw new PgDataException(505, "Тип представления класса не соотвествует сигнатуре функции, требуется активное представление класса");
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_parent_strict_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            cmdk = CommandByKey("class_act_by_id_parent_strict_name");
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

        /// <summary>
        /// Лист представлений активных классов указанного расположения по маске имени
        /// </summary>
        public List<vclass> class_act_by_id_parent_msk_name(Int64 iid_parent, String name_mask)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass  = TableByName("vclass");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("class_act_by_id_parent_msk_name");

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
            

            cmdk.Parameters["iid_parent"].Value = iid_parent;
            cmdk.Parameters["name_mask"].Value = name_mask;

            cmdk.Fill(tbl_vclass);
            
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
        /// Лист представлений активных классов указанного расположения по маске имени
        /// </summary>
        public List<vclass> class_act_by_id_parent_msk_name(vclass Vclass_parent, String name_mask)
        {
            return class_act_by_id_parent_msk_name(Vclass_parent.Id, name_mask); 
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_parent_msk_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("class_act_by_id_parent_msk_name");
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

        /// <summary>
        /// Лист представлений активных классов указанного расположения по маске имени
        /// </summary>
        public List<vclass> class_act_by_id_group_msk_name(Int64 iid_group, String name_mask)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("class_act_by_id_group_msk_name");

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
            

            cmdk.Parameters["iid_group"].Value = iid_group;
            cmdk.Parameters["name_mask"].Value = name_mask;

            cmdk.Fill(tbl_vclass);
            
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
        /// Лист представлений активных классов указанного расположения по маске имени
        /// </summary>
        public List<vclass> class_act_by_id_group_msk_name(group Group, String name_mask)
        {
            return class_act_by_id_group_msk_name(Group.Id, name_mask);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_group_msk_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("class_act_by_id_group_msk_name");
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
        
        /// <summary>
        /// Лист представлений активных классов концепции по маске имени
        /// </summary>
        public List<vclass> class_act_by_id_conception_msk_name(Int64 iid_conception, String name_mask)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass  = TableByName("vclass");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("class_act_by_id_conception_msk_name");

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
            

            cmdk.Parameters["iid_conception"].Value = iid_conception;
            cmdk.Parameters["name_mask"].Value = name_mask;

            cmdk.Fill(tbl_vclass);
            
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
        /// Лист представлений активных классов концепции по маске имени
        /// </summary>
        public List<vclass> class_act_by_id_conception_msk_name(conception Conception, String name_mask)
        {
            return class_act_by_id_conception_msk_name(Conception.Id, name_mask);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_by_id_conception_msk_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("class_act_by_id_conception_msk_name");
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
