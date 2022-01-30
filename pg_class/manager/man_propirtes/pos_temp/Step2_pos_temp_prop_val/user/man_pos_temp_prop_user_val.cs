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
        /// Добавить новое значение пользовательского свойства шаблона
        /// </summary>
        public pos_temp_prop_user_val pos_temp_prop_user_val_add(pos_temp_prop_user_val newPosTempPropUserVal)
        {
            pos_temp_prop_user_val PosTempPropUserVal = null;
            pos_temp_prop pos_temp_prop = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            //=======================
            if (newPosTempPropUserVal != null)
            {
                switch (newPosTempPropUserVal.DataSize)
                {
                    case eDataSize.BigData:
                        cmdk = CommandByKey("pos_temp_prop_user_big_val_add");

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
                                        cmdk.Parameters["ival_bytea"].Size = newPosTempPropUserVal.Val_bytea.Length;
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
                        cmdk = CommandByKey("pos_temp_prop_user_small_val_add");

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
                        cmdk.Parameters["ival_bigint"].Value = 0;

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
                            pos_temp_prop = pos_temp_prop_by_id(newPosTempPropUserVal.Id_pos_temp_prop);
                            PosTempPropUserVal = pos_temp_prop_user_val_by_id_prop(pos_temp_prop);
                        }
                        break;
                    default:
                        //Вызов события журнала
                        JournalEventArgs me = new JournalEventArgs(newPosTempPropUserVal.Id_pos_temp_prop, eEntity.pos_temp_prop_user_val, error, desc_error, eAction.Insert, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgDataException(error, desc_error);
                }

                if (PosTempPropUserVal != null)
                {
                    //Генерируем событие изменения значения свойства шаблона
                    PosTempPropUserValChangeEventArgs e = new PosTempPropUserValChangeEventArgs(PosTempPropUserVal, eAction.Insert);
                    PosTempPropUserValOnChange(e);
                }
            }
            //Возвращаем Объект
            return PosTempPropUserVal;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_user_val_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_user_small_val_add");
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
        public pos_temp_prop_user_val pos_temp_prop_user_val_upd(pos_temp_prop_user_val newPosTempPropUserVal)
        {
            pos_temp_prop pos_temp_prop = null;
            pos_temp_prop_user_val pos_temp_prop_user_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            if (newPosTempPropUserVal != null)
            {
                //=======================
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
                        //=======================

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
                        //=======================

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

                //Начало транзакции
                cmdk.ExecuteNonQuery();
                
                error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
                desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
                //SetLastTimeUsing();
                //=======================
                switch (error)
                {
                    case 0:
                        pos_temp_prop = pos_temp_prop_by_id(newPosTempPropUserVal.Id_pos_temp_prop);
                        pos_temp_prop_user_val = pos_temp_prop_user_val_by_id_prop(pos_temp_prop);
                        break;
                    default:
                        //Вызов события журнала
                        JournalEventArgs me = new JournalEventArgs(newPosTempPropUserVal.Id_pos_temp_prop, eEntity.pos_temp_prop_user_val, error, desc_error, eAction.Update, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgDataException(error, desc_error);
                }
                if (pos_temp_prop_user_val != null)
                {
                    //Генерируем событие изменения значения объектного свойства шаблоа
                    PosTempPropUserValChangeEventArgs e = new PosTempPropUserValChangeEventArgs(pos_temp_prop_user_val, eAction.Update);
                    PosTempPropUserValOnChange(e);
                }
            }
            //Возвращаем Объект
            return pos_temp_prop_user_val;
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_user_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
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
        //*********************************************************************************************


        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Удалить значение пользовательского свойства шаблона
        /// </summary>
        public void pos_temp_prop_user_val_del(Int64 iid_pos_temp_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("pos_temp_prop_user_val_del");

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

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            //Предварительный запрос данных
            pos_temp_prop pos_temp_prop = pos_temp_prop_by_id(iid_pos_temp_prop);
            pos_temp_prop_user_val pos_temp_prop_user_val = pos_temp_prop_user_val_by_id_prop(pos_temp_prop);
            
            //Начало транзакции
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_pos_temp_prop, eEntity.pos_temp_prop_user_val, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие удаления свойства класса
            if (pos_temp_prop_user_val != null)
            {
                //Генерируем событие изменения значения свойства шаблона
                PosTempPropUserValChangeEventArgs e = new PosTempPropUserValChangeEventArgs(pos_temp_prop_user_val, eAction.Delete);
                PosTempPropUserValOnChange(e);
            }
        }

        /// <summary>
        /// Удалить значение пользовательского свойства активного представления класса
        /// </summary>
        public void pos_temp_prop_user_val_del(pos_temp_prop PosTempProp)
        {
            pos_temp_prop_user_val_del(PosTempProp.Id);
        }

        /// <summary>
        /// Удалить значение пользовательского свойства активного представления класса
        /// </summary>
        public void pos_temp_prop_user_val_del(pos_temp_prop_user_val PosTempPropUserVal)
        {
            pos_temp_prop_user_val_del(PosTempPropUserVal.Id_pos_temp_prop);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_user_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_user_val_del");
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

        #region ВЫБРАТЬ

        #region Обобщение выборки
        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение пользовательского свойства шаблона по идентификатору значения свойства
        /// </summary>
        public pos_temp_prop_user_val pos_temp_prop_user_val_by_id_prop(pos_temp_prop PosTempProp)
        {
            pos_temp_prop_user_val Result = null;

            switch (PosTempProp.Datatype)
            {
                case eDataType.val_bytea:
                case eDataType.val_text:
                case eDataType.val_json:
                    Result = pos_temp_prop_user_big_val_by_id_prop(PosTempProp.Id);
                    break;
                default:
                    Result = pos_temp_prop_user_small_val_by_id_prop(PosTempProp.Id);
                    break;
            }
            return Result;
        }

        /// <summary>
        /// Выбрать значение пользовательского свойства шаблона по идентификатору значения свойства
        /// </summary>
        public pos_temp_prop_user_val pos_temp_prop_user_val_by_id_prop(pos_temp_prop_user_val PosTempPropUserVal)
        {
            pos_temp_prop_user_val Result = null;

            switch (PosTempPropUserVal.DataType)
            {
                case eDataType.val_bytea:
                case eDataType.val_text:
                case eDataType.val_json:
                    Result = pos_temp_prop_user_big_val_by_id_prop(PosTempPropUserVal.Id_pos_temp_prop);
                    break;
                default:
                    Result = pos_temp_prop_user_small_val_by_id_prop(PosTempPropUserVal.Id_pos_temp_prop);
                    break;
            }
            return Result;
        }
        #endregion

        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение пользовательского свойства шаблона по идентификатору значения свойства
        /// </summary>
        public pos_temp_prop_user_val pos_temp_prop_user_small_val_by_id_prop(Int64 iid_pos_temp_prop)
        {
            pos_temp_prop_user_val pos_temp_prop_user_val = null;

            DataTable tbl_vpos_temp_prop_obj_val_class  = TableByName("vpos_temp_prop_user_small_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_prop_user_small_val_by_id_prop");

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

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            cmdk.Fill(tbl_vpos_temp_prop_obj_val_class);
            
            if (tbl_vpos_temp_prop_obj_val_class.Rows.Count > 0)
            {
                pos_temp_prop_user_val = new pos_temp_prop_user_val(tbl_vpos_temp_prop_obj_val_class.Rows[0]);
            }
            return pos_temp_prop_user_val;
        }

        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение пользовательского свойства активного представления класса по идентификатору значения свойства
        /// </summary>
        public pos_temp_prop_user_val pos_temp_prop_user_small_val_by_id_prop(pos_temp_prop PosTempProp)
        {
            return pos_temp_prop_user_small_val_by_id_prop(PosTempProp.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_user_small_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_user_small_val_by_id_prop");
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
        /// Выбрать значение пользовательского свойства шаблона по идентификатору значения свойства
        /// </summary>
        public pos_temp_prop_user_val pos_temp_prop_user_big_val_by_id_prop(Int64 iid_pos_temp_prop)
        {
            pos_temp_prop_user_val pos_temp_prop_user_val = null;

            DataTable tbl_vpos_temp_prop_obj_val_class  = TableByName("vpos_temp_prop_user_big_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_prop_user_big_val_by_id_prop");

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

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            cmdk.Fill(tbl_vpos_temp_prop_obj_val_class);
            
            if (tbl_vpos_temp_prop_obj_val_class.Rows.Count > 0)
            {
                pos_temp_prop_user_val = new pos_temp_prop_user_val(tbl_vpos_temp_prop_obj_val_class.Rows[0]);
            }
            return pos_temp_prop_user_val;
        }

        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение пользовательского свойства шаблона по идентификатору значения свойства
        /// </summary>
        public pos_temp_prop_user_val pos_temp_prop_user_big_val_by_id_prop(pos_temp_prop PosTempProp)
        {
            return pos_temp_prop_user_big_val_by_id_prop(PosTempProp.Id);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_user_big_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_user_big_val_by_id_prop");
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
       
        #endregion
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ СВОЙСТВАМИ КЛАССОВ

        /// <summary>
        /// Делегат события изменения данных значения пользовательского свойства шаблона
        /// </summary>
        public delegate void PosTempPropUserValChangeEventHandler(Object sender, PosTempPropUserValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения пользовательского свойства шаблона методом доступа к БД
        /// </summary>
        public event PosTempPropUserValChangeEventHandler PosTempPropUserValChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения данных значения пользовательского свойства шаблона
        /// </summary>
        protected virtual void PosTempPropUserValOnChange(PosTempPropUserValChangeEventArgs e)
        {
            PosTempPropUserValChangeEventHandler temp = PosTempPropUserValChange;
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
