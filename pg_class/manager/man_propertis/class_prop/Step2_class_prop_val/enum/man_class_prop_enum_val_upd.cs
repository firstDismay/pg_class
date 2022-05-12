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
        /// Изменить данные значения свойства типа перечисление
        /// </summary>
        public class_prop_enum_val class_prop_enum_val_upd(Int64 iid_class_prop, Int64 iid_prop_enum, Int64 iid_prop_enum_val)
        {
            class_prop_enum_val Class_prop_enum_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
           
            //=======================
            cmdk = CommandByKey("class_prop_enum_val_upd");

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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.Parameters["iid_prop_enum"].Value = iid_prop_enum;

            if (iid_prop_enum_val <= 0)
            {
                cmdk.Parameters["iid_prop_enum_val"].Value = DBNull.Value;
            }
            else
            {
                cmdk.Parameters["iid_prop_enum_val"].Value = iid_prop_enum_val;
            }

            //Начало транзакции
            cmdk.ExecuteNonQuery();
           
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================     
            switch (error)
            {
                case 0:
                    Class_prop_enum_val = class_prop_enum_val_by_id_prop(iid_class_prop);
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_class_prop, eEntity.class_prop_enum_val, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            if (Class_prop_enum_val != null)
            {
                //Генерируем событие изменения свойства класса
                ClassPropEnumValChangeEventArgs e = new ClassPropEnumValChangeEventArgs(Class_prop_enum_val, eAction.Update);
                ClassPropEnumValOnChange(e);
            }
            //Возвращаем Сущность
            return Class_prop_enum_val;
        }


        /// <summary>
        /// Изменить данные значения свойства типа перечисление
        /// </summary>
        public class_prop_enum_val class_prop_enum_val_upd(class_prop_enum_val Class_prop_enum_val)
        {
            return class_prop_enum_val_upd(Class_prop_enum_val.Id_class_prop, Class_prop_enum_val.Id_prop_enum, Class_prop_enum_val.Id_prop_enum_val);
        }

        //-=ACCESS=-***********************************************************************************
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_enum_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("class_prop_enum_val_upd");
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
