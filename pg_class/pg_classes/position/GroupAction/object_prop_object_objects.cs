using System;

namespace pg_class.pg_classes
{
    public partial class position
    {
        #region МЕТОДЫ РАБОТЫ СО ЗНАЧЕНИЯМИ СВОЙСТВ ОБЪЕКТНЫХ ОБЪЕКТОВ УКАЗАННЫХ СНИМКА И ПОЗИЦИИ

        #region ДОБАВИТЬ ЗНАЧЕНИЕ
        /// <summary>
        /// Добавить новое значение объектного свойства объектов снимка класса в указанной позиции
        /// </summary>
        public position object_prop_object_val_oblects_add(position Position_parent, class_prop_object_val Class_prop_object_val, Decimal icquantity, Boolean on_internal = false)
        {
            return object_prop_object_val_oblects_add(this, Class_prop_object_val, icquantity, on_internal);
        }
        #endregion
        #endregion

    }
}
