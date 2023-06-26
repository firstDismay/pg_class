using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Изменить новое значение свойства-перечисления позиции
        /// </summary>
        public position_prop_enum_val position_prop_enum_val_upd(position_prop_enum_val newPositionPropEnumVal)
        {
            position_prop_enum_val position_prop_enum_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;

            if (newPositionPropEnumVal != null)
            {
                cmdk = CommandByKey("position_prop_enum_val_upd");

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

                cmdk.Parameters["iid_position"].Value = newPositionPropEnumVal.Id_position_carrier;
                cmdk.Parameters["iid_pos_temp_prop"].Value = newPositionPropEnumVal.Id_pos_temp_prop;

                if (newPositionPropEnumVal.Id_prop_enum_val <= 0)
                {
                    cmdk.Parameters["iid_prop_enum_val"].Value = DBNull.Value;
                }
                else
                {
                    cmdk.Parameters["iid_prop_enum_val"].Value = newPositionPropEnumVal.Id_prop_enum_val;
                }
                cmdk.ExecuteNonQuery();
                
                position_prop_enum_val = position_prop_enum_val_by_id_prop(newPositionPropEnumVal);
                if (position_prop_enum_val != null)
                {
                    //Генерируем событие изменения значения свойства объекта
                    PositionPropEnumValChangeEventArgs e = new PositionPropEnumValChangeEventArgs(position_prop_enum_val, eAction.Update);
                    PositionPropEnumValOnChange(e);
                }
            }
            //Возвращаем сущность
            return position_prop_enum_val;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_prop_enum_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_prop_enum_val_upd");
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
