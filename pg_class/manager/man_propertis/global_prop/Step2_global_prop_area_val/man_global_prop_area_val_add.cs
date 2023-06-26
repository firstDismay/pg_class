using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод добавляет новые данные области значения глобального свойства
        /// </summary>
        public global_prop_area_val global_prop_area_val_add(Int64 iid_global_prop, Int64 iid_area_val)
        {
            global_prop_area_val global_prop_area_val = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

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

            cmdk.Parameters["iid_global_prop"].Value = iid_global_prop;
            cmdk.Parameters["iid_area_val"].Value = iid_area_val;
            cmdk.ExecuteNonQuery();

            global_prop_area_val = global_prop_area_val_by_id_prop(iid_global_prop);
            //Генерируем событие изменения свойства класса
            if (global_prop_area_val != null)
            {
                GlobalPropAreaValChangeEventArgs e = new GlobalPropAreaValChangeEventArgs(global_prop_area_val, eAction.Insert);
                GlobalPropAreaValOnChange(e);
                //Возвращаем сущность
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
                    throw new ArgumentOutOfRangeException(
                        "Сущность области значений не соответствует типу свойства!");
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
                    throw new ArgumentOutOfRangeException(
                        "Сущность области значений не соответствует типу свойства!");
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
                    throw new ArgumentOutOfRangeException(
                        "Сущность области значений не соответствует типу свойства!");
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