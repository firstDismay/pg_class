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

        #region МЕТОДЫ ПОЗИЦИЙ ДОСТУПНЫХ ИЛИ НАЗНАЧЕННЫХ РАЗРЕШАЮЩИМИ ПРАВИЛАМ УРОВНЯ 2 КЛАСС НА ПОЗИЦИЮ
        /// <summary>
        /// Метод возвращает список разрешенных позиций с учетом разрешения уровня 2 класс на позицию по идентификатору класса
        /// </summary>
        public List<position> Position_allowed_rl2_by_id_class(Int64 iid_class)
        {
            List<position> position_list = new List<position>();


            DataTable tbl_position_list = TableByName("vposition");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_allowed_rl2_by_id_class");

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

            cmdk.Fill(tbl_position_list);

            position Position;
            if (tbl_position_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_position_list.Rows)
                {
                    Position = new position(dr);
                    position_list.Add(Position);
                }
            }
            return position_list;
        }

        /// <summary>
        /// Метод возвращает список разрешенных позиций с учетом разрешения уровня 2 класс на позицию по идентификатору класса
        /// </summary>
        public List<position> Position_allowed_rl2_by_id_class(vclass Class)
        {
            return Position_allowed_rl2_by_id_class(Class.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Position_allowed_rl2_by_id_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("position_allowed_rl2_by_id_class");
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