using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод переносит объект в новое расположение
        /// </summary>
        public object_general object_move(Int64 iid_object, Int64 iid_position, Decimal icquantity)
        {
            object_general Object_move = null;
            object_general Object_change = null;
            object_general Result = null;
            Int64 id = 0;
            NpgsqlCommandKey cmdk;

            if (iid_object > 0)
            {
                Object_move = object_by_id(iid_object);
            }

            cmdk = CommandByKey("object_move");
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

            cmdk.Parameters["iid_object"].Value = iid_object;
            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["icquantity"].Value = icquantity;
            cmdk.ExecuteNonQuery();

            id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
            if (Object_move != null)
            {
                if ((id > 0) && (id != Object_move.Id))
                {
                    Object_change = object_by_id(iid_object);
                    Object_move = object_by_id(id);
                    Result = Object_change;
                }
                else
                {
                    Object_move = object_by_id(id);
                    Result = Object_move;
                }
            }

            if (Object_move != null)
            {
                //Генерируем событие изменения объекта
                ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object_move, eAction.Move);
                ObjectOnChange(e);
            }
            //Если есть остаток то генерируем изменение остатка
            if (Object_change != null)
            {
                ObjectChangeEventArgs e3 = new ObjectChangeEventArgs(Object_change, eAction.Update);
                ObjectOnChange(e3);
            }
            //Возвращаем сущность
            return Result;
        }

        /// <summary>
        /// Метод переносит объект в новое расположение
        /// </summary>
        public object_general object_move(object_general Object, position Position, Decimal icuantity)
        {
            return object_move(Object.Id, Position.Id, icuantity);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_move(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_move");
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