using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод изменяет глобальное свойство
        /// </summary>
        public global_prop global_prop_upd(Int64 iid_global_prop, Int32 iid_prop_type, Int32 iid_data_type, String iname, String idesc, Boolean ivisible)

        {
            global_prop global_prop = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("global_prop_upd");
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

            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;
            cmdk.Parameters["iid_prop_type"].Value = iid_prop_type;
            cmdk.Parameters["iid_data_type"].Value = iid_data_type;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["ivisible"].Value = ivisible;
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            switch (error)
            {
                case 0:
                    global_prop = global_prop_by_id(iid_global_prop);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_global_prop, eEntity.global_prop, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения свойства класса
            GlobalPropChangeEventArgs e = new GlobalPropChangeEventArgs(global_prop, eAction.Update);
            GlobalPropOnChange(e);
            //Возвращаем сущность
            return global_prop;
        }

        /// <summary>
        /// Метод изменяет свойство активного представления класса
        /// </summary>
        public global_prop global_prop_upd(global_prop Global_prop)
        {
            global_prop Result = null;
            if (Global_prop != null)
            {
                Result = global_prop_upd(Global_prop.Id, Global_prop.Id_prop_type, Global_prop.Id_data_type, Global_prop.Name, Global_prop.Desc, Global_prop.Visible);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("global_prop_upd");
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