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
        /// Лист объектов по идентификатору элемента перечисления
        /// </summary>
        public List<object_general> object_by_id_prop_enum_val(Int64 iid_prop_enum_val)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_vclass = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_prop_enum_val");
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

            cmdk.Parameters["iid_prop_enum_val"].Value = iid_prop_enum_val;
            cmdk.Fill(tbl_vclass);

            object_general o;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    o = new object_general(dr);
                    object_list.Add(o);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов по идентификатору элемента перечисления
        /// </summary>
        public List<object_general> object_by_id_prop_enum_val(prop_enum_val Prop_enum_val)
        {
            return object_by_id_prop_enum_val(Prop_enum_val.Id_prop_enum_val);
        }

        /// <summary>
        /// Лист объектов по идентификатору элемента перечисления
        /// </summary>
        public List<object_general> object_by_id_prop_enum_val(prop_enum_val Prop_enum_val, Boolean Extended = false)
        {
            List<object_general> Result;
            if (Extended)
            {
                Result = object_ext_by_id_prop_enum_val(Prop_enum_val);
            }
            else
            {
                Result = object_by_id_prop_enum_val(Prop_enum_val);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_prop_enum_val(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_prop_enum_val");
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
