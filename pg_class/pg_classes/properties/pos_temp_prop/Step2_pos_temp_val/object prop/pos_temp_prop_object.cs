using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class.pg_classes
{
    public partial class pos_temp_prop
    {
        #region МЕТОДЫ РАБОТЫ СО ЗНАЧЕНИЯМИ ОБЪЕКТНЫХ СВОЙСТВ КЛАССА

        #region ДОБАВИТЬ ЗНАЧЕНИЕ

        /// <summary>
        /// Добавить данные значения свойства типа объектное, Шаг №2
        /// pos_temp_prop_object_val_add
        /// </summary>
        public pos_temp_prop_object_val object_data_add(vclass class_val,
                       Decimal ibquantity_min, Decimal ibquantity_max,
                                     eObjectPropCreateEmdedMode iembed_mode, Boolean iembed_single, Int64 embed_class_real_id, Int32 iid_unit_conversion_rule)
        {
            return Manager.pos_temp_prop_object_val_add(this, class_val,
                      ibquantity_min, ibquantity_max,
                                     iembed_mode, iembed_single, embed_class_real_id, iid_unit_conversion_rule);
        }


        /// <summary>
        /// Метод добавляет новое значение объектного свойство класса
        /// </summary>
        public pos_temp_prop_object_val object_data_add(vclass class_val, Decimal ibquantity_min, Decimal ibquantity_max,
                                     eObjectPropCreateEmdedMode iembed_mode, Boolean iembed_single, Int64 embed_class_real_id, unit_conversion_rule Unit_conversion_rule)
        {
            return Manager.pos_temp_prop_object_val_add(this, class_val,
                      ibquantity_min, ibquantity_max,
                                     iembed_mode, iembed_single, embed_class_real_id, Unit_conversion_rule);
        }


        /// <summary>
        /// Метод добавляет новое значение объектного свойство класса
        /// </summary>
        public pos_temp_prop_object_val object_data_add(vclass class_val, Decimal ibquantity_min, Decimal ibquantity_max)
        {
            return Manager.pos_temp_prop_object_val_add(this, class_val,
                      ibquantity_min, ibquantity_max,
                                     eObjectPropCreateEmdedMode.NoAction, true, -1, -1);
        }
        #endregion

        #region УДАЛИТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Удалить данные значения свойства типа объектное, Шаг №2
        /// pos_temp_prop_object_val_del
        /// </summary>
        public void object_data_del()
        {
            Manager.pos_temp_prop_object_val_del(this);
        }
        #endregion

        #region ВЫБРАТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Выбрать данные значения свойства типа объектное, Шаг №2
        /// pos_temp_prop_object_val_by_id_prop
        /// </summary>
        public pos_temp_prop_object_val object_data_get()
        {
            return Manager.pos_temp_prop_object_val_by_id_prop(this); 
        }
        #endregion

        #endregion
    }
}
