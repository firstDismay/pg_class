using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;
using Newtonsoft.Json;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод добавляет новую запись журнала
        /// </summary>
        public log log_add(Int64 iid_category, String iuser_author, DateTime idatetime,
                                     String ititle, String imessage, String iclass_body, String ibody,
                                     Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            log log = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_add");
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
            cmdk.Parameters["iuser_author"].Value = iuser_author;
            cmdk.Parameters["idatetime"].Value = idatetime;

            cmdk.Parameters["ititle"].Value = ititle;
            cmdk.Parameters["imessage"].Value = imessage;
            
            if (iclass_body == null || iclass_body == "") iclass_body = "none"; 
            cmdk.Parameters["iclass_body"].Value = iclass_body;

            if (ibody == null || !man_json.IsJson(ibody))
            {
                cmdk.Parameters["ibody"].Value = "{}";

            }
            else
            {
                cmdk.Parameters["ibody"].Value = ibody;
            }

            cmdk.Parameters["iid_entity"].Value = iid_entity;
            cmdk.Parameters["iid_entity_instance"].Value = iid_entity_instance;
            cmdk.Parameters["iid_sub_entity_instance"].Value = iid_sub_entity_instance;
            cmdk.ExecuteNonQuery();

            id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
            if (id > 0)
            {
                log = log_by_id(id);
            }

            if (log != null)
            {
                //Генерируем событие изменения 
                LogChangeEventArgs e = new LogChangeEventArgs(log, eAction.Insert);
                LogOnChange(e);
            }
            //Возвращаем сущность
            return log;
        }

        /// <summary>
        /// Метод добавляет новую запись журнала
        /// </summary>
        public log log_add(Int64 iid_category, String iuser_author, DateTime idatetime,
                                     String ititle, String imessage, String iclass_body, String ibody,
                                     user User)
        {
            return log_add(iid_category, iuser_author, idatetime,
                                     ititle, imessage, iclass_body, ibody,
                                     User.EntityID, User.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новую запись журнала
        /// </summary>
        public log log_add(Int64 iid_category, String iuser_author, DateTime idatetime,
                                     String ititle, String imessage, String iclass_body, String ibody,
                                     pos_temp Pos_temp)
        {
            return log_add(iid_category, iuser_author, idatetime,
                                     ititle, imessage, iclass_body, ibody,
                                     Pos_temp.EntityID, Pos_temp.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новую запись журнала
        /// </summary>
        public log log_add(Int64 iid_category, String iuser_author, DateTime idatetime,
                                     String ititle, String imessage, String iclass_body, String ibody,
                                     pos_temp_prop Pos_temp_prop)
        {
            return log_add(iid_category, iuser_author, idatetime,
                                     ititle, imessage, iclass_body, ibody,
                                     Pos_temp_prop.EntityID, Pos_temp_prop.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новую запись журнала
        /// </summary>
        public log log_add(Int64 iid_category, String iuser_author, DateTime idatetime,
                                     String ititle, String imessage, String iclass_body, String ibody,
                                     position Position)
        {
            return log_add(iid_category, iuser_author, idatetime,
                                     ititle, imessage, iclass_body, ibody,
                                     Position.EntityID, Position.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новую запись журнала
        /// </summary>
        public log log_add(Int64 iid_category, String iuser_author, DateTime idatetime,
                                     String ititle, String imessage, String iclass_body, String ibody,
                                     position_prop Position_prop)
        {
            return log_add(iid_category, iuser_author, idatetime,
                                     ititle, imessage, iclass_body, ibody,
                                     Position_prop.EntityID, Position_prop.Id_position_prop, Position_prop.Id_position_carrier);
        }

        /// <summary>
        /// Метод добавляет новую запись журнала
        /// </summary>
        public log log_add(Int64 iid_category, String iuser_author, DateTime idatetime,
                                     String ititle, String imessage, String iclass_body, String ibody,
                                     object_general Object_general)
        {
            return log_add(iid_category, iuser_author, idatetime,
                                     ititle, imessage, iclass_body, ibody,
                                     Object_general.EntityID, Object_general.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новую запись журнала
        /// </summary>
        public log log_add(Int64 iid_category, String iuser_author, DateTime idatetime,
                                     String ititle, String imessage, String iclass_body, String ibody,
                                     object_prop Object_prop)
        {
            return log_add(iid_category, iuser_author, idatetime,
                                     ititle, imessage, iclass_body, ibody,
                                     Object_prop.EntityID, Object_prop.Id_class_prop, Object_prop.Id_object_carrier);
        }

        /// <summary>
        /// Метод добавляет новую запись журнала
        /// </summary>
        public log log_add(Int64 iid_category, String iuser_author, DateTime idatetime,
                                     String ititle, String imessage, String iclass_body, String ibody,
                                     group Group)
        {
            return log_add(iid_category, iuser_author, idatetime,
                                     ititle, imessage, iclass_body, ibody,
                                     Group.EntityID, Group.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новую запись журнала
        /// </summary>
        public log log_add(Int64 iid_category, String iuser_author, DateTime idatetime,
                                     String ititle, String imessage, String iclass_body, String ibody,
                                     vclass Class)
        {
            return log_add(iid_category, iuser_author, idatetime,
                                     ititle, imessage, iclass_body, ibody,
                                     Class.EntityID, Class.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новую запись журнала
        /// </summary>
        public log log_add(Int64 iid_category, String iuser_author, DateTime idatetime,
                                     String ititle, String imessage, String iclass_body, String ibody,
                                     class_prop Class_prop)
        {
            return log_add(iid_category, iuser_author, idatetime,
                                     ititle, imessage, iclass_body, ibody,
                                     Class_prop.EntityID, Class_prop.Id, -1);
        }

        /// <summary>
        /// Метод добавляет новую запись журнала
        /// </summary>
        public log log_add(Int64 iid_category, String iuser_author, DateTime idatetime,
                                     String ititle, String imessage, String iclass_body, String ibody,
                                     document Document)
        {
            return log_add(iid_category, iuser_author, idatetime,
                                     ititle, imessage, iclass_body, ibody,
                                     Document.EntityID, Document.Id, -1);
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean log_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_add");
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