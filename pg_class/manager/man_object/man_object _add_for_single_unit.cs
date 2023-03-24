using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;
using System.Collections.Generic;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод добавляет новые объекты в указанное расположение в виде единичных юнитов с количеством указанного правила пересчета
        /// </summary>
        public List<object_general> object_add_by_single_unit(Int64 iid_class, Int64 iid_position, Int32 iid_unit_conversion_rule, Decimal icquantity)
        {
            List<object_general> Object_list = new List<object_general>();
            object_general Object;
            Int64[] id_array;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********


            cmdk = CommandByKey("object_add_by_single_unit");

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

            cmdk.Parameters["iid_class"].Value = iid_class;
            cmdk.Parameters["iid_position"].Value = iid_position;
            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;
            cmdk.Parameters["icquantity"].Value = icquantity;
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            switch (error)
            {
                case 0:
                    id_array = (Int64[])(cmdk.Parameters["outid"].Value);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(-1, eEntity.vobject, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Генерируем событие изменения объектов
            foreach (Int64 i in id_array)
            {
                if (i > 0)
                {
                    Object = object_by_id(i);
                    if (Object != null)
                    {
                        Object_list.Add(Object);
                        ObjectChangeEventArgs e = new ObjectChangeEventArgs(Object, eAction.Insert);
                        ObjectOnChange(e);
                    }
                }
            }
            //Возвращаем сущностьы
            return Object_list;
        }

        /// <summary>
        /// Метод добавляет новые объекты в указанное расположение в виде единичных юнитов с количеством указанного правила пересчета
        /// </summary>
        public List<object_general> object_add_by_single_unit(vclass Class, position Position, unit_conversion_rule Unit_conversion_rule, Decimal icquantity)
        {
            return object_add_by_single_unit(Class.Id, Position.Id, Unit_conversion_rule.Id, icquantity);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_add_by_single_unit(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("object_add_by_single_unit");
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
