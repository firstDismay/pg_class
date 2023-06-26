using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод удаляет указанную концепцию
        /// </summary>
        public void conception_del(Int64 id)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("conception_del");
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

            conception conception = conception_by_id(id);
            cmdk.Parameters["iid"].Value = id;
            cmdk.ExecuteNonQuery();

            //Генерируем событие изменения концепции
            if (conception != null)
            {
                ConceptionChangeEventArgs e = new ConceptionChangeEventArgs(conception, eAction.Delete);
                ConceptionOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет указанную концепцию
        /// </summary>
        public void conception_del(conception Conception)
        {
            conception_del(Conception);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean conception_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("conception_del");
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
