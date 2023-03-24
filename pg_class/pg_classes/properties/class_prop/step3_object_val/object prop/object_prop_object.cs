using System;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс свойств объекта
    /// </summary>
    public partial class object_prop
    {
        #region МЕТОДЫ КЛАССА ДЛЯ УПРАВЛЕНИЯ ЗНАЧЕНИЕМ ОБЪЕКТНОГО СВОЙСТВА

        #region ДОБАВИТЬ
        /// <summary>
        /// Создать и встроить объект в качестве значения объектного свойства
        /// object_prop_object_val_add_new
        /// </summary>
        public object_general object_data_add_new(vclass Class_real, unit_conversion_rule Unit_conversion_rule, Decimal iquantity)
        {
            return Manager.object_prop_object_val_add_new(this, Class_real, Unit_conversion_rule, iquantity);
        }

        /// <summary>
        /// Встроить существующий объект в качестве значения объектного свойства
        /// object_prop_object_val_add
        /// </summary>
        public object_general object_data_add(object_general Object_Val, Decimal icquantity)
        {
            return Manager.object_prop_object_val_add(this, Object_Val, icquantity);
        }
        #endregion

        #region УДАЛИТЬ
        /// <summary>
        /// Метод удаляет значение объектного свойства объекта
        /// object_del
        /// </summary>
        public void object_data_del(object_general Object_Val)
        {
            if (Object_Val.Id_class_prop_object_carrier == this.id_class_prop & Object_Val.Id_object_carrier == this.id_object_carrier)
            {
                Manager.object_del(Object_Val);
            }
        }

        /// <summary>
        /// Метод удаляет всеобъекты  значения объектного свойства объекта
        /// object_del
        /// </summary>
        public void object_data_del()
        {
            foreach (object_general Object_Val in object_data_get().value_get())
            {
                object_data_del(Object_Val);
            }
        }



        #endregion

        #region УНИЧТОЖИТЬ
        /// <summary>
        /// Метод уничтожает значение объектного свойства объекта
        /// object_destroy
        /// </summary>
        public void object_data_destroy(object_general Object_Val)
        {
            if (Object_Val.Id_class_prop_object_carrier == this.id_class_prop & Object_Val.Id_object_carrier == this.id_object_carrier)
            {
                Manager.object_destroy(Object_Val);
            }
        }

        /// <summary>
        /// Метод уничтожает всеобъекты  значения объектного свойства объекта
        /// object_destroy
        /// </summary>
        public void object_data_destroy()
        {
            foreach (object_general Object_Val in object_data_get().value_get())
            {
                object_data_destroy(Object_Val);
            }
        }



        #endregion

        #region ВЫБРАТЬ

        /// <summary>
        /// Данные значения объектного свойства объекта
        /// </summary>
        public object_prop_object_val object_data_get()
        {
            return Manager.object_prop_object_val_by_id_prop(id_object_carrier, id_class_prop);
        }
        #endregion

        #endregion

    }
}
