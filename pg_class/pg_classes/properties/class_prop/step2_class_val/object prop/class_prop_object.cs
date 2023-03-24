using System;

namespace pg_class.pg_classes
{
    public partial class class_prop
    {
        #region МЕТОДЫ РАБОТЫ СО ЗНАЧЕНИЯМИ ОБЪЕКТНЫХ СВОЙСТВ КЛАССА

        #region ДОБАВИТЬ ЗНАЧЕНИЕ

        /// <summary>
        /// Метод добавляет новое значение объектного свойство класса
        /// </summary>
        public class_prop_object_val object_data_add(vclass class_val, Decimal ibquantity_min, Decimal ibquantity_max,
                                     eObjectPropCreateEmdedMode iembed_mode, Boolean iembed_single, Int64 embed_class_real_id, Int32 iid_unit_conversion_rule)
        {
            return Manager.class_prop_object_val_add(this, class_val,
                      ibquantity_min, ibquantity_max,
                                     iembed_mode, iembed_single, embed_class_real_id, iid_unit_conversion_rule);
        }

        /// <summary>
        /// Метод добавляет новое значение объектного свойство класса
        /// </summary>
        public class_prop_object_val object_data_add(vclass class_val, Decimal ibquantity_min, Decimal ibquantity_max,
                                     eObjectPropCreateEmdedMode iembed_mode, Boolean iembed_single, Int64 embed_class_real_id, unit_conversion_rule Unit_conversion_rule)
        {
            return Manager.class_prop_object_val_add(this, class_val,
                      ibquantity_min, ibquantity_max,
                                     iembed_mode, iembed_single, embed_class_real_id, Unit_conversion_rule);
        }

        /// <summary>
        /// Метод добавляет новое значение объектного свойство класса
        /// </summary>
        public class_prop_object_val object_data_add(vclass class_val, Decimal ibquantity_min, Decimal ibquantity_max)
        {
            return Manager.class_prop_object_val_add(this, class_val,
                      ibquantity_min, ibquantity_max,
                                     eObjectPropCreateEmdedMode.NoAction, true, -1, -1);
        }

        #endregion

        #region УДАЛИТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Метод удаляет значение объектного свойства класса
        /// </summary>
        public void object_data_del()
        {
            Manager.class_prop_object_val_del(this);
        }
        #endregion

        #region ВЫБРАТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Значение объектного свойства, шаг №2
        /// </summary>
        public class_prop_object_val object_data_get()
        {
            class_prop_object_val Result = null;
            switch (StorageType)
            {
                case eStorageType.Active:
                    Result = Manager.class_prop_object_val_by_id_prop(this);
                    break;
                case eStorageType.History:
                    Result = Manager.class_prop_object_val_snapshot_by_id_prop(this);
                    break;
            }
            return Result;
        }
        #endregion

        #endregion

    }
}
