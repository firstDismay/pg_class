using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс свойств объекта
    /// </summary>
    public partial class position_prop
    {
        #region МЕТОДЫ КЛАССА ДЛЯ УПРАВЛЕНИЯ ЗНАЧЕНИЕМ ОБЪЕКТНОГО СВОЙСТВА

        #region ДОБАВИТЬ
        /// <summary>
        /// Создать и встроить объект в качестве значения объектного свойства
        /// position_prop_object_val_add_new
        /// </summary>
        public object_general object_data_set_new(vclass Class_real, unit_conversion_rule Unit_conversion_rule, Decimal iquantity)
        {
            return Manager.position_prop_object_val_set_new(this, Class_real, Unit_conversion_rule, iquantity);
        }

        /// <summary>
        /// Встроить существующий объект в качестве значения объектного свойства
        /// position_prop_object_val_add
        /// </summary>
        public object_general object_data_set(object_general Object_Val, Decimal icquantity)
        {
            return Manager.position_prop_object_val_set(this, Object_Val, icquantity);
        }
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет значение объектного свойства объекта
        /// object_del
        /// </summary>
        public void Object_data_del(object_general Object_Val)
        {
            Manager.object_del(Object_Val);
        }

        /// <summary>
        /// Метод удаляет всеобъекты  значения объектного свойства объекта
        /// object_del
        /// </summary>
        public void Object_data_del()
        {
            foreach (object_general Object_Val in object_data_get().value_get())
            {
                Object_data_del(Object_Val);
            }
        }
        #endregion

        #region УНИЧТОЖИТЬ
        /// <summary>
        /// Метод уничтожает значение объектного свойства объекта
        /// object_destroy
        /// </summary>
        public void Object_data_destroy(object_general Object_Val)
        {
            Manager.object_destroy(Object_Val);
        }

        /// <summary>
        /// Метод уничтожает всеобъекты  значения объектного свойства объекта
        /// object_destroy
        /// </summary>
        public void Object_data_destroy()
        {
            foreach (object_general Object_Val in object_data_get().value_get())
            {
                Object_data_destroy(Object_Val);
            }
        }
        #endregion

        #region ВЫБРАТЬ

        /// <summary>
        /// Данные значения объектного свойства объекта
        /// </summary>
        public position_prop_object_val object_data_get()
        {
            return Manager.position_prop_object_val_by_id_prop(id_position_carrier, id_pos_temp_prop);
        }
        #endregion
        #endregion
    }
}
