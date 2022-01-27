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
        /// Добавить данные значения свойства типа ссылка
        /// </summary>
        public pos_temp_prop_link_val pos_temp_prop_link_val_add(Int64 iid_pos_temp_prop, Int32 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            pos_temp_prop_link_val pos_temp_prop_link_val = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            //=======================
            cmdk = CommandByKey("pos_temp_prop_link_val_add");

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
            cmdk.Parameters["iid_entity"].Value = iid_entity;

            if (iid_entity_instance <= 0)
            {
                cmdk.Parameters["iid_entity_instance"].Value = DBNull.Value;
            }
            else
            {
                cmdk.Parameters["iid_entity_instance"].Value = iid_entity_instance;
            }

            if (iid_sub_entity_instance <= 0)
            {
                cmdk.Parameters["iid_sub_entity_instance"].Value = DBNull.Value;
            }
            else
            {
                cmdk.Parameters["iid_sub_entity_instance"].Value = iid_sub_entity_instance;
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
                    pos_temp_prop_link_val = pos_temp_prop_link_val_by_id_prop(iid_pos_temp_prop);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_pos_temp_prop, eEntity.pos_temp_prop_link_val, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения данных значения свойства типа ссылка
            PosTempPropLinkValChangeEventArgs e = new PosTempPropLinkValChangeEventArgs(pos_temp_prop_link_val, eAction.Insert);
            PosTempPropLinkValOnChange(e);
            
            //Возвращаем Сущность
            return pos_temp_prop_link_val;
        }

        /// <summary>
        /// Добавить данные значения свойства типа ссылка
        /// </summary>
        public pos_temp_prop_link_val pos_temp_prop_link_val_add(pos_temp_prop_link_val PosTemp_prop_link_val)
        {
            pos_temp_prop_link_val Result = null;
            if (PosTemp_prop_link_val != null)
            {
                Result = pos_temp_prop_link_val_add(PosTemp_prop_link_val.Id_pos_temp_prop, PosTemp_prop_link_val.Link_id_entity, PosTemp_prop_link_val.Link_id_entity_instance, PosTemp_prop_link_val.Link_id_sub_entity_instance);
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_link_val_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_link_val_add");
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
        /// Изменить данные значения свойства-ссылки
        /// </summary>
        public pos_temp_prop_link_val pos_temp_prop_link_val_upd(Int64 iid_pos_temp_prop, Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            pos_temp_prop_link_val pos_temp_prop_link_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            //=======================
            cmdk = CommandByKey("pos_temp_prop_link_val_upd");

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
            cmdk.Parameters["iid_entity"].Value = iid_entity;

            if (iid_entity_instance <= 0)
            {
                cmdk.Parameters["iid_entity_instance"].Value = DBNull.Value;
            }
            else
            {
                cmdk.Parameters["iid_entity_instance"].Value = iid_entity_instance;
            }

            if (iid_sub_entity_instance <= 0)
            {
                cmdk.Parameters["iid_sub_entity_instance"].Value = DBNull.Value;
            }
            else
            {
                cmdk.Parameters["iid_sub_entity_instance"].Value = iid_sub_entity_instance;
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
                    pos_temp_prop_link_val = pos_temp_prop_link_val_by_id_prop(iid_pos_temp_prop);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_pos_temp_prop, eEntity.pos_temp_prop_link_val, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения свойства шаблона
            PosTempPropLinkValChangeEventArgs e = new PosTempPropLinkValChangeEventArgs(pos_temp_prop_link_val, eAction.Update);
            PosTempPropLinkValOnChange(e);

            //Возвращаем Сущность
            return pos_temp_prop_link_val;
        }


        /// <summary>
        /// Изменить данные значения свойства-ссылки
        /// </summary>
        public pos_temp_prop_link_val pos_temp_prop_link_val_upd(pos_temp_prop_link_val PosTemp_prop_link_val)
        {
            return pos_temp_prop_link_val_upd(PosTemp_prop_link_val.Id_pos_temp_prop, PosTemp_prop_link_val.Link_id_entity, PosTemp_prop_link_val.Link_id_entity_instance, PosTemp_prop_link_val.Link_id_sub_entity_instance);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_link_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_link_val_upd");
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
        /// Удалить данные значения свойства-ссылки
        /// </summary>
        public void pos_temp_prop_link_val_del(Int64 iid_pos_temp_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("pos_temp_prop_link_val_del");

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
            pos_temp_prop_link_val pos_temp_prop_link_val = pos_temp_prop_link_val_by_id_prop(iid_pos_temp_prop);

            //Начало транзакции
            cmdk.ExecuteNonQuery();
          
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_pos_temp_prop, eEntity.pos_temp_prop_link_val, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие удаления свойства класса
            if (pos_temp_prop_link_val != null)
            {
                PosTempPropLinkValChangeEventArgs e = new PosTempPropLinkValChangeEventArgs(pos_temp_prop_link_val, eAction.Delete);
                PosTempPropLinkValOnChange(e);
            }
        }

        /// <summary>
        /// Удалить новое перечисление для свойств
        /// </summary>
        public void pos_temp_prop_link_val_del(pos_temp_prop_link_val PosTemp_prop_link_val)
        {
            pos_temp_prop_link_val_del(PosTemp_prop_link_val.Id_pos_temp_prop);
        }


        /// <summary>
        /// Удалить новое перечисление для свойств
        /// </summary>
        public void pos_temp_prop_link_val_del(pos_temp_prop PosTemp_prop)
        {
            pos_temp_prop_link_val_del(PosTemp_prop.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_link_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_link_val_del");
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

        # region ВЫБРАТЬ ДАННЫЕ ЗНАЧЕНИЯ СВОЙСТВА ТИПА ССЫЛКА
        //*********************************************************************************************
        /// <summary>
        /// Выбрать данные значения свойства-ссылки по идентификатору свойства
        /// </summary>
        public pos_temp_prop_link_val pos_temp_prop_link_val_by_id_prop(Int64 iid_pos_temp_prop)
        {
            pos_temp_prop_link_val pos_temp_prop_link_val = null;

            DataTable tbl_entity  = TableByName("vpos_temp_prop_link_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("pos_temp_prop_link_val_by_id_prop");

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

            cmdk.Fill(tbl_entity);
            
            if (tbl_entity.Rows.Count > 0)
            {
                pos_temp_prop_link_val = new pos_temp_prop_link_val(tbl_entity.Rows[0]);
            }
            return pos_temp_prop_link_val;
        }


        //*********************************************************************************************
        /// <summary>
        /// Выбрать данные значения свойства-ссылки по идентификатору свойства
        /// </summary>
        public pos_temp_prop_link_val pos_temp_prop_link_val_by_id_prop(pos_temp_prop PosTemp_prop)
        {
            return pos_temp_prop_link_val_by_id_prop(PosTemp_prop.Id);
        }

        //*********************************************************************************************
        /// <summary>
        /// Выбрать данные значения свойства-ссылки по идентификатору свойства
        /// </summary>
        public pos_temp_prop_link_val pos_temp_prop_link_val_by_id_prop(pos_temp_prop_link_val PosTemp_prop_link_val)
        {
            return pos_temp_prop_link_val_by_id_prop(PosTemp_prop_link_val.Id_pos_temp_prop);
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_link_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_link_val_by_id_prop");
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
        #endregion

        #region СВОЙСТВА ПОЛУЧАЕМЫЕ ИЗ БД
        #endregion
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ СВОЙСТВАМИ КЛАССОВ

        /// <summary>
        /// Делегат события изменения данных значения свойства шаблона типа ссылка
        /// </summary>
        public delegate void PosTempPropLinkValChangeEventHandler(Object sender, PosTempPropLinkValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении данных значения свойства шаблона типа ссылка
        /// </summary>
        public event PosTempPropLinkValChangeEventHandler PosTempPropLinkValChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения ссылки для свойств
        /// </summary>
        protected virtual void PosTempPropLinkValOnChange(PosTempPropLinkValChangeEventArgs e)
        {
            PosTempPropLinkValChangeEventHandler temp = PosTempPropLinkValChange;
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
