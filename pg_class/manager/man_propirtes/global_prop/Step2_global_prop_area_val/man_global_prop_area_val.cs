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
        #region ДОБАВИТЬ
        /// <summary>
        /// Метод добавляет новые данные области значения глобального свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_add( Int64 iid_global_prop, Int64 iid_area_val)
        {
            global_prop_area_val global_prop_area_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("global_prop_area_val_add");

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

            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;
            cmdk.Parameters["iid_area_val"].Value = iid_area_val;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    global_prop_area_val = global_prop_area_val_by_id_prop(iid_global_prop);
                    
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_global_prop, eEntity.global_prop_area_val, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения свойства класса
            if (global_prop_area_val != null)
            {
                GlobalPropAreaValChangeEventArgs e = new GlobalPropAreaValChangeEventArgs(global_prop_area_val, eAction.Insert);
                GlobalPropAreaValOnChange(e);
                //Возвращаем Объект
            }
            return global_prop_area_val;
        }

        /// <summary>
        /// Метод добавляет новые данные области значения глобального свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_add(global_prop GlobalProp, prop_enum PropEnum)
        {
            global_prop_area_val Result = null;
            if (GlobalProp != null && PropEnum != null)
            {
                if (GlobalProp.Prop_type == ePropType.PropEnum)
                {
                    Result = global_prop_area_val_add(GlobalProp.Id, PropEnum.Id_prop_enum);
                }
                else
                {
                    throw (new PgDataException( eEntity.global_prop_area_val, eAction.Insert, eSubClass_ErrID.SCE3_Violation_Rules, "Сущность области значений не соотвествует типу свойства!", eSourceError.ClassFuncVer2));
                }
            }
            return Result;
        }

        /// <summary>
        /// Метод добавляет новые данные области значения глобального свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_add(global_prop GlobalProp, vclass ClassVal)
        {
            global_prop_area_val Result = null;
            if (GlobalProp != null && ClassVal != null)
            {
                if (GlobalProp.Prop_type == ePropType.PropObject)
                {
                    Result = global_prop_area_val_add(GlobalProp.Id, ClassVal.Id);
                }
                else
                {
                    throw (new PgDataException(eEntity.global_prop_area_val, eAction.Insert, eSubClass_ErrID.SCE3_Violation_Rules, "Сущность области значений не соотвествует типу свойства!", eSourceError.ClassFuncVer2));
                }
            }
            return Result;
        }

        /// <summary>
        /// Метод добавляет новые данные области значения глобального свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_add(global_prop GlobalProp, entity EntityVal)
        {
            global_prop_area_val Result = null;
            if (GlobalProp != null && EntityVal != null)
            {
                if (GlobalProp.Prop_type == ePropType.PropLink)
                {
                    Result = global_prop_area_val_add(GlobalProp.Id, EntityVal.Id);
                }
                else
                {
                    throw (new PgDataException(eEntity.global_prop_area_val, eAction.Insert, eSubClass_ErrID.SCE3_Violation_Rules, "Сущность области значений не соотвествует типу свойства!", eSourceError.ClassFuncVer2));
                }
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_area_val_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("global_prop_area_val_add");
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
        /// Метод изменяет данные области значения глобального свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_upd(Int64 iid_global_prop, Int64 iid_area_val)
        {
            global_prop_area_val global_prop_area_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("global_prop_area_val_upd");

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

            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;
            cmdk.Parameters["iid_area_val"].Value = iid_area_val;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    global_prop_area_val = global_prop_area_val_by_id_prop(iid_global_prop);

                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_global_prop, eEntity.global_prop_area_val, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения свойства класса
            if (global_prop_area_val != null)
            {
                GlobalPropAreaValChangeEventArgs e = new GlobalPropAreaValChangeEventArgs(global_prop_area_val, eAction.Update);
                GlobalPropAreaValOnChange(e);
                //Возвращаем Объект
            }
            return global_prop_area_val;
        }

        /// <summary>
        /// Метод изменяет данные области значения глобального свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_upd(global_prop GlobalProp, prop_enum PropEnum)
        {
            global_prop_area_val Result = null;
            if (GlobalProp != null && PropEnum != null)
            {
                if (GlobalProp.Prop_type == ePropType.PropEnum)
                {
                    Result = global_prop_area_val_upd(GlobalProp.Id, PropEnum.Id_prop_enum);
                }
                else
                {
                    throw (new PgDataException(eEntity.global_prop_area_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules, "Сущность области значений не соотвествует типу свойства!", eSourceError.ClassFuncVer2));
                }
            }
            return Result;
        }

        /// <summary>
        /// Метод изменяет данные области значения глобального свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_upd(global_prop GlobalProp, vclass ClassVal)
        {
            global_prop_area_val Result = null;
            if (GlobalProp != null && ClassVal != null)
            {
                if (GlobalProp.Prop_type == ePropType.PropObject)
                {
                    Result = global_prop_area_val_upd(GlobalProp.Id, ClassVal.Id);
                }
                else
                {
                    throw (new PgDataException(eEntity.global_prop_area_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules, "Сущность области значений не соотвествует типу свойства!", eSourceError.ClassFuncVer2));
                }
            }
            return Result;
        }

        /// <summary>
        /// Метод изменяет данные области значения глобального свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_upd(global_prop GlobalProp, entity EntityVal)
        {
            global_prop_area_val Result = null;
            if (GlobalProp != null && EntityVal != null)
            {
                if (GlobalProp.Prop_type == ePropType.PropLink)
                {
                    Result = global_prop_area_val_upd(GlobalProp.Id, EntityVal.Id);
                }
                else
                {
                    throw (new PgDataException(eEntity.global_prop_area_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules, "Сущность области значений не соотвествует типу свойства!", eSourceError.ClassFuncVer2));
                }
            }
            return Result;
        }

        /// <summary>
        /// Метод изменяет данные области значения глобального свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_upd(global_prop_area_val GlobalPropAreaVal)
        {
            global_prop_area_val Result = null;
            if (GlobalPropAreaVal != null)
            {
                Result = global_prop_area_val_upd(GlobalPropAreaVal.Id_global_prop, GlobalPropAreaVal.Id_area_val);
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_area_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("global_prop_area_val_upd");
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
        /// Метод удаляет данные области значений глобального свойства
        /// </summary>
        public void global_prop_area_val_del(Int64 iid_global_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("global_prop_area_val_del");

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

            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;

            //Запрос удаляемой сущности
            global_prop global_prop = global_prop_by_id(iid_global_prop);
            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            
            //=======================
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_global_prop, eEntity.global_prop, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие удаления свойства класса
            if (global_prop != null)
            {
                GlobalPropChangeEventArgs e = new GlobalPropChangeEventArgs(global_prop, eAction.Delete);
                GlobalPropOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет данные области значений глобального свойства
        /// </summary>
        public void global_prop_area_val_del(global_prop Global_Prop)
        {
            if (Global_Prop != null)
            {
                global_prop_area_val_del(Global_Prop.Id);
            }
        }

        /// <summary>
        /// Метод удаляет данные области значений глобального свойства
        /// </summary>
        public void global_prop_area_val_del(global_prop_area_val GlobalPropAreaVal)
        {
            if (GlobalPropAreaVal != null)
            {
                global_prop_area_val_del(GlobalPropAreaVal.Id_global_prop);
            }
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_area_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("global_prop_area_val_del");
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
        /// Выбор данных области значений глобального свойства по идентификатру свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_by_id_prop(Int64 iid_global_prop)
        {
            global_prop_area_val global_prop_area_val = null;

            DataTable tbl_entity  = TableByName("vglobal_prop_area_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("global_prop_area_val_by_id_prop");

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

            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;

            cmdk.Fill(tbl_entity);
            
            if (tbl_entity.Rows.Count > 0)
            {
                global_prop_area_val = new global_prop_area_val(tbl_entity.Rows[0]);
            }
            return global_prop_area_val;
        }

        /// <summary>
        /// Выбор глобального свойства по идентификатру свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_by_id_prop(global_prop GlobalProp)
        {
            return global_prop_area_val_by_id_prop(GlobalProp.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_area_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("global_prop_area_val_by_id_prop");
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

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ СВОЙСТВАМИ КЛАССОВ

        /// <summary>
        /// Делегат события изменения данных области значений глобального свойства
        /// </summary>
        public delegate void GlobalPropAreaValChangeEventHandler(Object sender, GlobalPropAreaValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении данных области значений глобального свойства
        /// </summary>
        public event GlobalPropAreaValChangeEventHandler GlobalPropAreaValChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения данных области значений глобального свойства
        /// </summary>
        protected virtual void GlobalPropAreaValOnChange(GlobalPropAreaValChangeEventArgs e)
        {
            GlobalPropAreaValChangeEventHandler temp = GlobalPropAreaValChange;
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
