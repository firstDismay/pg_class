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
using Newtonsoft.Json;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод объединяет массив объектов с совпадающими снимками классов
        /// </summary>
        public object_general object_merging(Int64[] object_merging_array)
        {
            object_general Object_merging = null;

            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********

            if (object_merging_array.Length > 0)
            {
                id = object_merging_array[0];
            }

            //=======================
            cmdk = CommandByKey("object_merging2");

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

            cmdk.Parameters["object_merging_array"].Value = object_merging_array;
            
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
                        Object_merging = object_by_id(id);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(id, eEntity.vobject, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения объекта носителя суммы
            if (Object_merging != null)
            {
                //Генерируем событие с действием слияние для результирующего объекта
                ObjectChangeEventArgs eo = new ObjectChangeEventArgs(Object_merging, eAction.Merging);
                ObjectOnChange(eo);

                //Генерируем событие обновления для носителя объекта слияния
                if (Object_merging.Is_inside)
                {
                    object_general Object_carrier = object_by_id(Object_merging.Id_object_carrier);
                    if (Object_carrier != null)
                    {
                        ObjectChangeEventArgs oc = new ObjectChangeEventArgs(Object_carrier, eAction.Update);
                        ObjectOnChange(oc);
                    }
                }
                else
                {
                    position position_carrier = pos_by_id(Object_merging.Id_position);
                    if (position_carrier != null)
                    {
                        PositionChangeEventArgs pc = new PositionChangeEventArgs(position_carrier, eAction.Update);
                        PositionOnChange(pc);
                    }
                }
            }
            //Возвращаем Объект
            return Object_merging;
        }

        /// <summary>
        /// Метод объединяет массив объектов с совпадающими снимками классов
        /// </summary>
        public object_general object_merging(object_general[] Object_merging_array)
        {
            Int64[] id_array;
            if (Object_merging_array.Length > 0)
            {
                id_array = new Int64[Object_merging_array.Length];

                for (int i = 0; i < Object_merging_array.Length; i++)
                {
                    id_array[i] = Object_merging_array[i].Id;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Массив объектов пуст!");
            }
            return object_merging(id_array);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_merging(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_merging2");
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
