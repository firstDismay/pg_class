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
using pg_class.pg_classes.calendar;

namespace pg_class
{
    public partial class manager
    {
        #region МЕТОДЫ КЛАССА: ПЛАНОВЫЙ ДИАПАЗОН

        #region ДОБАВИТЬ
        
        /// <summary>
        /// Метод добавляет новую ссылку планового диапазона
        /// </summary>
        public plan_range_link plan_range_link_add( Int64 iid_plan_range, Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            plan_range_link centity = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("plan_range_link_add");

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
            cmdk.Parameters["iid_entity"].Value = iid_entity;
            cmdk.Parameters["iid_entity_instance"].Value = iid_entity_instance;
            cmdk.Parameters["iid_sub_entity_instance"].Value = iid_sub_entity_instance;
            
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
                        centity = plan_range_link_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.plan_range_link, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (centity != null)
            {
                //Генерируем событие изменения плана
                PlanRangeLinkChangeEventArgs e = new PlanRangeLinkChangeEventArgs(centity, eAction.Insert);
                PlanRangeLinkOnChange(e);
            }
            //Возвращаем Объект
            return centity;
        }
        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_range_link_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("plan_range_link_add");
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
        /// Метод удаляет указаную ссылку планового диапазона
        /// </summary>
        public void plan_range_link_del(Int64 iid_plan_range, Int64 iid_plan_range_link)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********

            //=======================
            cmdk = CommandByKey("plan_range_link_del");

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

            plan_range_link plan_range_link = plan_range_link_by_id(iid_plan_range_link);

            cmdk.Parameters["iid_plan_range"].Value = iid_plan_range;
            cmdk.Parameters["iid_plan_range_link"].Value = iid_plan_range_link;

