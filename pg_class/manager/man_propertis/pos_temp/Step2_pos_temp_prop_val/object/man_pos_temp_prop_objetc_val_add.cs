using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Добавить новое значение объектного свойства шаблона
        /// </summary>
        public pos_temp_prop_object_val pos_temp_prop_object_val_add(Int64 iid_pos_temp_prop, Int64 iid_class_val,
                                     Decimal ibquantity_min, Decimal ibquantity_max,
                                     eObjectPropCreateEmdedMode iembed_mode, Boolean iembed_single, Int64 iembed_class_real_id, Int32 iid_unit_conversion_rule)
        {
            pos_temp_prop_object_val pos_temp_prop_object_val = null;
            pos_temp_prop pos_temp_prop = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("pos_temp_prop_object_val_add");
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
            cmdk.Parameters["iid_class_val"].Value = iid_class_val;
            cmdk.Parameters["ibquantity_min"].Value = ibquantity_min;
            cmdk.Parameters["ibquantity_max"].Value = ibquantity_max;
            cmdk.Parameters["iembed_mode"].Value = (Int32)iembed_mode;
            cmdk.Parameters["iembed_single"].Value = iembed_single;
            cmdk.Parameters["iembed_class_real_id"].Value = iembed_class_real_id;
            cmdk.Parameters["iid_unit_conversion_rule"].Value = iid_unit_conversion_rule;
            cmdk.ExecuteNonQuery();

            pos_temp_prop = pos_temp_prop_by_id(iid_pos_temp_prop);
            if (pos_temp_prop != null)
            {
                //Генерируем событие изменения свойства шаблона позиции
                PosTempPropChangeEventArgs e = new PosTempPropChangeEventArgs(pos_temp_prop, eAction.Update);
                PosTempPropOnChange(e);
            }

            pos_temp_prop_object_val = pos_temp_prop.object_data_get();
            if (pos_temp_prop_object_val != null)
            {
                //Генерируем событие изменения значения объектного свойства класса
                PosTempPropObjectValChangeEventArgs e2 = new PosTempPropObjectValChangeEventArgs(pos_temp_prop_object_val, eAction.Insert);
                PosTempPropObjectValOnChange(e2);
            }

            //Возвращаем сущность
            return pos_temp_prop_object_val;
        }

        /// <summary>
        /// Добавить новое значение объектного свойства шаблона
        /// </summary>
        public pos_temp_prop_object_val pos_temp_prop_object_val_add(pos_temp_prop PosTemp_prop, vclass class_val,
                       Decimal ibquantity_min, Decimal ibquantity_max,
                                     eObjectPropCreateEmdedMode iembed_mode, Boolean iembed_single, Int64 embed_class_real_id, Int32 iid_unit_conversion_rule)
        {
            return pos_temp_prop_object_val_add(PosTemp_prop.Id, class_val.Id, ibquantity_min, ibquantity_max, iembed_mode, iembed_single, embed_class_real_id, iid_unit_conversion_rule);
        }


        /// <summary>
        /// Добавить новое значение объектного свойства шаблона
        public pos_temp_prop_object_val pos_temp_prop_object_val_add(pos_temp_prop PosTemp_prop, vclass class_val,
                       Decimal ibquantity_min, Decimal ibquantity_max,
                                     eObjectPropCreateEmdedMode iembed_mode, Boolean iembed_single, Int64 embed_class_real_id, unit_conversion_rule Unit_conversion_rule)
        {
            pos_temp_prop_object_val Result = null;
            if (PosTemp_prop != null)
            {
                Result = pos_temp_prop_object_val_add(PosTemp_prop.Id, class_val.Id, ibquantity_min, ibquantity_max, iembed_mode, iembed_single, embed_class_real_id, Unit_conversion_rule.Id);
            }
            return Result;
        }


        /// <summary>
        /// Добавить новое значение объектного свойства шаблона
        /// </summary>
        public pos_temp_prop_object_val pos_temp_prop_object_val_add(pos_temp_prop_object_val PosTemp_prop_object_val)
        {
            pos_temp_prop_object_val Result = null;
            if (PosTemp_prop_object_val != null)
            {
                Result = pos_temp_prop_object_val_add(PosTemp_prop_object_val.Id_pos_temp_prop, PosTemp_prop_object_val.Id_class_val, PosTemp_prop_object_val.Bquantity_min,
                    PosTemp_prop_object_val.Bquantity_max,
                                        PosTemp_prop_object_val.Embed_mode, PosTemp_prop_object_val.Embed_single, PosTemp_prop_object_val.Embed_class_real_id, PosTemp_prop_object_val.Id_unit_conversion_rule);
            }
            return Result;
        }
        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean pos_temp_prop_object_val_add(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;


            cmdk = CommandByKey("pos_temp_prop_object_val_add");
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