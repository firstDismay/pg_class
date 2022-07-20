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
        /// Изменить значение свойства-перечисления активного представления класса
        /// </summary>
        public object_prop_enum_val object_prop_enum_val_upd(object_prop_enum_val newObjectPropEnumVal)
        {
            object_prop_enum_val ObjectPropEnumVal = null;
            
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk = null;
            //**********
             
            if (newObjectPropEnumVal != null)
            {
                cmdk = CommandByKey("object_prop_enum_val_upd");

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

                cmdk.Parameters["iid_object"].Value = newObjectPropEnumVal.Id_object;
                cmdk.Parameters["iid_class_prop"].Value = newObjectPropEnumVal.Id_class_prop;

                if (newObjectPropEnumVal.Id_prop_enum_val <= 0)
                {
                    cmdk.Parameters["iid_prop_enum_val"].Value = DBNull.Value;
                }
                else
                {
                    cmdk.Parameters["iid_prop_enum_val"].Value = newObjectPropEnumVal.Id_prop_enum_val;
                }

                //Начало транзакции
                cmdk.ExecuteNonQuery();
                
                error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
                desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
                //SetLastTimeUsing();
                //=======================
                //=======================
                switch (error)
                {
                    case 0:
                        ObjectPropEnumVal = object_prop_enum_val_by_id_prop(newObjectPropEnumVal);
                        break;
                    default:
                        //Вызов события журнала
                        ObjectPropEnumVal = newObjectPropEnumVal;
                        JournalEventArgs me = new JournalEventArgs(newObjectPropEnumVal.Id_object, newObjectPropEnumVal.Id_class_prop, eEntity.object_prop_enum_val, error, desc_error, eAction.Update, eJournalMessageType.error);
                        JournalMessageOnReceived(me);
                        throw new PgDataException(error, desc_error);
                }
                if (ObjectPropEnumVal != null)
                {
                    //Генерируем событие изменения значения свойства объекта
                    ObjectPropEnumValChangeEventArgs e = new ObjectPropEnumValChangeEventArgs(ObjectPropEnumVal, eAction.Update);
                    ObjectPropEnumValOnChange(e);
                }
            }
            //Возвращаем Объект
            return ObjectPropEnumVal;
        }


        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean object_prop_enum_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("object_prop_enum_val_upd");
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
