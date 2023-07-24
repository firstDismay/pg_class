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
        ///  Метод выполняет создание объектов всех вещественных классов указанного класса
        /// </summary>
        public List<error_message> object_add_for_class_act(Int64 iid_class, Int64 iid_position)
        {
            List<error_message> object_list = new List<error_message>();
            DataTable tbl_result = TableByName("error_message");
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("object_add_for_class_act");

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
            cmdk.Parameters["iid_position"].Value = iid_position;

            cmdk.Fill(tbl_result);

            error_message og;
            if (tbl_result.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_result.Rows)
                {
                    og = new error_message(dr);
                    object_list.Add(og);
                }
            }

            position p = position_by_id(iid_position);
            if (p != null)
            {
                //Генерируем событие изменения остава объектов позиции
                PositionChangeEventArgs e = new PositionChangeEventArgs(p, eAction.Insert_mass);
                PositionOnChange(e);
            }
            return object_list;
        }

        /// <summary>
        ///  Метод выполняет создание объектов всех вещественных классов указанного класса
        /// </summary>
        public List<error_message> object_add_for_class_act(vclass Class, position Position_target)
        {
            return object_add_for_class_act(Class.Id, Position_target.Id);
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_add_for_class_act(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("object_add_for_class_act");
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
