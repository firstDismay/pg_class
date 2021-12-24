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
        /// Добавить новое значение свойства-перечисления активного представления класса
        /// </summary>
        public object_prop_enum_val object_prop_enum_val_add(object_prop_enum_val newObjectPropEnumVal)
        {
            object_prop_enum_val ObjectPropEnumVal = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            //=======================
            if (newObjectPropEnumVal != null)
            {
                cmdk = CommandByKey("object_prop_enum_val_add");

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

                cmdk.Parameters["iid_object"].Value = newObjectPropEnumVal.Id_object;
                cmdk.Parameters["iid_class_prop"].Value = newObjectPropEnumVal.Id_class_prop;

                if (newObjectPropEnumVal.Id_prop_enum_val <= 0)
                {
                    cmdk.Parameters["iid_prop_enum_val"].Value = DBNull.Value;
                }
                else
                {
                    cmdk.Parameters["iid_prop_enum_val"].Value = newObjectPropEnumVal.Id_prop_enum_val;
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
                        ObjectPropEnumVal = object_prop_enum_val_by_id_prop(newObjectPropEnumVal);
                        break;
                    default:
                        //Вызов события журнала
                        ObjectPropEnumVal = newObjectPropEnumVal;
                        JournalEventArgs me = new JournalEventArgs(newObjectPropEnumVal.Id_object, newObjectPropEnumVal.Id_class_prop, eEntity.object_prop_enum_val, error, desc_error, eAction.Insert, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgDataException(error, desc_error);
                }
                if (ObjectPropEnumVal != null)
                {
                    //Генерируем событие изменения значения свойства объекта
                    ObjectPropEnumValChangeEventArgs e = new ObjectPropEnumValChangeEventArgs(ObjectPropEnumVal, eAction.Insert);
                    ObjectPropEnumValOnChange(e);
                }
            }
            //Возвращаем Объект
            return ObjectPropEnumVal;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_enum_val_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_prop_enum_val_add");
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
        /// Изменить значение свойства-перечисления активного представления класса
        /// </summary>
        public object_prop_enum_val object_prop_enum_val_upd(object_prop_enum_val newObjectPropEnumVal)
        {
            object_prop_enum_val ObjectPropEnumVal = null;
            
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            if (newObjectPropEnumVal != null)
            {
                cmdk = CommandByKey("object_prop_enum_val_upd");

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

                cmdk.Parameters["iid_object"].Value = newObjectPropEnumVal.Id_object;
                cmdk.Parameters["iid_class_prop"].Value = newObjectPropEnumVal.Id_class_prop;

                if (newObjectPropEnumVal.Id_prop_enum_val <= 0)
                {
                    cmdk.Parameters["iid_prop_enum_val"].Value = DBNull.Value;
                }
                else
                {
                    cmdk.Parameters["iid_prop_enum_val"].Value = newObjectPropEnumVal.Id_prop_enum_val;
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
                        ObjectPropEnumVal = object_prop_enum_val_by_id_prop(newObjectPropEnumVal);
                        break;
                    default:
                        //Вызов события журнала
                        ObjectPropEnumVal = newObjectPropEnumVal;
                        JournalEventArgs me = new JournalEventArgs(newObjectPropEnumVal.Id_object, newObjectPropEnumVal.Id_class_prop, eEntity.object_prop_enum_val, error, desc_error, eAction.Update, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgDataException(error, desc_error);
                }
                if (ObjectPropEnumVal != null)
                {
                    //Генерируем событие изменения значения свойства объекта
                    ObjectPropEnumValChangeEventArgs e = new ObjectPropEnumValChangeEventArgs(ObjectPropEnumVal, eAction.Update);
                    ObjectPropEnumValOnChange(e);
                }
            }
            //Возвращаем Объект
            return ObjectPropEnumVal;
        }


        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_enum_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_prop_enum_val_upd");
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
        /// Удалить значение свойства-перечисления объекта
        /// </summary>
        public void object_prop_enum_val_del(Int64 iid_object, Int64 iid_class_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("object_prop_enum_val_del");

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

            object_prop object_prop = object_prop_by_id(iid_object, iid_class_prop);
            object_prop_enum_val object_prop_enum_val = object_prop_enum_val_by_id_prop(object_prop);

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
                    JournalEventArgs me = new JournalEventArgs(iid_object, iid_class_prop, eEntity.object_prop_enum_val, error, desc_error, eAction.Delete, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (object_prop_enum_val != null)
            {
                //Генерируем событие изменения значения свойства объекта
                ObjectPropEnumValChangeEventArgs e = new ObjectPropEnumValChangeEventArgs(object_prop_enum_val, eAction.Delete);
                ObjectPropEnumValOnChange(e);
            }
        }


        /// <summary>
        /// Удалить значение свойства-перечисления активного представления класса
        /// </summary>
        public void object_prop_enum_val_del(object_prop ObjectProp)
        {
            object_prop_enum_val_del(ObjectProp.Id_object_carrier, ObjectProp.Id_class_prop);
        }


        /// <summary>
        /// Удалить значение свойства-перечисления активного представления класса
        /// </summary>
        public void object_prop_enum_val_del(object_prop_enum_val ObjectPropEnumVal)
        {
            object_prop_enum_val_del(ObjectPropEnumVal.Id_object, ObjectPropEnumVal.Id_class_prop);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_enum_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_prop_enum_val_del");
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
        /// Выбрать значение свойства объекта типа перечисление по идентификатору значения свойства
        /// </summary>
        public object_prop_enum_val object_prop_enum_val_by_id_prop(Int64 iid_object, Int64 iid_class_prop)
        {
            object_prop_enum_val object_prop_enum_val = null;

            DataTable tbl_entity  = TableByName("vobject_prop_enum_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("object_prop_enum_val_by_id_prop");

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
                object_prop_enum_val = new object_prop_enum_val(tbl_entity.Rows[0]);
            }
            return object_prop_enum_val;
        }

        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение пользовательского свойства SMALL объекта по идентификатору значения свойства
        /// </summary>
        public object_prop_enum_val object_prop_enum_val_by_id_prop(object_prop ObjectProp)
        {
            return object_prop_enum_val_by_id_prop(ObjectProp.Id_object_carrier, ObjectProp.Id_class_prop);
        }

        //*********************************************************************************************
        /// <summary>
        /// Выбрать значение пользовательского свойства SMALL объекта по идентификатору значения свойства
        /// </summary>
        public object_prop_enum_val object_prop_enum_val_by_id_prop(object_prop_enum_val ObjectPropEnum_val)
        {
            return object_prop_enum_val_by_id_prop(ObjectPropEnum_val.Id_object, ObjectPropEnum_val.Id_class_prop);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_enum_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_prop_enum_val_by_id_prop");
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
        public eEntityState object_prop_enum_val_is_actual(Int64 iid_object, Int64 iid_class_prop, DateTime itimestamp_val)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("object_prop_enum_val_is_actual");

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
        public eEntityState object_prop_enum_val_is_actual(object_prop_enum_val ObjectPropEnumValClass)
        {
            eEntityState Result = eEntityState.History;
            Result = object_prop_enum_val_is_actual(ObjectPropEnumValClass.Id_object, ObjectPropEnumValClass.Id_class_prop, ObjectPropEnumValClass.Timestamp_val);
            return Result;
        }
        #endregion
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ ЗНАЧЕНИЯМИ ПОЛЬЗОВАТЕЛЬСКИХ СВОЙСТВ ОБЪЕКТОВ

        /// <summary>
        /// Делегат события изменения значения свойства объекта типа перечисление
        /// </summary>
        public delegate void ObjectPropEnumValChangeEventHandler(Object sender, ObjectPropEnumValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении значения свойства объекта типа перечисление
        /// </summary>
        public event ObjectPropEnumValChangeEventHandler ObjectPropEnumValChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения значения свойства объекта 
        /// </summary>
        protected virtual void ObjectPropEnumValOnChange(ObjectPropEnumValChangeEventArgs e)
        {
            ObjectPropEnumValChangeEventHandler temp = ObjectPropEnumValChange;
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
