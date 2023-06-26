using pg_class.pg_classes;
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
        public object_prop_user_val object_prop_user_val_add(object_prop_user_val newObjectPropUserVal)
        {
            object_prop_user_val ObjectPropUserVal = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;

            if (newObjectPropUserVal != null)
            {
                switch (newObjectPropUserVal.DataSize)
                {
                    case eDataSize.BigData:
                        cmdk = CommandByKey("object_prop_user_big_val_add");
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

                        cmdk.Parameters["iid_object"].Value = newObjectPropUserVal.Id_object_carrier;
                        cmdk.Parameters["iid_class_prop"].Value = newObjectPropUserVal.Id_class_prop;
                        cmdk.Parameters["setname"].Value = true;
                        cmdk.Parameters["ival_text"].Value = DBNull.Value;
                        cmdk.Parameters["ival_bytea"].Value = DBNull.Value;
                        cmdk.Parameters["ival_json"].Value = DBNull.Value;

                        switch (newObjectPropUserVal.DataType)
                        {
                            case eDataType.val_text:
                                if (newObjectPropUserVal.Val_text != null)
                                {
                                    cmdk.Parameters["ival_text"].Value = newObjectPropUserVal.Val_text;
                                }
                                break;
                            case eDataType.val_bytea:
                                if (newObjectPropUserVal.Val_bytea != null)
                                {
                                    cmdk.Parameters["ival_bytea"].Value = newObjectPropUserVal.Val_bytea;
                                }
                                break;
                            case eDataType.val_json:
                                if (newObjectPropUserVal.Val_json != null)
                                {
                                    cmdk.Parameters["ival_json"].Value = newObjectPropUserVal.Val_json;
                                }
                                break;
                        }

                        break;
                    case eDataSize.SmallData:
                        cmdk = CommandByKey("object_prop_user_small_val_add");

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

                        cmdk.Parameters["iid_object"].Value = newObjectPropUserVal.Id_object_carrier;
                        cmdk.Parameters["iid_class_prop"].Value = newObjectPropUserVal.Id_class_prop;
                        cmdk.Parameters["setname"].Value = true;
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

                        switch (newObjectPropUserVal.DataType)
                        {
                            case eDataType.val_varchar:
                                if (newObjectPropUserVal.Val_varchar != null)
                                {
                                    cmdk.Parameters["ival_varchar"].Value = newObjectPropUserVal.Val_varchar;
                                }
                                break;
                            case eDataType.val_int:
                                cmdk.Parameters["ival_int"].Value = newObjectPropUserVal.Val_int;
                                break;
                            case eDataType.val_numeric:
                                cmdk.Parameters["ival_numeric"].Value = newObjectPropUserVal.Val_numeric;
                                break;
                            case eDataType.val_real:
                                cmdk.Parameters["ival_real"].Value = newObjectPropUserVal.Val_real;
                                break;
                            case eDataType.val_double:
                                cmdk.Parameters["ival_double"].Value = newObjectPropUserVal.Val_double;
                                break;
                            case eDataType.val_money:
                                cmdk.Parameters["ival_money"].Value = newObjectPropUserVal.Val_money;
                                break;
                            case eDataType.val_boolean:
                                cmdk.Parameters["ival_boolean"].Value = newObjectPropUserVal.Val_boolean;
                                break;
                            case eDataType.val_date:
                                cmdk.Parameters["ival_date"].Value = newObjectPropUserVal.Val_date;
                                break;
                            case eDataType.val_time:
                                cmdk.Parameters["ival_time"].Value = newObjectPropUserVal.Val_time;
                                break;
                            case eDataType.val_interval:
                                cmdk.Parameters["ival_interval"].Value = newObjectPropUserVal.Val_interval;
                                break;
                            case eDataType.val_timestamp:
                                cmdk.Parameters["ival_timestamp"].Value = newObjectPropUserVal.Val_timestamp;
                                break;
                            case eDataType.val_bigint:
                                cmdk.Parameters["ival_bigint"].Value = newObjectPropUserVal.Val_bigint;
                                break;
                        }

                        break;
                }
                cmdk.ExecuteNonQuery();
                ObjectPropUserVal = object_prop_user_val_by_id_prop(newObjectPropUserVal);
                if (ObjectPropUserVal != null)
                {
                    //Генерируем событие изменения значения свойства объекта
                    ObjectPropUserValChangeEventArgs e = new ObjectPropUserValChangeEventArgs(ObjectPropUserVal, eAction.Insert);
                    ObjectPropUserValOnChange(e);
                }
            }
            //Возвращаем сущность
            return ObjectPropUserVal;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_user_val_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("object_prop_user_val_add");
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