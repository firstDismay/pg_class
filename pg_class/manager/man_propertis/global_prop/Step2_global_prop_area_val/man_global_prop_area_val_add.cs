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
        /// Метод добавляет новые данные области значения глобального свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_add( Int64 iid_global_prop, Int64 iid_area_val)
        {
            global_prop_area_val global_prop_area_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            //**********
             
            //=======================
            cmdk = CommandByKey("global_prop_area_val_add");

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

            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;
            cmdk.Parameters["iid_area_val"].Value = iid_area_val;

            //Начало транзакции
            cmdk.ExecuteNonQuery();
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            //SetLastTimeUsing();
            //=======================
            switch (error)
            {
                case 0:
                    global_prop_area_val = global_prop_area_val_by_id_prop(iid_global_prop);
                    
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_global_prop, eEntity.global_prop_area_val, error, desc_error, eAction.Insert, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения свойства класса
            if (global_prop_area_val != null)
            {
                GlobalPropAreaValChangeEventArgs e = new GlobalPropAreaValChangeEventArgs(global_prop_area_val, eAction.Insert);
                GlobalPropAreaValOnChange(e);
                //Возвращаем Объект
            }
            return global_prop_area_val;
        }

        /// <summary>
        /// Метод добавляет новые данные области значения глобального свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_add(global_prop GlobalProp, prop_enum PropEnum)
        {
            global_prop_area_val Result = null;
            if (GlobalProp != null && PropEnum != null)
            {
                if (GlobalProp.Prop_type == ePropType.PropEnum)
                {
                    Result = global_prop_area_val_add(GlobalProp.Id, PropEnum.Id_prop_enum);
                }
                else
                {
                    throw (new PgDataException( eEntity.global_prop_area_val, eAction.Insert, eSubClass_ErrID.SCE3_Violation_Rules, "Сущность области значений не соотвествует типу свойства!"));
                }
            }
            return Result;
        }

        /// <summary>
        /// Метод добавляет новые данные области значения глобального свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_add(global_prop GlobalProp, vclass ClassVal)
        {
            global_prop_area_val Result = null;
            if (GlobalProp != null && ClassVal != null)
            {
                if (GlobalProp.Prop_type == ePropType.PropObject)
                {
                    Result = global_prop_area_val_add(GlobalProp.Id, ClassVal.Id);
                }
                else
                {
                    throw (new PgDataException(eEntity.global_prop_area_val, eAction.Insert, eSubClass_ErrID.SCE3_Violation_Rules, "Сущность области значений не соотвествует типу свойства!"));
                }
            }
            return Result;
        }

        /// <summary>
        /// Метод добавляет новые данные области значения глобального свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_add(global_prop GlobalProp, entity EntityVal)
        {
            global_prop_area_val Result = null;
            if (GlobalProp != null && EntityVal != null)
            {
                if (GlobalProp.Prop_type == ePropType.PropLink)
                {
                    Result = global_prop_area_val_add(GlobalProp.Id, EntityVal.Id);
                }
                else
                {
                    throw (new PgDataException(eEntity.global_prop_area_val, eAction.Insert, eSubClass_ErrID.SCE3_Violation_Rules, "Сущность области значений не соотвествует типу свойства!"));
                }
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_area_val_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;
            //=======================
            //=======================
            cmdk = CommandByKey("global_prop_area_val_add");
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
