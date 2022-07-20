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
        /// Изменить элемент перечисления для свойств
        /// </summary>
        public prop_enum_val prop_enum_val_upd(Int64 iid_prop_enum_val, Decimal ival_numeric, String ival_varchar, Int64 iid_object_reference, Int64 isort = -1)
        {
            prop_enum_val Prop_enum_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;

            if (isort < 0)
            {
                isort = 1;
            }
            //**********
             
            //=======================
            cmdk = CommandByKey("prop_enum_val_upd");

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

            cmdk.Parameters["iid_prop_enum_val"].Value = iid_prop_enum_val;
            cmdk.Parameters["ival_numeric"].Value = ival_numeric;
            cmdk.Parameters["ival_varchar"].Value = ival_varchar;
            cmdk.Parameters["isort"].Value = isort;
            cmdk.Parameters["iid_object_reference"].Value = iid_object_reference;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================     
            switch (error)
            {
                case 0:
                    Prop_enum_val = prop_enum_val_by_id(iid_prop_enum_val);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_prop_enum_val, eEntity.prop_enum_val, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения свойства класса
            PropEnumValChangeEventArgs e = new PropEnumValChangeEventArgs(Prop_enum_val, eAction.Update);
            PropEnumValOnChange(e);

            //Возвращаем Сущность
            return Prop_enum_val;
        }


        /// <summary>
        /// Изменить элемент перечисления для свойств
        /// </summary>
        public prop_enum_val prop_enum_val_upd(prop_enum_val Prop_enum_val)
        {
            return prop_enum_val_upd(Prop_enum_val.Id_prop_enum_val, Prop_enum_val.Val_numeric, Prop_enum_val.Val_varchar, Prop_enum_val.Id_object_reference, Prop_enum_val.Sort);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean prop_enum_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("prop_enum_val_upd");
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
