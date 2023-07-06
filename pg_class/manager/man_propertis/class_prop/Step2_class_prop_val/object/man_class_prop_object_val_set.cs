﻿using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Установить новое значение объектного свойства активного представления класса
        /// </summary>
        public class_prop_object_val class_prop_object_val_set(Int64 iid_class_prop, Int64 iid_class_val,
                                     Decimal ibquantity_min, Decimal ibquantity_max,
                                     eObjectPropCreateEmdedMode iembed_mode, Boolean iembed_single, Int64 iembed_class_real_id, Int32 iid_unit_conversion_rule)
        {
            class_prop_object_val class_prop_obj_val_class = null;
            class_prop class_prop = null;
            Int64 id = 0;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_object_val_set");
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

            cmdk.Parameters["iid_class_prop"].Value = iid_class_prop;
            cmdk.Parameters["iid_class_val"].Value = iid_class_val;
            cmdk.Parameters["ibquantity_min"].Value = ibquantity_min;
            cmdk.Parameters["ibquantity_max"].Value = ibquantity_max;
            cmdk.Parameters["iembed_mode"].Value = (Int32)iembed_mode;
            cmdk.Parameters["iembed_single"].Value = iembed_single;
            cmdk.Parameters["iembed_class_real_id"].Value = iembed_class_real_id;
            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;
            cmdk.ExecuteNonQuery();

            id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
            if (id > 0)
            {
                class_prop_obj_val_class = class_prop_object_val_by_id(id);
                class_prop = class_prop_by_id(iid_class_prop);
            }

            if (class_prop != null)
            {
                //Генерируем событие изменения свойства класса
                ClassPropChangeEventArgs e = new ClassPropChangeEventArgs(class_prop, eAction.Update);
                ClassPropOnChange(e);
            }

            if (class_prop_obj_val_class != null)
            {
                //Генерируем событие изменения значения объектного свойства класса
                ClassPropObjectValChangeEventArgs e2 = new ClassPropObjectValChangeEventArgs(class_prop_obj_val_class, eAction.Insert);
                ClassPropObjectValOnChange(e2);
            }
            //Возвращаем сущность
            return class_prop_obj_val_class;
        }

        /// <summary>
        /// Добавить новое значение объектного свойства активного представления класса
        /// </summary>
        public class_prop_object_val class_prop_object_val_set(class_prop class_prop, vclass class_val,
                       Decimal ibquantity_min, Decimal ibquantity_max,
                                     eObjectPropCreateEmdedMode iembed_mode, Boolean iembed_single, Int64 embed_class_real_id, Int32 iid_unit_conversion_rule)
        {
            class_prop_object_val Result = null;
            if (class_prop != null)
            {
                Result = class_prop_object_val_set(class_prop.Id, class_val.Id, ibquantity_min, ibquantity_max, iembed_mode, iembed_single, embed_class_real_id, iid_unit_conversion_rule);
            }
            return Result;
        }

        /// <summary>
        /// Добавить новое значение объектного свойства активного представления класса
        /// </summary>
        public class_prop_object_val class_prop_object_val_set(class_prop class_prop, vclass class_val,
                       Decimal ibquantity_min, Decimal ibquantity_max,
                                     eObjectPropCreateEmdedMode iembed_mode, Boolean iembed_single, Int64 embed_class_real_id, unit_conversion_rule Unit_conversion_rule)
        {
            class_prop_object_val Result = null;
            if (class_prop != null)
            {
                Result = class_prop_object_val_set(class_prop.Id, class_val.Id, ibquantity_min, ibquantity_max, iembed_mode, iembed_single, embed_class_real_id, Unit_conversion_rule.Id);
            }
            return Result;
        }


        /// <summary>
        /// Добавить новое значение объектного свойства активного представления класса
        /// </summary>
        public class_prop_object_val class_prop_object_val_set(class_prop_object_val Class_prop_object_val)
        {
            class_prop_object_val Result = null;
            if (Class_prop_object_val != null)
            {
                Result = class_prop_object_val_set(Class_prop_object_val.Id_class_prop, Class_prop_object_val.Id_class_val,
                                        Class_prop_object_val.Bquantity_min, Class_prop_object_val.Bquantity_max,
                                        Class_prop_object_val.Embed_mode, Class_prop_object_val.Embed_single, Class_prop_object_val.Embed_class_real_id, Class_prop_object_val.Id_unit_conversion_rule);
            }
            return Result;
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_object_val_set(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_object_val_set");
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