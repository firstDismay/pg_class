using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Изменить допустимые параметры пользовательского свойства активного представления класса
        /// </summary>
        public pos_temp_prop_user_val pos_temp_prop_user_val_upd(pos_temp_prop_user_val newPosTempPropUserVal)
        {
            pos_temp_prop pos_temp_prop = null;
            pos_temp_prop_user_val pos_temp_prop_user_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;

            if (newPosTempPropUserVal != null)
            {
                switch (newPosTempPropUserVal.DataSize)
                {
                    case eDataSize.BigData:
                        cmdk = CommandByKey("pos_temp_prop_user_big_val_upd");

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

                        cmdk.Parameters["iid_pos_temp_prop"].Value = newPosTempPropUserVal.Id_pos_temp_prop;
                        cmdk.Parameters["imin_val"].Value = newPosTempPropUserVal.Min_val;
                        cmdk.Parameters["imin_on"].Value = newPosTempPropUserVal.Min_on;
                        cmdk.Parameters["imax_val"].Value = newPosTempPropUserVal.Max_val;
                        cmdk.Parameters["imax_on"].Value = newPosTempPropUserVal.Max_on;
                        cmdk.Parameters["ival_text"].Value = DBNull.Value;
                        cmdk.Parameters["ival_bytea"].Value = DBNull.Value;
                        cmdk.Parameters["ival_json"].Value = DBNull.Value;

                        if (newPosTempPropUserVal.On_val)
                        {
                            switch (newPosTempPropUserVal.DataType)
                            {
                                case eDataType.val_text:
                                    if (newPosTempPropUserVal.Val_text != null)
                                    {
                                        cmdk.Parameters["ival_text"].Value = newPosTempPropUserVal.Val_text;
                                    }
                                    break;
                                case eDataType.val_bytea:
                                    if (newPosTempPropUserVal.Val_bytea != null)
                                    {
                                        cmdk.Parameters["ival_bytea"].Value = newPosTempPropUserVal.Val_bytea;
                                    }
                                    break;
                                case eDataType.val_json:
                                    if (newPosTempPropUserVal.Val_json != null)
                                    {
                                        cmdk.Parameters["ival_json"].Value = newPosTempPropUserVal.Val_json;
                                    }
                                    break;
                            }
                        }
                        break;
                    case eDataSize.SmallData:
                        cmdk = CommandByKey("pos_temp_prop_user_small_val_upd");

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

                        cmdk.Parameters["iid_pos_temp_prop"].Value = newPosTempPropUserVal.Id_pos_temp_prop;
                        cmdk.Parameters["imin_val"].Value = newPosTempPropUserVal.Min_val;
                        cmdk.Parameters["imin_on"].Value = newPosTempPropUserVal.Min_on;
                        cmdk.Parameters["imax_val"].Value = newPosTempPropUserVal.Max_val;
                        cmdk.Parameters["imax_on"].Value = newPosTempPropUserVal.Max_on;
                        cmdk.Parameters["iround"].Value = newPosTempPropUserVal.Round_val;
                        cmdk.Parameters["iround_on"].Value = newPosTempPropUserVal.Round_on;
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
                        cmdk.Parameters["ival_bigint"].Value = DBNull.Value;

                        if (newPosTempPropUserVal.On_val)
                        {
                            switch (newPosTempPropUserVal.DataType)
                            {
                                case eDataType.val_varchar:
                                    if (newPosTempPropUserVal.Val_varchar != null)
                                    {
                                        cmdk.Parameters["ival_varchar"].Value = newPosTempPropUserVal.Val_varchar;
                                    }
                                    break;
                                case eDataType.val_int:
                                    cmdk.Parameters["ival_int"].Value = newPosTempPropUserVal.Val_int;
                                    break;
                                case eDataType.val_numeric:
                                    cmdk.Parameters["ival_numeric"].Value = newPosTempPropUserVal.Val_numeric;
                                    break;
                                case eDataType.val_real:
                                    cmdk.Parameters["ival_real"].Value = newPosTempPropUserVal.Val_real;
                                    break;
                                case eDataType.val_double:
                                    cmdk.Parameters["ival_double"].Value = newPosTempPropUserVal.Val_double;
                                    break;
                                case eDataType.val_money:
                                    cmdk.Parameters["ival_money"].Value = newPosTempPropUserVal.Val_money;
                                    break;
                                case eDataType.val_boolean:
                                    cmdk.Parameters["ival_boolean"].Value = newPosTempPropUserVal.Val_boolean;
                                    break;
                                case eDataType.val_date:
                                    cmdk.Parameters["ival_date"].Value = newPosTempPropUserVal.Val_date;
                                    break;
                                case eDataType.val_time:
                                    cmdk.Parameters["ival_time"].Value = newPosTempPropUserVal.Val_time;
                                    break;
                                case eDataType.val_interval:
                                    cmdk.Parameters["ival_interval"].Value = newPosTempPropUserVal.Val_interval;
                                    break;
                                case eDataType.val_timestamp:
                                    cmdk.Parameters["ival_timestamp"].Value = newPosTempPropUserVal.Val_timestamp;
                                    break;
                                case eDataType.val_bigint:
                                    cmdk.Parameters["ival_bigint"].Value = newPosTempPropUserVal.Val_bigint;
                                    break;
                            }
                        }
                        break;
                }
                cmdk.ExecuteNonQuery();

                pos_temp_prop = pos_temp_prop_by_id(newPosTempPropUserVal.Id_pos_temp_prop);
                pos_temp_prop_user_val = pos_temp_prop_user_val_by_id_prop(pos_temp_prop);
                if (pos_temp_prop_user_val != null)
                {
                    //Генерируем событие изменения значения объектного свойства шаблоа
                    PosTempPropUserValChangeEventArgs e = new PosTempPropUserValChangeEventArgs(pos_temp_prop_user_val, eAction.Update);
                    PosTempPropUserValOnChange(e);
                }
            }

            //Возвращаем сущность
            return pos_temp_prop_user_val;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_user_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_prop_user_small_val_upd");
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