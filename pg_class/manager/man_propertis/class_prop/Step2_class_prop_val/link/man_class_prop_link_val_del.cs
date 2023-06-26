using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Удалить данные значения свойства-ссылки
        /// </summary>
        public void class_prop_link_val_del(Int64 iid_class_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_link_val_del");
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

            //Получение удаляемой сущности
            class_prop_link_val Class_prop_link_val = class_prop_link_val_by_id_prop(iid_class_prop);

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.ExecuteNonQuery();
                        
            //Генерируем событие удаления свойства класса
            if (Class_prop_link_val != null)
            {
                ClassPropLinkValChangeEventArgs e = new ClassPropLinkValChangeEventArgs(Class_prop_link_val, eAction.Delete);
                ClassPropLinkValOnChange(e);
            }
        }

        /// <summary>
        /// Удалить новое перечисление для свойств
        /// </summary>
        public void class_prop_link_val_del(class_prop_link_val Class_prop_link_val)
        {
            class_prop_link_val_del(Class_prop_link_val.Id_class_prop);
        }

        /// <summary>
        /// Удалить новое перечисление для свойств
        /// </summary>
        public void class_prop_link_val_del(class_prop Class_prop)
        {
            class_prop_link_val_del(Class_prop.Id);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_link_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_link_val_del");
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