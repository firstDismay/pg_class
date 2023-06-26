using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод удаляет свойство шаблона
        /// </summary>
        public void pos_temp_prop_del(Int64 iid)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_prop_del");
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
            pos_temp_prop pos_temp_prop = pos_temp_prop_by_id(iid);

            cmdk.Parameters["iid"].Value = iid;
            cmdk.ExecuteNonQuery();

            //Генерируем событие удаления свойства
            if (pos_temp_prop != null)
            {
                PosTempPropChangeEventArgs e = new PosTempPropChangeEventArgs(pos_temp_prop, eAction.Delete);
                PosTempPropOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет свойство шаблона
        /// </summary>
        public void pos_temp_prop_del(pos_temp_prop PosTempProp)
        {
            if (PosTempProp != null)
            {
                pos_temp_prop_del(PosTempProp.Id);
            }
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_prop_del");
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