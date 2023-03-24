using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод переопределяет тэг для всех связанных свойств класса
        /// </summary>
        public global_prop global_prop_set_tag_class_prop(Int64 iid_global_prop, String itag)
        {
            global_prop global_prop = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("global_prop_set_tag_class_prop");
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
            cmdk.Parameters["itag"].Value = itag;
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
        public global_prop global_prop_set_tag_class_prop(global_prop Global_prop, String itag)
        {
            global_prop Result = null;
            if (Global_prop != null)
            {
                Result = global_prop_set_tag_class_prop(Global_prop.Id, itag);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_set_tag_class_prop(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("global_prop_set_tag_class_prop");
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