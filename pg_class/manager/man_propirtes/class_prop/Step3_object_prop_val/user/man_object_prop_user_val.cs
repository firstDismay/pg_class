using System;
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
        #region МЕТОДЫ КЛАССА: УПРАВЛЕНИЕ ЗНАЧЕНИЯМИ ПОЛЬЗОВАТЕЛЬСКИХ СВОЙСТВ КЛАССОВ ШАГ №03

        #region ДОБАВИТЬ

        /// <summary>
        /// Добавить новое значение пользовательского свойства активного представления класса
        /// </summary>
        public object_prop_user_val object_prop_user_val_add(object_prop_user_val newObjectPropUserVal)
        {
            object_prop_user_val ObjectPropUserVal = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            //=======================
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
                        //=======================

                        cmdk.Parameters["iid_object"].Value = newObjectPropUserVal.Id_object_carrier;
                        cmdk.Parameters["iid_class_prop"].Value = newObjectPropUserVal.Id_class_prop;

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
                        //=======================

                        cmdk.Parameters["iid_object"].Value = newObjectPropUserVal.Id_object_carrier;
                        cmdk.Parameters["iid_class_prop"].Value = newObjectPropUserVal.Id_class_prop;

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
                //Начало транзакции
                cmdk.ExecuteNonQuery();
                
                error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
                desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
                //SetLastTimeUsing();
                //=======================
                switch (error)
                {
                    case 0:
                        ObjectPropUserVal = object_prop_user_val_by_id_prop(newObjectPropUserVal);
                        break;
                    default:
                        //Вызов события журнала
                        JournalEventArgs me = new JournalEventArgs(newObjectPropUserVal.Id_object_carrier, newObjectPropUserVal.Id_class_prop, eEntity.object_prop_user_val, error, desc_error, eAction.Insert, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgDataException(error, desc_error);
                }
                if (ObjectPropUserVal != null)
                {
                    //Генерируем событие изменения значения свойства объекта
                    ObjectPropUserValChangeEventArgs e = new ObjectPropUserValChangeEventArgs(ObjectPropUserVal, eAction.Insert);
                    ObjectPropUserValOnChange(e);
                }
            }
            //Возвращаем Объект
            return ObjectPropUserVal;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_user_val_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
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
        //*********************************************************************************************
        #endregion

        #region ИЗМЕНИТЬ
        /// <summary>
        /// Изменить новое значение пользовательского свойства активного представления класса
        /// </summary>
        public object_prop_user_val object_prop_user_val_upd(object_prop_user_val newObjectPropUserVal)
        {
            object_prop_user_val ObjectPropUserVal = null;
            
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            if (newObjectPropUserVal != null)
            {
                //=======================
                switch (newObjectPropUserVal.DataSize)
                {
                    case eDataSize.BigData:
                        cmdk = CommandByKey("object_prop_user_big_val_upd");

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

                        cmdk.Parameters["iid_object"].Value = newObjectPropUserVal.Id_object_carrier;
                        cmdk.Parameters["iid_class_prop"].Value = newObjectPropUserVal.Id_class_prop;

                        cmdk.Parameters["ival_text"].Value = DBNull.Value;
                        cmdk.Parameters["ival_bytea"].Value = DBNull.Value;
                        cmdk.Parameters["ival_json"].Value = DBNull.Value;
                        if (newObjectPropUserVal.On_val)
                        {
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
                        }
                        break;
                    case eDataSize.SmallData:
                        cmdk = CommandByKey("object_prop_user_small_val_upd");

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

                        cmdk.Parameters["iid_object"].Value = newObjectPropUserVal.Id_object_carrier;
                        cmdk.Parameters["iid_class_prop"].Value = newObjectPropUserVal.Id_class_prop;

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

                        if (newObjectPropUserVal.On_val)
                        {
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
                        }
                        break;
                }

                //Начало транзакции
                cmdk.ExecuteNonQuery();
                
                error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
                desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
                //SetLastTimeUsing();
                //=======================
                //=======================
                switch (error)
                {
                    case 0:
                        ObjectPropUserVal = object_prop_user_val_by_id_prop(newObjectPropUserVal);
                        break;
                    default:
                        //Вызов события журнала
                        JournalEventArgs me = new JournalEventArgs(newObjectPropUserVal.Id_object_carrier, newObjectPropUserVal.Id_class_prop, eEntity.object_prop_user_val, error, desc_error, eAction.Update, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgDataException(error, desc_error);
                }
                if (ObjectPropUserVal != null)
                {
                    //Генерируем событие изменения значения свойства объекта
                    ObjectPropUserValChangeEventArgs e = new ObjectPropUserValChangeEventArgs(ObjectPropUserVal, eAction.Update);
                    ObjectPropUserValOnChange(e);
                }
            }
            //Возвращаем Объект
            return ObjectPropUserVal;
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_user_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_prop_user_small_val_upd");
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
        //*********************************************************************************************
        
     
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Удалить значение пользовательского свойства объекта
        /// </summary>
        public void object_prop_user_val_del(Int64 iid_object, Int64 iid_class_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("object_prop_user_val_del");

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

            cmdk.Parameters["iid_object"].Value = iid_object;
            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;

            //Предварительный запрос сущностей
            object_prop object_prop = object_prop_by_id(iid_object, iid_class_prop);
            object_prop_user_val object_prop_user_val = object_prop_user_val_by_id_prop(object_prop);
           
            //Начало транзакции
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================

            switch (error)
            {
                case 0:
                    //---Нет действий
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(object_prop_user_val.Id_object_carrier, object_prop_user_val.Id_class_prop, eEntity.object_prop_user_val, error, desc_error, eAction.Delete, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (object_prop_user_val != null)
            {
                //Генерируем событие изменения значения свойства объекта
                ObjectPropUserValChangeEventArgs e = new ObjectPropUserValChangeEventArgs(object_prop_user_val, eAction.Delete);
                ObjectPropUserValOnChange(e);
            }
        }


        /// <summary>
        /// Удалить значение объектного свойства активного представления класса
        /// </summary>
        public void object_prop_user_val_del(object_prop ObjectProp)
        {
            object_prop_user_val_del(ObjectProp.Id_object_carrier, ObjectProp.Id_class_prop);
        }

        /// <summary>
        /// Удалить значение объектного свойства активного представления класса
        /// </summary>
        public void object_prop_user_val_del(object_prop_user_val ObjectPropUserVal)
        {
            object_prop_user_val_del(ObjectPropUserVal.Id_object_carrier, ObjectPropUserVal.Id_class_prop);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_user_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_prop_user_val_del");
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
        //*********************************************************************************************
        #endregion

        #region ВЫБРАТЬ ЗНАЧЕНИЯ СВОЙСТВА ДЛЯ ОБЪЕКТА

        #region Обобщение выборки
        //*********************************************************************************************
    

        /// <summary>
        /// Выбрать значение пользовательского свойства объекта по идентификатору значения свойства
        /// </summary>
        public object_prop_user_val object_prop_user_val_by_id_prop(object_prop ObjectProp)
        {
            object_prop_user_val Result = null;

            switch (ObjectProp.Datatype)
            {
                case eDataType.val_bytea:
                case eDataType.val_text:
                case eDataType.val_json:
                    Result = object_prop_user_big_val_by_id_prop(ObjectProp);
                    break;
                default:
                    Result = object_prop_user_small_val_by_id_prop(ObjectProp);
                    break;
            }
            return Result;
        }

        /// <summary>
        /// Выбрать значение пользовательского свойства объекта по идентификатору значения свойства
        /// </summary>
        public object_prop_user_val object_prop_user_val_by_id_prop(object_prop_user_val ObjectPropUserVal)
        {
            object_prop_user_val Result = null;

            switch (ObjectPropUserVal.DataType)
            {
                case eDataType.val_bytea:
                case eDataType.val_text:
                case eDataType.val_json:
                    Result = object_prop_user_big_val_by_id_prop(ObjectPropUserVal.Id_object_carrier, ObjectPropUserVal.Id_class_prop);
                    break;
                default:
                    Result = object_prop_user_small_val_by_id_prop(ObjectPropUserVal.Id_object_carrier, ObjectPropUserVal.Id_class_prop);
                    break;
            }
            return Result;
        }
        #endregion

        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение пользовательского свойства SMALL объекта по идентификатору значения свойства
        /// </summary>
        public object_prop_user_val object_prop_user_small_val_by_id_prop(Int64 iid_object, Int64 iid_class_prop)
        {
            object_prop_user_val object_prop_user_val = null;

            DataTable tbl_vobject_prop_user_small_val  = TableByName("vobject_prop_user_small_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_prop_user_small_val_by_id_prop");

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

            cmdk.Parameters["iid_object"].Value = iid_object;
            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;

            cmdk.Fill(tbl_vobject_prop_user_small_val);
            
            if (tbl_vobject_prop_user_small_val.Rows.Count > 0)
            {
                object_prop_user_val = new object_prop_user_val(tbl_vobject_prop_user_small_val.Rows[0]);
            }
            return object_prop_user_val;
        }

        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение пользовательского свойства SMALL объекта по идентификатору значения свойства
        /// </summary>
        public object_prop_user_val object_prop_user_small_val_by_id_prop(object_prop ObjectProp)
        {
            return object_prop_user_small_val_by_id_prop(ObjectProp.Id_object_carrier, ObjectProp.Id_class_prop);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_user_small_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_prop_user_small_val_by_id_prop");
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
        //*********************************************************************************************

        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение пользовательского свойства BIG объекта по идентификатору значения свойства
        /// </summary>
        public object_prop_user_val object_prop_user_big_val_by_id_prop(Int64 iid_object, Int64 iid_class_prop)
        {
            object_prop_user_val object_prop_user_val = null;

            DataTable tbl_vobject_prop_user_big_val  = TableByName("vobject_prop_user_big_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_prop_user_big_val_by_id_prop");

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

            cmdk.Parameters["iid_object"].Value = iid_object;
            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;

            cmdk.Fill(tbl_vobject_prop_user_big_val);
            
            if (tbl_vobject_prop_user_big_val.Rows.Count > 0)
            {
                object_prop_user_val = new object_prop_user_val(tbl_vobject_prop_user_big_val.Rows[0]);
            }
            return object_prop_user_val;
        }

        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение пользовательского свойства BIG объекта по идентификатору значения свойства
        /// </summary>
        public object_prop_user_val object_prop_user_big_val_by_id_prop(object_prop ObjectProp)
        {
            return object_prop_user_big_val_by_id_prop(ObjectProp.Id_object_carrier, ObjectProp.Id_class_prop);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_user_big_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_prop_user_big_val_by_id_prop");
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

        #endregion

        #region СВОЙСТВА ПОЛУЧАЕМЫЕ ИЗ БД
        //*********************************************************************************************
        /// <summary>
        /// Определить актуальность состояния данных значения свойства объекта
        /// </summary>
        public eEntityState object_prop_user_val_is_actual(Int64 iid_object, Int64 iid_class_prop, DateTime itimestamp_val)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("object_prop_user_val_is_actual");

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

            cmdk.Parameters["iid_object"].Value = iid_object;
            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.Parameters["itimestamp_val"].Value = itimestamp_val;

            //Начало транзакции
            is_actual = (Int32)cmdk.ExecuteScalar();
            
            return (eEntityState)is_actual; 
        }

        /// <summary>
        /// Определить актуальность состояния значения свойства активного представления класса 
        /// </summary>
        public eEntityState object_prop_user_val_is_actual(object_prop_user_val ObjectPropUserValClass)
        {
            eEntityState Result = eEntityState.History;
            Result = object_prop_user_val_is_actual(ObjectPropUserValClass.Id_object_carrier, ObjectPropUserValClass.Id_class_prop, ObjectPropUserValClass.Timestamp_val);
            return Result;
        }
        #endregion
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ ЗНАЧЕНИЯМИ ПОЛЬЗОВАТЕЛЬСКИХ СВОЙСТВ ОБЪЕКТОВ

        /// <summary>
        /// Делегат события изменения значения пользовательского свойства объекта
        /// </summary>
        public delegate void ObjectPropUserValChangeEventHandler(Object sender, ObjectPropUserValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения пользовательского свойства объекта
        /// </summary>
        public event ObjectPropUserValChangeEventHandler ObjectPropUserValChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения значения свойства объекта
        /// </summary>
        protected virtual void ObjectPropUserValOnChange(ObjectPropUserValChangeEventArgs e)
        {
            ObjectPropUserValChangeEventHandler temp = ObjectPropUserValChange;
            if (temp != null)
            {
                temp(this, e);
            }
            //Вызов события журнала
            JournalEventArgs me = new JournalEventArgs(e);
            JournalMessageOnReceived(me);
        }
        #endregion
    }
}
