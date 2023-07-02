using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Изменить значение свойства-перечисления активного представления класса
        /// </summary>
        public object_prop_enum_val object_prop_enum_val_upd(object_prop_enum_val newObjectPropEnumVal)
        {
            object_prop_enum_val ObjectPropEnumVal = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;

            if (newObjectPropEnumVal != null)
            {
                cmdk = CommandByKey("object_prop_enum_val_upd");
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

                cmdk.Parameters["iid_object"].Value = newObjectPropEnumVal.Id_object;
                cmdk.Parameters["iid_class_prop"].Value = newObjectPropEnumVal.Id_class_prop;

                if (newObjectPropEnumVal.Id_prop_enum_val <= 0)
                {
                    cmdk.Parameters["iid_prop_enum_val"].Value = DBNull.Value;
                }
                else
                {
                    cmdk.Parameters["iid_prop_enum_val"].Value = newObjectPropEnumVal.Id_prop_enum_val;
                }
                cmdk.ExecuteNonQuery();

                ObjectPropEnumVal = object_prop_enum_val_by_id_prop(newObjectPropEnumVal);
                if (ObjectPropEnumVal != null)
                {
                    //Генерируем событие изменения значения свойства объекта
                    ObjectPropEnumValChangeEventArgs e = new ObjectPropEnumValChangeEventArgs(ObjectPropEnumVal, eAction.Update);
                    ObjectPropEnumValOnChange(e);
                }
            }
            //Возвращаем сущность
            return ObjectPropEnumVal;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_enum_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_prop_enum_val_upd");
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