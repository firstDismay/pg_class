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
        ///  Метод выполняет создание объектов всех вещественных классов указанного класса
        /// </summary>
        public List<errarg_object_add> object_add_for_class_act(Int64 iid_class, Int64 iid_position_target)
        {
            List<errarg_object_add> object_list = new List<errarg_object_add>();
            //object_general o;

            DataTable tbl_result = TableByName("errarg_object_add");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
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
            //=======================

            cmdk.Parameters["iid_class"].Value = iid_class;
            cmdk.Parameters["iid_position_target"].Value = iid_position_target;

            cmdk.Fill(tbl_result);
            
            errarg_object_add og;
            if (tbl_result.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_result.Rows)
                {
                    og = new errarg_object_add(dr);
                    object_list.Add(og);
                }
            }

            position p = pos_by_id(iid_position_target);
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
        public List<errarg_object_add> object_add_for_class_act(vclass Class, position Position_target)
        {
            return object_add_for_class_act(Class.Id, Position_target.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_add_for_class_act(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
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
