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
        /// Удалить значение пользовательского свойства шаблона
        /// </summary>
        public void pos_temp_prop_user_val_del(Int64 iid_pos_temp_prop)
        {
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("pos_temp_prop_user_val_del");

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

            cmdk.Parameters["iid_pos_temp_prop"].Value = iid_pos_temp_prop;

            //Предварительный запрос данных
            pos_temp_prop pos_temp_prop = pos_temp_prop_by_id(iid_pos_temp_prop);
            pos_temp_prop_user_val pos_temp_prop_user_val = pos_temp_prop_user_val_by_id_prop(pos_temp_prop);
            
            //Начало транзакции
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            
            if (error > 0)
            {
                //Вызов события журнала
                JournalEventArgs me = new JournalEventArgs(iid_pos_temp_prop, eEntity.pos_temp_prop_user_val, error, desc_error, eAction.Delete, eJournalMessageType.error);
                JournalMessageOnReceived(me);
                throw new PgDataException(error, desc_error);
            }

            //Генерируем событие удаления свойства класса
            if (pos_temp_prop_user_val != null)
            {
                //Генерируем событие изменения значения свойства шаблона
                PosTempPropUserValChangeEventArgs e = new PosTempPropUserValChangeEventArgs(pos_temp_prop_user_val, eAction.Delete);
                PosTempPropUserValOnChange(e);
            }
        }

        /// <summary>
        /// Удалить значение пользовательского свойства активного представления класса
        /// </summary>
        public void pos_temp_prop_user_val_del(pos_temp_prop PosTempProp)
        {
            pos_temp_prop_user_val_del(PosTempProp.Id);
        }

        /// <summary>
        /// Удалить значение пользовательского свойства активного представления класса
        /// </summary>
        public void pos_temp_prop_user_val_del(pos_temp_prop_user_val PosTempPropUserVal)
        {
            pos_temp_prop_user_val_del(PosTempPropUserVal.Id_pos_temp_prop);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_user_val_del(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("pos_temp_prop_user_val_del");
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
