using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Удалить значение свойства-перечисления позиции
        /// </summary>
        public void position_prop_enum_val_del(Int64 iid_position, Int64 iid_pos_temp_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_prop_enum_val_del");
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

            position_prop position_prop = position_prop_by_id(iid_position, iid_pos_temp_prop);
            position_prop_enum_val position_prop_enum_val = position_prop_enum_val_by_id_prop(position_prop);

            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            switch (error)
            {
                case 0:
                    if (position_prop_enum_val != null)
                    {
                        //Генерируем событие изменения значения свойства объекта
                        PositionPropEnumValChangeEventArgs e = new PositionPropEnumValChangeEventArgs(position_prop_enum_val, eAction.Delete);
                        PositionPropEnumValOnChange(e);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_position, iid_pos_temp_prop, eEntity.position_prop_enum_val, error, desc_error, eAction.Delete, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
        }

        /// <summary>
        /// Удалить значение свойства-перечисления активного представления класса
        /// </summary>
        public void position_prop_enum_val_del(position_prop PositionProp)
        {
            position_prop_enum_val_del(PositionProp.Id_position_carrier, PositionProp.Id_pos_temp_prop);
        }

        /// <summary>
        /// Удалить значение свойства-перечисления активного представления класса
        /// </summary>
        public void position_prop_enum_val_del(position_prop_enum_val PositionPropEnumVal)
        {
            position_prop_enum_val_del(PositionPropEnumVal.Id_position_carrier, PositionPropEnumVal.Id_pos_temp_prop);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_prop_enum_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_prop_enum_val_del");
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