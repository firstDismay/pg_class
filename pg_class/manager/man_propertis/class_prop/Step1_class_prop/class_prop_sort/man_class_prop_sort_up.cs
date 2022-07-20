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
        /// <summary>
        /// Метод изменяет сортировку свойства активного класса на один уровень вверх
        /// </summary>
        public class_prop class_prop_sort_up(Int64 iid_class_prop)
        {
            class_prop class_prop = null;
            vclass class_sort = null;
            List<class_prop> SortList = new List<class_prop>();
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //=======================
            cmdk = CommandByKey("class_prop_sort_up");

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
            //=======================

            //Начало транзакции
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    class_prop = class_prop_by_id(iid_class_prop);
                    class_sort = class_act_by_id(class_prop.Id_class);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_class_prop, eEntity.class_prop, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие применения метода сортировки
            if (class_sort != null)
            {
                ClassChangeEventArgs e = new ClassChangeEventArgs(class_sort, eAction.Update);
                ClassPropSortOnChange(e);
            }
            
            //Возвращаем Объект
            return class_prop;
        }

        /// <summary>
        /// Метод изменяет сортировку свойства активного класса на один уровень вверх
        /// </summary>
        public class_prop class_prop_sort_up(class_prop Class_prop)
        {

            class_prop Result = null;
            if (Class_prop != null)
            {
                if (Class_prop.StorageType == eStorageType.Active)
                {
                    Result = class_prop_sort_up(Class_prop.Id);
                }
                else
                {
                    throw new PgDataException(eEntity.class_prop, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Метод обновления данных свойства класса не применим к историческому представлению класса!");
                }
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_sort_up(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_sort_up");
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
