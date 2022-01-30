using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_commands;
using pg_class.pg_classes;
using Npgsql;
using System.Data;
using pg_class.pg_exceptions;

namespace pg_class
{
    public partial class manager
    {
        #region ВЫБРАТЬ
        //*********************************************************************************************
        /// <summary>
        /// Лист объектов path определяющих путь до активного представления класса
        /// </summary>
        public List<class_path> class_act_path_by_id_class(Int64 iid_class)
        {


            List<class_path> vclass_path_list = new List<class_path>();
            DataTable tbl_vclass_path = TableByName("path2");

            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;
            //=======================
            cmdk = CommandByKey("class_act_path");

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

            cmdk.Parameters["iid_class"].Value = iid_class;

            cmdk.Fill(tbl_vclass_path);
            
            class_path vcp;
            if (tbl_vclass_path.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass_path.Rows)
                {
                    vcp = new class_path(dr);
                    vclass_path_list.Add(vcp);
                }
            }

            return vclass_path_list;
        }

        /// <summary>
        /// Лист объектов path определяющих путь до активного представления класса
        /// </summary>
        public List<class_path> class_act_path_by_id_class(vclass Class)
        {
            List<class_path> Result = null;
            switch (Class.StorageType)
            {
                case eStorageType.Active:
                    Result = class_act_path_by_id_class(Class.Id);
                    break;
                case eStorageType.History:
                    throw new PgDataException(505, "Исторический класс vclass не допустим методе class_act_path_by_id_class!");
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_path_by_id_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_act_path");
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

 //*********************************************************************************************
        /// <summary>
        /// Лист объектов path определяющих путь до исторического представления класса
        /// </summary>
        public List<class_path> class_snapshot_path_by_id_class(Int64 iid_class, DateTime itimestamp_class)
        {
            List<class_path> vclass_path_list = new List<class_path>();
            DataTable tbl_vclass_path = TableByName("path2");

            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;
            //=======================
            cmdk = CommandByKey("class_snapshot_path");

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

            cmdk.Parameters["iid_class"].Value = iid_class;
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;

            cmdk.Fill(tbl_vclass_path);
            
            class_path vcp;
            if (tbl_vclass_path.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass_path.Rows)
                {
                    vcp = new class_path(dr);
                    vclass_path_list.Add(vcp);
                }
            }
            return vclass_path_list;
        }

        /// <summary>
        /// Лист объектов path определяющих путь до исторического представления класса
        /// </summary>
        public List<class_path> class_snapshot_path_by_id_class(vclass Class)
        {
            List<class_path> Result = null;
            switch (Class.StorageType)
            {
                case eStorageType.History:
                    Result = class_snapshot_path_by_id_class(Class.Id, Class.Timestamp);
                    break;
                case eStorageType.Active:
                    throw new PgDataException(505, "Активный класс vclass не допустим методе class_snapshot_path_by_id_class!");
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_snapshot_path_by_id_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_snapshot_path");
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
        #endregion
    }
}
