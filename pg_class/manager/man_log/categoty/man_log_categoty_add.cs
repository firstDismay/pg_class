using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод добавляет новую категорию записей журнала
        /// </summary>
        public log_category log_category_add(Int64 iid_conception, String iname, String idesc, Int32 ilevel, Boolean ion)
        {
            log_category log_category = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_category_add");
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
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["ilevel"].Value = ilevel;
            cmdk.Parameters["ion"].Value = ion;
            cmdk.ExecuteNonQuery();

            id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
            if (id > 0)
            {
                log_category = log_category_by_id(id);
            }

            if (log_category != null)
            {
                //Генерируем событие изменения категории документов
                LogCategoryChangeEventArgs e = new LogCategoryChangeEventArgs(log_category, eAction.Insert);
                LogCategoryOnChange(e);
            }
            //Возвращаем сущность
            return log_category;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean log_category_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_category_add");
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