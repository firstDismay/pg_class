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
        /// <summary>
        /// Метод изменяет текущую сортировку свойств активного класса на сортировку по имени
        /// </summary>
        public vclass class_prop_sort_by_name(Int64 iid_class)
        {
            vclass class_sort = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
            //=======================
            cmdk = CommandByKey("class_prop_sort_by_name");

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

            cmdk.Parameters["iid_class"].Value = iid_class;
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
                    class_sort = class_act_by_id(iid_class);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_class, eEntity.vclass, error, desc_error, eAction.Update, eJournalMessageType.error);
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
            return class_sort;
        }

        /// <summary>
        /// Метод изменяет текущую сортировку свойств активного класса на сортировку по имени
        /// </summary>
        public vclass class_prop_sort_by_name(vclass Class)
        {
            vclass Result = null;
            if (Class != null)
            {
                if (Class.StorageType == eStorageType.Active)
                {
                    Result = class_prop_sort_by_name(Class.Id);
                }
                else
                {
                    throw new PgDataException(eEntity.class_prop, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Метод обновления данных свойства класса не применим к историческому представлению класса!");
                }
            }
            return Result;
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_sort_by_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_sort_by_name");
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
