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
        /// Добавить новый элемент в перечисление для свойств
        /// </summary>
        public prop_enum_val prop_enum_val_add(Int64 iid_prop_enum, Decimal ival_numeric, String ival_varchar, Int64 iid_object_reference, Int64 isort = -1)
        {
            prop_enum_val Prop_enum_val = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;

            if (isort < 0)
            {
                isort = 1;
            }
            //**********
             
            //=======================
            cmdk = CommandByKey("prop_enum_val_add");

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

            cmdk.Parameters["iid_prop_enum"].Value = iid_prop_enum;
            cmdk.Parameters["ival_numeric"].Value = ival_numeric;
            cmdk.Parameters["ival_varchar"].Value = ival_varchar;
            cmdk.Parameters["isort"].Value = isort;
            cmdk.Parameters["iid_object_reference"].Value = iid_object_reference;

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
                        Prop_enum_val = prop_enum_val_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.prop_enum_val, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения свойства класса
            PropEnumValChangeEventArgs e = new PropEnumValChangeEventArgs(Prop_enum_val, eAction.Insert);
            PropEnumValOnChange(e);
            
            //Возвращаем Сущность
            return Prop_enum_val;
        }

        /// <summary>
        /// Добавить новый элемент в перечисление для свойств
        /// </summary>
        public prop_enum_val prop_enum_val_add(prop_enum Prop_enum, Object ival, Int64 iid_object_reference, Int64 isort)
        {
            prop_enum_val Result = null;

            switch (Prop_enum.Datatype)
            {
                case eDataType.val_varchar:
                    Result = prop_enum_val_add(Prop_enum.Id_prop_enum, 0, (String)ival, iid_object_reference, isort);
                    break;
                case eDataType.val_numeric:
                    Result = prop_enum_val_add(Prop_enum.Id_prop_enum, (Decimal)ival, "", iid_object_reference, isort);
                    break;
            }
            return Result;
        }

            //-=ACCESS=-***********************************************************************************
            /// <summary>
            /// Проверка прав доступа к методу
            /// </summary>
            public Boolean prop_enum_val_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_val_add");
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
        /// Изменить элемент перечисления для свойств
        /// </summary>
        public prop_enum_val prop_enum_val_upd(Int64 iid_prop_enum_val, Decimal ival_numeric, String ival_varchar, Int64 iid_object_reference, Int64 isort = -1)
        {
            prop_enum_val Prop_enum_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;

            if (isort < 0)
            {
                isort = 1;
            }
            //**********
             
            //=======================
            cmdk = CommandByKey("prop_enum_val_upd");

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

            cmdk.Parameters["iid_prop_enum_val"].Value = iid_prop_enum_val;
            cmdk.Parameters["ival_numeric"].Value = ival_numeric;
            cmdk.Parameters["ival_varchar"].Value = ival_varchar;
            cmdk.Parameters["isort"].Value = isort;
            cmdk.Parameters["iid_object_reference"].Value = iid_object_reference;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================     
            switch (error)
            {
                case 0:
                    Prop_enum_val = prop_enum_val_by_id(iid_prop_enum_val);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_prop_enum_val, eEntity.prop_enum_val, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения свойства класса
            PropEnumValChangeEventArgs e = new PropEnumValChangeEventArgs(Prop_enum_val, eAction.Update);
            PropEnumValOnChange(e);

            //Возвращаем Сущность
            return Prop_enum_val;
        }


        /// <summary>
        /// Изменить элемент перечисления для свойств
        /// </summary>
        public prop_enum_val prop_enum_val_upd(prop_enum_val Prop_enum_val)
        {
            return prop_enum_val_upd(Prop_enum_val.Id_prop_enum_val, Prop_enum_val.Val_numeric, Prop_enum_val.Val_varchar, Prop_enum_val.Id_object_reference, Prop_enum_val.Sort);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_val_upd");
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
        public void prop_enum_val_del(Int64 iid_prop_enum_val)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("prop_enum_val_del");

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

            cmdk.Parameters["iid_prop_enum_val"].Value = iid_prop_enum_val;

            //Запрос удаляемой сущности
            prop_enum_val Prop_enum_val = prop_enum_val_by_id(iid_prop_enum_val);
            //Начало транзакции
            cmdk.ExecuteNonQuery();
           
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_prop_enum_val, eEntity.prop_enum_val, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие удаления свойства класса
            if (Prop_enum_val != null)
            {
                PropEnumValChangeEventArgs e = new PropEnumValChangeEventArgs(Prop_enum_val, eAction.Delete);
                PropEnumValOnChange(e);
            }
        }


        /// <summary>
        /// Удалить новое перечисление для свойств
        /// </summary>
        public void prop_enum_val_del(prop_enum_val Prop_enum_val)
        {
            prop_enum_val_del(Prop_enum_val.Id_prop_enum_val);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_val_del");
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
        /// Выбрать элемент перечисления для свойства по идентификатору перечисления
        /// </summary>
        public prop_enum_val prop_enum_val_by_id(Int64 iid_prop_enum_val)
        {
            prop_enum_val prop_enum_val = null;

            DataTable tbl_entity  = TableByName("vprop_enum_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("prop_enum_val_by_id");

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

            cmdk.Parameters["iid_prop_enum_val"].Value = iid_prop_enum_val;

            cmdk.Fill(tbl_entity);
            
            if (tbl_entity.Rows.Count > 0)
            {
                prop_enum_val = new prop_enum_val(tbl_entity.Rows[0]);
            }
            return prop_enum_val;
        }
        
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_val_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_val_by_id");
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
        ///  Выбрать все элементы перечисления для свойства по идентификатору перечисления
        /// </summary>
        public List<prop_enum_val> prop_enum_val_by_id_prop_enum( Int64 iid_prop_enum)
        {
            List<prop_enum_val> entity_list = new List<prop_enum_val>();

            DataTable tbl_entity  = TableByName("vprop_enum_val");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("prop_enum_val_by_id_prop_enum");

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

            cmdk.Parameters["iid_prop_enum"].Value = iid_prop_enum;

            cmdk.Fill(tbl_entity);
            
            prop_enum_val prop_enum_val;
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    prop_enum_val = new prop_enum_val(dr);
                    entity_list.Add(prop_enum_val);
                }
            }
            return entity_list;
        }

        /// <summary>
        ///  Выбрать все элементы перечисления для свойства по идентификатору перечисления
        /// </summary>
        public List<prop_enum_val> prop_enum_val_by_id_prop_enum(prop_enum Prop_enum)
        {
            return prop_enum_val_by_id_prop_enum(Prop_enum.Id_prop_enum);
        }
        
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_val_by_id_prop_enum(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_val_by_id_prop_enum");
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
        /// Определить актуальность состояния элемента перечисления для свойства
        /// </summary>
        public eEntityState prop_enum_val_is_actual(Int64 iid, DateTime itimestamp)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("prop_enum_val_is_actual");

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

            cmdk.Parameters["iid"].Value = iid;
            cmdk.Parameters["itimestamp"].Value = itimestamp;

            //Начало транзакции
            is_actual = (Int32)cmdk.ExecuteScalar();
            
            return (eEntityState)is_actual;
        }

        /// <summary>
        /// Определить актуальность состояния элемента перечисления для свойства
        /// </summary>
        public eEntityState prop_enum_val_is_actual(prop_enum_val Prop_enum)
        {
            return prop_enum_is_actual(Prop_enum.Id_prop_enum, Prop_enum.Timestamp);
        }
        #endregion
        #endregion

        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ СВОЙСТВАМИ КЛАССОВ

        /// <summary>
        /// Делегат события изменения элемента перечисления для свойства
        /// </summary>
        public delegate void PropEnumValChangeEventHandler(Object sender, PropEnumValChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении перечисления для свойств
        /// </summary>
        public event PropEnumValChangeEventHandler PropEnumValChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения перечисления для свойств
        /// </summary>
        protected virtual void PropEnumValOnChange(PropEnumValChangeEventArgs e)
        {
            PropEnumValChangeEventHandler temp = PropEnumValChange;
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
