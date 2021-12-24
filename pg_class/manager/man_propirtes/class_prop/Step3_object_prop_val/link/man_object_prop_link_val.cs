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
        #region МЕТОДЫ КЛАССА: УПРАВЛЕНИЕ ЗНАЧЕНИЯМИ ПОЛЬЗОВАТЕЛЬСКИХ СВОЙСТВ КЛАССОВ ШАГ №03

        #region ДОБАВИТЬ

        /// <summary>
        /// Добавить новое значение свойства-ссылки активного представления класса
        /// </summary>
        public object_prop_link_val object_prop_link_val_add(object_prop_link_val newObjectPropLinkVal)
        {
            object_prop_link_val ObjectPropLinkVal = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            //=======================
            if (newObjectPropLinkVal != null)
            {
                cmdk = CommandByKey("object_prop_link_val_add");

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

                cmdk.Parameters["iid_object"].Value = newObjectPropLinkVal.Id_object;
                cmdk.Parameters["iid_class_prop"].Value = newObjectPropLinkVal.Id_class_prop;

                if (newObjectPropLinkVal.Link_id_entity_instance <= 0)
                {
                    cmdk.Parameters["iid_entity_instance"].Value = DBNull.Value;
                }
                else
                {
                    cmdk.Parameters["iid_entity_instance"].Value = newObjectPropLinkVal.Link_id_entity_instance;
                }

                if (newObjectPropLinkVal.Link_id_sub_entity_instance <= 0)
                {
                    cmdk.Parameters["iid_sub_entity_instance"].Value = DBNull.Value;
                }
                else
                {
                    cmdk.Parameters["iid_sub_entity_instance"].Value = newObjectPropLinkVal.Link_id_sub_entity_instance;
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
                        ObjectPropLinkVal = object_prop_link_val_by_id_prop(newObjectPropLinkVal);
                        break;
                    default:
                        //Вызов события журнала
                        ObjectPropLinkVal = newObjectPropLinkVal;
                        JournalEventArgs me = new JournalEventArgs(newObjectPropLinkVal.Id_object, newObjectPropLinkVal.Id_class_prop, eEntity.object_prop_link_val, error, desc_error, eAction.Insert, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgDataException(error, desc_error);
                }
                if (ObjectPropLinkVal != null)
                {
                    //Генерируем событие изменения значения свойства объекта
                    ObjectPropLinkValChangeEventArgs e = new ObjectPropLinkValChangeEventArgs(ObjectPropLinkVal, eAction.Insert);
                    ObjectPropLinkValOnChange(e);
                }
            }
            //Возвращаем Объект
            return ObjectPropLinkVal;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_link_val_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_prop_link_val_add");
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
        /// Изменить данные значения свойства-ссылки активного представления класса
        /// </summary>
        public object_prop_link_val object_prop_link_val_upd(object_prop_link_val newObjectPropLinkVal)
        {
            object_prop_link_val ObjectPropLinkVal = null;
            
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            if (newObjectPropLinkVal != null)
            {
                cmdk = CommandByKey("object_prop_link_val_upd");

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

                cmdk.Parameters["iid_object"].Value = newObjectPropLinkVal.Id_object;
                cmdk.Parameters["iid_class_prop"].Value = newObjectPropLinkVal.Id_class_prop;

                if (newObjectPropLinkVal.Link_id_entity_instance <= 0)
                {
                    cmdk.Parameters["iid_entity_instance"].Value = DBNull.Value;
                }
                else
                {
                    cmdk.Parameters["iid_entity_instance"].Value = newObjectPropLinkVal.Link_id_entity_instance;
                }

                if (newObjectPropLinkVal.Link_id_sub_entity_instance <= 0)
                {
                    cmdk.Parameters["iid_sub_entity_instance"].Value = DBNull.Value;
                }
                else
                {
                    cmdk.Parameters["iid_sub_entity_instance"].Value = newObjectPropLinkVal.Link_id_sub_entity_instance;
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
                        ObjectPropLinkVal = object_prop_link_val_by_id_prop(newObjectPropLinkVal);
                        break;
                    default:
                        //Вызов события журнала
                        ObjectPropLinkVal = newObjectPropLinkVal;
                        JournalEventArgs me = new JournalEventArgs(newObjectPropLinkVal.Id_object, newObjectPropLinkVal.Id_class_prop, eEntity.object_prop_link_val, error, desc_error, eAction.Update, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgDataException(error, desc_error);
                }
                if (ObjectPropLinkVal != null)
                {
                    //Генерируем событие изменения значения свойства объекта
                    ObjectPropLinkValChangeEventArgs e = new ObjectPropLinkValChangeEventArgs(ObjectPropLinkVal, eAction.Update);
                    ObjectPropLinkValOnChange(e);
                }
            }
            //Возвращаем Объект
            return ObjectPropLinkVal;
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_link_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_prop_link_val_upd");
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
        /// Удалить значение свойства-ссылки объекта
        /// </summary>
        public void object_prop_link_val_del(Int64 iid_object, Int64 iid_class_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("object_prop_link_val_del");

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
            object_prop_link_val object_prop_link_val = object_prop_link_val_by_id_prop(object_prop);

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
                    JournalEventArgs me = new JournalEventArgs(object_prop_link_val.Id_object, object_prop_link_val.Id_class_prop, eEntity.object_prop_link_val, error, desc_error, eAction.Delete, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (object_prop_link_val != null)
            {
                //Генерируем событие изменения значения свойства объекта
                ObjectPropLinkValChangeEventArgs e = new ObjectPropLinkValChangeEventArgs(object_prop_link_val, eAction.Delete);
                ObjectPropLinkValOnChange(e);
            }
        }


        /// <summary>
        /// Удалить значение свойства-перечисления активного представления класса
        /// </summary>
        public void object_prop_link_val_del(object_prop ObjectProp)
        {
            object_prop_link_val_del(ObjectProp.Id_object_carrier, ObjectProp.Id_class_prop);
        }


        /// <summary>
        /// Удалить значение свойства-перечисления активного представления класса
        /// </summary>
        public void object_prop_link_val_del(object_prop_link_val ObjectPropLinkVal)
        {
            object_prop_link_val_del(ObjectPropLinkVal.Id_object, ObjectPropLinkVal.Id_class_prop);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_link_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_prop_link_val_del");
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
        /// Выбрать данные значения свойства объекта типа ссылка по идентификатору значения свойства
        /// </summary>
        public object_prop_link_val object_prop_link_val_by_id_prop(Int64 iid_object, Int64 iid_class_prop)
        {
            object_prop_link_val object_prop_link_val = null;

            DataTable tbl_entity  = TableByName("vobject_prop_link_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_prop_link_val_by_id_prop");

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
                object_prop_link_val = new object_prop_link_val(tbl_entity.Rows[0]);
            }
            return object_prop_link_val;
        }

        //*********************************************************************************************
        /// <summary>
        /// Выбрать данные значения свойства объекта типа ссылка по идентификатору значения свойства
        /// </summary>
        public object_prop_link_val object_prop_link_val_by_id_prop(object_prop ObjectProp)
        {
            return object_prop_link_val_by_id_prop(ObjectProp.Id_object_carrier, ObjectProp.Id_class_prop);
        }

        //*********************************************************************************************
        /// <summary>
        /// Выбрать данные значения свойства объекта типа ссылка по идентификатору значения свойства
        /// </summary>
        public object_prop_link_val object_prop_link_val_by_id_prop(object_prop_link_val ObjectPropLink_val)
        {
            return object_prop_link_val_by_id_prop(ObjectPropLink_val.Id_object, ObjectPropLink_val.Id_class_prop);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_link_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_prop_link_val_by_id_prop");
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
        public eEntityState object_prop_link_val_is_actual(Int64 iid_object, Int64 iid_class_prop, DateTime itimestamp_val)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("object_prop_link_val_is_actual");

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
        public eEntityState object_prop_link_val_is_actual(object_prop_link_val ObjectPropLinkValClass)
        {
            eEntityState Result = eEntityState.History;
            Result = object_prop_link_val_is_actual(ObjectPropLinkValClass.Id_object, ObjectPropLinkValClass.Id_class_prop, ObjectPropLinkValClass.Timestamp_val);
            return Result;
        }
        #endregion
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ ЗНАЧЕНИЯМИ ПОЛЬЗОВАТЕЛЬСКИХ СВОЙСТВ ОБЪЕКТОВ

        /// <summary>
        /// Делегат события изменения значения свойства объекта типа ссылка
        /// </summary>
        public delegate void ObjectPropLinkValChangeEventHandler(Object sender, ObjectPropLinkValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения свойства объекта типа ссылка
        /// </summary>
        public event ObjectPropLinkValChangeEventHandler ObjectPropLinkValChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения значения свойства объекта 
        /// </summary>
        protected virtual void ObjectPropLinkValOnChange(ObjectPropLinkValChangeEventArgs e)
        {
            ObjectPropLinkValChangeEventHandler temp = ObjectPropLinkValChange;
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
