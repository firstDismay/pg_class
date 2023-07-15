﻿using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Добавить новое значение пользовательского свойства активного представления класса
        /// </summary>
        public class_prop_user_val class_prop_user_val_set(class_prop_user_val newClassPropUserVal)
        {
            class_prop_user_val ClassPropUserVal = null;
            class_prop class_prop = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;

            if (newClassPropUserVal != null)
            {
                switch (newClassPropUserVal.DataSize)
                {
                    case eDataSize.BigData:
                        cmdk = CommandByKey("class_prop_user_big_val_set");
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

                        cmdk.Parameters["iid_class_prop"].Value = newClassPropUserVal.Id_class_prop;
                        cmdk.Parameters["imin_val"].Value = newClassPropUserVal.Min_val;
                        cmdk.Parameters["imin_on"].Value = newClassPropUserVal.Min_on;
                        cmdk.Parameters["imax_val"].Value = newClassPropUserVal.Max_val;
                        cmdk.Parameters["imax_on"].Value = newClassPropUserVal.Max_on;
                        cmdk.Parameters["ival_text"].Value = DBNull.Value;
                        cmdk.Parameters["ival_bytea"].Value = DBNull.Value;
                        cmdk.Parameters["ival_json"].Value = DBNull.Value;

                        if (newClassPropUserVal.On_val)
                        {
                            switch (newClassPropUserVal.DataType)
                            {
                                case eDataType.val_text:
                                    if (newClassPropUserVal.Val_text != null)
                                    {
                                        cmdk.Parameters["ival_text"].Value = newClassPropUserVal.Val_text;
                                    }
                                    break;
                                case eDataType.val_bytea:
                                    if (newClassPropUserVal.Val_bytea != null)
                                    {
                                        cmdk.Parameters["ival_bytea"].Size = newClassPropUserVal.Val_bytea.Length;
                                        cmdk.Parameters["ival_bytea"].Value = newClassPropUserVal.Val_bytea;
                                    }
                                    break;
                                case eDataType.val_json:
                                    if (newClassPropUserVal.Val_json != null)
                                    {
                                        cmdk.Parameters["ival_json"].Value = newClassPropUserVal.Val_json;
                                    }
                                    break;
                            }
                        }
                        break;
                    case eDataSize.SmallData:
                        cmdk = CommandByKey("class_prop_user_small_val_set");

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

                        cmdk.Parameters["iid_class_prop"].Value = newClassPropUserVal.Id_class_prop;
                        cmdk.Parameters["imin_val"].Value = newClassPropUserVal.Min_val;
                        cmdk.Parameters["imin_on"].Value = newClassPropUserVal.Min_on;
                        cmdk.Parameters["imax_val"].Value = newClassPropUserVal.Max_val;
                        cmdk.Parameters["imax_on"].Value = newClassPropUserVal.Max_on;
                        cmdk.Parameters["iround"].Value = newClassPropUserVal.Round_val;
                        cmdk.Parameters["iround_on"].Value = newClassPropUserVal.Round_on;
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

                        if (newClassPropUserVal.On_val)
                        {
                            switch (newClassPropUserVal.DataType)
                            {
                                case eDataType.val_varchar:
                                    if (newClassPropUserVal.Val_varchar != null)
                                    {
                                        cmdk.Parameters["ival_varchar"].Value = newClassPropUserVal.Val_varchar;
                                    }
                                    break;
                                case eDataType.val_int:
                                    cmdk.Parameters["ival_int"].Value = newClassPropUserVal.Val_int;
                                    break;
                                case eDataType.val_numeric:
                                    cmdk.Parameters["ival_numeric"].Value = newClassPropUserVal.Val_numeric;
                                    break;
                                case eDataType.val_real:
                                    cmdk.Parameters["ival_real"].Value = newClassPropUserVal.Val_real;
                                    break;
                                case eDataType.val_double:
                                    cmdk.Parameters["ival_double"].Value = newClassPropUserVal.Val_double;
                                    break;
                                case eDataType.val_money:
                                    cmdk.Parameters["ival_money"].Value = newClassPropUserVal.Val_money;
                                    break;
                                case eDataType.val_boolean:
                                    cmdk.Parameters["ival_boolean"].Value = newClassPropUserVal.Val_boolean;
                                    break;
                                case eDataType.val_date:
                                    cmdk.Parameters["ival_date"].Value = newClassPropUserVal.Val_date;
                                    break;
                                case eDataType.val_time:
                                    cmdk.Parameters["ival_time"].Value = newClassPropUserVal.Val_time;
                                    break;
                                case eDataType.val_interval:
                                    cmdk.Parameters["ival_interval"].Value = newClassPropUserVal.Val_interval;
                                    break;
                                case eDataType.val_timestamp:
                                    cmdk.Parameters["ival_timestamp"].Value = newClassPropUserVal.Val_timestamp;
                                    break;
                                case eDataType.val_bigint:
                                    cmdk.Parameters["ival_bigint"].Value = newClassPropUserVal.Val_bigint;
                                    break;
                            }
                        }
                        break;

                }
                cmdk.ExecuteNonQuery();

                class_prop = class_prop_by_id(newClassPropUserVal.Id_class_prop);
                ClassPropUserVal = class_prop_user_val_by_id_prop(class_prop);
                if (ClassPropUserVal != null)
                {
                    //Генерируем событие изменения значения объектного свойства класса
                    ClassPropUserValChangeEventArgs e2 = new ClassPropUserValChangeEventArgs(ClassPropUserVal, eAction.Insert);
                    ClassPropUserValOnChange(e2);
                }
            }
            //Возвращаем сущность
            return ClassPropUserVal;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_user_val_set(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_user_small_val_set");
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