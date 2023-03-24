using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Добавить новый элемент в перечисление для свойств
        /// </summary>
        public prop_enum_val prop_enum_val_add(Int64 iid_prop_enum, Decimal ival_numeric, String ival_varchar, Int64 iid_object_reference, Int64 isort = -1)
        {
            prop_enum_val Prop_enum_val = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;

            if (isort < 0)
            {
                isort = 1;
            }

            cmdk = CommandByKey("prop_enum_val_add");
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

            cmdk.Parameters["iid_prop_enum"].Value = iid_prop_enum;
            cmdk.Parameters["ival_numeric"].Value = ival_numeric;
            cmdk.Parameters["ival_varchar"].Value = ival_varchar;
            cmdk.Parameters["isort"].Value = isort;
            cmdk.Parameters["iid_object_reference"].Value = iid_object_reference;
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            switch (error)
            {
                case 0:
                    id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
                    Prop_enum_val = prop_enum_val_by_id(id);
                    if (Prop_enum_val != null)
                    {
                        //Генерируем событие изменения свойства класса
                        PropEnumValChangeEventArgs e = new PropEnumValChangeEventArgs(Prop_enum_val, eAction.Insert);
                        PropEnumValOnChange(e);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.prop_enum_val, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Возвращаем Сущность
            return Prop_enum_val;
        }

        /// <summary>
        /// Добавить новый элемент в перечисление для свойств
        /// </summary>
        public prop_enum_val prop_enum_val_add(prop_enum Prop_enum, Object ival, Int64 iid_object_reference, Int64 isort)
        {
            prop_enum_val Result = null;

            switch (Prop_enum.Datatype)
            {
                case eDataType.val_varchar:
                    Result = prop_enum_val_add(Prop_enum.Id_prop_enum, 0, (String)ival, iid_object_reference, isort);
                    break;
                case eDataType.val_numeric:
                    Result = prop_enum_val_add(Prop_enum.Id_prop_enum, (Decimal)ival, "", iid_object_reference, isort);
                    break;
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_val_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("prop_enum_val_add");
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