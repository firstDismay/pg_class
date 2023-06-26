using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод изменяет указанную категорию записей журнала
        /// </summary>
        public log_category log_category_upd(Int64 iid, String iname, String idesc, Int32 ilevel, Boolean ion)
        {
            log_category log_category = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_category_upd");
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
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["ilevel"].Value = ilevel;
            cmdk.Parameters["ion"].Value = ion;
            cmdk.ExecuteNonQuery();

            log_category = log_category_by_id(iid);
            if (log_category != null)
            {
                //Генерируем событие изменения категории документов
                LogCategoryChangeEventArgs e = new LogCategoryChangeEventArgs(log_category, eAction.Update);
                LogCategoryOnChange(e);
            }
            //Возвращаем сущность
            return log_category;
        }

        /// <summary>
        /// Метод изменяет указанную категорию документов
        /// </summary>
        public log_category log_category_upd(log_category log_category)
        {
            return log_category_upd(log_category.Id, log_category.Name, log_category.Desc, log_category.Level, log_category.On);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean log_category_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("log_category_upd");
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