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
        /// Выбор свойства активного представления класса по идентификатору свойства
        /// </summary>
        public class_prop class_prop_by_id(Int64 iid)
        {
            class_prop class_prop = null;

            DataTable tbl_vclass_prop  = TableByName("vclass_prop");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("class_prop_by_id");

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
            

            cmdk.Parameters["iid"].Value = iid;

            cmdk.Fill(tbl_vclass_prop);
            
            if (tbl_vclass_prop.Rows.Count > 0)
            {
                class_prop = new class_prop(tbl_vclass_prop.Rows[0]);
            }
            return class_prop;
        }


        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("class_prop_by_id");
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
        /// Выбор свойства активного представления класса по идентификатору глобального свойства
        /// </summary>
        public class_prop class_prop_by_id_global_prop(Int64 iid_class, Int64 iid_global_prop)
        {
            class_prop class_prop = null;

            DataTable tbl_vclass_prop  = TableByName("vclass_prop");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("class_prop_by_id_global_prop");

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
            

            cmdk.Parameters["iid_class"].Value = iid_class;
            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;

            cmdk.Fill(tbl_vclass_prop);
            
            if (tbl_vclass_prop.Rows.Count > 0)
            {
                class_prop = new class_prop(tbl_vclass_prop.Rows[0]);
            }
            return class_prop;
        }

        /// <summary>
        /// Выбор свойства активного представления класса по идентификатору глобального свойства
        /// </summary>
        public class_prop class_prop_by_id_global_prop(vclass Class, global_prop Global_prop)
        {
            return class_prop_by_id_global_prop(Class.Id, Global_prop.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_by_id_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("class_prop_by_id_global_prop");
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
        /// Лист свойств представления активного класса по идентификатору класса с пустым тэгом
        /// </summary>
        public List<class_prop> class_prop_by_id_class(Int64 iid_class)
        {
            List<class_prop> class_prop_list = new List<class_prop>();

            
            DataTable tbl_class_prop  = TableByName("vclass_prop");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("class_prop_by_id_class");

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
            

            cmdk.Parameters["iid_class"].Value = iid_class;

            cmdk.Fill(tbl_class_prop);
            
            class_prop cp;
            if (tbl_class_prop.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_class_prop.Rows)
                {
                    cp = new class_prop(dr);
                    class_prop_list.Add(cp);
                }
            }
            return class_prop_list;
        }

        /// <summary>
        /// Лист свойств представления активного класса по идентификатору класса с пустым тэгом
        /// </summary>
        public List<class_prop> class_prop_by_id_class(vclass Class)
        {
            return class_prop_by_id_class(Class.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_by_id_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("class_prop_by_id_class");
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
        /// Лист свойств для формирования формата имени объекта
        /// </summary>
        public List<class_prop> class_prop_for_format_by_id_class(Int64 iid_class)
        {
            List<class_prop> class_prop_list = new List<class_prop>();


            DataTable tbl_class_prop = TableByName("vclass_prop");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("class_prop_for_format_by_id_class");

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
            

            cmdk.Parameters["iid_class"].Value = iid_class;

            cmdk.Fill(tbl_class_prop);

            class_prop cp;
            if (tbl_class_prop.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_class_prop.Rows)
                {
                    cp = new class_prop(dr);
                    class_prop_list.Add(cp);
                }
            }
            return class_prop_list;
        }

        /// <summary>
        /// Лист свойств представления активного класса по идентификатору класса
        /// </summary>
        public List<class_prop> class_prop_for_format_by_id_class(vclass Class)
        {
            return class_prop_for_format_by_id_class(Class.Id);
        }

        //ACCESS
        /// <summary>
        /// Лист свойств представления активного класса по идентификатору класса
        /// </summary>
        public Boolean class_prop_for_format_by_id_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            cmdk = CommandByKey("class_prop_for_format_by_id_class");
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
