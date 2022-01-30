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
        /// Добавить новое значение свойства-перечисления позиции
        /// </summary>
        public position_prop_enum_val position_prop_enum_val_add(position_prop_enum_val newPositionPropEnumVal)
        {
            position_prop_enum_val position_prop_enum_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            //=======================
            if (newPositionPropEnumVal != null)
            {
                cmdk = CommandByKey("position_prop_enum_val_add");

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

                //Начало транзакции
                cmdk.ExecuteNonQuery();
                
                error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
                desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
                //SetLastTimeUsing();
                //=======================
                switch (error)
                {
                    case 0:
                        position_prop_enum_val = position_prop_enum_val_by_id_prop(newPositionPropEnumVal);
                        break;
                    default:
                        //Вызов события журнала
                        position_prop_enum_val = newPositionPropEnumVal;
                        JournalEventArgs me = new JournalEventArgs(newPositionPropEnumVal.Id_position_carrier, newPositionPropEnumVal.Id_pos_temp_prop, eEntity.position_prop_enum_val, error, desc_error, eAction.Insert, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgDataException(error, desc_error);
                }
                //Генерируем событие изменения значения свойства объекта
                PositionPropEnumValChangeEventArgs e = new PositionPropEnumValChangeEventArgs(position_prop_enum_val, eAction.Insert);
                PositionPropEnumValOnChange(e);
            }
            //Возвращаем Объект
            return position_prop_enum_val;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_prop_enum_val_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_prop_enum_val_add");
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
        /// Изменить новое значение свойства-перечисления позиции
        /// </summary>
        public position_prop_enum_val position_prop_enum_val_upd(position_prop_enum_val newPositionPropEnumVal)
        {
            position_prop_enum_val position_prop_enum_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            //=======================
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
                //=======================

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

                //Начало транзакции
                cmdk.ExecuteNonQuery();
               
                error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
                desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
                //SetLastTimeUsing();
                //=======================
                switch (error)
                {
                    case 0:
                        position_prop_enum_val = position_prop_enum_val_by_id_prop(newPositionPropEnumVal);
                        break;
                    default:
                        //Вызов события журнала
                        position_prop_enum_val = newPositionPropEnumVal;
                        JournalEventArgs me = new JournalEventArgs(newPositionPropEnumVal.Id_position_carrier, newPositionPropEnumVal.Id_pos_temp_prop, eEntity.position_prop_enum_val, error, desc_error, eAction.Update, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgDataException(error, desc_error);
                }
                //Генерируем событие изменения значения свойства объекта
                PositionPropEnumValChangeEventArgs e = new PositionPropEnumValChangeEventArgs(position_prop_enum_val, eAction.Update);
                PositionPropEnumValOnChange(e);
            }
            //Возвращаем Объект
            return position_prop_enum_val;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_prop_enum_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
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
        //*********************************************************************************************
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Удалить значение свойства-перечисления позиции
        /// </summary>
        public void position_prop_enum_val_del(Int64 iid_position, Int64 iid_pos_temp_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("position_prop_enum_val_del");

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
            position_prop_enum_val position_prop_enum_val = position_prop_enum_val_by_id_prop(position_prop);

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
                    JournalEventArgs me = new JournalEventArgs(iid_position, iid_pos_temp_prop, eEntity.position_prop_enum_val, error, desc_error, eAction.Delete, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения значения свойства объекта
            PositionPropEnumValChangeEventArgs e = new PositionPropEnumValChangeEventArgs(position_prop_enum_val, eAction.Delete);
            PositionPropEnumValOnChange(e);
        }


        /// <summary>
        /// Удалить значение свойства-перечисления активного представления класса
        /// </summary>
        public void position_prop_enum_val_del(position_prop PositionProp)
        {
            position_prop_enum_val_del(PositionProp.Id_position_carrier, PositionProp.Id_pos_temp_prop);
        }


        /// <summary>
        /// Удалить значение свойства-перечисления активного представления класса
        /// </summary>
        public void position_prop_enum_val_del(position_prop_enum_val PositionPropEnumVal)
        {
            position_prop_enum_val_del(PositionPropEnumVal.Id_position_carrier, PositionPropEnumVal.Id_pos_temp_prop);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_prop_enum_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_prop_enum_val_del");
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


        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение свойства позиции типа перечисление по идентификатору значения свойства
        /// </summary>
        public position_prop_enum_val position_prop_enum_val_by_id_prop(Int64 iid_position, Int64 iid_pos_temp_prop)
        {
            position_prop_enum_val position_prop_enum_val = null;

            DataTable tbl_entity  = TableByName("vposition_prop_enum_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("position_prop_enum_val_by_id_prop");

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

            cmdk.Fill(tbl_entity);
            
            if (tbl_entity.Rows.Count > 0)
            {
                position_prop_enum_val = new position_prop_enum_val(tbl_entity.Rows[0]);
            }
            return position_prop_enum_val;
        }

        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение свойства позиции типа перечисление по идентификатору значения свойства
        /// </summary>
        public position_prop_enum_val position_prop_enum_val_by_id_prop(position_prop PositionProp)
        {
            return position_prop_enum_val_by_id_prop(PositionProp.Id_position_carrier, PositionProp.Id_pos_temp_prop);
        }

        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение свойства позиции типа перечисление по идентификатору значения свойства
        /// </summary>
        public position_prop_enum_val position_prop_enum_val_by_id_prop(position_prop_enum_val PositionPropEnum_val)
        {
            return position_prop_enum_val_by_id_prop(PositionPropEnum_val.Id_position_carrier, PositionPropEnum_val.Id_pos_temp_prop);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_prop_enum_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("position_prop_enum_val_by_id_prop");
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
        public eEntityState position_prop_enum_val_is_actual(Int64 iid_position, Int64 iid_pos_temp_prop, DateTime itimestamp_val)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("position_prop_enum_val_is_actual");

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
        public eEntityState position_prop_enum_val_is_actual(position_prop_enum_val PositionPropEnumVal)
        {
            eEntityState Result = eEntityState.History;
            Result = position_prop_enum_val_is_actual(PositionPropEnumVal.Id_position_carrier, PositionPropEnumVal.Id_pos_temp_prop, PositionPropEnumVal.Timestamp_val);
            return Result;
        }
        #endregion
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ ЗНАЧЕНИЯМИ ПОЛЬЗОВАТЕЛЬСКИХ СВОЙСТВ ОБЪЕКТОВ

        /// <summary>
        /// Делегат события изменения значения свойства позиции типа перечисление
        /// </summary>
        public delegate void PositionPropEnumValChangeEventHandler(Object sender, PositionPropEnumValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения свойства позиции типа перечисление
        /// </summary>
        public event PositionPropEnumValChangeEventHandler PositionPropEnumValChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения значения свойства позиции
        /// </summary>
        protected virtual void PositionPropEnumValOnChange(PositionPropEnumValChangeEventArgs e)
        {
            PositionPropEnumValChangeEventHandler temp = PositionPropEnumValChange;
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
