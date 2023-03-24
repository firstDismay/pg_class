using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод изменяет текущую сортировку свойств шаблона позиции на сортировку по имени
        /// </summary>
        public pos_temp pos_temp_prop_sort_by_name(Int64 iid_pos_temp)
        {
            pos_temp pos_temp_sort = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_prop_sort_by_name");
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

            cmdk.Parameters["iid_pos_temp"].Value = iid_pos_temp;
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            switch (error)
            {
                case 0:
                    pos_temp_sort = pos_temp_by_id(iid_pos_temp);
                    //Генерируем событие применения метода сортировки
                    if (pos_temp_sort != null)
                    {
                        PosTempChangeEventArgs e = new PosTempChangeEventArgs(pos_temp_sort, eAction.Update);
                        PosTempPropSortOnChange(e);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_pos_temp, eEntity.pos_temp, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Возвращаем сущность
            return pos_temp_sort;
        }

        /// <summary>
        /// Метод изменяет текущую сортировку свойств шаблона позиции на сортировку по имени
        /// </summary>
        public pos_temp pos_temp_prop_sort_by_name(pos_temp Pos_temp)
        {
            return pos_temp_prop_sort_by_name(Pos_temp.Id); ;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_sort_by_name(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_prop_sort_by_name");
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