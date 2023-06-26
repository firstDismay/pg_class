using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод добавляет новую концепцию
        /// </summary>
        public conception conception_add(String iname, String idesc)
        {
            conception conception = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("conception_add");
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
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.ExecuteNonQuery();

            id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
            if (id > 0)
            {
                conception = conception_by_id(id);
            }

            //Генерируем событие изменения концепции
            ConceptionChangeEventArgs e = new ConceptionChangeEventArgs(conception, eAction.Insert);
            ConceptionOnChange(e);
            //Возвращаем сущность
            return conception;
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean conception_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("conception_add");
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