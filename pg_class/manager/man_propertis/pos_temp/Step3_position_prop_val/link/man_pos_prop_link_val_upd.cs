using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Изменить значение свойства-ссылки позиции
        /// </summary>
        public position_prop_link_val position_prop_link_val_upd(position_prop_link_val newPositionPropLinkVal)
        {
            position_prop_link_val position_prop_link_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;

            if (newPositionPropLinkVal != null)
            {
                cmdk = CommandByKey("position_prop_link_val_upd");

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

                cmdk.Parameters["iid_position"].Value = newPositionPropLinkVal.Id_position_carrier;
                cmdk.Parameters["iid_pos_temp_prop"].Value = newPositionPropLinkVal.Id_pos_temp_prop;

                if (newPositionPropLinkVal.Link_id_entity_instance <= 0)
                {
                    cmdk.Parameters["iid_entity_instance"].Value = DBNull.Value;
                }
                else
                {
                    cmdk.Parameters["iid_entity_instance"].Value = newPositionPropLinkVal.Link_id_entity_instance;
                }

                if (newPositionPropLinkVal.Link_id_sub_entity_instance <= 0)
                {
                    cmdk.Parameters["iid_sub_entity_instance"].Value = DBNull.Value;
                }
                else
                {
                    cmdk.Parameters["iid_sub_entity_instance"].Value = newPositionPropLinkVal.Link_id_sub_entity_instance;
                }
                cmdk.ExecuteNonQuery();

                error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
                desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
                switch (error)
                {
                    case 0:
                        position_prop_link_val = position_prop_link_val_by_id_prop(newPositionPropLinkVal);
                        if (position_prop_link_val != null)
                        {
                            //Генерируем событие изменения значения свойства объекта
                            PositionPropLinkValChangeEventArgs e = new PositionPropLinkValChangeEventArgs(position_prop_link_val, eAction.Update);
                            PositionPropLinkValOnChange(e);
                        }
                        break;
                    default:
                        //Вызов события журнала
                        position_prop_link_val = newPositionPropLinkVal;
                        JournalEventArgs me = new JournalEventArgs(newPositionPropLinkVal.Id_position_carrier, newPositionPropLinkVal.Id_pos_temp_prop, eEntity.position_prop_link_val, error, desc_error, eAction.Update, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgDataException(error, desc_error);
                }
            }
            //Возвращаем сущность
            return position_prop_link_val;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean position_prop_link_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("position_prop_link_val_upd");
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