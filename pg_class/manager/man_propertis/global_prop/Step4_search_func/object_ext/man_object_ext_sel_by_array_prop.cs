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
using Newtonsoft.Json;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Лист расширенных представлений объектов соотвествующих набору значений глобальных/определяющих свойств (подбор по критериям)
        /// </summary>
        public List<object_general> object_ext_by_array_prop(PropSearchСondition[] array_prop, Int64 iid_position = -1)
        {
            List<object_general> object_list = new List<object_general>();

            DataTable tbl_object = TableByName("vobject_general_ext");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_ext_by_array_prop");
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

            String[] sarray_prop = new String[array_prop.Length];

            for (Int32 i = 0; i < array_prop.Length; i++)
            {
                sarray_prop[i] = JsonConvert.SerializeObject(array_prop[i], Formatting.Indented);
            }

            cmdk.Parameters["array_prop"].Value = sarray_prop;
            cmdk.Parameters["iid_position"].Value = iid_position;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист расширенных представлений объектов соотвествующих набору значений глобальных/определяющих свойств (подбор по критериям)
        /// </summary>
        public List<object_general> object_ext_by_array_prop(PropSearchСondition[] array_prop, position Position)
        {
            return object_ext_by_array_prop(array_prop, Position.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_ext_by_array_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            cmdk = CommandByKey("object_ext_by_array_prop");
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
