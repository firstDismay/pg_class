using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Удалить новое перечисление для свойств
        /// </summary>
        public void prop_enum_val_del(Int64 iid_prop_enum_val)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("prop_enum_val_del");
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

            //Запрос удаляемой сущности
            prop_enum_val Prop_enum_val = prop_enum_val_by_id(iid_prop_enum_val);

            cmdk.Parameters["iid_prop_enum_val"].Value = iid_prop_enum_val;
            cmdk.ExecuteNonQuery();

            //Генерируем событие удаления свойства класса
            if (Prop_enum_val != null)
            {
                PropEnumValChangeEventArgs e = new PropEnumValChangeEventArgs(Prop_enum_val, eAction.Delete);
                PropEnumValOnChange(e);
            }
        }

        /// <summary>
        /// Удалить новое перечисление для свойств
        /// </summary>
        public void prop_enum_val_del(prop_enum_val Prop_enum_val)
        {
            prop_enum_val_del(Prop_enum_val.Id_prop_enum_val);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("prop_enum_val_del");
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