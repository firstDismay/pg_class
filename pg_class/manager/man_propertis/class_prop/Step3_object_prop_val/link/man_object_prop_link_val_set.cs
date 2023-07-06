using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Добавить новое значение свойства-ссылки активного представления класса
        /// </summary>
        public object_prop_link_val object_prop_link_val_set(object_prop_link_val newObjectPropLinkVal)
        {
            object_prop_link_val ObjectPropLinkVal = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            if (newObjectPropLinkVal != null)
            {
                cmdk = CommandByKey("object_prop_link_val_set");
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

                cmdk.Parameters["iid_object"].Value = newObjectPropLinkVal.Id_object;
                cmdk.Parameters["iid_class_prop"].Value = newObjectPropLinkVal.Id_class_prop;
                cmdk.Parameters["setname"].Value = true;

                if (newObjectPropLinkVal.Link_id_entity_instance <= 0)
                {
                    cmdk.Parameters["iid_entity_instance"].Value = DBNull.Value;
                }
                else
                {
                    cmdk.Parameters["iid_entity_instance"].Value = newObjectPropLinkVal.Link_id_entity_instance;
                }

                if (newObjectPropLinkVal.Link_id_sub_entity_instance <= 0)
                {
                    cmdk.Parameters["iid_sub_entity_instance"].Value = DBNull.Value;
                }
                else
                {
                    cmdk.Parameters["iid_sub_entity_instance"].Value = newObjectPropLinkVal.Link_id_sub_entity_instance;
                }
                cmdk.ExecuteNonQuery();

                ObjectPropLinkVal = object_prop_link_val_by_id_prop(newObjectPropLinkVal);
                if (ObjectPropLinkVal != null)
                {
                    //Генерируем событие изменения значения свойства объекта
                    ObjectPropLinkValChangeEventArgs e = new ObjectPropLinkValChangeEventArgs(ObjectPropLinkVal, eAction.Insert);
                    ObjectPropLinkValOnChange(e);
                }
            }
            //Возвращаем сущность
            return ObjectPropLinkVal;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_link_val_set(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_prop_link_val_set");
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