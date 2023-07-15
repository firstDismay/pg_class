﻿using pg_class.pg_classes;
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
        /// Документ по идентификатору
        /// </summary>
        public document document_by_id(Int64 iid)
        {
            document document = null;
            DataTable tbl_entity = TableByName("vdocument");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id");
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

            cmdk.Parameters["iid"].Value = iid;
            cmdk.Fill(tbl_entity);

            if (tbl_entity.Rows.Count > 0)
            {
                document = new document(tbl_entity.Rows[0]);
            }
            return document;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id");
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
        /// Лист документов по идентификатору пакета документов документа
        /// </summary>
        public List<document> document_by_id_parent(Int64 iid_parent)
        {
            List<document> entity_list = new List<document>();
            DataTable tbl_entity = TableByName("vdocument");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_parent");
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

            cmdk.Parameters["iid_parent"].Value = iid_parent;
            cmdk.Fill(tbl_entity);

            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_parent(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_parent");
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
        /// Лист документов по идентификатору концепции
        /// </summary>
        public List<document> document_by_id_conception(Int64 iid_conception)
        {
            List<document> entity_list = new List<document>();
            DataTable tbl_entity = TableByName("vdocument");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_conception");
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

            cmdk.Fill(tbl_entity);

            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_conception(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_conception");
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
        /// Лист документов по идентификатору категории документов
        /// </summary>
        public List<document> document_by_id_category(Int64 iid_category)
        {
            List<document> entity_list = new List<document>();
            DataTable tbl_entity = TableByName("vdocument");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_category");
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

            cmdk.Parameters["iid_category"].Value = iid_category;
            cmdk.Fill(tbl_entity);

            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_category(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_category");
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
        /// Лист документов по идентификатору шаблона позиции
        /// </summary>
        public List<document> document_by_id_pos_temp(Int64 iid_pos_temp, Boolean position_on, Boolean object_on, Boolean recursive_on)
        {
            List<document> entity_list = new List<document>();
            DataTable tbl_entity = TableByName("vdocument");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_pos_temp");
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

            cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;
            cmdk.Parameters["position_on"].Value = position_on;
            cmdk.Parameters["object_on"].Value = object_on;
            cmdk.Parameters["recursive_on"].Value = recursive_on;
            cmdk.Fill(tbl_entity);

            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист документов по идентификатору шаблона позиции
        /// </summary>
        public List<document> document_by_id_pos_temp(pos_temp Pos_temp, Boolean position_on, Boolean object_on, Boolean recursive_on)
        {
            return document_by_id_pos_temp(Pos_temp.Id, position_on, object_on, recursive_on);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_pos_temp(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_pos_temp");
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
        /// Лист документов по идентификатору позиции
        /// </summary>
        public List<document> document_by_id_position(Int64 iid_position, Boolean object_on, Boolean recursive_on)
        {
            List<document> entity_list = new List<document>();
            DataTable tbl_entity = TableByName("vdocument");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_position");
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
            cmdk.Parameters["object_on"].Value = object_on;
            cmdk.Parameters["recursive_on"].Value = recursive_on;
            cmdk.Fill(tbl_entity);

            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист документов по идентификатору позиции
        /// </summary>
        public List<document> document_by_id_position(position Position, Boolean object_on, Boolean recursive_on)
        {
            return document_by_id_position(Position.Id, object_on, recursive_on);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_position(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_position");
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
        /// Лист документов по идентификатору пользователя
        /// </summary>
        public List<document> document_by_id_user(Int64 iid_user)
        {
            List<document> entity_list = new List<document>();
            DataTable tbl_entity = TableByName("vdocument");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_user");
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

            cmdk.Parameters["iid_user"].Value = iid_user;
            cmdk.Fill(tbl_entity);

            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист документов по идентификатору пользователя
        /// </summary>
        public List<document> document_by_id_user(user User)
        {
            return document_by_id_user(User.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_user(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_user");
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
        /// Лист документов по идентификатору свойства позиции
        /// </summary>
        public List<document> document_by_id_position_prop(Int64 iid_pos_temp_prop, Int64 iid_position)
        {
            List<document> entity_list = new List<document>();
            DataTable tbl_entity = TableByName("vdocument");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_position_prop");

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

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;
            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Fill(tbl_entity);

            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист документов по идентификатору свойства позиции
        /// </summary>
        public List<document> document_by_id_position_prop(position_prop Position_prop)
        {
            return document_by_id_position_prop(Position_prop.Id_position_prop, Position_prop.Id_position_carrier);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_position_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_position_prop");
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
        /// Лист документов по идентификатору свойства шаблона позиции
        /// </summary>
        public List<document> document_by_id_pos_temp_prop(Int64 iid_pos_temp_prop)
        {
            List<document> entity_list = new List<document>();
            DataTable tbl_entity = TableByName("vdocument");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_pos_temp_prop");
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

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;
            cmdk.Fill(tbl_entity);

            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист документов по идентификатору свойства шаблона позиции
        /// </summary>
        public List<document> document_by_id_pos_temp_prop(pos_temp_prop Pos_temp_prop)
        {
            return document_by_id_pos_temp_prop(Pos_temp_prop.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_pos_temp_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_pos_temp_prop");
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
        /// Лист документов по идентификатору группы классов
        /// </summary>
        public List<document> document_by_id_group(Int64 iid_group, Boolean class_on, Boolean object_on, Boolean recursive_on)
        {
            List<document> entity_list = new List<document>();
            DataTable tbl_entity = TableByName("vdocument");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_group");

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
            cmdk.Parameters["class_on"].Value = class_on;
            cmdk.Parameters["object_on"].Value = object_on;
            cmdk.Parameters["recursive_on"].Value = recursive_on;
            cmdk.Fill(tbl_entity);

            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист документов по идентификатору группы классов
        /// </summary>
        public List<document> document_by_id_group(group Group, Boolean class_on, Boolean object_on, Boolean recursive_on)
        {
            return document_by_id_group(Group.Id, class_on, object_on, recursive_on);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_group(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_group");
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
        /// Лист документов по идентификатору класса
        /// </summary>
        public List<document> document_by_id_class(Int64 iid_class, Boolean object_on, Boolean recursive_on)
        {
            List<document> entity_list = new List<document>();
            DataTable tbl_entity = TableByName("vdocument");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_class");
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
            cmdk.Parameters["object_on"].Value = object_on;
            cmdk.Parameters["recursive_on"].Value = recursive_on;
            cmdk.Fill(tbl_entity);

            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист документов по идентификатору класса
        /// </summary>
        public List<document> document_by_id_class(vclass Class, Boolean object_on, Boolean recursive_on)
        {
            return document_by_id_class(Class.Id, object_on, recursive_on);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_class(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_class");
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
        /// Лист документов по идентификатору свойства класса
        /// </summary>
        public List<document> document_by_id_class_prop(Int64 iid_class_prop)
        {
            List<document> entity_list = new List<document>();
            DataTable tbl_entity = TableByName("vdocument");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_class_prop");
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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.Fill(tbl_entity);

            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист документов по идентификатору свойства класса
        /// </summary>
        public List<document> document_by_id_class_prop(class_prop Class_prop)
        {
            return document_by_id_class_prop(Class_prop.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_class_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_class_prop");
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
        /// Лист документов по идентификатору объекта
        /// </summary>
        public List<document> document_by_id_object(Int64 iid_object, Boolean class_on, Boolean group_on, Boolean recursive_on)
        {
            List<document> entity_list = new List<document>();
            DataTable tbl_entity = TableByName("vdocument");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_object");
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
            cmdk.Parameters["class_on"].Value = class_on;
            cmdk.Parameters["group_on"].Value = group_on;
            cmdk.Parameters["recursive_on"].Value = recursive_on;
            cmdk.Fill(tbl_entity);

            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист документов по идентификатору объекта
        /// </summary>
        public List<document> document_by_id_object(object_general Object_general, Boolean class_on, Boolean group_on, Boolean recursive_on)
        {
            return document_by_id_object(Object_general.Id, class_on, group_on, recursive_on);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_object(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_object");
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
        /// Лист документов по идентификатору свойства объекта
        /// </summary>
        public List<document> document_by_id_object_prop(Int64 iid_class_prop, Int64 iid_object)
        {
            List<document> entity_list = new List<document>();
            DataTable tbl_entity = TableByName("vdocument");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_object_prop");
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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.Parameters["iid_object"].Value = iid_object;
            cmdk.Fill(tbl_entity);

            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист документов по идентификатору свойства класса
        /// </summary>
        public List<document> document_by_id_object_prop(object_prop Object_prop)
        {
            return document_by_id_object_prop(Object_prop.Id_class_prop, Object_prop.Id_object_carrier);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_object_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_object_prop");
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
        /// Лист документов по идентификатору записи лога
        /// </summary>
        public List<document> document_by_id_log(Int64 iid_log)
        {
            List<document> entity_list = new List<document>();
            DataTable tbl_entity = TableByName("vdocument");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_log");
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

            cmdk.Parameters["iid_log"].Value = iid_log;
            cmdk.Fill(tbl_entity);

            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        /// <summary>
        /// Лист документов по идентификатору записи лога
        /// </summary>
        public List<document> document_by_id_log(log Log)
        {
            return document_by_id_log(Log.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_id_log(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_id_log");
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
        /// Лист документов концепции по маске имени документа
        /// </summary>
        public List<document> document_by_msk_name_id_conception(String iname, Int64 iid_conception)
        {
            List<document> entity_list = new List<document>();
            DataTable tbl_entity = TableByName("vdocument");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_msk_name_id_conception");
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
            cmdk.Fill(tbl_entity);

            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_msk_name_id_conception(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("document_by_msk_name_id_conception");
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
        /// Лист документов категории по маске имени документа
        /// </summary>
        public List<document> document_by_msk_name_id_category(String iname, Int64 iid_category)
        {
            List<document> entity_list = new List<document>();
            DataTable tbl_entity = TableByName("vdocument");
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_msk_name_id_category");
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
            cmdk.Parameters["iid_category"].Value = iid_category;
            cmdk.Fill(tbl_entity);

            document ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new document(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean document_by_msk_name_id_category(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("document_by_msk_name_id_category");
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