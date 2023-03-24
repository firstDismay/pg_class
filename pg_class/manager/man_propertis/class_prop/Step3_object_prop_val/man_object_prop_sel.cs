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
        /// Выбор свойства объекта носителя по идентификатору объекта и свойства класса
        /// </summary>
        public object_prop object_prop_by_id(Int64 iid_object_carrier, Int64 iid_class_prop)
        {
            object_prop object_prop = null;

            DataTable tbl_object_prop = TableByName("vobject_prop");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("object_prop_by_id");

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


            cmdk.Parameters["iid_object_carrier"].Value = iid_object_carrier;
            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;

            cmdk.Fill(tbl_object_prop);

            if (tbl_object_prop.Rows.Count > 0)
            {
                object_prop = new object_prop(tbl_object_prop.Rows[0]);
            }
            return object_prop;
        }


        /// <summary>
        /// Выбор свойства объекта носителя по идентификатору объекта и свойства класса
        /// </summary>
        public object_prop object_prop_by_id(object_general Object_carrier, Int64 iid_class_prop)
        {
            return object_prop_by_id(Object_carrier.Id, iid_class_prop);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("object_prop_by_id");
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
        /// Лист свойств объекта по идентификатору объекта с пустым тэгом
        /// </summary>
        public List<object_prop> object_prop_by_id_object(Int64 iid_object_carrier)
        {
            List<object_prop> object_prop_list = new List<object_prop>();

            DataTable tbl_object_prop = TableByName("vobject_prop");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("object_prop_by_id_object");

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


            cmdk.Parameters["iid_object_carrier"].Value = iid_object_carrier;

            cmdk.Fill(tbl_object_prop);

            object_prop cp;
            if (tbl_object_prop.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object_prop.Rows)
                {
                    cp = new object_prop(dr);
                    object_prop_list.Add(cp);
                }
            }
            return object_prop_list;
        }

        /// <summary>
        /// Лист свойств объекта по идентификатору объекта с пустым тэгом
        /// </summary>
        public List<object_prop> object_prop_by_id_object(object_general Object)
        {
            return object_prop_by_id_object(Object.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_by_id_object(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("object_prop_by_id_object");
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
        /// Выбирает свойства объекта носителя по идентификатору объекта
        /// </summary>
        public object_prop object_prop_by_id_object_val(Int64 iid_object_val)
        {
            object_prop object_prop = null;

            DataTable tbl_object_prop = TableByName("vobject_prop");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("object_prop_by_id_object_val");

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


            cmdk.Parameters["iid_object_val"].Value = iid_object_val;

            cmdk.Fill(tbl_object_prop);

            if (tbl_object_prop.Rows.Count > 0)
            {
                object_prop = new object_prop(tbl_object_prop.Rows[0]);
            }
            return object_prop;
        }

        /// <summary>
        /// Выбирает свойства объекта носителя по идентификатору объекта
        /// </summary>
        public object_prop object_prop_by_id_object_val(object_general Object_val)
        {
            return object_prop_by_id_object_val(Object_val.Id);
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_by_id_object_val(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("object_prop_by_id_object_val");
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
        /// Выбор указанного свойства объекта STEP3 для указанного объекта по идентификатору определяющего свойства
        /// </summary>
        public object_prop object_prop_by_id_prop_definition(Int64 iid_object_carrier, Int64 iid_prop_definition)
        {
            object_prop object_prop = null;

            DataTable tbl_object_prop = TableByName("vobject_prop");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("object_prop_by_id_prop_definition");

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


            cmdk.Parameters["iid_object_carrier"].Value = iid_object_carrier;
            cmdk.Parameters["iid_prop_definition"].Value = iid_prop_definition;

            cmdk.Fill(tbl_object_prop);

            if (tbl_object_prop.Rows.Count > 0)
            {
                object_prop = new object_prop(tbl_object_prop.Rows[0]);
            }
            return object_prop;
        }


        /// <summary>
        /// Выбор указанного свойства объекта STEP3 для указанного объекта по идентификатору определяющего свойства
        /// </summary>
        public object_prop object_prop_by_id_prop_definition(object_general Object_carrier, Int64 iid_class_prop)
        {
            return object_prop_by_id_prop_definition(Object_carrier.Id, iid_class_prop);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_by_id_prop_definition(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("object_prop_by_id_prop_definition");
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
        /// Выбор указанного свойства объекта STEP3 для указанного объекта по идентификатору определяющего свойства
        /// </summary>
        public object_prop object_prop_by_id_global_prop(Int64 iid_object_carrier, Int64 iid_global_prop)
        {
            object_prop object_prop = null;

            DataTable tbl_object_prop = TableByName("vobject_prop");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("object_prop_by_id_global_prop");

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


            cmdk.Parameters["iid_object_carrier"].Value = iid_object_carrier;
            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;

            cmdk.Fill(tbl_object_prop);

            if (tbl_object_prop.Rows.Count > 0)
            {
                object_prop = new object_prop(tbl_object_prop.Rows[0]);
            }
            return object_prop;
        }


        /// <summary>
        /// Выбор указанного свойства объекта STEP3 для указанного объекта по идентификатору определяющего свойства
        /// </summary>
        public object_prop object_prop_by_id_global_prop(object_general Object_carrier, Int64 iid_global_prop)
        {
            return object_prop_by_id_global_prop(Object_carrier.Id, iid_global_prop);
        }

        /// <summary>
        /// Выбор указанного свойства объекта STEP3 для указанного объекта по идентификатору определяющего свойства
        /// </summary>
        public object_prop object_prop_by_id_global_prop(object_general Object_carrier, global_prop Global_prop)
        {
            return object_prop_by_id_global_prop(Object_carrier.Id, Global_prop.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_by_id_global_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("object_prop_by_id_global_prop");
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
