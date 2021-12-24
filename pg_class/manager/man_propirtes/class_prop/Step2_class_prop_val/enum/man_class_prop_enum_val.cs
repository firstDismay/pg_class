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
        public class_prop_enum_val class_prop_enum_val_add(Int64 iid_class_prop, Int64 iid_prop_enum, Int64 iid_prop_enum_val)
        {
            class_prop_enum_val Class_prop_enum_val = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_prop_enum_val_add");

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
                        Class_prop_enum_val = class_prop_enum_val_by_id_prop(iid_class_prop);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_class_prop, eEntity.class_prop_enum_val, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (Class_prop_enum_val != null)
            {
                //Генерируем событие изменения данных значения свойства типа перечисление
                ClassPropEnumValChangeEventArgs e = new ClassPropEnumValChangeEventArgs(Class_prop_enum_val, eAction.Insert);
                ClassPropEnumValOnChange(e);
            }
            //Возвращаем Сущность
            return Class_prop_enum_val;
        }


        /// <summary>
        /// Добавить данные значения свойства типа перечисление
        /// </summary>
        public class_prop_enum_val class_prop_enum_val_add(class_prop_enum_val Class_prop_enum_val)
        {
            class_prop_enum_val Result = null;
            if (Class_prop_enum_val != null)
            {
                Result = class_prop_enum_val_add(Class_prop_enum_val.Id_class_prop, Class_prop_enum_val.Id_prop_enum, Class_prop_enum_val.Id_prop_enum_val);
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_enum_val_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_enum_val_add");
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
        public class_prop_enum_val class_prop_enum_val_upd(Int64 iid_class_prop, Int64 iid_prop_enum, Int64 iid_prop_enum_val)
        {
            class_prop_enum_val Class_prop_enum_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
           
            //=======================
            cmdk = CommandByKey("class_prop_enum_val_upd");

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
                    Class_prop_enum_val = class_prop_enum_val_by_id_prop(iid_class_prop);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_class_prop, eEntity.class_prop_enum_val, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (Class_prop_enum_val != null)
            {
                //Генерируем событие изменения свойства класса
                ClassPropEnumValChangeEventArgs e = new ClassPropEnumValChangeEventArgs(Class_prop_enum_val, eAction.Update);
                ClassPropEnumValOnChange(e);
            }
            //Возвращаем Сущность
            return Class_prop_enum_val;
        }


        /// <summary>
        /// Изменить данные значения свойства типа перечисление
        /// </summary>
        public class_prop_enum_val class_prop_enum_val_upd(class_prop_enum_val Class_prop_enum_val)
        {
            return class_prop_enum_val_upd(Class_prop_enum_val.Id_class_prop, Class_prop_enum_val.Id_prop_enum, Class_prop_enum_val.Id_prop_enum_val);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_enum_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_enum_val_upd");
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
        /// Удалить новое перечисление для свойств
        /// </summary>
        public void class_prop_enum_val_del(Int64 iid_class_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_prop_enum_val_del");

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

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            //Запрос удаляемой сущности
            class_prop_enum_val Class_prop_enum_val = class_prop_enum_val_by_id_prop(iid_class_prop);
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_class_prop, eEntity.class_prop_enum_val, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие удаления свойства класса
            if (Class_prop_enum_val != null)
            {
                ClassPropEnumValChangeEventArgs e = new ClassPropEnumValChangeEventArgs(Class_prop_enum_val, eAction.Delete);
                ClassPropEnumValOnChange(e);
            }
        }


        /// <summary>
        /// Удалить новое перечисление для свойств
        /// </summary>
        public void class_prop_enum_val_del(class_prop_enum_val Class_prop_enum_val)
        {
            class_prop_enum_val_del(Class_prop_enum_val.Id_class_prop);
        }


        /// <summary>
        /// Удалить новое перечисление для свойств
        /// </summary>
        public void class_prop_enum_val_del(class_prop Class_prop)
        {
            class_prop_enum_val_del(Class_prop.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_enum_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_enum_val_del");
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

        # region ВЫБРАТЬ ЗНАЧЕНИЯ СВОЙСТВА ДЛЯ АКТИВНОГО ПРЕДСТАВЛЕНИЯ КЛАССА
        //*********************************************************************************************
        /// <summary>
        /// Выбрать данные значения свойства типа перечисление по идентификатору свойства
        /// </summary>
        public class_prop_enum_val class_prop_enum_val_by_id_prop(Int64 iid_class_prop)
        {
            class_prop_enum_val Class_prop_enum_val = null;

            DataTable tbl_entity  = TableByName("vclass_prop_enum_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_enum_val_by_id_prop");

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
                Class_prop_enum_val = new class_prop_enum_val(tbl_entity.Rows[0]);
            }
            return Class_prop_enum_val;
        }


        //*********************************************************************************************
        /// <summary>
        /// Выбрать данные значения свойства типа перечисление по идентификатору свойства
        /// </summary>
        public class_prop_enum_val class_prop_enum_val_by_id_prop(class_prop Class_prop)
        {
            return class_prop_enum_val_by_id_prop(Class_prop.Id);
        }
            //-=ACCESS=-***********************************************************************************
            /// <summary>
            /// Проверка прав доступа к методу
            /// </summary>
            public Boolean class_prop_enum_val_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_enum_val_by_id_prop");
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

        #region ВЫБРАТЬ ЗНАЧЕНИЯ СВОЙСТВА ДЛЯ ИСТОРИЧЕСКОГО ПРЕДСТАВЛЕНИЯ КЛАССА
        //*********************************************************************************************
        /// <summary>
        /// Выбрать данные значения свойства типа перечисление по идентификатору свойства
        /// </summary>
        public class_prop_enum_val class_prop_enum_val_snapshot_by_id_prop(Int64 iid_class_prop, DateTime itimestamp_class)
        {
            class_prop_enum_val Class_prop_enum_val = null;

            DataTable tbl_entity  = TableByName("vclass_prop_enum_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("class_prop_enum_val_snapshot_by_id_prop");

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
                Class_prop_enum_val = new class_prop_enum_val(tbl_entity.Rows[0]);
            }
            return Class_prop_enum_val;
        }


        /// <summary>
        /// Выбрать данные значения свойства типа перечисление по идентификатору свойства
        /// </summary>
        public class_prop_enum_val class_prop_enum_val_snapshot_by_id_prop(class_prop Class_prop)
        {
            return class_prop_enum_val_snapshot_by_id_prop(Class_prop.Id, Class_prop.Timestamp_class);
        }
            //-=ACCESS=-***********************************************************************************
            /// <summary>
            /// Проверка прав доступа к методу
            /// </summary>
            public Boolean class_prop_enum_val_snapshot_by_id_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_enum_val_snapshot_by_id_prop");
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
        //*********************************************************************************************
        /// <summary>
        /// Определить актуальность состояния данных значения свойства перечисления
        /// </summary>
        public eEntityState class_prop_enum_val_is_actual(Int64 iid_class_prop, DateTime itimestamp_class)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("class_prop_enum_val_is_actual");

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

            //Начало транзакции
            is_actual = (Int32)cmdk.ExecuteScalar();

            return (eEntityState)is_actual;
        }

        /// <summary>
        /// Определить актуальность состояния данных значения свойства перечисления
        /// </summary>
        public eEntityState class_prop_enum_val_is_actual(class_prop_enum_val Class_prop_enum_val)
        {
            eEntityState Result = eEntityState.History;
            if (Class_prop_enum_val.StorageType == eStorageType.Active)
            {
                Result = class_prop_enum_val_is_actual(Class_prop_enum_val.Id_class_prop, Class_prop_enum_val.Timestamp_class);
            }
            return Result;
        }

        #endregion
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ СВОЙСТВАМИ КЛАССОВ

        /// <summary>
        /// Делегат события изменения данных значения свойства класса типа перечисление
        /// </summary>
        public delegate void ClassPropEnumValChangeEventHandler(Object sender, ClassPropEnumValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении данных значения свойства класса типа перечисление
        /// </summary>
        public event ClassPropEnumValChangeEventHandler ClassPropEnumValChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения перечисления для свойств
        /// </summary>
        protected virtual void ClassPropEnumValOnChange(ClassPropEnumValChangeEventArgs e)
        {
            ClassPropEnumValChangeEventHandler temp = ClassPropEnumValChange;
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
