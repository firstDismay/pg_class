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
        /// Класс носитель свойства, указанного по идентификатору
        /// </summary>
        public vclass class_carrier_by_id_class_prop(Int64 iid_class_prop, DateTime itimestamp_class, eStorageType storagetype)
        {
            vclass vclass = null;

            DataTable tbl_vclass = TableByName("vclass");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_carrier_by_id_class_prop");

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
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;
            cmdk.Parameters["storagetype"].Value = storagetype.ToString("G");

            cmdk.Fill(tbl_vclass);

            if (tbl_vclass.Rows.Count > 0)
            {
                vclass = new vclass(tbl_vclass.Rows[0]);
            }
            return vclass;
        }

        /// <summary>
        /// Класс носитель свойства, указанного по идентификатору
        /// </summary>
        public vclass class_carrier_by_id_class_prop(class_prop ClassProp)
        {
            return class_carrier_by_id_class_prop(ClassProp.Id, ClassProp.Timestamp_class, ClassProp.StorageType);
        }

        /// <summary>
        /// Класс носитель свойства, указанного по идентификатору
        /// </summary>
        public vclass class_carrier_by_id_class_prop(object_prop ObjectProp)
        {
            return class_carrier_by_id_class_prop(ObjectProp.Id_class_prop, ObjectProp.Timestamp_class, eStorageType.History);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_carrier_by_id_class_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_carrier_by_id_class_prop");
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