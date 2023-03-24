using System.Collections.Generic;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс обобщенного представления объектов
    /// </summary>
    public partial class position
    {
        #region МЕТОДЫ ДЛЯ РАБОТЫ СО СВОЙСТВАМИ

        /// <summary>
        /// Лист свойств позиции
        /// </summary>
        public List<position_prop> Property_list_get()
        {
            return Manager.position_prop_by_id_position(this);
        }

        /// <summary>
        /// Метод возвращает свойство позции сопоставленное указанному глобальному свойству 
        /// </summary>
        public position_prop Property_by_global_prop(global_prop Global_prop)
        {
            position_prop Result = null;

            List<position_prop> Property_list = Property_list_get();
            Result = Property_list.Find(x => x.Id_global_prop == Global_prop.Id);
            return Result;
        }
        #endregion
    }
}
