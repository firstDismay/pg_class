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
        public void prop_enum_del(Int64 iid_prop_enum, Int64 iid_conception)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("prop_enum_del");
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
            prop_enum Prop_enum = prop_enum_by_id(iid_prop_enum);

            cmdk.Parameters["iid_prop_enum"].Value = iid_prop_enum;
            cmdk.Parameters["iid_conception"].Value = iid_conception;
            cmdk.ExecuteNonQuery();

            if (Prop_enum != null)
            {
                //Генерируем событие удаления перечисления для свойства
                PropEnumChangeEventArgs e = new PropEnumChangeEventArgs(Prop_enum, eAction.Delete);
                PropEnumOnChange(e);
            }
        }

        /// <summary>
        /// Удалить новое перечисление для свойств
        /// </summary>
        public void prop_enum_del(prop_enum Prop_enum)
        {
            prop_enum_del(Prop_enum.Id_prop_enum, Prop_enum.Id_conception);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("prop_enum_del");
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