using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод изменяет указанный указанный позиций
        /// </summary>
        public pos_temp pos_temp_upd(Int64 iid, String iname, Boolean ion, Boolean inested_limit, String idesc)
        {
            pos_temp pos_temp = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_upd");
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
            cmdk.Parameters["ion"].Value = ion;
            cmdk.Parameters["inested_limit"].Value = inested_limit;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.ExecuteNonQuery();

            pos_temp = pos_temp_by_id(iid);
            if (pos_temp != null)
            {
                //Генерируем событие изменения
                PosTempChangeEventArgs e = new PosTempChangeEventArgs(pos_temp, eAction.Update);
                PosTempOnChange(e);
            }

            //Возвращаем сущность
            return pos_temp;
        }

        /// <summary>
        /// Метод изменяет указанный указанный позиций
        /// </summary>
        public pos_temp pos_temp_upd(pos_temp pos_temp)
        {
            return pos_temp_upd(pos_temp.Id, pos_temp.Name_pos_temp, pos_temp.On, pos_temp.Nested_limit, pos_temp.Desc);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_upd");
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