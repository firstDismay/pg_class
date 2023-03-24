using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Добавить данные значения свойства типа перечисление
        /// </summary>
        public pos_temp_prop_enum_val pos_temp_prop_enum_val_add(Int64 iid_pos_temp_prop, Int64 iid_prop_enum, Int64 iid_prop_enum_val)
        {
            pos_temp_prop_enum_val pos_temp_prop_enum_val = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;

            cmdk = CommandByKey("pos_temp_prop_enum_val_add");
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

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;
            cmdk.Parameters["iid_prop_enum"].Value = iid_prop_enum;

            if (iid_prop_enum_val <= 0)
            {
                cmdk.Parameters["iid_prop_enum_val"].Value = DBNull.Value;
            }
            else
            {
                cmdk.Parameters["iid_prop_enum_val"].Value = iid_prop_enum_val;
            }
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            switch (error)
            {
                case 0:
                    id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
                    if (id > 0)
                    {
                        pos_temp_prop_enum_val = pos_temp_prop_enum_val_by_id_prop(iid_pos_temp_prop);
                    }
                    if (pos_temp_prop_enum_val != null)
                    {
                        //Генерируем событие изменения данных значения свойства типа перечисление
                        PosTempPropEnumValChangeEventArgs e = new PosTempPropEnumValChangeEventArgs(pos_temp_prop_enum_val, eAction.Insert);
                        PosTempPropEnumValOnChange(e);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_pos_temp_prop, eEntity.pos_temp_prop_enum_val, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }

            //Возвращаем Сущность
            return pos_temp_prop_enum_val;
        }


        /// <summary>
        /// Добавить данные значения свойства типа перечисление
        /// </summary>
        public pos_temp_prop_enum_val pos_temp_prop_enum_val_add(pos_temp_prop_enum_val PosTemp_prop_enum_val)
        {
            pos_temp_prop_enum_val Result = null;
            if (PosTemp_prop_enum_val != null)
            {
                Result = pos_temp_prop_enum_val_add(PosTemp_prop_enum_val.Id_pos_temp_prop, PosTemp_prop_enum_val.Id_prop_enum, PosTemp_prop_enum_val.Id_prop_enum_val);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_enum_val_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_prop_enum_val_add");
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