using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод исключает шаблон позиции из листа ограничений вложенности
        /// </summary>
        public pos_temp pos_temp_nested_exclude(Int64 iid_pos_temp, Int64 iid_pos_temp_nested)
        {
            pos_temp pos_temp = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_nested_exclude");
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

            cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;
            cmdk.Parameters["iid_pos_temp_nested"].Value = iid_pos_temp_nested;
            cmdk.ExecuteNonQuery();

            pos_temp = pos_temp_by_id(iid_pos_temp);
            if (pos_temp != null)
            {
                //Вызов события изменения списка вложенности
                PosTempNestedListChangeEventArgs e;
                e = new PosTempNestedListChangeEventArgs(pos_temp, eActionPosTempNestedList.delrule);
                OnPosTempNestedListChange(e);
            }

            //Возвращаем сущность
            return pos_temp;
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_nested_exclude(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_nested_exclude");
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

        /// <summary>
        /// Метод исключает все шаблоны позиции из листа ограничений вложенности
        /// </summary>
        public pos_temp pos_temp_nested_exclude_all(Int64 iid_pos_temp)
        {
            pos_temp pos_temp = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_nested_exclude_all");
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

            cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;
            cmdk.ExecuteNonQuery();

            pos_temp = pos_temp_by_id(iid_pos_temp);
            if (pos_temp != null)
            {
                //Генерируем событие изменения шаблона позиции
                PosTempNestedListChangeEventArgs e;
                e = new PosTempNestedListChangeEventArgs(pos_temp, eActionPosTempNestedList.delallrule);
                OnPosTempNestedListChange(e);
            }

            //Возвращаем сущность
            return pos_temp;
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_nested_exclude_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_nested_exclude_all");
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