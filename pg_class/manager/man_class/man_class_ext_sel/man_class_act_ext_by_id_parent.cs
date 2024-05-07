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
        /// Лист представлений активных классов  с признаком готовности к созданию объектов по идентификатору родительского класса
        /// </summary>
        public List<vclass> class_act_ext_by_id_parent(Int64 id_parent)
        {
            List<vclass> vclass_list = new List<vclass>();

            DataTable tbl_vclass = new DataTable(); // TableByName("vclass_ext");
            tbl_vclass.TableName = "vclass_ext";


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_act_ext_by_id_parent");

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


            cmdk.Parameters["iid_parent"].Value = id_parent;

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
        /// Лист представлений активных классов  с признаком готовности к созданию объектов по идентификатору родительского класса
        /// </summary>
        public List<vclass> class_act_ext_by_id_parent(vclass Vclass_parent)
        {
            List<vclass> Result = null;
            switch (Vclass_parent.StorageType)
            {
                case eStorageType.Active:
                    Result = class_act_ext_by_id_parent(Vclass_parent.Id);
                    break;
                case eStorageType.History:
                    throw new ArgumentOutOfRangeException("Тип представления класса не соответствует сигнатуре функции, требуется активное представление класса");
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_ext_by_id_parent(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_act_ext_by_id_parent");
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
