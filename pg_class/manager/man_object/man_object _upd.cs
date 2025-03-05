using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод изменяет указанное представление класса
        /// </summary>
        public object_general object_upd(Int64 iid, Int32 iid_unit_conversion_rule, Decimal icquantity)

        {
            object_general Object = null;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_upd");
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
            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;
            cmdk.Parameters["icquantity"].Value = icquantity;
            cmdk.Parameters["setname"].Value = true;
            cmdk.ExecuteNonQuery();

            Object = object_by_id(iid);

            if (Object != null)
            {
                //Генерируем событие изменения
                ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object, eAction.Update);
                ObjectOnChange(e);
            }
            //Возвращаем сущность
            return Object;
        }

        /// <summary>
        /// Метод изменяет указанное представление класса
        /// </summary>
        public object_general object_upd(object_general Object)
        {
            return object_upd(Object.Id, Object.Id_unit_conversion_rule, Object.Quantity_curent);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_upd");
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