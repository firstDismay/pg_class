﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Npgsql;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using pg_class.pg_classes;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод исключает шаблон позиции из листа ограничений вложенности
        /// </summary>
        public pos_temp pos_temp_nested_exclude(Int64 iid_pos_temp, Int64 iid_pos_temp_nested)
        {
            pos_temp pos_temp = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
            
            //=======================
            cmdk = CommandByKey("pos_temp_nested_exclude");

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

            cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;
            cmdk.Parameters["iid_pos_temp_nested"].Value = iid_pos_temp_nested;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    pos_temp = pos_temp_by_id(iid_pos_temp);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_pos_temp, eEntity.pos_temp_nested_rule, error, desc_error, eAction.Exclude, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения шаблона позиции
            /*PosTempChangeEventArgs e = new PosTempChangeEventArgs(pos_temp, eAction.Update);
            PosTempOnChange(e);*/
            //Вызов события изменения списка вложенности
            PosTempNestedListChangeEventArgs e;
            e = new PosTempNestedListChangeEventArgs(pos_temp, eActionPosTempNestedList.delrule);
            OnPosTempNestedListChange(e);
            //Возвращаем Объект
            return pos_temp;
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_nested_exclude(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_nested_exclude");
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
        /// Метод исключает все шаблоны позиции из листа ограничений вложенности
        /// </summary>
        public pos_temp pos_temp_nested_exclude_all(Int64 iid_pos_temp)
        {
            pos_temp pos_temp = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
            
            //=======================
            cmdk = CommandByKey("pos_temp_nested_exclude_all");

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

            cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    pos_temp = pos_temp_by_id(iid_pos_temp);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_pos_temp, eEntity.pos_temp_nested_rule, error, desc_error, eAction.Exclude, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения шаблона позиции
            /*PosTempChangeEventArgs e = new PosTempChangeEventArgs(pos_temp, eAction.Update);
            PosTempOnChange(e);*/
            PosTempNestedListChangeEventArgs e;
            e = new PosTempNestedListChangeEventArgs(pos_temp, eActionPosTempNestedList.delallrule);
            OnPosTempNestedListChange(e);
            //Возвращаем Объект
            return pos_temp;
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_nested_exclude_all(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_nested_exclude_all");
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