            //Начало транзакции
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_plan_range_link, eEntity.plan_range_link, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            if (plan_range_link != null)
            {
                //Генерируем событие изменения
                PlanRangeLinkChangeEventArgs e = new PlanRangeLinkChangeEventArgs(plan_range_link, eAction.Delete);
                PlanRangeLinkOnChange(e);
            }
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_range_link_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("plan_range_link_del");
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
        /// Метод удаляет указаную ссылку планового диапазона по идентификатору сущности
        /// </summary>
        public void plan_range_link_del_by_entity(Int64 iid_plan_range, Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            Int64 iid_doc_link = -1;
            //**********

            //=======================
            cmdk = CommandByKey("plan_range_link_del_by_entity");

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

            plan_range_link plan_range_link = plan_range_link_by_entity(iid_plan_range, iid_entity, iid_entity_instance, iid_sub_entity_instance);
            if (plan_range_link != null)
            {
                iid_doc_link = plan_range_link.Id;
            }

            cmdk.Parameters["iid_plan_range"].Value = iid_plan_range;
            cmdk.Parameters["iid_entity"].Value = iid_entity;
            cmdk.Parameters["iid_entity_instance"].Value = iid_entity_instance;
            cmdk.Parameters["iid_sub_entity_instance"].Value = iid_sub_entity_instance;

            //Начало транзакции
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_doc_link, eEntity.plan_range_link, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            if (plan_range_link != null)
            {
                //Генерируем событие изменения
                PlanRangeLinkChangeEventArgs e = new PlanRangeLinkChangeEventArgs(plan_range_link, eAction.Delete);
                PlanRangeLinkOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет указаную ссылку планового диапазона по идентификатору сущности
        /// </summary>
        public void plan_range_link_del_by_entity(Int64 iid_plan, user User)
        {
            plan_range_link_del_by_entity(iid_plan, User.EntityID, User.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку планового диапазона по идентификатору сущности
        /// </summary>
        public void plan_range_link_del_by_entity(Int64 iid_plan, pos_temp Pos_temp)
        {
            plan_range_link_del_by_entity(iid_plan, Pos_temp.EntityID, Pos_temp.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку планового диапазона по идентификатору сущности
        /// </summary>
        public void plan_range_link_del_by_entity(Int64 iid_plan, pos_temp_prop Pos_temp_prop)
        {
            plan_range_link_del_by_entity(iid_plan, Pos_temp_prop.EntityID, Pos_temp_prop.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку планового диапазона по идентификатору сущности
        /// </summary>
        public void plan_range_link_del_by_entity(Int64 iid_plan, position Position)
        {
            plan_range_link_del_by_entity(iid_plan, Position.EntityID, Position.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку планового диапазона по идентификатору сущности
        /// </summary>
        public void plan_range_link_del_by_entity(Int64 iid_plan, position_prop Position_prop)
        {
            plan_range_link_del_by_entity(iid_plan, Position_prop.EntityID, Position_prop.Id_position_prop, Position_prop.Id_position_carrier);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку планового диапазона по идентификатору сущности
        /// </summary>
        public void plan_range_link_del_by_entity(Int64 iid_plan, object_general Object_general)
        {
            plan_range_link_del_by_entity(iid_plan, Object_general.EntityID, Object_general.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку планового диапазона по идентификатору сущности
        /// </summary>
        public void plan_range_link_del_by_entity(Int64 iid_plan, object_prop Object_prop)
        {
            plan_range_link_del_by_entity(iid_plan, Object_prop.EntityID, Object_prop.Id_class_prop, Object_prop.Id_object_carrier);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку планового диапазона по идентификатору сущности
        /// </summary>
        public void plan_range_link_del_by_entity(Int64 iid_plan, group Group)
        {
            plan_range_link_del_by_entity(iid_plan, Group.EntityID, Group.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку планового диапазона по идентификатору сущности
        /// </summary>
        public void plan_range_link_del_by_entity(Int64 iid_plan, vclass Class)
        {
            plan_range_link_del_by_entity(iid_plan, Class.EntityID, Class.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку планового диапазона по идентификатору сущности
        /// </summary>
        public void plan_range_link_del_by_entity(Int64 iid_plan, class_prop Class_prop)
        {
            plan_range_link_del_by_entity(iid_plan, Class_prop.EntityID, Class_prop.Id, -1);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_range_link_del_by_entity(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("plan_range_link_del_by_entity");
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
        /// Метод удаляет все ссылки плана
        /// </summary>
        public void plan_range_link_del_all(Int64 iid_plan_range)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********

            //=======================
            cmdk = CommandByKey("plan_range_link_del_all");

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


            //Начало транзакции
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_plan_range, eEntity.plan_range_link, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_range_link_del_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("plan_range_link_del_all");
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
        /// Ссылка плана по идентификатору
        /// </summary>
        public plan_range_link plan_range_link_by_id(Int64 iid)
        {
            plan_range_link plan_range_link = null;

            DataTable tbl_entity  = TableByName("vplan_range_link");
            //NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("plan_range_link_by_id");

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
                plan_range_link = new plan_range_link(tbl_entity.Rows[0]);
            }
            return plan_range_link;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_range_link_by_id(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("plan_range_link_by_id");
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
        /// Лист ссылок плана по идентификатору планового диапазона
        /// </summary>
        public List<plan_range_link> plan_range_link_by_id_plan_range(Int64 iid_plan_range)
        {
            List<plan_range_link>  entity_list = new List<plan_range_link>();

            
            DataTable tbl_entity  = TableByName("vplan_range_link");
            
            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("plan_range_link_by_id_plan_range");

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

            plan_range_link centity;
            
            if (tbl_entity.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in tbl_entity.Rows)
                {
                    centity = new plan_range_link(dr);
                    entity_list.Add(centity);
                }
            }

            return entity_list;
        }

        /// <summary>
        /// Лист ссылок плана по идентификатору планового диапазона
        /// </summary>
        public List<plan_range_link> plan_range_link_by_id_plan_range(plan_range Plan_range)
        {
            return plan_range_link_by_id_plan_range(Plan_range.Id);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_range_link_by_id_plan_range(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("plan_range_link_by_id_plan_range");
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
        /// Лист ссылок плана по идентификатору сущности
        /// </summary>
        public plan_range_link plan_range_link_by_entity(Int64 iid_plan, Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            plan_range_link plan_range_link = null;

            DataTable tbl_entity = TableByName("vplan_range_link");

            //=======================
            NpgsqlCommandKey cmdk;

            //=======================
            cmdk = CommandByKey("plan_range_link_by_entity");

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
            cmdk.Parameters["iid_entity"].Value = iid_entity;
            cmdk.Parameters["iid_entity_instance"].Value = iid_entity_instance;
            cmdk.Parameters["iid_sub_entity_instance"].Value = iid_sub_entity_instance;

            cmdk.Fill(tbl_entity);

            if (tbl_entity.Rows.Count > 0)
            {
                plan_range_link = new plan_range_link(tbl_entity.Rows[0]);
            }
            return plan_range_link;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_range_link_by_entity(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("plan_range_link_by_entity");
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
        /// Метод определяет актуальность состояния ссылки плана
        /// </summary>
        public eEntityState plan_range_link_is_actual(Int64 iid)
        {
            Int32 is_actual = 3;
            //=======================
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("plan_range_link_is_actual");

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

            //Начало транзакции
            is_actual = (Int32)cmdk.ExecuteScalar();
            
            return (eEntityState)is_actual;
        }

        /// <summary>
        /// Метод определяет актуальность состояния ссылки плана
        /// </summary>
        public eEntityState plan_range_link_is_actual(plan Plan)
        {
            return plan_range_link_is_actual(Plan.Id);
        }
        #endregion
        #endregion
        
        #region СОБЫТИЕ ИСПОЛЬЗОВАНИЯ МЕТОДОВ УПРАВЛЕНИЯ ГРУППАМИ

        /// <summary>
        /// Делегат события изменения ссылки планового диапазона
        /// </summary>
        public delegate void PlanRangeLinkChangeEventHandler(Object sender, PlanRangeLinkChangeEventArgs e);

        /// <summary>
        /// Событие возникает при изменении ссылки плана методом доступа к БД
        /// </summary>
        public event PlanRangeLinkChangeEventHandler PlanRangeLinkChange;
        //===========================================================

        /// <summary>
        ///  Метод вызова события изменения ссылки плана
        /// </summary>
        protected virtual void PlanRangeLinkOnChange(PlanRangeLinkChangeEventArgs e)
        {
            PlanRangeLinkChangeEventHandler temp = PlanRangeLinkChange;
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
