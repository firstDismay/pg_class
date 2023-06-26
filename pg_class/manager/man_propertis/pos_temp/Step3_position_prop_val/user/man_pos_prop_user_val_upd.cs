using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Изменить новое значение пользовательского свойства позиции
        /// </summary>
        public position_prop_user_val position_prop_user_val_upd(position_prop_user_val newPositionPropUserVal)
        {
            position_prop_user_val position_prop_user_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;

            if (newPositionPropUserVal != null)
            {
                switch (newPositionPropUserVal.DataSize)
                {
                    case eDataSize.BigData:
                        cmdk = CommandByKey("position_prop_user_big_val_upd");

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

                        cmdk.Parameters["iid_position"].Value = newPositionPropUserVal.Id_position_carrier;
                        cmdk.Parameters["iid_pos_temp_prop"].Value = newPositionPropUserVal.Id_pos_temp_prop;
                        cmdk.Parameters["ival_text"].Value = DBNull.Value;
                        cmdk.Parameters["ival_bytea"].Value = DBNull.Value;
                        cmdk.Parameters["ival_json"].Value = DBNull.Value;

                        switch (newPositionPropUserVal.DataType)
                        {
                            case eDataType.val_text:
                                if (newPositionPropUserVal.Val_text != null)
                                {
                                    cmdk.Parameters["ival_text"].Value = newPositionPropUserVal.Val_text;
                                }
                                break;
                            case eDataType.val_bytea:
                                if (newPositionPropUserVal.Val_bytea != null)
                                {
                                    cmdk.Parameters["ival_bytea"].Value = newPositionPropUserVal.Val_bytea;
                                }
                                break;
                            case eDataType.val_json:
                                if (newPositionPropUserVal.Val_json != null)
                                {
                                    cmdk.Parameters["ival_json"].Value = newPositionPropUserVal.Val_json;
                                }
                                break;
                        }
                        break;
                    case eDataSize.SmallData:
                        cmdk = CommandByKey("position_prop_user_small_val_upd");

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

                        cmdk.Parameters["iid_position"].Value = newPositionPropUserVal.Id_position_carrier;
                        cmdk.Parameters["iid_pos_temp_prop"].Value = newPositionPropUserVal.Id_pos_temp_prop;
                        cmdk.Parameters["ival_varchar"].Value = DBNull.Value;
                        cmdk.Parameters["ival_int"].Value = DBNull.Value;
                        cmdk.Parameters["ival_numeric"].Value = DBNull.Value;
                        cmdk.Parameters["ival_real"].Value = DBNull.Value;
                        cmdk.Parameters["ival_double"].Value = DBNull.Value;
                        cmdk.Parameters["ival_money"].Value = DBNull.Value;
                        cmdk.Parameters["ival_boolean"].Value = DBNull.Value;
                        cmdk.Parameters["ival_date"].Value = DBNull.Value;
                        cmdk.Parameters["ival_time"].Value = DBNull.Value;
                        cmdk.Parameters["ival_interval"].Value = DBNull.Value;
                        cmdk.Parameters["ival_timestamp"].Value = DBNull.Value;
                        cmdk.Parameters["ival_bigint"].Value = 0;

                        switch (newPositionPropUserVal.DataType)
                        {
                            case eDataType.val_varchar:
                                if (newPositionPropUserVal.Val_varchar != null)
                                {
                                    cmdk.Parameters["ival_varchar"].Value = newPositionPropUserVal.Val_varchar;
                                }
                                break;
                            case eDataType.val_int:
                                cmdk.Parameters["ival_int"].Value = newPositionPropUserVal.Val_int;
                                break;
                            case eDataType.val_numeric:
                                cmdk.Parameters["ival_numeric"].Value = newPositionPropUserVal.Val_numeric;
                                break;
                            case eDataType.val_real:
                                cmdk.Parameters["ival_real"].Value = newPositionPropUserVal.Val_real;
                                break;
                            case eDataType.val_double:
                                cmdk.Parameters["ival_double"].Value = newPositionPropUserVal.Val_double;
                                break;
                            case eDataType.val_money:
                                cmdk.Parameters["ival_money"].Value = newPositionPropUserVal.Val_money;
                                break;
                            case eDataType.val_boolean:
                                cmdk.Parameters["ival_boolean"].Value = newPositionPropUserVal.Val_boolean;
                                break;
                            case eDataType.val_date:
                                cmdk.Parameters["ival_date"].Value = newPositionPropUserVal.Val_date;
                                break;
                            case eDataType.val_time:
                                cmdk.Parameters["ival_time"].Value = newPositionPropUserVal.Val_time;
                                break;
                            case eDataType.val_interval:
                                cmdk.Parameters["ival_interval"].Value = newPositionPropUserVal.Val_interval;
                                break;
                            case eDataType.val_timestamp:
                                cmdk.Parameters["ival_timestamp"].Value = newPositionPropUserVal.Val_timestamp;
                                break;
                            case eDataType.val_bigint:
                                cmdk.Parameters["ival_bigint"].Value = newPositionPropUserVal.Val_bigint;
                                break;
                        }

                        break;
                }
                cmdk.ExecuteNonQuery();

                position_prop_user_val = position_prop_user_val_by_id_prop(newPositionPropUserVal);
                if (position_prop_user_val != null)
                {
                    //Генерируем событие изменения значения свойства позиции
                    PositionPropUserValChangeEventArgs e = new PositionPropUserValChangeEventArgs(position_prop_user_val, eAction.Update);
                    PositionPropUserValOnChange(e);
                }
            }
            //Возвращаем сущность
            return position_prop_user_val;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_prop_user_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_prop_user_small_val_upd");
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
