using System;
using System.Collections.Generic;

namespace pg_class.pg_classes
{
    public partial class prop_enum
    {
        #region СВОЙСТВА ДЛЯ РАБОТЫ С ЭЛЕМЕНТАМИ ПЕРЕЧИСЛЕНИЯ

        /// <summary>
        /// Метод возвращает лист элементов перечисления для свойств
        /// </summary>
        public List<prop_enum_val> Prop_enum_val_list
        {
            get
            {
                return Manager.prop_enum_val_by_id_prop_enum(this);
            }
        }
        #endregion

        #region МЕТОДЫ РАБОТЫ С ЭЛЕМЕНТАМИ ПЕРЕЧИСЛЕНИЯ

        #region ДОБАВИТЬ

        /// <summary>
        /// Добавить новый элемент в перечисление для свойств
        /// </summary>
        public prop_enum_val prop_enum_val_add(Decimal ival_numeric, String ival_varchar, Int64 iid_object_reference = -1, Int32 isort = -1)
        {
            return Manager.prop_enum_val_add(id_prop_enum, ival_numeric, ival_varchar, iid_object_reference, isort);
        }

        /// <summary>
        /// Добавить новый элемент в перечисление для свойств
        /// </summary>
        public prop_enum_val prop_enum_val_add(Object ival, Int64 iid_object_reference = -1, Int32 isort = -1)
        {
            return Manager.prop_enum_val_add(this, ival, iid_object_reference, isort);
        }
        #endregion

        #region ИЗМЕНИТЬ
        /// <summary>
        /// Метод изменяет текущую сортировку элементов перечисления на сортировку по имени
        /// prop_enum_val_sort_by_name
        /// </summary>
        public void Sort_prop_enum_val_by_name()
        {
            Manager.prop_enum_val_sort_by_name(this);
        }
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Удалить новое перечисление для свойств
        /// </summary>
        public void prop_enum_val_del(prop_enum_val Prop_enum_val)
        {
            Manager.prop_enum_val_del(Prop_enum_val);
        }
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Метод возвращает лист элементов перечисления для свойств
        /// </summary>
        public List<prop_enum_val> Prop_enum_val_list_get()
        {
            return Manager.prop_enum_val_by_id_prop_enum(this);
        }

        /// <summary>
        /// Метод возвращает лист элементов перечисления для свойств
        /// </summary>
        public List<prop_enum_val> Items_list_get()
        {
            return Manager.prop_enum_val_by_id_prop_enum(this);
        }
        #endregion
        #endregion
    }
}