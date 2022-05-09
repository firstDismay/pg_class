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
        /// <summary>
        /// Метод удаляет ссылку выделенного диапазона плановго диапазона
        /// </summary>
        public void plan_given_range_plan_link_del(Int64 iid_plan_given_range_plan, Int64 iid_plan_given_range_plan_link)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********

            //=======================
            cmdk = CommandByKey("plan_given_range_plan_link_del");

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

            plan_given_range_plan_link plan_given_range_plan_link = plan_given_range_plan_link_by_id(iid_plan_given_range_plan_link);

            cmdk.Parameters["iid_plan_given_range_plan"].Value = iid_plan_given_range_plan;
            cmdk.Parameters["iid_plan_given_range_plan_link"].Value = iid_plan_given_range_plan_link;

            //Начало транзакции
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_plan_given_range_plan_link, eEntity.plan_given_range_plan_link, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            if (plan_given_range_plan_link != null)
            {
                //Генерируем событие изменения
                PlanGivenRangePlanLinkChangeEventArgs e = new PlanGivenRangePlanLinkChangeEventArgs(plan_given_range_plan_link, eAction.Delete);
                PlanGivenRangePlanLinkOnChange(e);
            }
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_given_range_plan_link_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("plan_given_range_plan_link_del");
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
        /// Метод удаляет указаную ссылку выделенного диапазона планового диапазона по идентификатору сущности
        /// </summary>
        public void plan_given_range_plan_link_del_by_entity(Int64 iid_plan_given_range_plan, Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            Int64 iid_plan_link = -1;
            //**********

            //=======================
            cmdk = CommandByKey("plan_given_range_plan_link_del_by_entity");

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

            plan_given_range_plan_link plan_given_range_plan_link = plan_given_range_plan_link_by_entity(iid_plan_given_range_plan, iid_entity, iid_entity_instance, iid_sub_entity_instance);
            if (plan_given_range_plan_link != null)
            {
                iid_plan_link = plan_given_range_plan_link.Id;
            }

            cmdk.Parameters["iid_plan_given_range_plan"].Value = iid_plan_given_range_plan;
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
                JournalEventArgs me = new JournalEventArgs(iid_plan_link, eEntity.plan_given_range_plan_link, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            if (plan_given_range_plan_link != null)
            {
                //Генерируем событие изменения
                PlanGivenRangePlanLinkChangeEventArgs e = new PlanGivenRangePlanLinkChangeEventArgs(plan_given_range_plan_link, eAction.Delete);
                PlanGivenRangePlanLinkOnChange(e);
            }
        }

        /// <summary>
        /// Метод удаляет указаную ссылку выделенного диапазона планового диапазона по идентификатору сущности
        /// </summary>
        public void plan_given_range_plan_link_del_by_entity(Int64 iid_plan, user User)
        {
            plan_given_range_plan_link_del_by_entity(iid_plan, User.EntityID, User.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку выделенного диапазона планового диапазона по идентификатору сущности
        /// </summary>
        public void plan_given_range_plan_link_del_by_entity(Int64 iid_plan, pos_temp Pos_temp)
        {
            plan_given_range_plan_link_del_by_entity(iid_plan, Pos_temp.EntityID, Pos_temp.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку выделенного диапазона планового диапазона по идентификатору сущности
        /// </summary>
        public void plan_given_range_plan_link_del_by_entity(Int64 iid_plan, pos_temp_prop Pos_temp_prop)
        {
            plan_given_range_plan_link_del_by_entity(iid_plan, Pos_temp_prop.EntityID, Pos_temp_prop.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку выделенного диапазона планового диапазона по идентификатору сущности
        /// </summary>
        public void plan_given_range_plan_link_del_by_entity(Int64 iid_plan, position Position)
        {
            plan_given_range_plan_link_del_by_entity(iid_plan, Position.EntityID, Position.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку выделенного диапазона планового диапазона по идентификатору сущности
        /// </summary>
        public void plan_given_range_plan_link_del_by_entity(Int64 iid_plan, position_prop Position_prop)
        {
            plan_given_range_plan_link_del_by_entity(iid_plan, Position_prop.EntityID, Position_prop.Id_position_prop, Position_prop.Id_position_carrier);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку выделенного диапазона планового диапазона по идентификатору сущности
        /// </summary>
        public void plan_given_range_plan_link_del_by_entity(Int64 iid_plan, object_general Object_general)
        {
            plan_given_range_plan_link_del_by_entity(iid_plan, Object_general.EntityID, Object_general.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку выделенного диапазона планового диапазона по идентификатору сущности
        /// </summary>
        public void plan_given_range_plan_link_del_by_entity(Int64 iid_plan, object_prop Object_prop)
        {
            plan_given_range_plan_link_del_by_entity(iid_plan, Object_prop.EntityID, Object_prop.Id_class_prop, Object_prop.Id_object_carrier);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку выделенного диапазона планового диапазона по идентификатору сущности
        /// </summary>
        public void plan_given_range_plan_link_del_by_entity(Int64 iid_plan, group Group)
        {
            plan_given_range_plan_link_del_by_entity(iid_plan, Group.EntityID, Group.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку выделенного диапазона планового диапазона по идентификатору сущности
        /// </summary>
        public void plan_given_range_plan_link_del_by_entity(Int64 iid_plan, vclass Class)
        {
            plan_given_range_plan_link_del_by_entity(iid_plan, Class.EntityID, Class.Id, -1);
        }

        /// <summary>
        /// Метод удаляет указаную ссылку выделенного диапазона планового диапазона по идентификатору сущности
        /// </summary>
        public void plan_given_range_plan_link_del_by_entity(Int64 iid_plan, class_prop Class_prop)
        {
            plan_given_range_plan_link_del_by_entity(iid_plan, Class_prop.EntityID, Class_prop.Id, -1);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_given_range_plan_link_del_by_entity(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("plan_given_range_plan_link_del_by_entity");
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
        public void plan_given_range_plan_link_del_all(Int64 iid_plan)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********

            //=======================
            cmdk = CommandByKey("plan_given_range_plan_link_del_all");

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


            //Начало транзакции
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_plan, eEntity.plan_given_range_plan_link, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean plan_given_range_plan_link_del_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("plan_given_range_plan_link_del_all");
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
    }
}
