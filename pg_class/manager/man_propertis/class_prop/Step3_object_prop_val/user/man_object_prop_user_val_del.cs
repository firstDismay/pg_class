using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Удалить значение пользовательского свойства объекта
        /// </summary>
        public void object_prop_user_val_del(Int64 iid_object, Int64 iid_class_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_prop_user_val_del");
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

            //Предварительный запрос сущностей
            object_prop object_prop = object_prop_by_id(iid_object, iid_class_prop);
            object_prop_user_val object_prop_user_val = object_prop_user_val_by_id_prop(object_prop);

            cmdk.Parameters["iid_object"].Value = iid_object;
            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            switch (error)
            {
                case 0:
                    if (object_prop_user_val != null)
                    {
                        //Генерируем событие изменения значения свойства объекта
                        ObjectPropUserValChangeEventArgs e = new ObjectPropUserValChangeEventArgs(object_prop_user_val, eAction.Delete);
                        ObjectPropUserValOnChange(e);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_object, iid_class_prop, eEntity.object_prop_user_val, error, desc_error, eAction.Delete, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
        }

        /// <summary>
        /// Удалить значение объектного свойства активного представления класса
        /// </summary>
        public void object_prop_user_val_del(object_prop ObjectProp)
        {
            object_prop_user_val_del(ObjectProp.Id_object_carrier, ObjectProp.Id_class_prop);
        }

        /// <summary>
        /// Удалить значение объектного свойства активного представления класса
        /// </summary>
        public void object_prop_user_val_del(object_prop_user_val ObjectPropUserVal)
        {
            object_prop_user_val_del(ObjectPropUserVal.Id_object_carrier, ObjectPropUserVal.Id_class_prop);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_user_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_prop_user_val_del");
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