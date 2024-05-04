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
        /// Позиция по идентификатору
        /// </summary>
        public position position_by_id(Int64 id)
        {
            position position = null;

            DataTable tbl_pos = TableByName("vposition");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_by_id");

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


            cmdk.Parameters["iid"].Value = id;

            cmdk.Fill(tbl_pos);

            if (tbl_pos.Rows.Count > 0)
            {
                position = new position(tbl_pos.Rows[0]);
            }
            return position;
        }

        /// <summary>
        /// Позиция по объекту pos_path
        /// </summary>
        public position position_by_pos_path(pos_path pos_path)
        {
            return position_by_id(pos_path.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_by_id");
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
