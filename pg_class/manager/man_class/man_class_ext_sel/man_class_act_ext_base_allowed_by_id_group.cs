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
        /// Лист разрешенных расширенных представлений базовых абстрактных классов по идентификатору группы и целевой позиции создаваемого объекта
        /// </summary>
        public List<vclass> class_act_ext_base_allowed_by_id_group(Int64 iid_group, Int64 iid_position)
        {
            List<vclass> vclass_list = new List<vclass>();


            DataTable tbl_vclass = TableByName("vclass_ext");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_act_ext_base_allowed_by_id_group");

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


            cmdk.Parameters["iid_group"].Value = iid_group;
            cmdk.Parameters["iid_position"].Value = iid_position;

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
        /// Лист разрешенных расширенных представлений базовых абстрактных классов по идентификатору группы и целевой позиции создаваемого объекта
        /// </summary>
        public List<vclass> class_act_ext_base_allowed_by_id_group(group Group, position Position)
        {
            return class_act_ext_base_allowed_by_id_group(Group.Id, Position.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_act_ext_base_allowed_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("class_act_ext_base_allowed_by_id_group");
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
