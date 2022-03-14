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
        #region МЕТОДЫ КЛАССА: УПРАВЛЕНИЕ ЗНАЧЕНИЯМИ ПОЛЬЗОВАТЕЛЬСКИХ СВОЙСТВ КЛАССОВ ШАГ №02

        #region ДОБАВИТЬ

        /// <summary>
        /// Добавить новое значение пользовательского свойства активного представления класса
        /// </summary>
        public class_prop_user_val class_prop_user_val_add(class_prop_user_val newClassPropUserVal)
        {
            class_prop_user_val ClassPropUserVal = null;
            class_prop class_prop = null;
            Int64 id = 0;
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
                        cmdk = CommandByKey("class_prop_user_big_val_add");
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
                        cmdk = CommandByKey("class_prop_user_small_val_add");

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

                //Начало транзакции
                cmdk.ExecuteNonQuery();
                
                error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
                desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
                //SetLastTimeUsing();
                //=======================
                switch (error)
                {
                    case 0:
                        id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
                        if (id > 0)
                        {
                            class_prop = class_prop_by_id(newClassPropUserVal.Id_class_prop);
                            ClassPropUserVal = class_prop_user_val_by_id_prop(class_prop);
                        }
                        break;
                    default:
                        //Вызов события журнала
                        JournalEventArgs me = new JournalEventArgs(newClassPropUserVal.Id_class_prop, eEntity.class_prop_user_val, error, desc_error, eAction.Insert, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgDataException(error, desc_error);
                }

                if (ClassPropUserVal != null)
                {
                    //Генерируем событие изменения значения объектного свойства класса
                    ClassPropUserValChangeEventArgs e2 = new ClassPropUserValChangeEventArgs(ClassPropUserVal, eAction.Insert);
                    ClassPropUserValOnChange(e2);
                }
            }
            //Возвращаем Объект
            return ClassPropUserVal;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_user_val_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_user_small_val_add");
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
        /// Изменить допустимые параметры пользовательского свойства активного представления класса
        /// </summary>
        public class_prop_user_val class_prop_user_val_upd(class_prop_user_val newClassPropUserVal)
        {
            class_prop class_prop = null;
            class_prop_user_val class_prop_user_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            if (newClassPropUserVal != null)
            {
                //=======================
                switch (newClassPropUserVal.DataSize)
                {
                    case eDataSize.BigData:
                        cmdk = CommandByKey("class_prop_user_big_val_upd");

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
                        cmdk = CommandByKey("class_prop_user_small_val_upd");

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
                        cmdk.Parameters["ival_bigint"].Value = DBNull.Value;

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
                switch (error)
                {
                    case 0:
                        class_prop = class_prop_by_id(newClassPropUserVal.Id_class_prop);
                        class_prop_user_val = class_prop_user_val_by_id_prop(class_prop);
                        break;
                    default:
                        //Вызов события журнала
                        JournalEventArgs me = new JournalEventArgs(newClassPropUserVal.Id_class_prop, eEntity.class_prop_user_val, error, desc_error, eAction.Update, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgDataException(error, desc_error);
                }
                if (class_prop_user_val != null)
                {
                    //Генерируем событие изменения значения объектного свойства класса
                    ClassPropUserValChangeEventArgs e2 = new ClassPropUserValChangeEventArgs(class_prop_user_val, eAction.Update);
                    ClassPropUserValOnChange(e2);
                }

            }
            //Возвращаем Объект
            return class_prop_user_val;
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_user_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_user_small_val_upd");
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
        /// Удалить значение пользовательского свойства активного представления класса
        /// </summary>
        public void class_prop_user_val_del(Int64 iid_class_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_prop_user_val_del");

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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;

            //Предварительный запрос данных
            class_prop class_prop = class_prop_by_id(iid_class_prop);
            class_prop_user_val class_prop_user_val = class_prop_user_val_by_id_prop(class_prop);

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_class_prop, eEntity.class_prop_user_val, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие удаления свойства класса
            if (class_prop_user_val != null)
            {
                //Генерируем событие изменения значения объектного свойства класса
                ClassPropUserValChangeEventArgs e = new ClassPropUserValChangeEventArgs(class_prop_user_val, eAction.Delete);
                ClassPropUserValOnChange(e);
            }
        }


        /// <summary>
        /// Удалить значение пользовательского свойства активного представления класса
        /// </summary>
        public void class_prop_user_val_del(class_prop ClassProp)
        {
            class_prop_user_val_del(ClassProp.Id);
        }

        /// <summary>
        /// Удалить значение пользовательского свойства активного представления класса
        /// </summary>
        public void class_prop_user_val_del(class_prop_user_val ClassPropUserVal)
        {
            class_prop_user_val_del(ClassPropUserVal.Id_class_prop);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_user_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_user_val_del");
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

        #region ВЫБРАТЬ ЗНАЧЕНИЯ СВОЙСТВА ДЛЯ АКТИВНОГО ПРЕДСТАВЛЕНИЯ КЛАССА

        #region Обобщение выборки
        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение пользовательского свойства активного представления класса по идентификатору значения свойства
        /// </summary>
        public class_prop_user_val class_prop_user_val_by_id_prop(class_prop ClassProp)
        {
            class_prop_user_val Result = null;

            switch (ClassProp.Datatype)
            {
                case eDataType.val_bytea:
                case eDataType.val_text:
                case eDataType.val_json:
                    Result = class_prop_user_big_val_by_id_prop(ClassProp.Id);
                    break;
                default:
                    Result = class_prop_user_small_val_by_id_prop(ClassProp.Id);
                    break;
            }
            return Result;
        }

        /// <summary>
        /// Выбрать значение пользовательского свойства активного представления класса по идентификатору значения свойства
        /// </summary>
        public class_prop_user_val class_prop_user_val_by_id_prop(class_prop_user_val ClassPropUserVal)
        {
            class_prop_user_val Result = null;

            switch (ClassPropUserVal.DataType)
            {
                case eDataType.val_bytea:
                case eDataType.val_text:
                case eDataType.val_json:
                    Result = class_prop_user_big_val_by_id_prop(ClassPropUserVal.Id_class_prop);
                    break;
                default:
                    Result = class_prop_user_small_val_by_id_prop(ClassPropUserVal.Id_class_prop);
                    break;
            }
            return Result;
        }
        #endregion

        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение пользовательского свойства активного представления класса по идентификатору значения свойства
        /// </summary>
        public class_prop_user_val class_prop_user_small_val_by_id_prop(Int64 iid_class_prop)
        {
            class_prop_user_val class_prop_user_val = null;

            DataTable tbl_vclass_prop_obj_val_class  = TableByName("vclass_prop_user_small_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_user_small_val_by_id_prop");

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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;

            cmdk.Fill(tbl_vclass_prop_obj_val_class);
            
            if (tbl_vclass_prop_obj_val_class.Rows.Count > 0)
            {
                class_prop_user_val = new class_prop_user_val(tbl_vclass_prop_obj_val_class.Rows[0]);
            }
            return class_prop_user_val;
        }

        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение пользовательского свойства активного представления класса по идентификатору значения свойства
        /// </summary>
        public class_prop_user_val class_prop_user_small_val_by_id_prop(class_prop ClassProp)
        {
            return class_prop_user_small_val_by_id_prop(ClassProp.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_user_small_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_user_small_val_by_id_prop");
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
        /// Выбрать значение пользовательского свойства активного представления класса по идентификатору значения свойства
        /// </summary>
        public class_prop_user_val class_prop_user_big_val_by_id_prop(Int64 iid_class_prop)
        {
            class_prop_user_val class_prop_user_val = null;

            DataTable tbl_vclass_prop_obj_val_class  = TableByName("vclass_prop_user_big_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_user_big_val_by_id_prop");

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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;

            cmdk.Fill(tbl_vclass_prop_obj_val_class);
            
            if (tbl_vclass_prop_obj_val_class.Rows.Count > 0)
            {
                class_prop_user_val = new class_prop_user_val(tbl_vclass_prop_obj_val_class.Rows[0]);
            }
            return class_prop_user_val;
        }

        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение пользовательского свойства активного представления класса по идентификатору значения свойства
        /// </summary>
        public class_prop_user_val class_prop_user_big_val_by_id_prop(class_prop ClassProp)
        {
            return class_prop_user_big_val_by_id_prop(ClassProp.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_user_big_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_user_big_val_by_id_prop");
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

        #region ВЫБРАТЬ ЗНАЧЕНИЯ СВОЙСТВА ДЛЯ ИСТОРИЧЕСКОГО ПРЕДСТАВЛЕНИЯ КЛАССА

        #region Обобщение выборки
        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение пользовательского свойства активного представления класса по идентификатору значения свойства
        /// </summary>
        public class_prop_user_val class_prop_user_val_snapshot_by_id_prop(class_prop ClassProp)
        {
            class_prop_user_val Result = null;

            switch (ClassProp.Datatype)
            {
                case eDataType.val_bytea:
                case eDataType.val_text:
                case eDataType.val_json:
                    Result = class_prop_user_big_val_snapshot_by_id_prop(ClassProp.Id, ClassProp.Timestamp_class);
                    break;
                default:
                    Result = class_prop_user_small_val_snapshot_by_id_prop(ClassProp.Id, ClassProp.Timestamp_class);
                    break;
            }
            return Result;
        }

        /// <summary>
        /// Выбрать значение пользовательского свойства активного представления класса по идентификатору значения свойства
        /// </summary>
        public class_prop_user_val class_prop_user_val_snapshot_by_id_prop(class_prop_user_val ClassPropUserVal)
        {
            class_prop_user_val Result = null;

            switch (ClassPropUserVal.DataType)
            {
                case eDataType.val_bytea:
                case eDataType.val_text:
                case eDataType.val_json:
                    Result = class_prop_user_big_val_snapshot_by_id_prop(ClassPropUserVal.Id_class_prop, ClassPropUserVal.Timestamp_class);
                    break;
                default:
                    Result = class_prop_user_small_val_snapshot_by_id_prop(ClassPropUserVal.Id_class_prop, ClassPropUserVal.Timestamp_class);
                    break;
            }
            return Result;
        }
        #endregion


        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение пользовательского свойства исторического представления класса по идентификатору значения свойства
        /// </summary>
        public class_prop_user_val class_prop_user_small_val_snapshot_by_id_prop(Int64 iid_class_prop, DateTime itimestamp_class)
        {
            class_prop_user_val class_prop_user_val = null;

            DataTable tbl_vclass_prop_obj_val_class  = TableByName("vclass_prop_user_small_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_user_small_val_snapshot_by_id_prop");

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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;

            cmdk.Fill(tbl_vclass_prop_obj_val_class);
            
            if (tbl_vclass_prop_obj_val_class.Rows.Count > 0)
            {
                class_prop_user_val = new class_prop_user_val(tbl_vclass_prop_obj_val_class.Rows[0]);
            }
            return class_prop_user_val;
        }


        /// <summary>
        /// Выбрать значение пользовательского свойства исторического представления класса по идентификатору значения свойства
        /// </summary>
        public class_prop_user_val class_prop_user_small_val_snapshot_by_id_prop(class_prop Class_prop)
        {
            return class_prop_user_small_val_snapshot_by_id_prop(Class_prop.Id, Class_prop.Timestamp_class);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_user_small_val_snapshot_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_user_small_val_snapshot_by_id_prop");
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


        /// <summary>
        /// Выбрать значение пользовательского свойства исторического представления класса по идентификатору значения свойства
        /// </summary>
        public class_prop_user_val class_prop_user_big_val_snapshot_by_id_prop(Int64 iid_class_prop, DateTime itimestamp_class)
        {
            class_prop_user_val class_prop_user_val = null;

            DataTable tbl_vclass_prop_obj_val_class  = TableByName("vclass_prop_user_big_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_user_big_val_snapshot_by_id_prop");

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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.Parameters["itimestamp_class"].Value = itimestamp_class;

            cmdk.Fill(tbl_vclass_prop_obj_val_class);
            
            if (tbl_vclass_prop_obj_val_class.Rows.Count > 0)
            {
                class_prop_user_val = new class_prop_user_val(tbl_vclass_prop_obj_val_class.Rows[0]);
            }
            return class_prop_user_val;
        }


        /// <summary>
        /// Выбрать значение пользовательского свойства исторического представления класса по идентификатору значения свойства
        /// </summary>
        public class_prop_user_val class_prop_user_big_val_snapshot_by_id_prop(class_prop Class_prop)
        {
            return class_prop_user_big_val_snapshot_by_id_prop(Class_prop.Id, Class_prop.Timestamp_class);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_user_big_val_snapshot_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_user_big_val_snapshot_by_id_prop");
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

        #region СВОЙСТВА ПОЛУЧАЕМЫЕ ИЗ БД
        //*********************************************************************************************
        /// <summary>
        /// Определить актуальность состояния значения свойства активного представления класса 
        /// </summary>
        public eEntityState class_prop_user_val_is_actual(Int64 iid_class_prop, DateTime timestamp_class)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_prop_user_val_is_actual");

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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.Parameters["timestamp_class"].Value = timestamp_class;
            
            //Начало транзакции
            is_actual = (Int32)cmdk.ExecuteScalar();
            
            return (eEntityState)is_actual;          
        }

        /// <summary>
        /// Определить актуальность состояния значения свойства активного представления класса 
        /// </summary>
        public eEntityState class_prop_user_val_is_actual(class_prop_user_val ClassPropUserValClass)
        {
            eEntityState Result = eEntityState.History;
            Result = class_prop_object_val_is_actual(ClassPropUserValClass.Id_class_prop, ClassPropUserValClass.Timestamp_class);
            return Result;
        }
        #endregion
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ СВОЙСТВАМИ КЛАССОВ

        /// <summary>
        /// Делегат события изменения данных значения пользовательского свойства класса
        /// </summary>
        public delegate void ClassPropUserValChangeEventHandler(Object sender, ClassPropUserValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения пользовательского свойства класса методом доступа к БД
        /// </summary>
        public event ClassPropUserValChangeEventHandler ClassPropUserValChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения данных значения пользовательского свойства класса
        /// </summary>
        protected virtual void ClassPropUserValOnChange(ClassPropUserValChangeEventArgs e)
        {
            ClassPropUserValChangeEventHandler temp = ClassPropUserValChange;
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
