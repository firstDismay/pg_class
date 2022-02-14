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
using pg_class.pg_classes.calendar;
using NpgsqlTypes;

namespace pg_class
{
    public partial class manager
    {
        #region МЕТОДЫ КЛАССА: ВЫДЕЛЕННЫЙ ДИАПАЗОН ПЛАНА

        #region ДОБАВИТЬ
        
        /// <summary>
        /// Метод добавляет новый выделенный диапазон планового диапазона
        /// </summary>
        public plan_given_range_plan plan_given_range_plan_add(Int64 iid_plan, Int64 iid_plan_range, NpgsqlRange<DateTime> irange_plan)
        {
            plan_given_range_plan centity = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("plan_given_range_plan_add");

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

            cmdk.Parameters["iid_plan"].Value = iid_plan;
            cmdk.Parameters["iid_plan_range"].Value = iid_plan_range;
            cmdk.Parameters["irange_plan"].Value = irange_plan;

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
                        centity = plan_given_range_plan_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.plan_given_range_plan, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (centity != null)
            {
                //Генерируем событие изменения выделенного диапазона планогового диапазона плана
                PlanGivenRangePlanChangeEventArgs e = new PlanGivenRangePlanChangeEventArgs(centity, eAction.Insert);
                PlanGivenRangePlanOnChange(e);
            }
            //Возвращаем Объект
            return centity;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_given_range_plan_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("plan_given_range_plan_add");
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
        /// Метод изменяет выделенный диапазон планового диапазона плана
        /// </summary>
        public plan_given_range_plan plan_given_range_plan_upd(Int64 iid, NpgsqlRange<DateTime> irange_plan)
        {
            plan_given_range_plan centity = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("plan_given_range_plan_upd");

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
            cmdk.Parameters["irange_plan"].Value = irange_plan;
            
            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    centity = plan_given_range_plan_by_id(iid);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid, eEntity.plan_given_range_plan, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (centity != null)
            {
                //Генерируем событие изменения планового диапазона
                PlanGivenRangePlanChangeEventArgs e = new PlanGivenRangePlanChangeEventArgs(centity, eAction.Update);
                PlanGivenRangePlanOnChange(e);
            }
            //Возвращаем Объект
            return centity;
        }

        /// <summary>
        /// Метод изменяет выделенный диапазон планового диапазона плана
        /// </summary>
        public plan_given_range_plan plan_given_range_plan_upd(plan_range Plan_range)
        {
            return plan_given_range_plan_upd(Plan_range.Id, Plan_range.Range_plan);
        }
       

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_given_range_plan_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("plan_given_range_plan_upd");
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

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет выделенный  диапазон планового диапазона плана
        /// </summary>
        public void plan_given_range_plan_del(Int64 iid)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("plan_given_range_plan_del");

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

            plan_given_range_plan centity= plan_given_range_plan_by_id(iid);

            cmdk.Parameters["iid"].Value = iid;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid, eEntity.plan_given_range_plan, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие изменения выделенного диапазона планового диапазона плана
            if (centity != null)
            {
                PlanGivenRangePlanChangeEventArgs e = new PlanGivenRangePlanChangeEventArgs(centity, eAction.Delete);
                PlanGivenRangePlanOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет выделенный  диапазон планового диапазона плана
        /// </summary>
        public void plan_given_range_plan_del(plan_given_range_plan Plan_given_range_plan)
        {
            plan_given_range_plan_del(Plan_given_range_plan.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_given_range_plan_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("plan_given_range_plan_del");
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
        /// Метод удаляет выделенные  диапазоны планового диапазона плана по идентификатору планового диапазона
        /// </summary>
        public void plan_given_range_plan_del_by_id_plan_range(Int64 iid_plan_range)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********

            //=======================
            cmdk = CommandByKey("plan_given_range_plan_del_by_id_plan_range");

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

            plan_range centity = plan_range_by_id(iid_plan_range);

            cmdk.Parameters["iid_plan_range"].Value = iid_plan_range;

            //Начало транзакции
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_plan_range, eEntity.plan_range, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие изменения планового диапазона плана
            if (centity != null)
            {
                PlanRangeChangeEventArgs e = new PlanRangeChangeEventArgs(centity, eAction.Delete);
                PlanRangeOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет выделенные  диапазоны планового диапазона плана по идентификатору планового диапазона
        /// </summary>
        public void plan_given_range_plan_del_by_id_plan_range(plan_range Plan_range)
        {
            plan_given_range_plan_del_by_id_plan_range(Plan_range.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_given_range_plan_del_by_id_plan_range(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("plan_given_range_plan_del_by_id_plan_range");
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
        /// Выделенный диапазон плана по идентификатору
        /// </summary>
        public plan_given_range_plan plan_given_range_plan_by_id(Int64 iid)
        {
            plan_given_range_plan plan_given_range_plan = null;

            DataTable tbl_entity  = TableByName("vplan_given_range_plan");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("plan_given_range_plan_by_id");

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

            cmdk.Fill(tbl_entity);
            
            if (tbl_entity.Rows.Count > 0)
            {
                plan_given_range_plan = new plan_given_range_plan(tbl_entity.Rows[0]);
            }
            return plan_given_range_plan;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_given_range_plan_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("plan_given_range_plan_by_id");
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
        /// Лист выделенных диапазонов планового диапаона плана по идентификатору планового диапазона
        /// </summary>
        public List<plan_given_range_plan> plan_given_range_plan_by_id_plan_range(Int64 iid_plan_range)
        {
            List<plan_given_range_plan>  entity_list = new List<plan_given_range_plan>();

            
            DataTable tbl_entity  = TableByName("vplan_given_range_plan");
            
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("plan_given_range_plan_by_id_plan_range");

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

            cmdk.Parameters["iid_plan_range"].Value = iid_plan_range;

            cmdk.Fill(tbl_entity);

            plan_given_range_plan centity;
            
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    centity = new plan_given_range_plan(dr);
                    entity_list.Add(centity);
                }
            }

            return entity_list;
        }

        /// <summary>
        /// Лист выделенных диапазонов планового диапаона плана по идентификатору планового диапазона
        /// </summary>
        public List<plan_given_range_plan> plan_given_range_plan_by_id_plan_range(plan_range Plan_range)
        {
            return plan_given_range_plan_by_id_plan_range(Plan_range.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_given_range_plan_by_id_plan_range(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("plan_given_range_plan_by_id_plan_range");
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
        /// Метод определяет актуальность состояния выделенного диапазона плана
        /// </summary>
        public eEntityState plan_given_range_plan_is_actual(Int64 iid, DateTime itimestamp)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("plan_given_range_plan_is_actual");

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
        /// Метод определяет актуальность состояния выделенного диапазона плана
        /// </summary>
        public eEntityState plan_given_range_plan_is_actual(plan_given_range_plan Plan_given_range_plan)
        {
            return plan_given_range_plan_is_actual(Plan_given_range_plan.Id, Plan_given_range_plan.Timestamp);
        }
        #endregion
        #endregion
        
        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ ГРУППАМИ

        /// <summary>
        /// Делегат события изменения выделенного диапазона плана
        /// </summary>
        public delegate void PlanGivenRangePlanChangeEventHandler(Object sender, PlanGivenRangePlanChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении выделенного диапазона плана методом доступа к БД
        /// </summary>
        public event PlanGivenRangePlanChangeEventHandler PlanGivenRangePlanChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения плана
        /// </summary>
        protected virtual void PlanGivenRangePlanOnChange(PlanGivenRangePlanChangeEventArgs e)
        {
            PlanGivenRangePlanChangeEventHandler temp = PlanGivenRangePlanChange;
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
