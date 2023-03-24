using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод изменяет данные области значения глобального свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_upd(Int64 iid_global_prop, Int64 iid_area_val)
        {
            global_prop_area_val global_prop_area_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("global_prop_area_val_upd");
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
            cmdk.Parameters["iid_area_val"].Value = iid_area_val;
            cmdk.ExecuteNonQuery();

            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            switch (error)
            {
                case 0:
                    global_prop_area_val = global_prop_area_val_by_id_prop(iid_global_prop);

                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(iid_global_prop, eEntity.global_prop_area_val, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
            }
            //Генерируем событие изменения свойства класса
            if (global_prop_area_val != null)
            {
                GlobalPropAreaValChangeEventArgs e = new GlobalPropAreaValChangeEventArgs(global_prop_area_val, eAction.Update);
                GlobalPropAreaValOnChange(e);
                //Возвращаем сущность
            }
            return global_prop_area_val;
        }

        /// <summary>
        /// Метод изменяет данные области значения глобального свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_upd(global_prop GlobalProp, prop_enum PropEnum)
        {
            global_prop_area_val Result = null;
            if (GlobalProp != null && PropEnum != null)
            {
                if (GlobalProp.Prop_type == ePropType.PropEnum)
                {
                    Result = global_prop_area_val_upd(GlobalProp.Id, PropEnum.Id_prop_enum);
                }
                else
                {
                    throw (new PgDataException(eEntity.global_prop_area_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules, "Сущность области значений не соотвествует типу свойства!"));
                }
            }
            return Result;
        }

        /// <summary>
        /// Метод изменяет данные области значения глобального свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_upd(global_prop GlobalProp, vclass ClassVal)
        {
            global_prop_area_val Result = null;
            if (GlobalProp != null && ClassVal != null)
            {
                if (GlobalProp.Prop_type == ePropType.PropObject)
                {
                    Result = global_prop_area_val_upd(GlobalProp.Id, ClassVal.Id);
                }
                else
                {
                    throw (new PgDataException(eEntity.global_prop_area_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules, "Сущность области значений не соотвествует типу свойства!"));
                }
            }
            return Result;
        }

        /// <summary>
        /// Метод изменяет данные области значения глобального свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_upd(global_prop GlobalProp, entity EntityVal)
        {
            global_prop_area_val Result = null;
            if (GlobalProp != null && EntityVal != null)
            {
                if (GlobalProp.Prop_type == ePropType.PropLink)
                {
                    Result = global_prop_area_val_upd(GlobalProp.Id, EntityVal.Id);
                }
                else
                {
                    throw (new PgDataException(eEntity.global_prop_area_val, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules, "Сущность области значений не соотвествует типу свойства!"));
                }
            }
            return Result;
        }

        /// <summary>
        /// Метод изменяет данные области значения глобального свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_upd(global_prop_area_val GlobalPropAreaVal)
        {
            global_prop_area_val Result = null;
            if (GlobalPropAreaVal != null)
            {
                Result = global_prop_area_val_upd(GlobalPropAreaVal.Id_global_prop, GlobalPropAreaVal.Id_area_val);
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean global_prop_area_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("global_prop_area_val_upd");
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