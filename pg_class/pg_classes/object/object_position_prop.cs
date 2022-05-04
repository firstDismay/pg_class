using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace pg_class.pg_classes
{


    /// <summary>
    /// Класс обобщенного представления объектов
    /// </summary>
    public partial class object_general
    {
        #region БАЗОВЫЕ СВОЙСТВА ВСТРОЕНОГО ОБЪЕКТА  

        /// <summary>
        /// Идентификатор позиции носителя
        /// </summary>
        public Int64 Id_position_carrier
        {
            get
            {
                return id_position;
            }
        }

        /// <summary>
        /// Идентификатор объектного свойства шаблона позиции носителя
        /// </summary>
        public Int64 Id_pos_temp_prop_position_carrier
        {
            get
            {
                return id_pos_temp_prop;
            }
        }

        /// <summary>
        /// Идентификатор объктного свойства позиции носителя
        /// </summary>
        public Int64 Id_object_prop_position_carrier
        {
            get
            {
                return id_pos_temp_prop;
            }
        }
        #endregion

        #region СВОЙСТВА ДЛЯ РАБОТЫ СО СВОЙСТВАМИ

        /// <summary>
        /// Свойство позиции носителя содержащее текущий объект значение
        /// </summary>
        public position_prop Position_property_carrier
        {
            get
            {
                return Manager.position_prop_by_id_object_val(this);
            }
        }

        /// <summary>
        /// Позиция носитель содержащий текущий объект значение
        /// </summary>
        public position Position_carrier
        {
            get
            {
                return Manager.position_by_id(this.id_position);
            }
        }
        #endregion
    }
}
