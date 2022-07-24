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
        
        #region МЕТОДЫ СЛОЖНОГО ПОИСКА ПОЛУЧАЕМЫЕ ИЗ БД
        /// <summary>
        /// Метод возвращает список методов сложного поиска по идентификатору свойства
        /// </summary>
        public List<String> class_prop_search_method_by_id_global_prop(Int64 iid_global_prop)
        {
            DataTable tsearch_method;
            List<String> search_method = new List<String>();
            NpgsqlCommandKey cmdk;
            tsearch_method = new DataTable();

            cmdk = CommandByKey("class_prop_search_method_by_id_global_prop");
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

            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;
            cmdk.Fill(tsearch_method);

            String sm;
            if (tsearch_method.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tsearch_method.Rows)
                {
                    sm = dr[0].ToString();
                    search_method.Add(sm);
                }
            }
            return search_method;
        }

        /// <summary>
        /// Метод возвращает список методов сложного поиска по идентификатору свойства
        /// </summary>
        public List<eSearchMethods> class_prop_search_method_by_id_global_prop2(Int64 iid_global_prop)
        {
            DataTable tsearch_method;
            List<eSearchMethods> search_method = new List<eSearchMethods>();
            NpgsqlCommandKey cmdk;
            tsearch_method = new DataTable();

            cmdk = CommandByKey("class_prop_search_method_by_id_global_prop");
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

            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;
            cmdk.Fill(tsearch_method);

            String sm;
            if (tsearch_method.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tsearch_method.Rows)
                {
                    sm = dr[0].ToString();
                    search_method.Add((eSearchMethods)Enum.Parse(typeof(eSearchMethods), sm));
                }
            }
            return search_method;
        }

        /// <summary>
        /// Метод возвращает список методов сложного поиска по идентификатору свойства
        /// </summary>
        public List<SearchMetodObject> class_prop_search_method_by_id_global_prop3(Int64 iid_global_prop)
        {
            List<SearchMetodObject> Result = new List<SearchMetodObject>();

            List<eSearchMethods> sm_list = class_prop_search_method_by_id_class_prop2(iid_global_prop);

            foreach (eSearchMethods sm in sm_list)
            {
                Result.Add(new SearchMetodObject(sm));
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_search_method_by_id_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_search_method_by_id_global_prop");
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
    }
}