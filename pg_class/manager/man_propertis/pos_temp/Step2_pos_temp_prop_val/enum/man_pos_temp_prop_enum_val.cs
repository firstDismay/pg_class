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
        /// Добавить данные значения свойства типа перечисление
        /// </summary>
        public pos_temp_prop_enum_val pos_temp_prop_enum_val_add(Int64 iid_pos_temp_prop, Int64 iid_prop_enum, Int64 iid_prop_enum_val)
        {
            pos_temp_prop_enum_val pos_temp_prop_enum_val = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            //=======================
            cmdk = CommandByKey("pos_temp_prop_enum_val_add");

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
            cmdk.Parameters["iid_prop_enum"].Value = iid_prop_enum;

            if (iid_prop_enum_val <= 0)
            {
                cmdk.Parameters["iid_prop_enum_val"].Value = DBNull.Value;
            }
            else
            {
                cmdk.Parameters["iid_prop_enum_val"].Value = iid_prop_enum_val;
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
                        pos_temp_prop_enum_val = pos_temp_prop_enum_val_by_id_prop(iid_pos_temp_prop);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_pos_temp_prop, eEntity.pos_temp_prop_enum_val, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения данных значения свойства типа перечисление
            PosTempPropEnumValChangeEventArgs e = new PosTempPropEnumValChangeEventArgs(pos_temp_prop_enum_val, eAction.Insert);
            PosTempPropEnumValOnChange(e);
            
            //Возвращаем Сущность
            return pos_temp_prop_enum_val;
        }


        /// <summary>
        /// Добавить данные значения свойства типа перечисление
        /// </summary>
        public pos_temp_prop_enum_val pos_temp_prop_enum_val_add(pos_temp_prop_enum_val PosTemp_prop_enum_val)
        {
            pos_temp_prop_enum_val Result = null;
            if (PosTemp_prop_enum_val != null)
            {
                Result = pos_temp_prop_enum_val_add(PosTemp_prop_enum_val.Id_pos_temp_prop, PosTemp_prop_enum_val.Id_prop_enum, PosTemp_prop_enum_val.Id_prop_enum_val);
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_enum_val_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_enum_val_add");
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
        /// Изменить данные значения свойства типа перечисление
        /// </summary>
        public pos_temp_prop_enum_val pos_temp_prop_enum_val_upd(Int64 iid_pos_temp_prop, Int64 iid_prop_enum, Int64 iid_prop_enum_val)
        {
            pos_temp_prop_enum_val pos_temp_prop_enum_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            //=======================
            cmdk = CommandByKey("pos_temp_prop_enum_val_upd");

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
            cmdk.Parameters["iid_prop_enum"].Value = iid_prop_enum;

            if (iid_prop_enum_val <= 0)
            {
                cmdk.Parameters["iid_prop_enum_val"].Value = DBNull.Value;
            }
            else
            {
                cmdk.Parameters["iid_prop_enum_val"].Value = iid_prop_enum_val;
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
                    pos_temp_prop_enum_val = pos_temp_prop_enum_val_by_id_prop(iid_pos_temp_prop);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_pos_temp_prop, eEntity.pos_temp_prop_enum_val, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения свойства класса
            PosTempPropEnumValChangeEventArgs e = new PosTempPropEnumValChangeEventArgs(pos_temp_prop_enum_val, eAction.Update);
            PosTempPropEnumValOnChange(e);

            //Возвращаем Сущность
            return pos_temp_prop_enum_val;
        }


        /// <summary>
        /// Изменить данные значения свойства типа перечисление
        /// </summary>
        public pos_temp_prop_enum_val pos_temp_prop_enum_val_upd(pos_temp_prop_enum_val PosTemp_prop_enum_val)
        {
            return pos_temp_prop_enum_val_upd(PosTemp_prop_enum_val.Id_pos_temp_prop, PosTemp_prop_enum_val.Id_prop_enum, PosTemp_prop_enum_val.Id_prop_enum_val);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_enum_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_enum_val_upd");
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
        /// Удалить данные значения свойства перечисления
        /// </summary>
        public void pos_temp_prop_enum_val_del(Int64 iid_pos_temp_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("pos_temp_prop_enum_val_del");

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

            //Запрос удаляемой сущности
            pos_temp_prop_enum_val pos_temp_prop_enum_val = pos_temp_prop_enum_val_by_id_prop(iid_pos_temp_prop);
            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_pos_temp_prop, eEntity.pos_temp_prop_enum_val, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }
            //Генерируем событие удаления свойства класса
            if (pos_temp_prop_enum_val != null)
            {
                PosTempPropEnumValChangeEventArgs e = new PosTempPropEnumValChangeEventArgs(pos_temp_prop_enum_val, eAction.Delete);
                PosTempPropEnumValOnChange(e);
            }
        }


        /// <summary>
        /// Удалить данные значения свойства перечисления
        /// </summary>
        public void pos_temp_prop_enum_val_del(pos_temp_prop_enum_val PosTemp_prop_enum_val)
        {
            pos_temp_prop_enum_val_del(PosTemp_prop_enum_val.Id_pos_temp_prop);
        }


        /// <summary>
        /// Удалить данные значения свойства перечисления
        /// </summary>
        public void pos_temp_prop_enum_val_del(pos_temp_prop PosTemp_prop)
        {
            pos_temp_prop_enum_val_del(PosTemp_prop.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_enum_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_enum_val_del");
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

        //*********************************************************************************************
        /// <summary>
        /// Выбрать данные значения свойства типа перечисление по идентификатору свойства
        /// </summary>
        public pos_temp_prop_enum_val pos_temp_prop_enum_val_by_id_prop(Int64 iid_pos_temp_prop)
        {
            pos_temp_prop_enum_val pos_temp_prop_enum_val = null;

            DataTable tbl_entity  = TableByName("vpos_temp_prop_enum_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_prop_enum_val_by_id_prop");

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

            //DA.SelectCommand = cmdk.Cmd;
            try
            {
                cmdk.Fill(tbl_entity);
            }
            catch (Exception ex)
            {
                PG_exception_hadler(ex, cmdk);
            }
            //SetLastTimeUsing();

            if (tbl_entity.Rows.Count > 0)
            {
                pos_temp_prop_enum_val = new pos_temp_prop_enum_val(tbl_entity.Rows[0]);
            }
            return pos_temp_prop_enum_val;
        }


        //*********************************************************************************************
        /// <summary>
        /// Выбрать данные значения свойства типа перечисление по идентификатору свойства
        /// </summary>
        public pos_temp_prop_enum_val pos_temp_prop_enum_val_by_id_prop(pos_temp_prop PosTemp_prop)
        {
            return pos_temp_prop_enum_val_by_id_prop(PosTemp_prop.Id);
        }

        //*********************************************************************************************
        /// <summary>
        /// Выбрать данные значения свойства типа перечисление по идентификатору свойства
        /// </summary>
        public pos_temp_prop_enum_val pos_temp_prop_enum_val_by_id_prop(pos_temp_prop_enum_val PosTemp_prop_enum_val)
        {
            return pos_temp_prop_enum_val_by_id_prop(PosTemp_prop_enum_val.Id_pos_temp_prop);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_enum_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_enum_val_by_id_prop");
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

        #endregion
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ СВОЙСТВАМИ КЛАССОВ

        /// <summary>
        /// Делегат события изменения данных значения свойства шаблона типа перечисление
        /// </summary>
        public delegate void PosTempPropEnumValChangeEventHandler(Object sender, PosTempPropEnumValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении данных значения свойства шаблона типа перечисление
        /// </summary>
        public event PosTempPropEnumValChangeEventHandler PosTempPropEnumValChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения перечисления для свойств
        /// </summary>
        protected virtual void PosTempPropEnumValOnChange(PosTempPropEnumValChangeEventArgs e)
        {
            PosTempPropEnumValChangeEventHandler temp = PosTempPropEnumValChange;
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
