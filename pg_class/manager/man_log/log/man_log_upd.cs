using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод изменяет данные записи журнала
        /// </summary>
        public log log_upd(Int64 iid_log, Int64 iid_category, String iuser_author, DateTime idatetime,
                                        String ititle, String imessage, String iclass_body, String ibody)
        {
            log log = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_upd");
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
            cmdk.Parameters["iid_category"].Value = iid_category;
            cmdk.Parameters["iuser_author"].Value = iuser_author;
            cmdk.Parameters["idatetime"].Value = idatetime;
            cmdk.Parameters["ititle"].Value = ititle;
            cmdk.Parameters["imessage"].Value = imessage;
            cmdk.Parameters["iclass_body"].Value = iclass_body;
            if (ibody != null)
            {
                cmdk.Parameters["ibody"].Value = ibody;
            }
            else
            {
                cmdk.Parameters["ibody"].Value = DBNull.Value;
            }
            cmdk.ExecuteNonQuery();

            log = log_by_id(iid_log);
            if (log != null)
            {
                //Генерируем событие изменения
                LogChangeEventArgs e = new LogChangeEventArgs(log, eAction.Update);
                LogOnChange(e);
            }
            //Возвращаем сущность
            return log;
        }

        /// <summary>
        /// Метод изменяет данные записи журнала
        /// </summary>
        public log log_upd(log log)
        {
            return log_upd(log.Id, log.Id_category, log.User_author, log.Datetime,
                                        log.Title, log.Message, log.Class_body, log.Body);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean log_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_upd");
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