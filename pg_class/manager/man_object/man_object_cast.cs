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
        /// Метод выполняет приведение объекта к указанному снимку класса
        /// </summary>
        public object_general object_cast(Int64 iid_object, DateTime itimestamp_class)
        {
            object_general Object = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_cast");
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

            cmdk.Parameters["iid_object"].Value = iid_object;
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;
            cmdk.ExecuteNonQuery();

            Object = object_by_id(iid_object);

            if (Object != null)
            {
                //Генерируем событие изменения
                ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object, eAction.Cast);
                ObjectOnChange(e);
            }
            //Возвращаем сущность
            return Object;
        }

        /// <summary>
        /// Метод выполняет приведение объекта к указанному снимку класса
        /// </summary>
        public object_general object_cast(object_general Object, vclass Class_target)
        {
            return object_cast(Object.Id, Class_target.Timestamp);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_cast(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_cast");
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
        ///  Метод выполняет приведение всех объектов к указанному снимку класса
        /// </summary>
        public List<error_message> object_cast_for_class(Int64 iid_class, DateTime itimestamp_class)
        {
            List<error_message> object_cast_list = new List<error_message>();
            DataTable tbl_result = TableByName("error_message");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_cast_for_class");
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
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;
            cmdk.Fill(tbl_result);

            error_message og;
            if (tbl_result.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_result.Rows)
                {
                    og = new error_message(dr);
                    object_cast_list.Add(og);
                }
            }
            return object_cast_list;
        }

        /// <summary>
        ///  Метод выполняет приведение всех объектов к указанному снимку класса
        /// </summary>
        public List<error_message> object_cast_for_class(vclass Class_target)
        {
            return object_cast_for_class(Class_target.Id, Class_target.Timestamp);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_cast_for_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_cast_for_class");
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
        ///  Метод приводит все объекты к активным состояниям классов рекурсивно начиная с указанного
        /// </summary>
        public List<error_message> object_cast_for_class_act(Int64 iid_class)
        {
            List<error_message> object_cast_list = new List<error_message>();
            DataTable tbl_result = TableByName("error_message");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_cast_for_class_act");
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
            cmdk.Fill(tbl_result);

            error_message og;
            if (tbl_result.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_result.Rows)
                {
                    og = new error_message(dr);
                    object_cast_list.Add(og);
                }
            }
            return object_cast_list;
        }

        /// <summary>
        ///  Метод приводит все объекты к активным состояниям классов рекурсивно начиная с указанного
        /// </summary>
        public List<error_message> object_cast_for_class_act(vclass Class_target)
        {
            return object_cast_for_class_act(Class_target.Id);
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_cast_for_class_act(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_cast_for_class_act");
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
        ///  Метод приводит все объекты к активным состояниям классов указанной группы
        /// </summary>
        public List<error_message> object_cast_for_class_act_by_id_group(Int64 iid_group)
        {
            List<error_message> object_cast_list = new List<error_message>();
            DataTable tbl_result = TableByName("error_message");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_cast_for_class_act_by_id_group");
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
            cmdk.Fill(tbl_result);

            error_message og;
            if (tbl_result.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_result.Rows)
                {
                    og = new error_message(dr);
                    object_cast_list.Add(og);
                }
            }
            return object_cast_list;
        }

        /// <summary>
        ///  Метод приводит все объекты к активным состояниям классов указанной группы
        /// </summary>
        public List<error_message> object_cast_for_class_act_by_id_group(group Group_target)
        {
            return object_cast_for_class_act_by_id_group(Group_target.Id);
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_cast_for_class_act_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_cast_for_class_act_by_id_group");
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
        ///  Метод приводит все объекты позции к активным состояниям классов рекурсивно
        /// </summary>
        public List<error_message> object_cast_for_class_act_by_id_position(Int64 iid_position)
        {
            List<error_message> object_cast_list = new List<error_message>();
            DataTable tbl_result = TableByName("error_message");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_cast_for_class_act_by_id_position");
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

            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Fill(tbl_result);

            error_message og;
            if (tbl_result.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_result.Rows)
                {
                    og = new error_message(dr);
                    object_cast_list.Add(og);
                }
            }
            return object_cast_list;
        }

        /// <summary>
        ///  Метод приводит все объекты позции к активным состояниям классов рекурсивно
        /// </summary>
        public List<error_message> object_cast_for_class_act_by_id_position(position Position_target)
        {
            return object_cast_for_class_act_by_id_position(Position_target.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_cast_for_class_act_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_cast_for_class_act_by_id_position");
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