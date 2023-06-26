using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод удаляет указанный шаблон позиций
        /// </summary>
        public void pos_temp_del(Int64 id)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_del");
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

            pos_temp pos_temp = pos_temp_by_id(id);

            cmdk.Parameters["iid"].Value = id;
            cmdk.ExecuteNonQuery();

            //Генерируем событие изменения концепции
            if (pos_temp != null)
            {
                PosTempChangeEventArgs e = new PosTempChangeEventArgs(pos_temp, eAction.Delete);
                PosTempOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет указанный шаблон позиций
        /// </summary>
        public void pos_temp_del(pos_temp pos_temp)
        {
            pos_temp_del(pos_temp.Id);
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_del");
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