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
        #region МЕТОДЫ КЛАССА: УПРАВЛЕНИЕ ЗНАЧЕНИЯМИ ПОЛЬЗОВАТЕЛЬСКИХ СВОЙСТВ ШАБЛОНОВ ШАГ №03

        #region ДОБАВИТЬ

        /// <summary>
        /// Добавить новое значение пользовательского свойства позиции
        /// </summary>
        public position_prop_user_val position_prop_user_val_add(position_prop_user_val newPositionPropUserVal)
        {
            position_prop_user_val position_prop_user_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            //=======================
            if (newPositionPropUserVal != null)
            {
                switch (newPositionPropUserVal.DataSize)
                {
                    case eDataSize.BigData:
                        cmdk = CommandByKey("position_prop_user_big_val_add");

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
                        cmdk = CommandByKey("position_prop_user_small_val_add");

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
                //Начало транзакции
                cmdk.ExecuteNonQuery();
                
                error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
                desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
                //SetLastTimeUsing();
                //=======================
                switch (error)
                {
                    case 0:
                        position_prop_user_val = position_prop_user_val_by_id_prop(newPositionPropUserVal);
                        break;
                    default:
                        //Вызов события журнала
                        JournalEventArgs me = new JournalEventArgs(newPositionPropUserVal.Id_position_carrier, newPositionPropUserVal.Id_pos_temp_prop, eEntity.position_prop_user_val, error, desc_error, eAction.Insert, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgDataException(error, desc_error);
                }
                //Генерируем событие изменения значения свойства позиции
                PositionPropUserValChangeEventArgs e = new PositionPropUserValChangeEventArgs(position_prop_user_val, eAction.Insert);
                PositionPropUserValOnChange(e);
            }
            //Возвращаем Объект
            return position_prop_user_val;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_prop_user_val_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_prop_user_small_val_add");
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
        /// Изменить новое значение пользовательского свойства позиции
        /// </summary>
        public position_prop_user_val position_prop_user_val_upd(position_prop_user_val newPositionPropUserVal)
        {
            position_prop_user_val position_prop_user_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            //=======================
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
                        //=======================

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
                        //=======================

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
                //Начало транзакции
                cmdk.ExecuteNonQuery();
                
                error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
                desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
                //SetLastTimeUsing();
                //=======================
                switch (error)
                {
                    case 0:
                        position_prop_user_val = position_prop_user_val_by_id_prop(newPositionPropUserVal);
                        break;
                    default:
                        //Вызов события журнала
                        JournalEventArgs me = new JournalEventArgs(newPositionPropUserVal.Id_position_carrier, newPositionPropUserVal.Id_pos_temp_prop, eEntity.position_prop_user_val, error, desc_error, eAction.Update, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgDataException(error, desc_error);
                }
                //Генерируем событие изменения значения свойства позиции
                PositionPropUserValChangeEventArgs e = new PositionPropUserValChangeEventArgs(position_prop_user_val, eAction.Update);
                PositionPropUserValOnChange(e);
            }
            //Возвращаем Объект
            return position_prop_user_val;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_prop_user_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
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
        //*********************************************************************************************
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Удалить значение пользовательского свойства позиции
        /// </summary>
        public void position_prop_user_val_del(Int64 iid_position, Int64 iid_pos_temp_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("position_prop_user_val_del");

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

            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            position_prop position_prop = position_prop_by_id(iid_position, iid_pos_temp_prop);
            position_prop_user_val position_prop_user_val = position_prop_user_val_by_id_prop(position_prop);

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
                    JournalEventArgs me = new JournalEventArgs(position_prop_user_val.Id_position_carrier, position_prop_user_val.Id_pos_temp_prop, eEntity.position_prop_user_val, error, desc_error, eAction.Delete, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения значения свойства объекта
            PositionPropUserValChangeEventArgs e = new PositionPropUserValChangeEventArgs(position_prop_user_val, eAction.Delete);
            PositionPropUserValOnChange(e);
        }

        /// <summary>
        /// Удалить значение объектного свойства активного представления класса
        /// </summary>
        public void position_prop_user_val_del(position_prop PositionProp)
        {
            position_prop_user_val_del(PositionProp.Id_position_carrier, PositionProp.Id_pos_temp_prop);
        }

        /// <summary>
        /// Удалить значение объектного свойства активного представления класса
        /// </summary>
        public void position_prop_user_val_del(position_prop_user_val ObjectPropUserVal)
        {
            position_prop_user_val_del(ObjectPropUserVal.Id_position_carrier, ObjectPropUserVal.Id_pos_temp_prop);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_prop_user_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_prop_user_val_del");
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
        /// Выбрать значение пользовательского свойства позиции по идентификатору значения свойства
        /// </summary>
        public position_prop_user_val position_prop_user_val_by_id_prop(position_prop PositiontProp)
        {
            position_prop_user_val Result = null;

            switch (PositiontProp.Datatype)
            {
                case eDataType.val_bytea:
                case eDataType.val_text:
                case eDataType.val_json:
                    Result = position_prop_user_big_val_by_id_prop(PositiontProp);
                    break;
                default:
                    Result = position_prop_user_small_val_by_id_prop(PositiontProp);
                    break;
            }
            return Result;
        }

        /// <summary>
        /// Выбрать значение пользовательского свойства объекта по идентификатору значения свойства
        /// </summary>
        public position_prop_user_val position_prop_user_val_by_id_prop(position_prop_user_val PositionPropUserVal)
        {
            position_prop_user_val Result = null;

            switch (PositionPropUserVal.DataType)
            {
                case eDataType.val_bytea:
                case eDataType.val_text:
                case eDataType.val_json:
                    Result = position_prop_user_big_val_by_id_prop(PositionPropUserVal.Id_position_carrier, PositionPropUserVal.Id_pos_temp_prop);
                    break;
                default:
                    Result = position_prop_user_small_val_by_id_prop(PositionPropUserVal.Id_position_carrier, PositionPropUserVal.Id_pos_temp_prop);
                    break;
            }
            return Result;
        }
        #endregion

        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение пользовательского свойства SMALL позиции по идентификатору значения свойства
        /// </summary>
        public position_prop_user_val position_prop_user_small_val_by_id_prop(Int64 iid_position, Int64 iid_pos_temp_prop)
        {
            position_prop_user_val position_prop_user_val = null;

            DataTable tbl_vposition_prop_user_small_val  = TableByName("vposition_prop_user_small_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("position_prop_user_small_val_by_id_prop");

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

            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            cmdk.Fill(tbl_vposition_prop_user_small_val);
            
            if (tbl_vposition_prop_user_small_val.Rows.Count > 0)
            {
                position_prop_user_val = new position_prop_user_val(tbl_vposition_prop_user_small_val.Rows[0]);
            }
            return position_prop_user_val;
        }

        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение пользовательского свойства SMALL объекта по идентификатору значения свойства
        /// </summary>
        public position_prop_user_val position_prop_user_small_val_by_id_prop(position_prop PositionProp)
        {
            return position_prop_user_small_val_by_id_prop(PositionProp.Id_position_carrier, PositionProp.Id_pos_temp_prop);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_prop_user_small_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_prop_user_small_val_by_id_prop");
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
        public position_prop_user_val position_prop_user_big_val_by_id_prop(Int64 iid_position, Int64 iid_pos_temp_prop)
        {
            position_prop_user_val position_prop_user_val = null;

            DataTable tbl_vposition_prop_user_big_val  = TableByName("vposition_prop_user_big_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("position_prop_user_big_val_by_id_prop");

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

            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            cmdk.Fill(tbl_vposition_prop_user_big_val);
            
            if (tbl_vposition_prop_user_big_val.Rows.Count > 0)
            {
                position_prop_user_val = new position_prop_user_val(tbl_vposition_prop_user_big_val.Rows[0]);
            }
            return position_prop_user_val;
        }

        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение пользовательского свойства BIG объекта по идентификатору значения свойства
        /// </summary>
        public position_prop_user_val position_prop_user_big_val_by_id_prop(position_prop PositionProp)
        {
            return position_prop_user_big_val_by_id_prop(PositionProp.Id_position_carrier, PositionProp.Id_pos_temp_prop);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_prop_user_big_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_prop_user_big_val_by_id_prop");
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
        /// Определить актуальность состояния данных значения свойства позиции
        /// </summary>
        public eEntityState position_prop_user_val_is_actual(Int64 iid_position, Int64 iid_pos_temp_prop, DateTime itimestamp_val)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("position_prop_user_val_is_actual");

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

            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;
            cmdk.Parameters["itimestamp_val"].Value = itimestamp_val;

            //Начало транзакции
            is_actual = (Int32)cmdk.ExecuteScalar();
            
            return (eEntityState)is_actual;
           
        }

        /// <summary>
        /// Определить актуальность состояния значения свойства активного представления класса 
        /// </summary>
        public eEntityState position_prop_user_val_is_actual(position_prop_user_val PositionPropUserValClass)
        {
            eEntityState Result = eEntityState.NotFound;
            Result = position_prop_user_val_is_actual(PositionPropUserValClass.Id_position_carrier, PositionPropUserValClass.Id_pos_temp_prop, PositionPropUserValClass.Timestamp_val);
            return Result;
        }
        #endregion
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ ЗНАЧЕНИЯМИ ПОЛЬЗОВАТЕЛЬСКИХ СВОЙСТВ ПОЗИЦИЙ

        /// <summary>
        /// Делегат события изменения значения пользовательского свойства Позиции
        /// </summary>
        public delegate void PositionPropUserValChangeEventHandler(Object sender, PositionPropUserValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения пользовательского свойства позиции
        /// </summary>
        public event PositionPropUserValChangeEventHandler PositionPropUserValChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения значения свойства объекта
        /// </summary>
        protected virtual void PositionPropUserValOnChange(PositionPropUserValChangeEventArgs e)
        {
            PositionPropUserValChangeEventHandler temp = PositionPropUserValChange;
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
