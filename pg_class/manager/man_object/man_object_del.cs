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
        /// Метод удаляет объект
        /// </summary>
        public void object_del(Int64 iid)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_del");
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

            object_general Object = object_by_id(iid);

            cmdk.Parameters["iid"].Value = iid;
            cmdk.ExecuteNonQuery();

            //Генерируем событие удаления представления класса
            if (Object != null)
            {
                ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object, eAction.Delete);
                ObjectOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет объект
        /// </summary>
        public void object_del(object_general Object)
        {
            object_del(Object.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_del");
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

        /// <summary>
        ///  Метод удаляет группу объектов по массиву идентификаторов объектов
        /// </summary>
        public List<errarg_action> object_del_by_id_array(Int64[] object_array)
        {
            List<errarg_action> entity_action_list = new List<errarg_action>();
            DataTable tbl_result = TableByName("errarg_action");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_del_by_id_array");
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

            cmdk.Parameters["object_array"].Value = object_array;
            cmdk.Fill(tbl_result);

            errarg_action ea;
            if (tbl_result.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_result.Rows)
                {
                    ea = new errarg_action(dr);
                    entity_action_list.Add(ea);
                }
            }
            return entity_action_list;
        }

        /// <summary>
        ///  Метод удаляет группу объектов по массиву идентификаторов объектов
        /// </summary>
        public List<errarg_action> object_del_by_id_array(object_general[] object_array)
        {
            Int64[] id_array;
            if (object_array.Length > 0)
            {
                id_array = new Int64[object_array.Length];
                for (int i = 0; i < object_array.Length; i++)
                {
                    id_array[i] = object_array[i].Id;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Массив объектов пуст!");
            }
            return object_del_by_id_array(id_array);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_del_by_id_array(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_del_by_id_array");
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