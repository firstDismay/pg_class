using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод изменяет свойство шаблона
        /// </summary>
        public pos_temp_prop pos_temp_prop_upd(Int64 iid, Int32 iid_prop_type, Boolean ion_override, Int32 iid_data_type, String iname, String idesc, Int32 isort)
        {
            pos_temp_prop pos_temp_prop = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_prop_upd");
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

            cmdk.Parameters["iid"].Value = iid;
            cmdk.Parameters["iid_prop_type"].Value = iid_prop_type;
            cmdk.Parameters["ion_override"].Value = ion_override;
            cmdk.Parameters["iid_data_type"].Value = iid_data_type;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["isort"].Value = isort;
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            switch (error)
            {
                case 0:
                    pos_temp_prop = pos_temp_prop_by_id(iid);
                    if (pos_temp_prop != null)
                    {
                        //Генерируем событие изменения свойства
                        PosTempPropChangeEventArgs e = new PosTempPropChangeEventArgs(pos_temp_prop, eAction.Update);
                        PosTempPropOnChange(e);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid, eEntity.pos_temp_prop, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Возвращаем сущность
            return pos_temp_prop;
        }

        /// <summary>
        /// Метод изменяет свойство активного представления класса
        /// </summary>
        public pos_temp_prop pos_temp_prop_upd(pos_temp_prop PosTempProp)
        {
            return pos_temp_prop_upd(PosTempProp.Id, PosTempProp.Id_prop_type, PosTempProp.On_override, PosTempProp.Id_data_type, PosTempProp.Name, PosTempProp.Desc, PosTempProp.Sort);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_prop_upd");
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