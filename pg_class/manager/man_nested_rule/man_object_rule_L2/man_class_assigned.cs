using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Npgsql;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using pg_class.pg_classes;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод возвращает классы назначенные с учетом правил уровня 2 класс на позицию по идентификатору позиции
        /// </summary>
        public List<vclass> Class_assigned_rl2_by_id_position(Int64 iid_position)
        {
            List<vclass> class_list = new List<vclass>();


            DataTable tbl_class_list = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_assigned_rl2_by_id_position");

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

            cmdk.Parameters["iid_position"].Value = iid_position;

            cmdk.Fill(tbl_class_list);
            
            vclass Class;
            if (tbl_class_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_class_list.Rows)
                {
                    Class = new vclass(dr);
                    class_list.Add(Class);
                }
            }
            return class_list;
        }

        /// <summary>
        /// Метод возвращает классы назначенные с учетом правил уровня 2 класс на позицию по идентификатору позиции
        /// </summary>
        public List<vclass> Class_assigned_rl2_by_id_position(position Position)
        {
            return Class_assigned_rl2_by_id_position(Position.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Сlass_assigned_rl2_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_assigned_rl2_by_id_position");
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
        //*********************************************************************************************

        /// <summary>
        /// Метод возвращает классы назначенные с учетом правил уровня 2 класс на позицию для выбранной группы по идентификатору позиции
        /// </summary>
        public List<vclass> Class_allowed_rl2_for_group_by_id_position(Int64 iid_position, Int64 iid_group)
        {
            List<vclass> class_list = new List<vclass>();


            DataTable tbl_class_list  = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_allowed_rl2_for_group_by_id_position");

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

            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["iid_group"].Value = iid_group;

            cmdk.Fill(tbl_class_list);
            
            vclass Class;
            if (tbl_class_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_class_list.Rows)
                {
                    Class = new vclass(dr);
                    class_list.Add(Class);
                }
            }
            return class_list;
        }

        /// <summary>
        /// Метод возвращает классы назначенные с учетом правил уровня 2 класс на позицию для выбранной группы по идентификатору позиции
        /// </summary>
        public List<vclass> Class_allowed_rl2_for_group_by_id_position(position Position, group Group)
        {
            return Class_allowed_rl2_for_group_by_id_position(Position.Id, Group.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean Class_allowed_rl2_for_group_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_allowed_rl2_for_group_by_id_position");
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
        //*********************************************************************************************

        /// <summary>
        /// Метод возвращает классы назначенные с учетом правил уровня 2 класс на позицию для выбранного класса по идентификатору позиции
        /// </summary>
        public List<vclass> class_allowed_rl2_for_class_by_id_position(Int64 iid_position, Int64 iid_class)
        {
            List<vclass> class_list = new List<vclass>();


            DataTable tbl_class_list = TableByName("vclass");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_allowed_rl2_for_class_by_id_position");

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

            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["iid_class"].Value = iid_class;

            cmdk.Fill(tbl_class_list);
            
            vclass Class;
            if (tbl_class_list.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_class_list.Rows)
                {
                    Class = new vclass(dr);
                    class_list.Add(Class);
                }
            }
            return class_list;
        }

        /// <summary>
        /// Метод возвращает классы назначенные с учетом правил уровня 2 класс на позицию для выбранного класса по идентификатору позиции
        /// </summary>
        public List<vclass> class_allowed_rl2_for_class_by_id_position(position Position, vclass Class)
        {
            return class_allowed_rl2_for_class_by_id_position(Position.Id, Class.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_allowed_rl2_for_class_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_allowed_rl2_for_class_by_id_position");
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