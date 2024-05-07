using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;
using System.Collections.Generic;
using System.Data;

namespace pg_class
{
    public partial class manager
    {

        /// <summary>
        /// Выбор активного представления класса с признаком готовности к созданию объектов по идентификатору
        /// class_act_ready_by_id
        /// </summary>
        public vclass class_act_ext_by_id(Int64 iid)
        {
            vclass vclass = null;

            DataTable tbl_vclass = TableByName("vclass_ext");  //new DataTable("vclass_ext")


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_act_ext_by_id");

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

            cmdk.Fill(tbl_vclass);

            if (tbl_vclass.Rows.Count > 0)
            {
                vclass = new vclass(tbl_vclass.Rows[0]);
            }
            return vclass;
        }

        /// <summary>
        /// Выбор активного представления класса с признаком готовности к созданию объектов по объекту vclass_path
        /// </summary>
        public vclass class_act_ext_by_class_path(class_path Class_path)
        {

            vclass Result = null;
            switch (Class_path.StorageType)
            {
                case eStorageType.Active:
                    Result = class_act_ext_by_id(Class_path.Id);
                    break;
                case eStorageType.History:
                    throw new ArgumentOutOfRangeException(
                        "Исторический класс class_path не допустим методе class_act_by_class_path!");
            }
            return Result;
        }

        /// <summary>
        /// Выбор активного представления класса с признаком готовности к созданию объектов по объекту vclass
        /// class_act_ready_by_id
        /// </summary>
        public vclass class_act_ext_by_class(vclass Class)
        {

            vclass Result = null;
            switch (Class.StorageType)
            {
                case eStorageType.Active:
                    Result = class_act_ext_by_id(Class.Id);
                    break;
                case eStorageType.History:
                    throw new ArgumentOutOfRangeException(
                        "Исторический класс не допустим методе class_act_ext_by_class_path!");
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_ext_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_act_ext_by_id");
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
