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
        /// Метод изменяет сортировку элементов перечисления поднимая элемент вверх
        /// </summary>
        public prop_enum_val prop_enum_val_sort_top(Int64 iid_prop_enum_val)
        {
            prop_enum_val prop_enum_val = null;
            List<prop_enum_val> SortList = new List<prop_enum_val>();
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("prop_enum_val_sort_top");
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

            cmdk.Parameters["iid_prop_enum_val"].Value = iid_prop_enum_val;
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            switch (error)
            {
                case 0:
                    prop_enum_val = prop_enum_val_by_id(iid_prop_enum_val);
                    SortList = prop_enum_val_by_id_prop_enum(prop_enum_val.Id_prop_enum);
                    foreach (prop_enum_val item in SortList)
                    {
                        //Генерируем события изменения сортировки элементов перечисления
                        PropEnumValChangeEventArgs e = new PropEnumValChangeEventArgs(item, eAction.Update);
                        PropEnumValOnChange(e);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_prop_enum_val, eEntity.prop_enum_val, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Возвращаем сущность
            return prop_enum_val;
        }

        /// <summary>
        /// Метод изменяет сортировку элементов перечисления поднимая элемент вверх
        /// </summary>
        public prop_enum_val prop_enum_val_sort_top(prop_enum_val PropEnumVal)
        {
            prop_enum_val Result = null;
            if (PropEnumVal != null)
            {
                Result = prop_enum_val_sort_top(PropEnumVal.Id_prop_enum_val);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_val_sort_top(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("prop_enum_val_sort_top");
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