﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using pg_class.pg_classes;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Изменить значение пользовательского свойства объектам снимка класса в указанной позиции
        /// </summary>
        public position objects_prop_user_val_objects_upd(position Position_parent, class_prop_user_val newClassPropUserVal, Boolean on_internal = false)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********

            //=======================
            if (newClassPropUserVal != null)
            {
                switch (newClassPropUserVal.DataSize)
                {
                    case eDataSize.BigData:
                        cmdk = CommandByKey("object_prop_user_big_val_objects_upd");

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
                        //=======================

                        cmdk.Parameters["iid_position"].Value = Position_parent.Id;
                        cmdk.Parameters["iid_class_prop"].Value = newClassPropUserVal.Id_class_prop;
                        cmdk.Parameters["itimestamp_class"].Value = newClassPropUserVal.Timestamp_class;
                        cmdk.Parameters["on_internal"].Value = on_internal;

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
                        cmdk = CommandByKey("object_prop_user_small_val_objects_upd");

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
                        //=======================

                        cmdk.Parameters["iid_position"].Value = Position_parent.Id;
                        cmdk.Parameters["iid_class_prop"].Value = newClassPropUserVal.Id_class_prop;
                        cmdk.Parameters["itimestamp_class"].Value = newClassPropUserVal.Timestamp_class;
                        cmdk.Parameters["on_internal"].Value = on_internal;

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

                //Начало транзакции
                cmdk.ExecuteNonQuery();

                error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
                desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
                //SetLastTimeUsing();
                //=======================
                if (error > 0)
                {
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(Position_parent.Id, eEntity.position, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
                }

                /*if (Position_parent != null)
                {
                    //Генерируем событие изменения позиции
                    PositionChangeEventArgs e = new PositionChangeEventArgs(Position_parent, eAction.Update);
                    PositionOnChange(e);
                }*/
            }
            //Возвращаем Объект
            return Position_parent;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_user_val_objects_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_prop_user_small_val_objects_upd");
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
