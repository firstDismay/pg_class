using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод уничтожает объект минуя корзину
        /// </summary>
        public void object_destroy(Int64 iid)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_destroy");
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

            //Запрос удаляемой сущности
            object_general Object = object_by_id(iid);

            cmdk.Parameters["iid"].Value = iid;
            cmdk.ExecuteNonQuery();

            //Генерируем событие удаления представления класса
            if (Object != null)
            {
                ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object, eAction.Delete);
                ObjectOnChange(e);
            }
        }

        /// <summary>
        /// Метод уничтожает объект минуя корзину
        /// </summary>
        public void object_destroy(object_general Object)
        {
            object_destroy(Object.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_destroy(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_destroy");
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