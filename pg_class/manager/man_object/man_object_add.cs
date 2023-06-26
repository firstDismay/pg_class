using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод добавляет новый объект в указанное расположение
        /// </summary>
        public object_general object_add(Int64 iid_class, Int64 iid_position, Int32 iid_unit_conversion_rule, Decimal icquantity)
        {
            object_general Object_add = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_add");
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

            cmdk.Parameters["iid_class"].Value = iid_class;
            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;
            cmdk.Parameters["icquantity"].Value = icquantity;
            cmdk.Parameters["setname"].Value = true;
            cmdk.ExecuteNonQuery();

            id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
            if (id > 0)
            {
                Object_add = object_by_id(id);
            }

            //Генерируем событие изменения 
            if (Object_add != null)
            {
                ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object_add, eAction.Insert);
                ObjectOnChange(e);
            }
            //Возвращаем сущность
            return Object_add;
        }

        /// <summary>
        /// Метод добавляет новый объект в указанное расположение
        /// </summary>
        public object_general object_add(vclass Class, position Position, unit_conversion_rule Unit_conversion_rule, Decimal icquantity)
        {
            return object_add(Class.Id, Position.Id, Unit_conversion_rule.Id, icquantity);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_add");
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