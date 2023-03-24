using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Агрегатная функция определяет сумму значений глобальных числовых свойств агрегатных объектов с учетом количества
        /// </summary>
        public Decimal object_prop_user_small_agg_func_sum(Int64 iid_global_prop, Int64 iid_object, Boolean on_quantity = true)
        {
            Decimal Result = 0;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_prop_user_small_agg_func_sum");
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

            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;
            cmdk.Parameters["iid_object"].Value = iid_object;
            cmdk.Parameters["on_quantity"].Value = on_quantity;
            Result = (Decimal)cmdk.ExecuteScalar();

            return Result;
        }

        /// <summary>
        /// Агрегатная функция определяет сумму значений глобальных числовых свойств агрегатных объектов с учетом количества
        /// </summary>
        public Decimal object_prop_user_small_agg_func_sum(global_prop GlobalProp, object_general Object, Boolean on_quantity = true)
        {
            Decimal Result = 0;

            if (GlobalProp != null && Object != null)
            {
                Result = object_prop_user_small_agg_func_sum(GlobalProp.Id, Object.Id, on_quantity);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_user_small_agg_func_sum(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_prop_user_small_agg_func_sum");
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