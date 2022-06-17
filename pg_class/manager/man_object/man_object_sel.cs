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
    #region ВЫБРАТЬ
    public partial class manager
    {
        /// <summary>
        /// Представление объекта по идентификатору
        /// </summary>
        public object_general object_by_id(Int64 id)
        {
            object_general object_general = null;

            DataTable tbl_object  = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id");
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
            cmdk.Fill(tbl_object);
            if (tbl_object.Rows.Count > 0)
            {
                object_general = new object_general(tbl_object.Rows[0]);
            }
            return object_general;
        }

        /// <summary>
        /// Представление объекта по идентификатору пути объекта
        /// </summary>
        public object_general object_by_id(object_path Object_path, Boolean Extended = false)
        {
            object_general Result;
            if (Extended)
            {
                Result = object_ext_by_id(Object_path.Id_object);
            }
            else
            {
                Result = object_by_id(Object_path.Id_object);
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            cmdk = CommandByKey("object_by_id");
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
        /// Лист представлений объектов по идентификатору позиции
        /// </summary>
        public List<object_general> object_by_id_position(Int64 iid_position)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_object  = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_position");
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
        /// Лист представлений объектов по идентификатору позиции
        /// </summary>
        public List<object_general> object_by_id_position(position Position)
        {
            return object_by_id_position(Position.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_position");
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
        /// Лист представлений объектов по идентификатору позиции рекурсивно
        /// </summary>
        public List<object_general> object_by_id_position_full(Int64 iid_position)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_object = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_position_full");
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
        /// Лист представлений объектов по идентификатору позиции рекурсивно
        /// </summary>
        public List<object_general> object_by_id_position_full(position Position)
        {
            return object_by_id_position_full(Position.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_position_full(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_position_full");
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
        /// Лист представлений объектов по id объекта носителя
        /// </summary>
        public List<object_general> object_by_id_object_carrier(Int64 iid_object_carrier)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_object  = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_object_carrier");
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
        /// Лист представлений объектов по id родительского объекта
        /// </summary>
        public List<object_general> object_by_id_object_carrier(object_general Object_parent)
        {
            return object_by_id_object_carrier(Object_parent.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_object_carrier(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_object_carrier");
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
        /// Лист представлений объектов по маске имени объекта в указанной позиции рекурсивно
        /// </summary>
        public List<object_general> object_by_name_id_pos(String iname, Int64 iid_position, Boolean on_inside)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_object = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_name_id_pos");
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

            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["on_inside"].Value = on_inside;
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

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_name_id_pos(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_name_id_pos");
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
        /// Лист представлений объектов по маске имени объекта в указанной концепции
        /// </summary>
        public List<object_general> object_by_name(String iname, Int64 iid_conception, Boolean on_inside)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_object = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_name");
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

            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["iid_conception"].Value = iid_conception;
            cmdk.Parameters["on_inside"].Value = on_inside;
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

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_name");
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
        /// Лист объектов активного представления класса по идентификатору класса
        /// </summary>
        public List<object_general> object_by_id_class_act(Int64 iid_class)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_object  = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_class_act");
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
        /// Лист объектов активного представления класса по идентификатору класса
        /// </summary>
        public List<object_general> object_by_id_class_act(vclass Class)
        {
            return object_by_id_class_act(Class.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_class_act(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            cmdk = CommandByKey("object_by_id_class_act");
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
        /// Лист объектов всех представления класса по идентификатору класса
        /// </summary>
        public List<object_general> object_by_id_class_full(Int64 iid_class)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_object  = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_class_full");
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
        /// Лист объектов всех представления класса по идентификатору класса
        /// </summary>
        public List<object_general> object_by_id_class_full(vclass Class)
        {
            return object_by_id_class_full(Class.Id);
        }

        /// <summary>
        /// Лист объектов всех представления класса по идентификатору класса
        /// </summary>
        public List<object_general> object_by_id_class_full(object_general Object_general)
        {
            return object_by_id_class_full(Object_general.Id_class);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_class_full(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_class_full");
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
        /// Лист объектов снимка класса по идентификатору класса
        /// </summary>
        public List<object_general> object_by_id_class_snapshot(Int64 iid_class, DateTime itimestamp)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_object  = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_class_snapshot");
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
            cmdk.Parameters["itimestamp"].Value = itimestamp;
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
        /// Лист объектов снимка класса по идентификатору класса
        /// </summary>
        public List<object_general> object_by_id_class_snapshot(vclass Class)
        {
            return object_by_id_class_snapshot(Class.Id, Class.Timestamp);
        }

        /// <summary>
        /// Лист объектов снимка класса по идентификатору класса
        /// </summary>
        public List<object_general> object_by_id_class_snapshot(object_general Object_general)
        {
            return object_by_id_class_snapshot(Object_general.Id_class, Object_general.Timestamp_class);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_class_snapshot(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            cmdk = CommandByKey("object_by_id_class_snapshot");
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
        /// Лист объектов снимка класса по идентификатору класса и содержащей позиции
        /// </summary>
        public List<object_general> object_by_id_class_snapshot_id_pos(Int64 iid_class, DateTime itimestamp, Int64 iid_position)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_object = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_class_snapshot_id_pos");
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
            cmdk.Parameters["itimestamp"].Value = itimestamp;
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
        /// Лист объектов снимка класса по идентификатору класса и содержащей позиции
        /// </summary>
        public List<object_general> object_by_id_class_snapshot_id_pos(vclass Class, position Position_parent)
        {
            return object_by_id_class_snapshot_id_pos(Class.Id, Class.Timestamp, Position_parent.Id);
        }

        /// <summary>
        /// Лист объектов снимка класса по идентификатору класса и содержащей позиции
        /// </summary>
        public List<object_general> object_by_id_class_snapshot_id_pos(vclass Class, Int64 Id_position_parent)
        {
            return object_by_id_class_snapshot_id_pos(Class.Id, Class.Timestamp, Id_position_parent);
        }

        /// <summary>
        /// Лист объектов снимка класса по идентификатору класса и содержащей позиции
        /// </summary>
        public List<object_general> object_by_id_class_snapshot_id_pos(object_general Object_general, position Position_parent)
        {
            return object_by_id_class_snapshot_id_pos(Object_general.Id_class, Object_general.Timestamp_class, Position_parent.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_class_snapshot_id_pos(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_class_snapshot_id_pos");
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
        /// Лист объектов класса по идентификатору класса рекурсивно и содержащей позиции
        /// </summary>
        public List<object_general> object_by_id_class_id_pos(Int64 iid_class, Int64 iid_position)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_object = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_class_id_pos");
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
        /// Лист объектов класса по идентификатору класса рекурсивно и содержащей позиции
        /// </summary>
        public List<object_general> object_by_id_class_id_pos(vclass Class, position Position_parent)
        {
            return object_by_id_class_id_pos(Class.Id, Position_parent.Id);
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_class_id_pos(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_class_id_pos");
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
        /// Лист представлений объектов по идентификатору корневого класса
        /// </summary>
        public List<object_general> object_by_id_class_root(Int64 iid_class_root)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_object  = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_class_root");
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

            cmdk.Parameters["iid_class_root"].Value = iid_class_root;
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
        /// Лист представлений объектов по идентификатору корневого класса
        /// </summary>
        public List<object_general> object_by_id_class_root(vclass Class)
        {
            return object_by_id_class_root(Class.Id_root);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_class_root(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            cmdk = CommandByKey("object_by_id_class_root");
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
        /// Лист представлений объектов по идентификатору группы
        /// </summary>
        public List<object_general> object_by_id_group(Int64 iid_group)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_object  = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;
            cmdk = CommandByKey("object_by_id_group");

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
        /// Лист представлений объектов по идентификатору группы
        /// </summary>
        public List<object_general> object_by_id_group(group Group)
        {
            return object_by_id_group(Group.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_group");
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
        /// Лист представлений объектов по идентификатору группы
        /// </summary>
        public List<object_general> object_by_id_group_root(Int64 iid_group_root)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_object  = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_group_root");
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

            cmdk.Parameters["iid_group_root"].Value = iid_group_root;
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
        /// Лист представлений объектов по идентификатору группы
        /// </summary>
        public List<object_general> object_by_id_group_root(group Group)
        {
            return object_by_id_group_root(Group.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_group_root(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_group_root");
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
        /// Лист объектов по идентификатору правила пересчета
        /// </summary>
        public List<object_general> object_by_id_unit_conversion_rule(Int32 iid_unit_conversion_rule)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_vclass  = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;
            cmdk = CommandByKey("object_by_id_unit_conversion_rule");
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

            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;
            cmdk.Fill(tbl_vclass);
            
            object_general o;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    o = new object_general(dr);
                    object_list.Add(o);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов по идентификатору правила пересчета
        /// </summary>
        public List<object_general> object_by_id_unit_conversion_rule(unit_conversion_rule Unit_conversion_rule)
        {
            return object_by_id_unit_conversion_rule(Unit_conversion_rule.Id);
        }

        /// <summary>
        /// Лист объектов по идентификатору правила пересчета
        /// </summary>
        public List<object_general> object_by_id_unit_conversion_rule(class_unit_conversion_rule Unit_conversion_rule)
        {
            return object_by_id_unit_conversion_rule(Unit_conversion_rule.Id_unit_conversion_rule);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_unit_conversion_rule(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            
            cmdk = CommandByKey("object_by_id_unit_conversion_rule");
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
        /// Лист объектов по идентификатору перечисления
        /// </summary>
        public List<object_general> object_by_id_prop_enum(Int64 iid_prop_enum)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_vclass  = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_prop_enum");
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

            cmdk.Parameters["iid_prop_enum"].Value = iid_prop_enum;
            cmdk.Fill(tbl_vclass);
            
            object_general o;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    o = new object_general(dr);
                    object_list.Add(o);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов по идентификатору перечисления
        /// </summary>
        public List<object_general> object_by_id_prop_enum(prop_enum Prop_enum)
        {
            return object_by_id_prop_enum(Prop_enum.Id_prop_enum);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_prop_enum(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_prop_enum");
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
        /// Лист объектов по идентификатору элемента перечисления
        /// </summary>
        public List<object_general> object_by_id_prop_enum_val(Int64 iid_prop_enum_val)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_vclass  = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_prop_enum_val");
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

            cmdk.Parameters["iid_prop_enum_val"].Value = iid_prop_enum_val;
            cmdk.Fill(tbl_vclass);
            
            object_general o;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    o = new object_general(dr);
                    object_list.Add(o);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов по идентификатору элемента перечисления
        /// </summary>
        public List<object_general> object_by_id_prop_enum_val(prop_enum_val Prop_enum_val)
        {
            return object_by_id_prop_enum_val(Prop_enum_val.Id_prop_enum_val);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_prop_enum_val(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_prop_enum_val");
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
        /// Лист объектов по идентификатору типа данных свойств концепции
        /// </summary>
        public List<object_general> object_by_id_prop_data_type( Int64 iid_conception, Int64 iid_prop_data_type)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_vclass  = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_prop_data_type");
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

            cmdk.Parameters["iid_conception"].Value = iid_conception;
            cmdk.Parameters["iid_prop_data_type"].Value = iid_prop_data_type;

            cmdk.Fill(tbl_vclass);
            
            object_general o;
            if (tbl_vclass.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_vclass.Rows)
                {
                    o = new object_general(dr);
                    object_list.Add(o);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист объектов по идентификатору типа данных свойств концепции
        /// </summary>
        public List<object_general> object_by_id_prop_data_type(con_prop_data_type Con_prop_data_type)
        {
            return object_by_id_prop_data_type(Con_prop_data_type.Id_conception, Con_prop_data_type.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_id_prop_data_type(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_id_prop_data_type");
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

        #region ВЫБРАТЬ ПО ССЫЛКАМ НА ОБЪЕКТ

        /// <summary>
        /// Лист представлений объектов ссылающихся на указанный объект, разрешение обратных ссылок
        /// </summary>
        public List<object_general> object_by_link_object(Int64 iid_object, Boolean on_recursive)
        {
            List<object_general> object_list = new List<object_general>();
            DataTable tbl_object = TableByName("vobject_general");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_link_object");
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
            cmdk.Parameters["on_recursive"].Value = on_recursive;
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
        /// Лист представлений объектов ссылающихся на указанный объект, разрешение обратных ссылок
        /// </summary>
        public List<object_general> object_by_link_object(object_general Object_link, Boolean on_recursive)
        {
            return object_by_link_object(Object_link.Id, on_recursive);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_by_link_object(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_by_link_object");
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
