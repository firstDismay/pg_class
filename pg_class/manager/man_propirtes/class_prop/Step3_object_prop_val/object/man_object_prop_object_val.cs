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
        #region МЕТОДЫ КЛАССА: Доступ к правилам(ссылкам) на объекты значения объектных свойств ШАГ №03

        #region ВСТРОИТЬ
        /// <summary>
        /// Метод добавляет новый объект и встраивает его в объектное свойство в качестве значения
        /// </summary>
        public object_general object_prop_object_val_add_new(Int64 iid_object_carrier, Int64 iid_class_prop_snapshot, Int64 iid_class_real, Int32 iid_unit_conversion_rule, Decimal icquantity)
        {
            object_general Object = null;
            object_prop_object_val ObjectPropObjectVal = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("object_prop_object_val_add_new");

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

            cmdk.Parameters["iid_object_carrier"].Value = iid_object_carrier;
            cmdk.Parameters["iid_class_real"].Value = iid_class_real;
            cmdk.Parameters["iid_class_prop_snapshot"].Value = iid_class_prop_snapshot;
            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;
            cmdk.Parameters["icquantity"].Value = icquantity;

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
                        Object = object_by_id(id);
                        ObjectPropObjectVal = object_prop_object_val_by_id_prop(iid_object_carrier, iid_class_prop_snapshot);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.vobject, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения объекта
            if (Object != null)
            {
                ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object, eAction.Insert);
                ObjectOnChange(e);
            }

            if (ObjectPropObjectVal != null)
            {
                //Генерируем событие изменения значения данных значения объектного свойства объекта
                ObjectPropObjectValChangeEventArgs e2 = new ObjectPropObjectValChangeEventArgs(ObjectPropObjectVal, eAction.Insert);
                ObjectPropObjectValOnChange(e2);
            }
            //Возвращаем данные значения объетного свойства
            return Object;
        }

        /// <summary>
        /// Метод добавляет новый объект и встраивает его в объектное свойство в качестве значения
        /// </summary>
        public object_general object_prop_object_val_add_new(object_prop Object_prop, vclass Class_real, unit_conversion_rule Unit_conversion_rule, Decimal icquantity)
        {
            return object_prop_object_val_add_new(Object_prop.Id_object_carrier, Object_prop.Id_class_prop, Class_real.Id, Unit_conversion_rule.Id, icquantity);
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_object_val_add_new(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_prop_object_val_add_new");
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
        /// Метод встраивает существующий объект в объектное свойство в качестве значения STEP3
        /// </summary>
        public object_general object_prop_object_val_add(Int64 iid_object_carrier, Int64 iid_class_prop_snapshot, Int64 iid_object_val, Decimal icquantity)
        {
            object_general Object_embed = null;
            object_general Object_change = null;

            object_prop_object_val ObjectPropObjectVal = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("object_prop_object_val_add");

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

            cmdk.Parameters["iid_object_carrier"].Value = iid_object_carrier;
            cmdk.Parameters["iid_class_prop_snapshot"].Value = iid_class_prop_snapshot;
            cmdk.Parameters["iid_object_val"].Value = iid_object_val;
            cmdk.Parameters["icquantity"].Value = icquantity;

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
                        Object_embed = object_by_id(id);
                        ObjectPropObjectVal = object_prop_object_val_by_id_prop(iid_object_carrier, iid_class_prop_snapshot);

                        //Если идет частичное встраивание с созданием нового объекта находим остаток
                        if (id != iid_object_val)
                        {
                            Object_change = object_by_id(iid_object_val);
                        }

                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_object_val, eEntity.vobject, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения встроенного объекта
            if (Object_embed != null)
            {
                ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object_embed, eAction.Insert);
                ObjectOnChange(e);
            }

            //Если есть остаток то генерируем изменение остатка
            if (Object_change != null)
            {
                ObjectChangeEventArgs e3 = new ObjectChangeEventArgs(Object_change, eAction.Update);
                ObjectOnChange(e3);
            }

            if (ObjectPropObjectVal != null)
            {
                //Генерируем событие изменения данных значения объектного свойства
                ObjectPropObjectValChangeEventArgs e2 = new ObjectPropObjectValChangeEventArgs(ObjectPropObjectVal, eAction.Insert);
                ObjectPropObjectValOnChange(e2);
            }

            //Возвращаем Объект
            return Object_embed;
        }

        /// <summary>
        /// Метод встраивает существующий объект в объектное свойство в качестве значения STEP3
        /// </summary>
        public object_general object_prop_object_val_add(object_prop Object_prop, object_general Object_Val, Decimal icquantity)
        {
            return object_prop_object_val_add(Object_prop.Id_object_carrier, Object_prop.Id_class_prop, Object_Val.Id, icquantity);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_object_val_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_prop_object_val_add");
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

        #region ВЫБРАТЬ ДАННЫЕ ЗНАЧЕНИЯ ОБЪЕКТНОГО СВОЙСТВА ОБЪЕКТА ШАГ №3

        //*********************************************************************************************
        /// <summary>
        /// Данные значения объектного свойства объекта
        /// </summary>
        public object_prop_object_val object_prop_object_val_by_id_prop(Int64 iid_object_carrier, Int64 iid_class_prop)
        {
            object_prop_object_val object_prop_object_val  = null;

            DataTable tbl_object  = TableByName("vobject_prop_object_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_prop_object_val_by_id_prop");

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

            cmdk.Parameters["iid_object_carrier"].Value = iid_object_carrier;
            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;

            cmdk.Fill(tbl_object);
            
            if (tbl_object.Rows.Count > 0)
            {
                object_prop_object_val = new object_prop_object_val(tbl_object.Rows[0]);
            }
            return object_prop_object_val;
        }

        /// <summary>
        /// Данные значения объектного свойства объекта
        /// </summary>
        public object_prop_object_val object_prop_object_val_by_id_prop(object_general Object_carrier, class_prop Class_prop_object_carrier)
        {
            return object_prop_object_val_by_id_prop(Object_carrier.Id, Class_prop_object_carrier.Id);
        }

        /// <summary>
        /// Данные значения объектного свойства объекта
        /// </summary>
        public object_prop_object_val object_prop_object_val_by_id_prop(object_general Object_carrier, object_prop Object_carrier_prop)
        {
            return object_prop_object_val_by_id_prop(Object_carrier.Id, Object_carrier_prop.Id_class_prop);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_object_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_prop_object_val_by_id_prop");
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


        #region ОБЪЕКТЫ ЗНАЧЕНИЯ СВОЙСТВА ОБЪЕКТА НОСИТЕЛЯ

        #region FAST
        //*********************************************************************************************
        /// <summary>
        /// Лист представлений объектов значений объектного свойства
        /// </summary>
        public List<object_general> object_object_prop_by_id_object_carrier(Int64 iid_object_carrier, Int64 iid_class_prop)
        {
            List<object_general> object_list = new List<object_general>();

            DataTable tbl_object  = TableByName("vobject_general");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_object_prop_by_id_object_carrier");

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

            cmdk.Parameters["iid_object_carrier"].Value = iid_object_carrier;
            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист представлений объектов значений объектного свойства
        /// </summary>
        public List<object_general> object_object_prop_by_id_object_carrier(object_general Object_carrier, class_prop Class_prop)
        {
            return object_object_prop_by_id_object_carrier(Object_carrier.Id, Class_prop.Id);
        }

        /// <summary>
        /// Лист представлений объектов значений объектного свойства
        /// </summary>
        public List<object_general> object_object_prop_by_id_object_carrier(object_general Object_carrier, object_prop Object_prop)
        {
            return object_object_prop_by_id_object_carrier(Object_carrier.Id, Object_prop.Id_class_prop);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_object_prop_by_id_object_carrier(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_object_prop_by_id_object_carrier");
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

        #region EXT
        //*********************************************************************************************
        /// <summary>
        /// Лист представлений объектов значений объектного свойства
        /// </summary>
        public List<object_general> object_object_prop_by_id_object_carrier_ext(Int64 iid_object_carrier, Int64 iid_class_prop)
        {
            List<object_general> object_list = new List<object_general>();

            DataTable tbl_object = TableByName("vobject_general_ext");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_object_prop_by_id_object_carrier_ext");

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

            cmdk.Parameters["iid_object_carrier"].Value = iid_object_carrier;
            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;

            cmdk.Fill(tbl_object);
            
            object_general og;
            if (tbl_object.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_object.Rows)
                {
                    og = new object_general(dr);
                    object_list.Add(og);
                }
            }
            return object_list;
        }

        /// <summary>
        /// Лист представлений объектов значений объектного свойства
        /// </summary>
        public List<object_general> object_object_prop_by_id_object_carrier_ext(object_general Object_carrier, class_prop Class_prop)
        {
            return object_object_prop_by_id_object_carrier_ext(Object_carrier.Id, Class_prop.Id);
        }

        /// <summary>
        /// Лист представлений объектов значений объектного свойства
        /// </summary>
        public List<object_general> object_object_prop_by_id_object_carrier_ext(object_general Object_carrier, object_prop Object_prop)
        {
            return object_object_prop_by_id_object_carrier_ext(Object_carrier.Id, Object_prop.Id_class_prop);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_object_prop_by_id_object_carrier_ext(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_object_prop_by_id_object_carrier_ext");
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
        #endregion

        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ ЗНАЧЕНИЯМИ ОБЪЕКТНЫХ СВОЙСТВ ОБЪЕКТОВ

        /// <summary>
        /// Делегат события изменения значения объектного свойства объекта
        /// </summary>
        public delegate void ObjectPropObjectValChangeEventHandler(Object sender, ObjectPropObjectValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения объектного свойства объекта
        /// </summary>
        public event ObjectPropObjectValChangeEventHandler ObjectPropObjectValChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения значения свойства объекта
        /// </summary>
        protected virtual void ObjectPropObjectValOnChange(ObjectPropObjectValChangeEventArgs e)
        {
            ObjectPropObjectValChangeEventHandler temp = ObjectPropObjectValChange;
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
