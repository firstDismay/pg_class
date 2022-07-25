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
        /// Изменить допустимые параметры объектного свойства активного представления класса
        /// </summary>
        public class_prop_object_val class_prop_object_val_upd(Int64 iid_class_prop, Int64 iid_class_val,
                                                                    Decimal ibquantity_min, Decimal ibquantity_max,
                                                                eObjectPropCreateEmdedMode iembed_mode, Boolean iembed_single, Int64 iembed_class_real_id, Int32 iid_unit_conversion_rule)
        {
            class_prop_object_val class_prop_obj_val_class = null;
            class_prop class_prop = null;
            Int64 id;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;
            
            cmdk = CommandByKey("class_prop_object_val_upd");
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
            
            error = Convert.ToInt32(cmdk.Parameters["outresult"].Value);
            desc_error = Convert.ToString(cmdk.Parameters["outdesc"].Value);
            switch (error)
            {
                case 0:
                    id = Convert.ToInt64(cmdk.Parameters["outid"].Value);
                    if (id > 0)
                    {
                        class_prop_obj_val_class = class_prop_object_val_by_id(id);
                        class_prop = class_prop_by_id(iid_class_prop);
                    }
                    break;
                default:
                    //Вызов события журнала
                    JournalEventArgs me = new JournalEventArgs(class_prop.Id, eEntity.class_prop_object_val, error, desc_error, eAction.Update, eJournalMessageType.error);
                    JournalMessageOnReceived(me);
                    throw new PgDataException(error, desc_error);
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
                ClassPropObjectValChangeEventArgs e2 = new ClassPropObjectValChangeEventArgs(class_prop_obj_val_class, eAction.Update);
                ClassPropObjectValOnChange(e2);
            }
            //Возвращаем сущность
            return class_prop_obj_val_class;
        }

        /// <summary>
        /// Изменить допустимые параметры объектного свойства активного представления класса
        /// </summary>
        public class_prop_object_val class_prop_object_val_upd(class_prop_object_val Class_prop_object_val)
        {

            class_prop_object_val Result = null;
            if (Class_prop_object_val != null)
            {
                if (Class_prop_object_val.StorageType == eStorageType.Active)
                {
                    Class_prop_object_val = class_prop_object_val_upd(Class_prop_object_val.Id_class_prop, Class_prop_object_val.Id_class_val,
                                                                     Class_prop_object_val.Bquantity_min, Class_prop_object_val.Bquantity_max,
                                        Class_prop_object_val.Embed_mode, Class_prop_object_val.Embed_single, Class_prop_object_val.Embed_class_real_id, Class_prop_object_val.Id_unit_conversion_rule);
                }
                else
                {
                    throw new PgDataException(eEntity.vclass, eAction.Update, eSubClass_ErrID.SCE3_Violation_Rules,
                        "Метод изменения параметров объектного свойства класса не применим к историческому представлению класса!");
                }
            }
            return Result;
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean class_prop_object_val_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("class_prop_object_val_upd");
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