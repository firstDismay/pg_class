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
        /// Ссылка документа по идентификатору
        /// </summary>
        public doc_link doc_link_by_id(Int64 iid)
        {
            doc_link doc_link = null;

            DataTable tbl_entity = TableByName("vdoc_link");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("doc_link_by_id");

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
                doc_link = new doc_link(tbl_entity.Rows[0]);
            }
            return doc_link;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_link_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("doc_link_by_id");
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
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            doc_link doc_link = null;

            DataTable tbl_entity = TableByName("vdoc_link");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("doc_link_by_entity");

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


            cmdk.Parameters["iid_document"].Value = iid_document;
            cmdk.Parameters["iid_entity"].Value = iid_entity;
            cmdk.Parameters["iid_entity_instance"].Value = iid_entity_instance;
            cmdk.Parameters["iid_sub_entity_instance"].Value = iid_sub_entity_instance;

            cmdk.Fill(tbl_entity);

            if (tbl_entity.Rows.Count > 0)
            {
                doc_link = new doc_link(tbl_entity.Rows[0]);
            }
            return doc_link;
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, user User)
        {
            return doc_link_by_entity(iid_document, User.EntityID, User.Id, -1);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, pos_temp Pos_temp)
        {
            return doc_link_by_entity(iid_document, Pos_temp.EntityID, Pos_temp.Id, -1);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, pos_temp_prop Pos_temp_prop)
        {
            return doc_link_by_entity(iid_document, Pos_temp_prop.EntityID, Pos_temp_prop.Id, -1);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, position Position)
        {
            return doc_link_by_entity(iid_document, Position.EntityID, Position.Id, -1);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, position_prop Position_prop)
        {
            return doc_link_by_entity(iid_document, Position_prop.EntityID, Position_prop.Id_position_prop, Position_prop.Id_position_carrier);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, object_general Object_general)
        {
            return doc_link_by_entity(iid_document, Object_general.EntityID, Object_general.Id, -1);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, object_prop Object_prop)
        {
            return doc_link_by_entity(iid_document, Object_prop.EntityID, Object_prop.Id_class_prop, Object_prop.Id_object_carrier);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, group Group)
        {
            return doc_link_by_entity(iid_document, Group.EntityID, Group.Id, -1);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, vclass Class)
        {
            return doc_link_by_entity(iid_document, Class.EntityID, Class.Id, -1);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, class_prop Class_prop)
        {
            return doc_link_by_entity(iid_document, Class_prop.EntityID, Class_prop.Id, -1);
        }

        /// <summary>
        /// Ссылка на документ по идентификатору сущности
        /// </summary>
        public doc_link doc_link_by_entity(Int64 iid_document, log Log)
        {
            return doc_link_by_entity(iid_document, Log.EntityID, Log.Id, -1);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_link_by_entity(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("doc_link_by_entity");
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
        /// Лист ссылок документа по идентификатору документа
        /// </summary>
        public List<doc_link> doc_link_by_id_document(Int64 iid_document)
        {
            List<doc_link> entity_list = new List<doc_link>();

            DataTable tbl_entity = TableByName("vdoc_link");


            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("doc_link_by_id_document");

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


            cmdk.Parameters["iid_document"].Value = iid_document;

            cmdk.Fill(tbl_entity);

            doc_link ce;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    ce = new doc_link(dr);
                    entity_list.Add(ce);
                }
            }
            return entity_list;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_link_by_id_document(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("doc_link_by_id_document");
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
