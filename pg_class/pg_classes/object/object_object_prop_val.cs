using System;

namespace pg_class.pg_classes
{


    /// <summary>
    /// Класс обобщенного представления объектов
    /// </summary>
    public partial class object_general
    {
        #region БАЗОВЫЕ СВОЙСТВА ВСТРОЕНОГО ОБЪЕКТА  

        /// <summary>
        /// Идентификатор объекта носителя
        /// </summary>
        public Int64 Id_object_carrier
        {
            get
            {
                return id_object_carrier;
            }
        }

        /// <summary>
        /// Идентификатор объектного свойства класса объекта носителя
        /// </summary>
        public Int64 Id_class_prop_object_carrier
        {
            get
            {
                return id_class_prop_object_carrier;
            }
        }

        /// <summary>
        /// Идентификатор объктного свойства объекта носителя
        /// </summary>
        public Int64 Id_object_prop_object_carrier
        {
            get
            {
                return id_class_prop_object_carrier;
            }
        }

        #endregion

        #region СВОЙСТВА ДЛЯ РАБОТЫ СО СВОЙСТВАМИ

        /// <summary>
        /// Свойство объекта носителя содержащее текущий объект значение
        /// </summary>
        public object_prop Object_property_carrier
        {
            get
            {
                return Manager.object_prop_by_id_object_val(this);
            }
        }


        /// <summary>
        /// Объект носитель содержащий текущий объект значение
        /// </summary>
        public object_general Object_carrier_get(Boolean Extended = false)
        {
            object_general Result;
            if (Extended)
            {
                Result = Manager.object_ext_by_id(this.Id_object_carrier);
            }
            else
            {
                Result = Manager.object_by_id(this.Id_object_carrier);
            }
            return Result;
        }
        #endregion
    }
}
