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
        #region МЕТОДЫ КЛАССА: ПОЛУЧЕНИЕ СВОЙСТВ ДЛЯ СЛОЖНЫХ МЕТОДОВ ПОИСКА ШАГ №01
        /// <summary>
        /// Лист свойств класса по идентификатору класса-носителя с учетом метода сложного поиска
        /// </summary>
        public List<class_prop> class_prop_by_id_class_search_method(Int64 iid_class, eSearchMethods isearch_method)
        {
            List<class_prop> class_prop_list = new List<class_prop>();
            
            DataTable tbl_class_prop  = TableByName("vclass_prop");
            
            
            NpgsqlCommandKey cmdk;

            
            cmdk = CommandByKey("class_prop_by_id_class_search_method");

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
            cmdk.Parameters["isearch_method"].Value = isearch_method.ToString();

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
        /// Лист свойств класса по идентификатору класса-носителя с учетом метода сложного поиска
        /// </summary>
        public List<class_prop> class_prop_by_id_class_search_method(vclass Class, eSearchMethods isearch_method)
        {
            return class_prop_by_id_class_search_method(Class.Id, isearch_method);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_by_id_class_search_method(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            
            cmdk = CommandByKey("class_prop_by_id_class_search_method");
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

        #region МЕТОДЫ СЛОЖНОГО ПОИСКА ПОЛУЧАЕМЫЕ ИЗ БД
        /// <summary>
        /// Метод возвращает список методов сложного поиска по идентификатору свойства
        /// </summary>
        public List<String> class_prop_search_method_by_id_class_prop(Int64 iid_class_prop)
        {
            DataTable tsearch_method;
            List<String> search_method = new List<String>();
            NpgsqlCommandKey cmdk;
            tsearch_method = new DataTable();

            cmdk = CommandByKey("class_prop_search_method_by_id_class_prop");
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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
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
        public List<eSearchMethods> class_prop_search_method_by_id_class_prop2(Int64 iid_class_prop)
        {
            DataTable tsearch_method;
            List<eSearchMethods> search_method = new List<eSearchMethods>();
            NpgsqlCommandKey cmdk;
            tsearch_method = new DataTable();

            cmdk = CommandByKey("class_prop_search_method_by_id_class_prop");
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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
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
        public List<SearchMetodObject> class_prop_search_method_by_id_class_prop3(Int64 iid_class_prop)
        {
            List<SearchMetodObject> Result = new List<SearchMetodObject>();

            List<eSearchMethods> sm_list = class_prop_search_method_by_id_class_prop2(iid_class_prop);

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
        public Boolean class_prop_search_method_by_id_class_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_search_method_by_id_class_prop");
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