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
        public List<class_prop> class_prop_snapshot_by_id_class_snapshot_search_method(Int64  iid_class_snapshot, DateTime itimestamp_class_snapshot, eSearchMethods isearch_method)
        {
            List<class_prop> class_prop_list = new List<class_prop>();
            
            DataTable tbl_class_prop  = TableByName("vclass_prop");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_snapshot_by_id_class_snapshot_search_method");

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

            cmdk.Parameters["iid_class_snapshot"].Value = iid_class_snapshot;
            cmdk.Parameters["itimestamp_class_snapshot"].Value = itimestamp_class_snapshot;
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
        public List<class_prop> class_prop_snapshot_by_id_class_snapshot_search_method(vclass Class, eSearchMethods isearch_method)
        {
            return class_prop_snapshot_by_id_class_snapshot_search_method(Class.Id, Class.Timestamp, isearch_method);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_snapshot_by_id_class_snapshot_search_method(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_snapshot_by_id_class_snapshot_search_method");
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
